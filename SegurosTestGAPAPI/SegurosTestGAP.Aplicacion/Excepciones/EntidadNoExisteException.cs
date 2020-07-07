using System;

namespace SegurosTestGAP.Aplicacion.Excepciones
{
    [Serializable]
    public class EntidadNoExisteException : Exception
    {
        public Type EntityType { get; set; }

        public EntidadNoExisteException()
        {
            EntityType = default!;
        }

        public EntidadNoExisteException(string message) : base(message)
        {
            EntityType = default!;
        }

        public EntidadNoExisteException(string message, Exception inner) : base(message, inner)
        {
            EntityType = default!;
        }

        protected EntidadNoExisteException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
            EntityType = default!;
        }
    }
}
