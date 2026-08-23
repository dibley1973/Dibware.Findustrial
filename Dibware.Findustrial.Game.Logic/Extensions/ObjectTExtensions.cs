namespace Dibware.Findustrial.Game.Logic.Extensions;

using Dibware.Findustrial.Game.Logic.SharedKernel.Amplifiers;

/// <summary>
/// Extends the <see langword="object"/> class.
/// </summary>
public static class ObjectTExtensions
{
    /// <summary>
    /// Wraps the specified <paramref name="object"/> in a <see cref="Maybe{T}"/>.
    /// If the calue of <paramref name="object"/> is <see langword="null"/> then
    /// <see cref="Maybe.Empty"/> is returned, otherwise the object is wrapped in
    /// the <see cref="Maybe{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to wrap.</typeparam>
    /// <param name="object">The object to wrap.</param>
    /// <returns>
    /// Returns a <see cref="Maybe{T}"/>.
    /// </returns>
    public static Maybe<T> WrapInMaybe<T>(this T? @object)
    {
        return (@object is null)
            ? Maybe<T>.Empty
            : Maybe<T>.Wrap(@object);
    }
}
