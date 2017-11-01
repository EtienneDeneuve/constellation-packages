﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Constellation SDK Code Generator.
//     Generator Version: 1.8.2.17110
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Constellation;
using Constellation.Package;
using System.Threading;
using System.Threading.Tasks;

namespace IslamicPrayerTimes
{
    /// <summary>
    /// Represents your Constellation
    /// </summary>
	public static class MyConstellation
	{
		/// <summary>
		/// Specifies the sentinels in your Constellation
		/// </summary>
		public enum Sentinels
		{
			/// <summary>
            /// Sentinel 'DESKTOP-1ESJC3M'
            /// </summary>
			[RealName("DESKTOP-1ESJC3M")]
			DESKTOP_1ESJC3M,
		}

		/// <summary>
		/// Specifies the package's instances in your Constellation
		/// </summary>
		public enum PackageInstances
		{
			/// <summary>
            /// Package 'IslamicPrayTimes' on 'DESKTOP-1ESJC3M'
            /// </summary>
			[RealName("DESKTOP-1ESJC3M/IslamicPrayTimes")]
			DESKTOP_1ESJC3M_IslamicPrayTimes,
		}
		
		/// <summary>
		/// Specifies the packages in your Constellation
		/// </summary>
		public enum Packages
		{
			/// <summary>
            /// Package 'IslamicPrayTimes'
            /// </summary>
			[RealName("IslamicPrayTimes")]
			IslamicPrayTimes,
		}
    
		/// <summary>
        /// Creates the message scope to the specified sentinel.
        /// </summary>
        /// <param name="sentinel">The sentinel.</param>
        /// <returns>MessageScope</returns>
		public static MessageScope CreateScope(this Sentinels sentinel)
		{
		    return MessageScope.Create(MessageScope.ScopeType.Sentinel, sentinel.GetRealName());
		}    
		
		/// <summary>
        /// Creates the message scope to the specified package's instance.
        /// </summary>
        /// <param name="package">The package's instance.</param>
        /// <returns>MessageScope</returns>
		public static MessageScope CreateScope(this PackageInstances package)
		{
		    return MessageScope.Create(MessageScope.ScopeType.Package, package.GetRealName());      
		} 
		
		/// <summary>
        /// Creates the message scope to the specified package.
        /// </summary>
        /// <param name="package">The package.</param>
        /// <returns>MessageScope</returns>
		public static MessageScope CreateScope(this Packages package)
		{
		    return MessageScope.Create(MessageScope.ScopeType.Package, package.GetRealName());        
		}
	}
	
	/// <summary>
    /// Specifies the real name of an enum value.
    /// </summary>
    /// <seealso cref="System.Attribute" />
	[System.AttributeUsage(System.AttributeTargets.Field)]
	public class RealNameAttribute : System.Attribute
	{
	    /// <summary>
        /// Gets or sets the real name.
        /// </summary>
        /// <value>
        /// The real name.
        /// </value>
		public System.String RealName { get; set; }

		/// <summary>
        /// Initializes a new instance of the <see cref="RealNameAttribute"/> class.
        /// </summary>
        /// <param name="realname">The real name.</param>
		public RealNameAttribute(System.String realname)
		{
			this.RealName = realname;
		}
		
	    /// <summary>
        /// Gets the real name of an enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns>The real name.</returns>
		public static string GetRealName<TEnum>(TEnum value)
		{
			var memInfo = typeof(TEnum).GetMember(value.ToString());
			var attributes = memInfo[0].GetCustomAttributes(typeof(RealNameAttribute), false);
			return (attributes != null && attributes.Length > 0) ? ((RealNameAttribute)attributes[0]).RealName : value.ToString();
		}
	}

