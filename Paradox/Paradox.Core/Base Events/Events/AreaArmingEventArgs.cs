﻿/*
 *	 Paradox .NET library
 *	 Web site: http://sebastien.warin.fr
 *	 Copyright (C) 2014-2017 - Sebastien Warin <http://sebastien.warin.fr>	   	  
 *	
 *	 Licensed to Sebastien Warin under one or more contributor
 *	 license agreements. Sebastien Warin licenses this file to you under
 *	 the Apache License, Version 2.0 (the "License"); you may
 *	 not use this file except in compliance with the License.
 *	 You may obtain a copy of the License at
 *	
 *	 http://www.apache.org/licenses/LICENSE-2.0
 *	
 *	 Unless required by applicable law or agreed to in writing,
 *	 software distributed under the License is distributed on an
 *	 "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 *	 KIND, either express or implied. See the License for the
 *	 specific language governing permissions and limitations
 *	 under the License.
 */

namespace Paradox
{
    /// <summary>
    /// Represent an Area arming event
    /// </summary>
    /// <seealso cref="Paradox.Core.ParadoxBaseEventArgs" />
    public class AreaArmingEventArgs : ParadoxBaseEventArgs
    {
        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        public Area Area { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the arming has failed.
        /// </summary>
        /// <value>
        /// <c>true</c> if the arming has failed; otherwise, <c>false</c>.
        /// </value>
        public bool HasFailed { get; set; }

        /// <summary>
        /// Processes the raw message to extract the event data.
        /// </summary>
        /// <param name="message">The raw message.</param>
        internal override void ProcessMessage(string message)
        {
            this.Area = Utils.GetEnumValueFromStringId<Area>(message.Substring(2, 3));
            this.HasFailed = message.EndsWith("&fail");
        }
    }
}
