// JsonNull.cs
//
// Copyright (C) 2006 Andy Kernahan
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace NetServ.Net.Json
{
    /// <summary>
    /// Represents a Json null value. This class cannot be inherited.
    /// </summary>
    [Serializable()]    
    [DebuggerDisplay("JsonNull")]
    public sealed class JsonNull : JsonTypeSkeleton, IJsonNull, IObjectReference
    {
        #region Public Interface.

        /// <summary>
        /// Defines the JsonNull string. This field is constant.
        /// </summary>
        public const string NullString = "null";

        /// <summary>
        /// Defines a JsonNull instance. This field is readonly.
        /// </summary>
        public static readonly JsonNull Null = new JsonNull();        

        /// <summary>
        /// Writes the contents of this Json type using the specified
        /// <see cref="NetServ.Net.Json.IJsonWriter"/>.
        /// </summary>
        /// <param name="writer">The Json writer.</param>
        public override void Write(IJsonWriter writer) {

            if(writer == null)
                throw new ArgumentNullException("writer");

            writer.WriteValue(JsonNull.NullString);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> representation of this JsonNull instance.
        /// </summary>
        /// <returns> <see cref="System.String"/> representation of this JsonNull instance.</returns>
        public override string ToString() {

            return JsonNull.NullString;
        }

        /// <summary>
        /// Returns a indicating whether this instance is equal to the specified
        /// <see cref="System.Object"/>.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>True if the specified object is equal to this instance, otherwise;
        /// false.</returns>
        public override bool Equals(object obj) {

            if(obj == null)
                return false;
            if(obj.GetType() != GetType())
                return false;

            return Equals((JsonNull)obj);
        }

        /// <summary>
        /// Returns a indicating whether this instance is equal to the specified
        /// JsonNull.
        /// </summary>
        /// <param name="other">The value to compare.</param>
        /// <returns>True if the specified instance is equal to this instance, otherwise;
        /// false.</returns>
        public bool Equals(JsonNull other) {

            // Should I make a null JsonNull equal to this regardless?
            return other != null;
        }

        /// <summary>
        /// Returns a indicating whether this instance is equal to the specified
        /// <see cref="NetServ.Net.Json.IJsonNull"/>.
        /// </summary>
        /// <param name="other">The value to compare.</param>
        /// <returns>True if the specified instance is equal to this instance, otherwise;
        /// false.</returns>
        public bool Equals(IJsonNull other) {

            // Should I make a null IJsonNull equal to this regardless?
            return other != null;
        }   

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance.</returns>
        public override int GetHashCode() {            

            // We do not want to return zero as that would make this equal
            // with a false JsonBoolean.
            return 0x3641694F;            
        }             

        /// <summary>
        /// Maps the specified value to the type of the type paramater.
        /// </summary>
        /// <typeparam name="T">The type to map to.</typeparam>
        /// <param name="value">The value to map.</param>
        /// <returns>The mapped value if not logically null, otherwise the default value of 
        /// <typeparamref name="T"/>.</returns>
        public static T Map<T>(IJsonType value) where T : IJsonType {

            if(value == null || value.JsonTypeCode == JsonTypeCode.Null)
                return default(T);
            return (T)value;
        }

        #endregion

        #region Explicit Interface.

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        object IObjectReference.GetRealObject(StreamingContext context) {

            return JsonNull.Null;
        }

        #endregion

        #region Private Impl.

        /// <summary>
        /// Initialises a new instance of the JsonNull class.
        /// </summary>
        private JsonNull()
            : base(JsonTypeCode.Null) {
        }

        #endregion
    }
}
