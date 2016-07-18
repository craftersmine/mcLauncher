using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace craftersmine.Launcher.Exceptions
{

    [Serializable]
    public class UnableGetSessionIDException : Exception
    {
        public UnableGetSessionIDException() { }
        public UnableGetSessionIDException(string message) : base(message) { }
        public UnableGetSessionIDException(string message, Exception inner) : base(message, inner) { }
        protected UnableGetSessionIDException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
