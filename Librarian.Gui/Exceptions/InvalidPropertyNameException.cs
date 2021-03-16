using System;

namespace Librarian.Gui.Exceptions
{
    public class InvalidPropertyNameException : Exception
    {
        public string PropertyName { get; }
        public Type ObjectType { get; }

        public override string Message => $"Object of type {ObjectType.Name} does not have property with name {PropertyName}";

        public InvalidPropertyNameException(string propertyName, Type objectType) : base()
        {
            PropertyName = propertyName;
            ObjectType = objectType;
        }
    }
}
