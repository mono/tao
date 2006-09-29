#region License
/*
MIT License
Copyright ©2003-2006 Tao Framework Team
http://www.taoframework.com
All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Collections.Generic;
using System.Text;

namespace Tao.GlBindGen
{
    /// <summary>
    /// Represents an opengl function.
    /// The return value, function name, function parameters and opengl version can be retrieved or set.
    /// </summary>
    public class Function
    {
        #region Needs wrapper property

        bool _needs_wrapper;

        /// <summary>
        /// Indicates whether this function needs to be wrapped with a Marshaling function.
        /// This flag is set if a function contains an Array parameter, or returns
        /// an Array or string.
        /// </summary>
        public bool NeedsWrapper
        {
            get { return _needs_wrapper; }
            set { _needs_wrapper = value; }
        }

        #endregion

        #region Return value property

        string _return_value;
        /// <summary>
        /// Gets or sets the return value of the opengl function.
        /// </summary>
        public string ReturnValue
        {
            get { return _return_value; }
            set { _return_value = value; }
        }

        #endregion

        #region Name property

        string _name;
        /// <summary>
        /// Gets or sets the name of the opengl function.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    _name = value.Trim();
                else
                    _name = value;
            }
        }

        #endregion

        #region Parameter collection property

        ParameterCollection _parameters = new ParameterCollection();

        public ParameterCollection Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        #endregion

        #region Version property

        string _version;

        /// <summary>
        /// Defines the opengl version that introduced this function.
        /// </summary>
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        #endregion

        #region Extension property

        bool _extension = false;

        public bool Extension
        {
            get { return _extension; }
            set { _extension = value; }
        }

        #endregion

        #region Constructor

        public Function()
        {
        }

        #endregion
        
        #region ToString function

        /// <summary>
        /// Gets the string representing the full function declaration without decorations
        /// (ie "void glClearColor(float red, float green, float blue, float alpha)"
        /// </summary>
        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ReturnValue + " " + Name + Parameters.ToString());
            return sb.ToString();
        }

        #endregion
    }
}
