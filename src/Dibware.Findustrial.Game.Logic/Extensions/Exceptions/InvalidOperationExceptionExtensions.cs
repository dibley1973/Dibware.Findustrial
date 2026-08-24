namespace Dibware.Findustrial.Game.Logic.Extensions.Exceptions;

using System;

/// <summary>
/// Provides extension methods for the <see cref="InvalidOperationException"/> class.
/// </summary>
public static class InvalidOperationExceptionExtensions
{
    // 👇 Extension block specifies receiver type but doesn't specify a parameter name
    extension(InvalidOperationException)
    {
        /// <summary>
        /// Throws a new <see cref="InvalidOperationException"/> with the specified <paramref name="message"/>
        /// if the specified <paramref name="condition"/> is <see langword="true"/>.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="message">The message to include with the exception if it is thrown.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the value of <paramref name="condition"/> is <see langword="true"/>.
        /// </exception>
        public static void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
                throw new InvalidOperationException(message);
        }

        /// <summary>
        /// Throws a new <see cref="InvalidOperationException"/> with the specified <paramref name="message"/>
        /// if the result of calling the specified <paramref name="conditionCallback"/> function returns true.
        /// </summary>
        /// <param name="conditionCallback">The function to call to evaluates the condition to check.</param>
        /// <param name="message">The message to include with the exception if it is thrown.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the value returned by the <paramref name="conditionCallback"/> is <see langword="true"/>.
        /// </exception>
        public static void ThrowIfTrue(Func<bool> conditionCallback, string message)
        {
            if (conditionCallback())
                throw new InvalidOperationException(message);
        }
    }
}
