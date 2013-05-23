// JsonTokenType.cs
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

namespace NetServ.Net.Json
{
    /// <summary>
    /// Defines the high level Json tokens.
    /// </summary>
    [Serializable()]
    public enum JsonTokenType
    {
        /// <summary>
        /// No token.
        /// </summary>
        None = 0,
        /// <summary>
        /// The start of array token.
        /// </summary>
        BeginArray = 1,
        /// <summary>
        /// The end of array token.
        /// </summary>
        EndArray = 2,
        /// <summary>
        /// The start of object token.
        /// </summary>
        BeginObject = 3,
        /// <summary>
        /// The end of object token.
        /// </summary>
        EndObject = 4,
        /// <summary>
        /// An object property name token.
        /// </summary>
        Name = 5,
        /// <summary>
        /// A value token.
        /// </summary>
        Value = 6,
    }

}
