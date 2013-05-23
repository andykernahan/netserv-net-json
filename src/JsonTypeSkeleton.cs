// JsonTypeSkeleton.cs
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
    /// Defines a base class for most Json types. This class is abstract.
    /// </summary>
    [Serializable()]
    public abstract class JsonTypeSkeleton : IJsonType
    {
        #region Private Fields.

        private readonly JsonTypeCode _typeCode;

        #endregion

        #region Protected Interface.

        /// <summary>
        /// Initialises a new instance of the JsonTypeSkeleton class and specifies the 
        /// type code.
        /// </summary>
        /// <param name="typeCode">The type code.</param>
        protected JsonTypeSkeleton(JsonTypeCode typeCode) {

            _typeCode = typeCode;
        }

        #endregion

        #region Public Interface.

        /// <summary>
        /// When overriden in a derived class; writes the contents of the Json type 
        /// to the specified <see cref="NetServ.Net.Json.IJsonWriter"/>.
        /// </summary>
        /// <param name="writer">The Json writer.</param>
        public abstract void Write(IJsonWriter writer);

        /// <summary>
        /// Gets the type code of this Json type.
        /// </summary>
        public JsonTypeCode JsonTypeCode {

            get { return _typeCode; }
        }

        #endregion
    }
}
