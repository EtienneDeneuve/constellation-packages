using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constellation;
using Constellation.Package;

namespace IslamicPrayTime
{
    /// <summary>
    /// Islamic pray informations
    /// </summary>
    [StateObject]
    public class IslamicPrayTimeObject
    {
        /// <summary>
        /// Time of the Pray.
        /// </summary>
        /// <value>
        /// DateTime.
        /// </value>
        public DateTime prayTime { get; set; }
        /// <summary>
        /// Name of the pray.
        /// </summary>
        /// <value>
        /// String.
        /// </value>
        public String prayName { get; set; }
        /// <summary>
        /// Pray State.
        /// </summary>
        /// <value>
        /// Boolean.
        /// </value>
        public Boolean prayState { get; set; }
        /// <summary>
        /// Default Constructor.
        /// </summary>
        /// <value>
        /// Boolean.
        /// </value>
        
    }
    /// <summary>
    /// Islamic pray informations
    /// </summary>
    public class IslamicPrayTime
    {
       
        /// <summary>
        /// Gets the Imsak time.
        /// </summary>
        /// <value>
        /// DateTime.
        /// </value>
        public DateTime Imsak
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the Fajr time.
        /// </summary>
        /// <value>
        /// DateTime.
        /// </value>
        public DateTime Fajr { get; set; }
        /// <summary>
        /// Gets the Sunrise time.
        /// </summary>
        /// <value>
        /// DateTime.
        /// </value>
        public DateTime Sunrise { get; set; }
        /// <summary>
        /// Gets the Dhuhr time.
        /// </summary>
        /// <value>
        /// DateTime.
        /// </value>
        public DateTime Dhuhr { get; set; }
        /// <summary>
        /// Gets the Asr time.
        /// </summary>
        /// <value>
        /// DateTime.
        /// </value>
        public DateTime Asr { get; set; }
        /// <summary>
        /// Gets the Sunset time.
        /// </summary>
        /// <value>
        /// DateTime.
        /// </value>
        public DateTime Sunset { get; set; }
        /// <summary>
        /// Gets the Maghrib time.
        /// </summary>
        /// <value>
        /// DateTime.
        /// </value>
        public DateTime Maghrib { get; set; }
        /// <summary>
        /// Gets the Isha time.
        /// </summary>
        /// <value>
        /// DateTime.
        /// </value>
        public DateTime Isha { get; set; }
        /// <summary>
        /// Gets the Midnight time.
        /// </summary>
        /// <value>
        /// DateTime.
        /// </value>
        public DateTime Midnight { get; set; }
    }
}