	/// <summary>
    /// Provides extension methods to get the real name of a Sentinel, Package or PackageInstance.
    /// </summary>
	public static class RealNameExtension
	{
		/// <summary>
        /// Gets the real name of a Sentinel.
        /// </summary>
        /// <param name="sentinel">The Sentinel.</param>
        /// <returns>The real name.</returns>
		public static string GetRealName(this MyConstellation.Sentinels sentinel)
		{
			return RealNameAttribute.GetRealName<MyConstellation.Sentinels>(sentinel);
		}

		/// <summary>
        /// Gets the real name of a Package.
        /// </summary>
        /// <param name="package">The Package.</param>
        /// <returns>The real name.</returns>
		public static string GetRealName(this MyConstellation.Packages package)
		{
			return RealNameAttribute.GetRealName<MyConstellation.Packages>(package);
		}

		/// <summary>
        /// Gets the real name of a Package's instance.
        /// </summary>
        /// <param name="package">The Package's instance.</param>
        /// <returns>The real name.</returns>
		public static string GetRealName(this MyConstellation.PackageInstances package)
		{
			return RealNameAttribute.GetRealName<MyConstellation.PackageInstances>(package);
		}
	}
}

namespace IslamicPrayerTimes.IslamicPrayTimes.StateObjects
{
	/// <summary>
	/// Specifies the know StateObjects for the package IslamicPrayTimes
	/// </summary>
	public enum IslamicPrayTimesStateObjectNames
	{
		/// <summary>
		/// StateObject 'PrayTime'
		/// </summary>
		[RealName("PrayTime")]
        PrayTime,
		/// <summary>
		/// StateObject 'PrayTimeState'
		/// </summary>
		[RealName("PrayTimeState")]
        PrayTimeState,
	}

	/// <summary>
    /// Provides extension methods to get the real name of a IslamicPrayTimesStateObjectNames.
    /// </summary>
	public static class IslamicPrayTimesStateObjectNamesExtension
	{
		/// <summary>
        /// Gets the real name of a IslamicPrayTimes's StateObject.
        /// </summary>
        /// <param name="stateObjectName">The IslamicPrayTimes 's StateObject.</param>
        /// <returns>The real name.</returns>
		public static string GetRealName(this IslamicPrayTimesStateObjectNames stateObjectName)
		{
			return RealNameAttribute.GetRealName<IslamicPrayTimesStateObjectNames>(stateObjectName);
		}
	}

    /// <summary>
    ///  Specifies that the property is attach to IslamicPrayTimes's StateObject.
    /// </summary>
    /// <seealso cref="Constellation.Package.StateObjectLinkAttribute" />
    public class IslamicPrayTimesStateObjectLinkAttribute : StateObjectLinkAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IslamicPrayTimesStateObjectLinkAttribute"/> class.
        /// </summary>
        public IslamicPrayTimesStateObjectLinkAttribute() : base()
        {
            this.Package = MyConstellation.Packages.IslamicPrayTimes.GetRealName();
        }

		/// <summary>
        /// Initializes a new instance of the <see cref="IslamicPrayTimesStateObjectLinkAttribute"/> class.
        /// </summary>
        /// <param name="sentinel">The sentinel.</param>
        public IslamicPrayTimesStateObjectLinkAttribute(MyConstellation.Sentinels sentinel) : this()
        { 
			this.Sentinel = sentinel.GetRealName();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="IslamicPrayTimesStateObjectLinkAttribute"/> class.
        /// </summary>
        /// <param name="name">The StateObject name.</param>
        public IslamicPrayTimesStateObjectLinkAttribute(IslamicPrayTimesStateObjectNames name)
            : base(MyConstellation.Packages.IslamicPrayTimes.GetRealName(), name.GetRealName())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="IslamicPrayTimesStateObjectLinkAttribute"/> class.
        /// </summary>
        /// <param name="sentinel">The sentinel.</param>
        /// <param name="name">The StateObject name.</param>
        public IslamicPrayTimesStateObjectLinkAttribute(MyConstellation.Sentinels sentinel, IslamicPrayTimesStateObjectNames name)
            : base(sentinel.GetRealName(), MyConstellation.Packages.IslamicPrayTimes.GetRealName(), name.GetRealName())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="IslamicPrayTimesStateObjectLinkAttribute"/> class.
        /// </summary>
        /// <param name="sentinel">The sentinel.</param>
        /// <param name="name">The StateObject name.</param>
        /// <param name="type">The StateObject type.</param>
        public IslamicPrayTimesStateObjectLinkAttribute(MyConstellation.Sentinels sentinel, IslamicPrayTimesStateObjectNames name, string type)
            : base(sentinel.GetRealName(), MyConstellation.Packages.IslamicPrayTimes.GetRealName(), name.GetRealName(), type)
        { }
    }

