using Librarian.Domain.Factories.Abstract;
using System;

namespace Librarian.Logic.Exceptions
{
    public class InvalidStrategyFindTypeException<TElement, TFindType> : Exception
    {
        public TFindType PassedFindType { get; }
        public FindStrategyFactory<TElement, TFindType> Factory { get; }

        public override string Message => $"Trying to pass {PassedFindType} as find type to strategy factory of type {Factory.GetType().FullName}. Invalid find type input";

        public InvalidStrategyFindTypeException(TFindType findType, FindStrategyFactory<TElement, TFindType> factory) : base()
        {
            PassedFindType = findType;
            Factory = factory;
        }
    }
}
