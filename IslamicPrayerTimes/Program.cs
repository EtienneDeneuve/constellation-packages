//--------------------- Copyright Block ----------------------
/* 
I use the Praytime lib form them in my plugin for Constellation
PrayTime.cs: Prayer Times Calculator (ver 2.3)
Copyright (C) 2007-2013 PrayTimes.org

C# Code By: Jandost Khoso
Original JS Code By: Hamid Zarrabi-Zadeh
 * Modification of original code to version 2.3 By: Gregory Morse
 * Added Imsak, Midnight times and elevation adjustment
 * Optimized sun position calculations, added tune offsets

License: GNU LGPL v3.0

TERMS OF USE:
    Permission is granted to use this code, with or 
    without modification, in any website or application 
    provided that credit is given to the original work 
    with a link back to PrayTimes.org.

This program is distributed in the hope that it will 
be useful, but WITHOUT ANY WARRANTY. 

PLEASE DO NOT REMOVE THIS COPYRIGHT BLOCK.

*/

using Constellation;
using Constellation.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrayTime;
using System.Threading;

namespace IslamicPrayTime
{
    public class Program : PackageBase
    {
        static void Main(string[] args)
        {
            PackageHost.Start<Program>(args);

        }


        public override void OnStart()
        {
            PackageHost.WriteInfo("Package starting - IsRunning: {0} - IsConnected: {1}", PackageHost.IsRunning, PackageHost.IsConnected);

            while (PackageHost.IsRunning)
            {
                PackageHost.PushStateObject("PrayTimeState", this.SetAllPrayState());
                // TODO : Add a way to auto refresh the states of the pray from the 1st launch of the day
                Thread.Sleep(PackageHost.GetSettingValue<int>("Interval"));
            }

        }

        private IslamicPrayTime GetIslamicPrayTime()
        {
            int caclMethod = PackageHost.GetSettingValue<int>("CalcMethod");
            int AsrMethod = PackageHost.GetSettingValue<int>("AsrMethod");
            double lo = PackageHost.GetSettingValue<double>("longitude");
            double la = PackageHost.GetSettingValue<double>("latitude");
            PrayTime.PrayTime p = new PrayTime.PrayTime();

            int y = 0, m = 0, d = 0, tz = 0;

            DateTime cc = DateTime.Now;
            y = cc.Year;
            m = cc.Month;
            d = cc.Day;

            tz = TimeZoneInfo.Local.GetUtcOffset(new DateTime(y, m, d)).Hours;
            String[] s;
            p.setCalcMethod(caclMethod);
            p.setAsrMethod(AsrMethod);
            s = p.getDatePrayerTimes(y, m, d, lo, la, tz, 0);
            DateTime midnight;
            // I added this because Midnight can be after 00:00 and we need to add 1 day
            // this is for correct the sorting of all the pray and "day" event.
            if (Convert.ToDateTime(s[8].ToString()) > Convert.ToDateTime("00:00:00"))
            {
                midnight = Convert.ToDateTime(s[8].ToString()).AddDays(1);
            }
            else
            {
                midnight = Convert.ToDateTime(s[8].ToString());
            }
            return new IslamicPrayTime()
            {
                Imsak = Convert.ToDateTime(s[0]),
                Fajr = Convert.ToDateTime(s[1]),
                Sunrise = Convert.ToDateTime(s[2]),
                Dhuhr = Convert.ToDateTime(s[3]),
                Asr = Convert.ToDateTime(s[4]),
                Sunset = Convert.ToDateTime(s[5]),
                Maghrib = Convert.ToDateTime(s[6]),
                Isha = Convert.ToDateTime(s[7]),
                Midnight = midnight
            };
        }

        // This method send a Saga with the list of pray time for today
        [MessageCallback(Key = "IslamicPrayTimeList", ResponseType = typeof(IslamicPrayTime))]
        void SendIslamicPrayTime()
        {
            IslamicPrayTime prayTime = GetIslamicPrayTime();
            if (MessageContext.Current.IsSaga)
            {
                MessageContext.Current.SendResponse(prayTime);
            }

        }