	/// <summary>
	/// Islamic pray informations 
	/// </summary>
	public class IslamicPrayTimeObject 
	{
		/// <summary>
		/// Time of the Pray. 
		/// </summary>
		public System.DateTime prayTime { get; set; }

		/// <summary>
		/// Name of the pray. 
		/// </summary>
		public System.String prayName { get; set; }

		/// <summary>
		/// Pray State. 
		/// </summary>
		public System.Boolean prayState { get; set; }

	}

	/// <summary>
	/// Islamic pray informations 
	/// </summary>
	public class IslamicPrayTime 
	{
		/// <summary>
		/// Gets the Imsak time. 
		/// </summary>
		public System.DateTime Imsak { get; set; }

		/// <summary>
		/// Gets the Fajr time. 
		/// </summary>
		public System.DateTime Fajr { get; set; }

		/// <summary>
		/// Gets the Sunrise time. 
		/// </summary>
		public System.DateTime Sunrise { get; set; }

		/// <summary>
		/// Gets the Dhuhr time. 
		/// </summary>
		public System.DateTime Dhuhr { get; set; }

		/// <summary>
		/// Gets the Asr time. 
		/// </summary>
		public System.DateTime Asr { get; set; }

		/// <summary>
		/// Gets the Sunset time. 
		/// </summary>
		public System.DateTime Sunset { get; set; }

		/// <summary>
		/// Gets the Maghrib time. 
		/// </summary>
		public System.DateTime Maghrib { get; set; }

		/// <summary>
		/// Gets the Isha time. 
		/// </summary>
		public System.DateTime Isha { get; set; }

		/// <summary>
		/// Gets the Midnight time. 
		/// </summary>
		public System.DateTime Midnight { get; set; }

	}

    /// <summary>
    /// Provides extension methods for IslamicPrayTimes's StateObjects
    /// </summary>
	public static class IslamicPrayTimesExtensions
	{
		/// <summary>
		/// Get StateObject value as IslamicPrayTimeObject
		/// </summary>
		public static IslamicPrayTimeObject AsIslamicPrayTimesIslamicPrayTimeObject(this StateObject stateObject)
		{
			return stateObject.GetValue<IslamicPrayTimeObject>();
		}

		/// <summary>
		/// Get StateObject value as IslamicPrayTimeObject
		/// </summary>
		public static IslamicPrayTimeObject AsIslamicPrayTimesIslamicPrayTimeObject(this StateObjectNotifier stateObjectNotifier)
		{
			return stateObjectNotifier.Value.GetValue<IslamicPrayTimeObject>();
		}

		/// <summary>
		/// Get StateObject value as IslamicPrayTime
		/// </summary>
		public static IslamicPrayTime AsIslamicPrayTimesIslamicPrayTime(this StateObject stateObject)
		{
			return stateObject.GetValue<IslamicPrayTime>();
		}

		/// <summary>
		/// Get StateObject value as IslamicPrayTime
		/// </summary>
		public static IslamicPrayTime AsIslamicPrayTimesIslamicPrayTime(this StateObjectNotifier stateObjectNotifier)
		{
			return stateObjectNotifier.Value.GetValue<IslamicPrayTime>();
		}

