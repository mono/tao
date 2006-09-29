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
using System.Runtime.InteropServices;

namespace Tao.GlBindGen
{
    /// <summary>
    /// Represents a single parameter of an opengl function.
    /// </summary>
    public class Parameter
    {
        #region Name property

        string _name;
        /// <summary>
        /// Gets or sets the name of the parameter.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        #endregion

        #region _unmanaged_type property

        UnmanagedType _unmanaged_type;
        /// <summary>
        /// Gets or sets the name of the parameter.
        /// </summary>
        public UnmanagedType UnmanagedType
        {
            get { return _unmanaged_type; }
            set { _unmanaged_type = value; }
        }

        #endregion

        #region Type property

        string _type;
        /// <summary>
        /// Gets the type of the parameter.
        /// </summary>
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        #endregion

        #region Flow property

        /// <summary>
        /// Enumarates the possible flows of a parameter (ie. is this parameter
        /// used as input or as output?)
        /// </summary>
        public enum FlowDirection
        {
            Undefined = 0,
            In,
            Out
        }

        FlowDirection _flow;

        /// <summary>
        /// Gets or sets the flow of the parameter.
        /// </summary>
        public FlowDirection Flow
        {
            get { return _flow; }
            set { _flow = value; }
        }

        #endregion

        #region Array property

        bool _array = false;

        public bool Array
        {
            get { return _array; }
            set { _array = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new Parameter without type and name.
        /// </summary>
        public Parameter() { }

        #endregion

        #region ToString function
        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (UnmanagedType == UnmanagedType.AsAny && Flow == FlowDirection.In)
                sb.Append("[MarshalAs(UnmanagedType.AsAny)] ");

            if (UnmanagedType == UnmanagedType.LPArray)
                sb.Append("[MarshalAs(UnmanagedType.LPArray)] ");

            if (Flow == FlowDirection.Out && !Array)
                sb.Append("out ");

            sb.Append(Type);
            if (Array)
                sb.Append("[]");

            sb.Append(" ");
            sb.Append(Name);

            return sb.ToString();
        }
        #endregion
    }
}
