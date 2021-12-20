using System;

namespace CSharp_053505_Gerashchenko_Lab6.Exceptions
{
    public class CustomCollectionException : InvalidOperationException
    {
        public CustomCollectionException(string message)
            : base(message)
        {
        }
    }
}