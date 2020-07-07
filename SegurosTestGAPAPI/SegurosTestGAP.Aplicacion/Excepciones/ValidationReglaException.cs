using System;

namespace SegurosTestGAP.Aplicacion.Excepciones
{
    [Serializable]
    public class ValidationReglaException : InvalidOperationException
    {
        public ValidationReglaException() { }
        public ValidationReglaException(string message) : base(message) { }
        public ValidationReglaException(string message, Exception inner) : base(message, inner) { }
        protected ValidationReglaException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
