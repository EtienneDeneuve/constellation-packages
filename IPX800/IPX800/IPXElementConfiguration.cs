﻿/*
 *	 GCE Electronics IPX800 Package for Constellation
 *	 Web site: http://www.myConstellation.io
 *	 Copyright (C) 2018 - Sebastien Warin <http://sebastien.warin.fr>
 *	
 *	 Licensed to Constellation under one or more contributor
 *	 license agreements. Constellation licenses this file to you under
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

namespace IPX800
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the configuration of an IPX element
    /// </summary>
    public class IPXElementConfiguration
    {
        /// <summary>
        /// Gets or sets the IPX identifier.
        /// </summary>
        /// <value>
        /// The IPX identifier.
        /// </value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the label for this IPX element.
        /// </summary>
        /// <value>
        /// The element's label.
        /// </value>
        public string Label { get; set; }
        /// <summary>
        /// Gets or sets the room for this IPX element.
        /// </summary>
        /// <value>
        /// The room name.
        /// </value>
        public string Room { get; set; }

        /// <summary>
        /// Gets or sets the element's options.
        /// </summary>
        /// <value>
        /// The element's options.
        /// </value>
        public Dictionary<string, object> Options { get; set; }
    }
}