		/// <summary>
		/// Get StateObject value as System.Collections.Generic.List Of IslamicPrayTimeObject
		/// </summary>
		public static System.Collections.Generic.List<IslamicPrayTimeObject> AsIslamicPrayTimesListOfIslamicPrayTimeObject(this StateObject stateObject)
		{
			return stateObject.GetValue<System.Collections.Generic.List<IslamicPrayTimeObject>>();
		}

	}
}

namespace IslamicPrayerTimes.IslamicPrayTimes.MessageCallbacks
{
	/// <summary>
	/// Islamic pray informations 
	/// </summary>
	public class IslamicPrayTime 
	{
		/// <summary>
		/// Gets the Imsak time. 
		/// </summary>
		public System.DateTime Imsak { get; set; }

		/// <summary>
		/// Gets the Fajr time. 
		/// </summary>
		public System.DateTime Fajr { get; set; }

		/// <summary>
		/// Gets the Sunrise time. 
		/// </summary>
		public System.DateTime Sunrise { get; set; }

		/// <summary>
		/// Gets the Dhuhr time. 
		/// </summary>
		public System.DateTime Dhuhr { get; set; }

		/// <summary>
		/// Gets the Asr time. 
		/// </summary>
		public System.DateTime Asr { get; set; }

		/// <summary>
		/// Gets the Sunset time. 
		/// </summary>
		public System.DateTime Sunset { get; set; }

		/// <summary>
		/// Gets the Maghrib time. 
		/// </summary>
		public System.DateTime Maghrib { get; set; }

		/// <summary>
		/// Gets the Isha time. 
		/// </summary>
		public System.DateTime Isha { get; set; }

		/// <summary>
		/// Gets the Midnight time. 
		/// </summary>
		public System.DateTime Midnight { get; set; }

	}

	/// <summary>
	/// Islamic pray informations 
	/// </summary>
	public class IslamicPrayTimeObject 
	{
		/// <summary>
		/// Time of the Pray. 
		/// </summary>
		public System.DateTime prayTime { get; set; }

		/// <summary>
		/// Name of the pray. 
		/// </summary>
		public System.String prayName { get; set; }

		/// <summary>
		/// Pray State. 
		/// </summary>
		public System.Boolean prayState { get; set; }

	}

	/// <summary>
	/// Provides extension methods for the MessageScope to IslamicPrayTimes
	/// </summary>
	public static class IslamicPrayTimesExtensions
	{
		/// <summary>
		/// Create a IslamicPrayTimesScope
		/// </summary>
		/// <param name="scope">The Constellation MessageScope</param>
		public static IslamicPrayTimesScope ToIslamicPrayTimesScope(this MessageScope scope)
		{
			return new IslamicPrayTimesScope(scope);
		}

		/// <summary>
		/// Create a IslamicPrayTimesScope to all packages of the specified sentinel
		/// </summary>
		/// <param name="sentinel">The sentinel</param>
		public static IslamicPrayTimesScope CreateIslamicPrayTimesScope(this IslamicPrayerTimes.MyConstellation.Sentinels sentinel)
		{
		    return MessageScope.Create(MessageScope.ScopeType.Sentinel, sentinel.GetRealName()).ToIslamicPrayTimesScope();        
		}
		
		/// <summary>
		/// Create a IslamicPrayTimesScope to a specific package
		/// </summary>
		/// <param name="package">The package</param>
		public static IslamicPrayTimesScope CreateIslamicPrayTimesScope(this IslamicPrayerTimes.MyConstellation.PackageInstances package)
		{
		    return MessageScope.Create(MessageScope.ScopeType.Package, package.GetRealName()).ToIslamicPrayTimesScope();        
		}
		
