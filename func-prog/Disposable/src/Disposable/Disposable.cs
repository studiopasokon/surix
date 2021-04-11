using System;

namespace StudioPasokon.ForEverProject.FuncProg
{
    /// <summary>
    /// Class implementing supporting functions for assisting coding "disposable" and "using"
    /// constructs in a functional way.
    /// </summary>
    public static class Disposable
    {
        /// <summary>
        /// Implementation of a helper function to apply the "using" statement in a functional
        /// programing style.
        /// This piece of code is taken from the Pluralsight course "Functional Programming with C#"
        /// by Dave Fancher.
        /// </summary>
        /// <typeparam name="TDisposable">Type of the disposable object.</typeparam>
        /// <typeparam name="TResult">Type of the returning result of the actions.</typeparam>
        /// <param name="factory">Function creating the disposable object.</param>
        /// <param name="fn">Function applying the required action on the disposable object.</param>
        /// <returns>The result of the actions applied on the disposable object.</returns>
        public static TResult Using<TDisposable, TResult> (
            Func<TDisposable> factory,
            Func<TDisposable, TResult> fn) where TDisposable : IDisposable
        {
            using (var disposable = factory())
                return fn(disposable);
        }
    }
}
