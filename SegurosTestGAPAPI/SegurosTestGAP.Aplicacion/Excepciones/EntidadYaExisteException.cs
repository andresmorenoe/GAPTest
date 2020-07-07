using System;

namespace SegurosTestGAP.Aplicacion.Excepciones
{
    [Serializable]
    public class EntidadYaExisteException : Exception
    {
        public Type EntityType { get; set; }

        public EntidadYaExisteException()
        {
            EntityType = default!;
        }

        public EntidadYaExisteException(string message) : base(message)
        {
            EntityType = default!;
        }

        public EntidadYaExisteException(string message, Exception inner) : base(message, inner)
        {
            EntityType = default!;
        }

        protected EntidadYaExisteException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
            EntityType = default!;
        }
    }
}
