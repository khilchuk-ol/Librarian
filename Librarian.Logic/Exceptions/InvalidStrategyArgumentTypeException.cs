using Librarian.Domain.Strategies.Abstract;
using System;

namespace Librarian.Domain.Exceptions
{
    public class InvalidStrategyArgumentTypeException<T> : Exception
    {
        public Type ArgumentType { get; }
        public IFindStrategy<T> Strategy { get; }

        public override string Message => $"Trying to pass argument of type {ArgumentType.FullName} to strategy of type {Strategy.GetType().FullName}. Cast failed";

        public InvalidStrategyArgumentTypeException(Type argType, IFindStrategy<T> strategy) : base()
        {
            ArgumentType = argType;
            Strategy = strategy;
        }
    }
}
