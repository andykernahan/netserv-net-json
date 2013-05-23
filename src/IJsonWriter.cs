// IJsonEncoder.cs
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

namespace NetServ.Net.Json
{
    /// <summary>
    /// Defines a JavaScript Object Notation writer.
    /// </summary>
    public interface IJsonWriter
    {
        /// <summary>
        /// Writes the start of an array to the underlying data stream.
        /// </summary>
        void WriteBeginArray();        

        /// <summary>
        /// Writes the end of an array to the underlying data stream.
        /// </summary>
        void WriteEndArray();

        /// <summary>
        /// Writes the start of an object to the underlying data stream.
        /// </summary>
        void WriteBeginObject();        

        /// <summary>
        /// Writes the end of an object to the underlying data stream.
        /// </summary>
        void WriteEndObject();

        /// <summary>
        /// Writes a object property name to the underlying data stream.
        /// </summary>
        /// <param name="value">The property name.</param>
        void WriteName(string value);

        /// <summary>
        /// Writes a raw string value to the underlying data stream.
        /// </summary>
        /// <param name="value">The string to write.</param>
        void WriteValue(string value);        
    }
}
