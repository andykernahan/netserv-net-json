// IJsonTypeFactory.cs
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

// The purpose of this interface and the JsonTypeFactory was to allow consumers to
// utilise the JsonParser and have it construct their own types. The reason that it
// is not used is that it made the use of the parser rather messy if one wanted to
// take advantage of the operator overloads defined in most of the NetServ types.
// Also, as I have tried to make the classes as consumer friendly as possible, I 
// couldn't think of any other way that they may implemented. These factors negated 
// the usefulness of this interface and therefore it is not included.

#if NOT_USED

using System;

namespace NetServ.Net.Json
{
    /// <summary>
    /// Defines a factory for JavaScript Object Notation data types.
    /// </summary>
    public interface IJsonTypeFactory
    {
        /// <summary>
        /// Creates a <see cref="NetServ.Net.Json.IJsonObject"/>.
        /// </summary>
        /// <returns>A <see cref="NetServ.Net.Json.IJsonObject"/>.</returns>
        IJsonObject CreateObject();

        /// <summary>
        /// Creates a <see cref="NetServ.Net.Json.IJsonArray"/>.
        /// </summary>
        /// <returns>A <see cref="NetServ.Net.Json.IJsonArray"/>.</returns>
        IJsonArray CreateArray();

        /// <summary>
        /// Creates a <see cref="NetServ.Net.Json.IJsonString"/> representing
        /// the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>a <see cref="NetServ.Net.Json.IJsonString"/> representing
        /// the specified <paramref name="value"/></returns>
        IJsonString CreateString(string value);

        /// <summary>
        /// Creates a <see cref="NetServ.Net.Json.IJsonNumber"/> representing
        /// the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>a <see cref="NetServ.Net.Json.IJsonNumber"/> representing
        /// the specified <paramref name="value"/></returns>
        IJsonNumber CreateNumber(double value);

        /// <summary>
        /// Creates a <see cref="NetServ.Net.Json.IJsonBoolean"/> representing
        /// the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>a <see cref="NetServ.Net.Json.IJsonBoolean"/> representing
        /// the specified <paramref name="value"/></returns>
        IJsonBoolean CreateBoolean(bool value);

        /// <summary>
        /// Creates a <see cref="NetServ.Net.Json.IJsonNull"/>.
        /// </summary>
        /// <returns>A <see cref="NetServ.Net.Json.IJsonNull"/>.</returns>
        IJsonNull CreateNull();
    }
}

#endif