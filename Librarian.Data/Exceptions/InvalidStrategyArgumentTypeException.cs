using Librarian.Data.Strategies;
using System;

namespace Librarian.Data.Exceptions
{
    public class InvalidStrategyArgumentTypeException<T> : Exception
    {
        public Type ArgumentType { get; }
        public IFindStrategy<T> Strategy { get; }

        public override string Message => $"Trying to pass argument of type {ArgumentType.FullName} to strategy of type {Strategy.GetType().FullName}, what caused cast to fail";

        public InvalidStrategyArgumentTypeException(Type argType, IFindStrategy<T> strategy)
        {
            ArgumentType = argType;
            Strategy = strategy;
        }
    }
}