		/// <summary>
		/// Create a IslamicPrayTimesScope to a specific package
		/// </summary>
		/// <param name="package">The package</param>
		public static IslamicPrayTimesScope CreateIslamicPrayTimesScope(this IslamicPrayerTimes.MyConstellation.Packages package)
		{
		    return MessageScope.Create(MessageScope.ScopeType.Package, package.GetRealName()).ToIslamicPrayTimesScope();  
		}
	}

	/// <summary>
    /// Represent a message scope to IslamicPrayTimes
    /// </summary>
	public class IslamicPrayTimesScope
	{
        /// <summary>
        /// The current scope
        /// </summary>
		private MessageScope currentScope = null;

		/// <summary>
        /// Initializes a new instance of the <see cref="IslamicPrayTimesScope"/> class.
        /// </summary>
        /// <param name="scope">The scope.</param>
		public IslamicPrayTimesScope(MessageScope scope)
		{
			this.currentScope = scope;
		}

		/// <summary>
		/// Send message 'IslamicPrayTimeList' to the current scope
		/// </summary>
		/// <returns>Task of IslamicPrayTime</returns>
		/// <param name="cancellationToken">The CancellationToken that this task will observe.</param>		
		/// <param name="context">The MessageContext of the received message.</param>
		public Task<IslamicPrayTime> IslamicPrayTimeList(CancellationToken cancellationToken, out MessageContext context)
		{
			Task<dynamic> result = this.currentScope.GetProxy().IslamicPrayTimeList<IslamicPrayTime>(cancellationToken, out context);
            return result.ContinueWith<IslamicPrayTime>(task => (IslamicPrayTime)task.Result);
		}

		/// <summary>
		/// Send message 'IslamicPrayTimeList' to the current scope
		/// </summary>
		/// <returns>Task of IslamicPrayTime</returns>
		/// <param name="context">The MessageContext of the received message.</param>
		public Task<IslamicPrayTime> IslamicPrayTimeList(out MessageContext context)
		{
			Task<dynamic> result = this.currentScope.GetProxy().IslamicPrayTimeList<IslamicPrayTime>(out context);
            return result.ContinueWith<IslamicPrayTime>(task => (IslamicPrayTime)task.Result);
		}

		/// <summary>
		/// Send message 'IslamicPrayTimeList' to the current scope
		/// </summary>
		/// <returns>Task of IslamicPrayTime</returns>
		/// <param name="cancellationToken">The CancellationToken that this task will observe.</param>
		public Task<IslamicPrayTime> IslamicPrayTimeList(CancellationToken cancellationToken)
		{
			Task<dynamic> result = this.currentScope.GetProxy().IslamicPrayTimeList<IslamicPrayTime>(cancellationToken);
            return result.ContinueWith<IslamicPrayTime>(task => (IslamicPrayTime)task.Result);
		}

		/// <summary>
		/// Send message 'IslamicPrayTimeList' to the current scope
		/// </summary>
		/// <returns>Task of IslamicPrayTime</returns>
		public Task<IslamicPrayTime> IslamicPrayTimeList()
		{
			Task<dynamic> result = this.currentScope.GetProxy().IslamicPrayTimeList<IslamicPrayTime>();
            return result.ContinueWith<IslamicPrayTime>(task => (IslamicPrayTime)task.Result);
		}


		/// <summary>
		/// Send message 'IslamicPrayState' to the current scope
		/// </summary>
		/// <returns>Task of IslamicPrayTimeObject</returns>
		/// <param name="cancellationToken">The CancellationToken that this task will observe.</param>		
		/// <param name="context">The MessageContext of the received message.</param>
		public Task<IslamicPrayTimeObject> IslamicPrayState(CancellationToken cancellationToken, out MessageContext context)
		{
			Task<dynamic> result = this.currentScope.GetProxy().IslamicPrayState<IslamicPrayTimeObject>(cancellationToken, out context);
            return result.ContinueWith<IslamicPrayTimeObject>(task => (IslamicPrayTimeObject)task.Result);
		}

