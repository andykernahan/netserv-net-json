// JsonObject.cs
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
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NetServ.Net.Json
{
    /// <summary>
    /// Represents a JavaScript Object Notation Object data type which contains a 
    /// collection of <see cref="NetServ.Net.Json.IJsonType"/>s accessed by key.
    /// </summary>
    [Serializable()]
    public class JsonObject : Dictionary<string, IJsonType>, IJsonObject
    {
        #region Protected Interface.

        /// <summary>
        /// Deserialisation constructor.
        /// </summary>
        /// <param name="info">The object containing the data needed to deserialise an instance.</param>
        /// <param name="context">The boejct which specifies the source of the deserialisation.</param>
        protected JsonObject(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        #endregion

        #region Public Interface.

        /// <summary>
        /// Inialises a new instance of the JsonObject class.
        /// </summary>
        public JsonObject()
            : base(StringComparer.Ordinal) {
        }

        /// <summary>
        /// Writes the contents of this Json type using the specified
        /// <see cref="NetServ.Net.Json.IJsonWriter"/>.
        /// </summary>
        /// <param name="writer">The Json writer.</param>
        public void Write(IJsonWriter writer) {

            if(writer == null)
                throw new ArgumentNullException("writer");

            writer.WriteBeginObject();
            foreach(KeyValuePair<string, IJsonType> pair in this) {
                writer.WriteName(pair.Key);
                pair.Value.Write(writer);
            }
            writer.WriteEndObject();
        }

        /// <summary>
        /// Adds the specified key and item to this dictionary.
        /// </summary>
        /// <param name="key">The key of the item</param>
        /// <param name="item">The value of the item.</param>
        public void Add(string key, string item) {

            if(string.IsNullOrEmpty(item))
                base.Add(key, JsonString.Empty);
            else
                base.Add(key, new JsonString(item));
        }

        /// <summary>
        /// Adds the specified key and item to this dictionary.
        /// </summary>
        /// <param name="key">The key of the item</param>
        /// <param name="item">The value of the item.</param>
        public void Add(string key, bool item) {

            base.Add(key, JsonBoolean.Get(item));
        }

        /// <summary>
        /// Adds the specified key and item to this dictionary.
        /// </summary>
        /// <param name="key">The key of the item</param>
        /// <param name="item">The value of the item.</param>
        public void Add(string key, byte item) {

            base.Add(key, new JsonNumber(item));
        }

        /// <summary>
        /// Adds the specified key and item to this dictionary.
        /// </summary>
        /// <param name="key">The key of the item</param>
        /// <param name="item">The value of the item.</param>
        [CLSCompliant(false)]
        public void Add(string key, sbyte item) {

            base.Add(key, new JsonNumber(item));
        }

        /// <summary>
        /// Adds the specified key and item to this dictionary.
        /// </summary>
        /// <param name="key">The key of the item</param>
        /// <param name="item">The value of the item.</param>
        public void Add(string key, short item) {

            base.Add(key, new JsonNumber(item));
        }

        /// <summary>
        /// Adds the specified key and item to this dictionary.
        /// </summary>
        /// <param name="key">The key of the item</param>
        /// <param name="item">The value of the item.</param>
        [CLSCompliant(false)]
        public void Add(string key, ushort item) {

            base.Add(key, new JsonNumber(item));
        }

        /// <summary>
        /// Adds the specified key and item to this dictionary.
        /// </summary>
        /// <param name="key">The key of the item</param>
        /// <param name="item">The value of the item.</param>
        [CLSCompliant(false)]
        public void Add(string key, int item) {

            base.Add(key, new JsonNumber(item));
        }

        /// <summary>
        /// Adds the specified key and item to this dictionary.
        /// </summary>
        /// <param name="key">The key of the item</param>
        /// <param name="item">The value of the item.</param>
        [CLSCompliant(false)]
        public void Add(string key, uint item) {

            base.Add(key, new JsonNumber(item));
        }

        /// <summary>
        /// Adds the specified key and item to this dictionary.
        /// </summary>
        /// <param name="key">The key of the item</param>
        /// <param name="item">The value of the item.</param>
        public void Add(string key, long item) {

            base.Add(key, new JsonNumber(item));
        }

        /// <summary>
        /// Adds the specified key and item to this dictionary.
        /// </summary>
        /// <param name="key">The key of the item</param>
        /// <param name="item">The value of the item.</param>
        [CLSCompliant(false)]
        public void Add(string key, ulong item) {

            base.Add(key, new JsonNumber(item));
        }

        /// <summary>
        /// Adds the specified key and item to this dictionary.
        /// </summary>
        /// <param name="key">The key of the item</param>
        /// <param name="item">The value of the item.</param>
        public void Add(string key, double item) {

            base.Add(key, new JsonNumber(item));
        }        

        /// <summary>
        /// Returns the JsonTypeCode for this instance.
        /// </summary>
        public JsonTypeCode JsonTypeCode {

            get { return JsonTypeCode.Object; }
        }

        /// <summary>
        /// Implicit conversion operator.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>This method always returns null.</returns>
        public static implicit operator JsonObject(JsonNull value) {

            return null;
        }

        #endregion
    }
}