        // I create a new method to get a tuple with the pray name and the time
        List<Tuple<string, DateTime>> GetPrayList()
        {
            IslamicPrayTime prayTime = GetIslamicPrayTime();
            var prayList = new List<Tuple<String, DateTime>>
            {
                Tuple.Create("Imsak",prayTime.Imsak),
                Tuple.Create("Fajr",prayTime.Fajr),
                Tuple.Create("Sunrise",prayTime.Sunrise),
                Tuple.Create("Dhuhr",prayTime.Dhuhr),
                Tuple.Create("Asr",prayTime.Asr),
                Tuple.Create("Sunset",prayTime.Sunset),
                Tuple.Create("Maghrib",prayTime.Maghrib),
                Tuple.Create("Isha",prayTime.Isha),
                Tuple.Create("Midnight",prayTime.Midnight)
            };
            return prayList;
        }

        private List<IslamicPrayTimeObject> SetAllPrayState()
        {
            List<IslamicPrayTimeObject> praylist = new List<IslamicPrayTimeObject>();
            var list = GetPrayList();
            foreach (var pray in list)
            {
                var islamic = new IslamicPrayTimeObject();
                islamic.prayName = pray.Item1;
                islamic.prayTime = pray.Item2;
                islamic.prayState = GetPrayState(pray.Item2);
                praylist.Add(islamic);
            }
            return praylist;
        }

        [MessageCallback(Key = "IslamicPrayState", ResponseType = typeof(IslamicPrayTimeObject))]
        private IslamicPrayTimeObject SetPrayState()
        {
            TimeSpan now = DateTime.Now.TimeOfDay;
            var list = GetPrayList();
            var pray = new IslamicPrayTimeObject();
            foreach (var item in list)
            {
                if (item.Item2.Date == DateTime.Now.Date)
                {
                    int result = TimeSpan.Compare(now, item.Item2.TimeOfDay);
                    if (result == 1)
                    {
                        PackageHost.WriteInfo("Priere: {0} a {1}", item.Item1, "passe");
                        pray.prayName = item.Item1.ToString();
                        pray.prayTime = item.Item2;
                        pray.prayState = true;
                    }
                    else if (result == 0)
                    {
                        PackageHost.WriteInfo("Priere: {0} a {1}", item.Item1, "en cours");
                        pray.prayName = item.Item1.ToString();
                        pray.prayTime = item.Item2;
                        pray.prayState = false;
                    }
                    else
                    {
                        PackageHost.WriteInfo("Priere: {0} a {1}", item.Item1, "a venir");
                        pray.prayName = item.Item1.ToString();
                        pray.prayTime = item.Item2;
                        pray.prayState = false;
                    }
                }
                else
                {
                    PackageHost.WriteInfo("Priere: {0} a {1}", item.Item1, "a venir");
                    pray.prayName = item.Item1.ToString();
                    pray.prayTime = item.Item2;
                    pray.prayState = false;
                }
            }
            return pray;
        }

        private Boolean GetPrayState(DateTime prayTimeObject)
        {
            TimeSpan now = DateTime.Now.TimeOfDay;
            bool state;
            if (prayTimeObject.Date == DateTime.Now.Date)
            {
                int result = TimeSpan.Compare(now, prayTimeObject.TimeOfDay);
                if (result == 1)
                {
                    state = true;
                }
                else if (result == 0)
                {
                    state = false;
                }
                else
                {
                    state = false;
                }

            }
            else
            {
                state = false;
            }
            return state;
        }

        [MessageCallback(Key = "IslamicPrayNextTime", ResponseType = typeof(DateTime))]
        void SendIslamicPrayNextTime()
        {
            TimeSpan now = DateTime.Now.TimeOfDay;
            var list = GetPrayList();
            foreach (var item in list)
            {
                if (item.Item2.Date == DateTime.Now.Date)
                {
                    int result = TimeSpan.Compare(now, item.Item2.TimeOfDay);
                    if (result == 1)
                    {
                        PackageHost.WriteInfo("Priere: {0} a {1}", item.Item1, "passe");
                    }
                    else if (result == 0)
                    {
                        PackageHost.WriteInfo("Priere: {0} a {1}", item.Item1, "en cours");
                    }
                    else
                    {
                        PackageHost.WriteInfo("Priere: {0} a {1}", item.Item1, "a venir");
                        if (MessageContext.Current.IsSaga)
                        {
                            MessageContext.Current.SendResponse(String.Concat("La prochaine priere est ", item.Item1, " a ", item.Item2));
                        };
                    }
                }
                else if (item.Item2.Date > DateTime.Now.Date)
                {
                    PackageHost.WriteInfo("Priere: {0} a {1}", item.Item1, "a venir");
                    if (MessageContext.Current.IsSaga)
                    {
                        MessageContext.Current.SendResponse(String.Concat("La prochaine priere est ", item.Item1, " a ", item.Item2));
                    };
                }
            }
        }
    }
}