		/// <summary>
		/// Send message 'IslamicPrayState' to the current scope
		/// </summary>
		/// <returns>Task of IslamicPrayTimeObject</returns>
		/// <param name="context">The MessageContext of the received message.</param>
		public Task<IslamicPrayTimeObject> IslamicPrayState(out MessageContext context)
		{
			Task<dynamic> result = this.currentScope.GetProxy().IslamicPrayState<IslamicPrayTimeObject>(out context);
            return result.ContinueWith<IslamicPrayTimeObject>(task => (IslamicPrayTimeObject)task.Result);
		}

		/// <summary>
		/// Send message 'IslamicPrayState' to the current scope
		/// </summary>
		/// <returns>Task of IslamicPrayTimeObject</returns>
		/// <param name="cancellationToken">The CancellationToken that this task will observe.</param>
		public Task<IslamicPrayTimeObject> IslamicPrayState(CancellationToken cancellationToken)
		{
			Task<dynamic> result = this.currentScope.GetProxy().IslamicPrayState<IslamicPrayTimeObject>(cancellationToken);
            return result.ContinueWith<IslamicPrayTimeObject>(task => (IslamicPrayTimeObject)task.Result);
		}

		/// <summary>
		/// Send message 'IslamicPrayState' to the current scope
		/// </summary>
		/// <returns>Task of IslamicPrayTimeObject</returns>
		public Task<IslamicPrayTimeObject> IslamicPrayState()
		{
			Task<dynamic> result = this.currentScope.GetProxy().IslamicPrayState<IslamicPrayTimeObject>();
            return result.ContinueWith<IslamicPrayTimeObject>(task => (IslamicPrayTimeObject)task.Result);
		}


		/// <summary>
		/// Send message 'IslamicPrayNextTime' to the current scope
		/// </summary>
		/// <returns>Task of System.DateTime</returns>
		/// <param name="cancellationToken">The CancellationToken that this task will observe.</param>		
		/// <param name="context">The MessageContext of the received message.</param>
		public Task<System.DateTime> IslamicPrayNextTime(CancellationToken cancellationToken, out MessageContext context)
		{
			Task<dynamic> result = this.currentScope.GetProxy().IslamicPrayNextTime<System.DateTime>(cancellationToken, out context);
            return result.ContinueWith<System.DateTime>(task => (System.DateTime)task.Result);
		}

		/// <summary>
		/// Send message 'IslamicPrayNextTime' to the current scope
		/// </summary>
		/// <returns>Task of System.DateTime</returns>
		/// <param name="context">The MessageContext of the received message.</param>
		public Task<System.DateTime> IslamicPrayNextTime(out MessageContext context)
		{
			Task<dynamic> result = this.currentScope.GetProxy().IslamicPrayNextTime<System.DateTime>(out context);
            return result.ContinueWith<System.DateTime>(task => (System.DateTime)task.Result);
		}

		/// <summary>
		/// Send message 'IslamicPrayNextTime' to the current scope
		/// </summary>
		/// <returns>Task of System.DateTime</returns>
		/// <param name="cancellationToken">The CancellationToken that this task will observe.</param>
		public Task<System.DateTime> IslamicPrayNextTime(CancellationToken cancellationToken)
		{
			Task<dynamic> result = this.currentScope.GetProxy().IslamicPrayNextTime<System.DateTime>(cancellationToken);
            return result.ContinueWith<System.DateTime>(task => (System.DateTime)task.Result);
		}

		/// <summary>
		/// Send message 'IslamicPrayNextTime' to the current scope
		/// </summary>
		/// <returns>Task of System.DateTime</returns>
		public Task<System.DateTime> IslamicPrayNextTime()
		{
			Task<dynamic> result = this.currentScope.GetProxy().IslamicPrayNextTime<System.DateTime>();
            return result.ContinueWith<System.DateTime>(task => (System.DateTime)task.Result);
		}

	}
}
