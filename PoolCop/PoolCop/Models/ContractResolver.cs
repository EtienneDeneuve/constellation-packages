﻿/*
 *	 PoolCop connector for Constellation
 *	 Web site: http://www.myConstellation.io
 *	 Copyright (C) 2018-2019 - Sebastien Warin <http://sebastien.warin.fr>
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

namespace PoolCop.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// Used by Newtonsoft.Json.JsonSerializer to resolves a Newtonsoft.Json.Serialization.JsonContract for a given System.Type.
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.Serialization.DefaultContractResolver" />
    public class PoolCopilotContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// Gets the JsonSerializerSettings that use the PushBulletContractResolver.
        /// </summary>
        /// <value>
        /// The JsonSerializerSettings.
        /// </value>
        public static JsonSerializerSettings Settings { get; } = new JsonSerializerSettings()
        {
            ContractResolver = new PoolCopilotContractResolver(),
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

        /// <summary>
        /// Creates properties for the given <see cref="T:Newtonsoft.Json.Serialization.JsonContract" />.
        /// </summary>
        /// <param name="type">The type to create properties for.</param>
        /// <param name="memberSerialization">The member serialization mode for the type.</param>
        /// <returns>
        /// Properties for the given <see cref="T:Newtonsoft.Json.Serialization.JsonContract" />.
        /// </returns>
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> list = base.CreateProperties(type, memberSerialization);
            foreach (JsonProperty prop in list)
            {
                var attribute = prop.AttributeProvider.GetAttributes(typeof(PoolCopilotPropertyAttribute), true).FirstOrDefault() as PoolCopilotPropertyAttribute;
                if (attribute != null)
                {
                    prop.PropertyName = attribute.PropertyName;
                }
            }
            return list;
        }
    }

    /// <summary>
    /// Maps a JSON property to a .NET member or constructor parameter.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public class PoolCopilotPropertyAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>
        /// The name of the property.
        /// </value>
        public string PropertyName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PoolCopilotPropertyAttribute"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public PoolCopilotPropertyAttribute(string propertyName)
        {
            this.PropertyName = propertyName;
        }
    }

    /// <summary>
    /// JSON string coverter
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter" />
    internal class ParseStringConverter : JsonConverter
    {
        /// <summary>
        /// The singleton instance
        /// </summary>
        public static readonly ParseStringConverter Singleton = new ParseStringConverter();

        /// <summary>
        /// Determines whether this instance can convert the specified t.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns>
        ///   <c>true</c> if this instance can convert the specified t; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type t) => true;

        /// <summary>
        /// Reads the json.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="t">The t.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The serializer.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Cannot unmarshal type long</exception>
        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            return Convert.ChangeType(value, t);
        }

        /// <summary>
        /// Writes the json.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="untypedValue">The untyped value.</param>
        /// <param name="serializer">The serializer.</param>
        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            serializer.Serialize(writer, untypedValue);
        }
    }

    /// <summary>
    /// Unix timestamp converter
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.Converters.DateTimeConverterBase" />
    public class UnixTimestampConverter : IsoDateTimeConverter
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            base.WriteJson(writer, value, serializer);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value == null ? _epoch : TimeFromUnixTimestamp(Convert.ToInt64(reader.Value));
        }

        /// <summary>
        /// DateTime from unix timestamp.
        /// </summary>
        /// <param name="unixTimestamp">The unix timestamp.</param>
        /// <returns></returns>
        private static DateTime TimeFromUnixTimestamp(long unixTimestamp)
        {
            long unixTimeStampInTicks = unixTimestamp * TimeSpan.TicksPerSecond;
            return new DateTime(_epoch.Ticks + unixTimeStampInTicks);
        }
    }
}
