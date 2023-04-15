using System;
using System.Runtime.Serialization;

namespace WalkYourDogApp
{
    [Serializable]
    public class WrongLengthException : Exception
    {
        /// <summary>
        /// WrongLengthException jest wyjątkiem, który jest generowany, gdy długość danych jest niepoprawna.
        /// </summary>
        public WrongLengthException()
        {
        }

        public WrongLengthException(string message) : base(message)
        {
        }

        public WrongLengthException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongLengthException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}