// JsonTypeFactory.cs
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

// See comment in IJsonTypeFactory.cs.

#if NOT_USED

using System;

namespace NetServ.Net.Json
{
    /// <summary>
    /// Represents the default type factory for the <see cref="NetServ.Net.Json"/>
    /// namespace.
    /// </summary>
    public sealed class JsonTypeFactory : IJsonTypeFactory
    {
        #region Public Interface.

        /// <summary>
        /// Gets the default instance of the factory.
        /// </summary>
        public static readonly JsonTypeFactory Instance = new JsonTypeFactory();        

        /// <summary>
        /// Creates a <see cref="NetServ.Net.Json.JsonObject"/>.
        /// </summary>
        /// <returns>A <see cref="NetServ.Net.Json.JsonObject"/>.</returns>
        public JsonObject CreateObject() {

            return new JsonObject();
        }

        /// <summary>
        /// Creates a <see cref="NetServ.Net.Json.JsonArray"/>.
        /// </summary>
        /// <returns>A <see cref="NetServ.Net.Json.JsonArray"/>.</returns>
        public JsonArray CreateArray() {

            return new JsonArray();
        }

        /// <summary>
        /// Creates a <see cref="NetServ.Net.Json.JsonString"/> representing
        /// the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>a <see cref="NetServ.Net.Json.JsonString"/> representing
        /// the specified <paramref name="value"/></returns>
        public JsonString CreateString(string value) {

            if(value == null)
                return null;
            if(value.Equals(string.Empty))
                return JsonString.Empty;
            return new JsonString(value);
        }

        /// <summary>
        /// Creates a <see cref="NetServ.Net.Json.JsonNumber"/> representing
        /// the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>a <see cref="NetServ.Net.Json.JsonNumber"/> representing
        /// the specified <paramref name="value"/></returns>
        public JsonNumber CreateNumber(double value) {

            return new JsonNumber(value);
        }

        /// <summary>
        /// Creates a <see cref="NetServ.Net.Json.JsonBoolean"/> representing
        /// the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>a <see cref="NetServ.Net.Json.JsonBoolean"/> representing
        /// the specified <paramref name="value"/></returns>
        public JsonBoolean CreateBoolean(bool value) {

            return JsonBoolean.Get(value);
        }

        /// <summary>
        /// Creates a <see cref="NetServ.Net.Json.JsonNull"/>.
        /// </summary>
        /// <returns>A <see cref="NetServ.Net.Json.JsonNull"/>.</returns>
        public JsonNull CreateNull() {

            return JsonNull.Null;
        }

        #endregion

        #region Explict Interface.

        IJsonObject IJsonTypeFactory.CreateObject() {

            return CreateObject();
        }

        IJsonArray IJsonTypeFactory.CreateArray() {

            return CreateArray();
        }

        IJsonString IJsonTypeFactory.CreateString(string value) {

            return CreateString(value);
        }

        IJsonNumber IJsonTypeFactory.CreateNumber(double value) {

            return CreateNumber(value);
        }

        IJsonBoolean IJsonTypeFactory.CreateBoolean(bool value) {

            return CreateBoolean(value);
        }

        IJsonNull IJsonTypeFactory.CreateNull() {

            return CreateNull();
        }

        #endregion

        #region Private Impl.

        private JsonTypeFactory() {
        }

        #endregion
    }  
}

#endif