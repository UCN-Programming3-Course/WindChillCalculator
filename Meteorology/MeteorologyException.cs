using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteorology
{

    [Serializable]
    public class MeteorologyException : Exception
    {
        public MeteorologyException() { }
        public MeteorologyException(string message) : base(message) { }
        public MeteorologyException(string message, Exception inner) : base(message, inner) { }
        protected MeteorologyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
