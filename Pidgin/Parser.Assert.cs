using System;

namespace Pidgin
{
    public abstract partial class Parser<TToken, T>
    {
        /// <summary>
        /// Creates a parser that fails if the value returned by the current parser fails to satisfy a predicate.
        /// </summary>
        /// <param name="predicate">The predicate to apply to the value returned by the current parser</param>
        /// <returns>A parser that fails if the value returned by the current parser fails to satisfy <paramref name="predicate"/></returns>
        public Parser<TToken, T> Assert(Func<T, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            return Assert(predicate, "Assertion failed");
        }

        /// <summary>
        /// Creates a parser that fails if the value returned by the current parser fails to satisfy a predicate.
        /// </summary>
        /// <param name="predicate">The predicate to apply to the value returned by the current parser</param>
        /// <param name="message">A custom error message to return when the value returned by the current parser fails to satisfy the predicate</param>
        /// <returns>A parser that fails if the value returned by the current parser fails to satisfy <paramref name="predicate"/></returns>
        public Parser<TToken, T> Assert(Func<T, bool> predicate, string message)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            return Assert(predicate, _ => message);
        }

        /// <summary>
        /// Creates a parser that fails if the value returned by the current parser fails to satisfy a predicate.
        /// </summary>
        /// <param name="predicate">The predicate to apply to the value returned by the current parser</param>
        /// <param name="message">A function to produce a custom error message to return when the value returned by the current parser fails to satisfy the predicate</param>
        /// <returns>A parser that fails if the value returned by the current parser fails to satisfy <paramref name="predicate"/></returns>
        public Parser<TToken, T> Assert(Func<T, bool> predicate, Func<T, string> message)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            return new AssertParser<TToken, T>(this, predicate, message);
        }
    }

    internal sealed class AssertParser<TToken, T> : Parser<TToken, T>
    {
        private static readonly Expected<TToken> _expected
            = new Expected<TToken>("result satisfying assertion");

        private readonly Parser<TToken, T> _parser;
        private readonly Func<T, bool> _predicate;
        private readonly Func<T, string> _message;

        public AssertParser(Parser<TToken, T> parser, Func<T, bool> predicate, Func<T, string> message)
        {
            _parser = parser;
            _predicate = predicate;
            _message = message;
        }

        internal sealed override InternalResult<T> Parse(ref ParseState<TToken> state, ref ExpectedCollector<TToken> expecteds)
        {
            var childExpecteds = new ExpectedCollector<TToken>();

            var result = _parser.Parse(ref state, ref childExpecteds);

            expecteds.AddIf(ref childExpecteds, result.Success);
            childExpecteds.Dispose();

            if (!result.Success)
            {
                return result;
            }

            var val = result.Value;
            if (!_predicate(val))
            {
                state.Error = new InternalError<TToken>(
                    Maybe.Nothing<TToken>(),
                    false,
                    state.Location,
                    _message(val)
                );
                expecteds.Add(_expected);
                return InternalResult.Failure<T>();
            }
            return result;
        }
    }
}