// IndentedJsonWriter.cs
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
using System.IO;

namespace NetServ.Net.Json
{
    /// <summary>
    /// Provided support for writing JavaScript Object Notation data types to an
    /// underlying <see cref="System.IO.TextWriter"/> whilst indenting the output.
    /// </summary>   
    public class IndentedJsonWriter : JsonWriter
    {
        #region Private Fields.

        private int _indentLevel;
        private string _indentString = "\t";

        #endregion

        #region Public Interface.

        /// <summary>
        /// Initialises a new instance of then IndentedJsonWriter class using a
        /// <see cref="System.IO.StringWriter"/> as the underlying 
        /// <see cref="System.IO.TextWriter"/>.
        /// </summary>
        public IndentedJsonWriter()
            : base() {
        }

        /// <summary>
        /// Initialises a new instance of the IndentedJsonWriter class and specifies
        /// the underlying <see cref="System.IO.TextWriter"/> and a value indicating
        /// if the instance owns the specified TextWriter.
        /// </summary>
        /// <param name="writer">The underlying text writer.</param>
        /// <param name="ownsWriter">True if this instance owns the specified TextWriter,
        /// otherwise; false.</param>
        public IndentedJsonWriter(TextWriter writer, bool ownsWriter)
            : base(writer, ownsWriter) {
        }

        /// <summary>
        /// Gets or sets the string used to indent the output.
        /// </summary>
        public string IndentString {

            get { return _indentString; }
            set {
                if(value == null)
                    throw new ArgumentNullException("value");
                _indentString = value;
            }
        }

        #endregion

        #region Protected Interface.

        /// <summary>
        /// Performs any assertions and / or write operations needed before the specified
        /// token is written to the underlying stream.
        /// </summary>
        /// <param name="token">The next token to be written.</param>
        protected override void PreWrite(JsonTokenType token) {

            base.PreWrite(token);
            // Firstly, see if a new line is required.
            switch(base.CurrentStruct) {
                case JsonStructType.Array:
                    // Every array element starts on a new line.
                    base.Writer.WriteLine();
                    break;
                case JsonStructType.Object:
                    // Don't write primitives on a new line.
                    if(token != JsonTokenType.Value)
                        base.Writer.WriteLine();                    
                    break;
                case JsonStructType.None:
                    break;
                default:
                    Debug.Fail("IndentedJsonWriter::PreWrite - Unknown base.CurrentStruct.");
                    break;
            }
            // Secondly, see if the indent should be written and / or adjusted.
            switch(token) {
                case JsonTokenType.BeginArray:
                case JsonTokenType.BeginObject:
                    WriteIndent();
                    ++this.IndentLevel;
                    break;
                case JsonTokenType.EndArray:
                case JsonTokenType.EndObject:
                    --this.IndentLevel;
                    WriteIndent();
                    break;
                case JsonTokenType.Name:
                    WriteIndent();
                    break;
                case JsonTokenType.Value:
                    // Primtives are not written on a new line when in an object.
                    if(base.CurrentStruct != JsonStructType.Object)
                        WriteIndent();
                    else
                        base.Writer.Write(" ");
                    break;
                case JsonTokenType.None:
                    break;
                default:
                    Debug.Fail("IndentedJsonWriter::PreWrite - Unknown token.");
                    break;
            }
        }

        /// <summary>
        /// Writes the indent to the underlying stream.
        /// </summary>
        protected void WriteIndent() {

            for(int i = 0; i < this.IndentLevel; ++i)
                base.Writer.Write(this.IndentString);           
        }

        /// <summary>
        /// Gets or sets the indent level.
        /// </summary>
        protected int IndentLevel {

            get { return _indentLevel; }
            set {
                if(value < 0)
                    throw new ArgumentOutOfRangeException("value");
                _indentLevel = value;
            }
        }

        #endregion
    }
}
