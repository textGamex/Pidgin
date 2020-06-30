using System;
using System.Collections.Generic;

namespace Pidgin
{
    public abstract partial class Parser<TToken, T>
    {
        /// <summary>
        /// Creates a parser which applies the current parser repeatedly, interleaved with a specified parser.
        /// The resulting parser ignores the return value of the separator parser.
        /// </summary>
        /// <typeparam name="U">The return type of the separator parser</typeparam>
        /// <param name="separator">A parser which parses a separator to be interleaved with the current parser</param>
        /// <returns>A parser which applies the current parser repeatedly, interleaved by <paramref name="separator"/></returns>
        public Parser<TToken, IEnumerable<T>> Separated<U>(Parser<TToken, U> separator)
        {
            if (separator == null)
            {
                throw new ArgumentNullException(nameof(separator));
            }
            return this.SeparatedAtLeastOnce(separator)
                .Or(ReturnEmptyEnumerable);
        }
        
        /// <summary>
        /// Creates a parser which applies the current parser at least once, interleaved with a specified parser.
        /// The resulting parser ignores the return value of the separator parser.
        /// </summary>
        /// <typeparam name="U">The return type of the separator parser</typeparam>
        /// <param name="separator">A parser which parses a separator to be interleaved with the current parser</param>
        /// <returns>A parser which applies the current parser at least once, interleaved by <paramref name="separator"/></returns>
        public Parser<TToken, IEnumerable<T>> SeparatedAtLeastOnce<U>(Parser<TToken, U> separator)
        {
            if (separator == null)
            {
                throw new ArgumentNullException(nameof(separator));
            }
            return new SeparatedAtLeastOnceParser<TToken, T, U>(this, separator);
        }

        /// <summary>
        /// Creates a parser which applies the current parser repeatedly, interleaved and terminated with a specified parser.
        /// The resulting parser ignores the return value of the separator parser.
        /// </summary>
        /// <typeparam name="U">The return type of the separator parser</typeparam>
        /// <param name="separator">A parser which parses a separator to be interleaved with the current parser</param>
        /// <returns>A parser which applies the current parser repeatedly, interleaved and terminated by <paramref name="separator"/></returns>
        public Parser<TToken, IEnumerable<T>> SeparatedAndTerminated<U>(Parser<TToken, U> separator)
        {
            if (separator == null)
            {
                throw new ArgumentNullException(nameof(separator));
            }
            return this.Before(separator).Many();
        }
        
        /// <summary>
        /// Creates a parser which applies the current parser at least once, interleaved and terminated with a specified parser.
        /// The resulting parser ignores the return value of the separator parser.
        /// </summary>
        /// <typeparam name="U">The return type of the separator parser</typeparam>
        /// <param name="separator">A parser which parses a separator to be interleaved with the current parser</param>
        /// <returns>A parser which applies the current parser at least once, interleaved and terminated by <paramref name="separator"/></returns>
        public Parser<TToken, IEnumerable<T>> SeparatedAndTerminatedAtLeastOnce<U>(Parser<TToken, U> separator)
        {
            if (separator == null)
            {
                throw new ArgumentNullException(nameof(separator));
            }
            return this.Before(separator).AtLeastOnce();
        }

        /// <summary>
        /// Creates a parser which applies the current parser repeatedly, interleaved and optionally terminated with a specified parser.
        /// The resulting parser ignores the return value of the separator parser.
        /// </summary>
        /// <typeparam name="U">The return type of the separator parser</typeparam>
        /// <param name="separator">A parser which parses a separator to be interleaved with the current parser</param>
        /// <returns>A parser which applies the current parser repeatedly, interleaved and optionally terminated by <paramref name="separator"/></returns>
        public Parser<TToken, IEnumerable<T>> SeparatedAndOptionallyTerminated<U>(Parser<TToken, U> separator)
        {
            if (separator == null)
            {
                throw new ArgumentNullException(nameof(separator));
            }
            return this.SeparatedAndOptionallyTerminatedAtLeastOnce(separator)
                .Or(ReturnEmptyEnumerable);
        }
        
        /// <summary>
        /// Creates a parser which applies the current parser at least once, interleaved and optionally terminated with a specified parser.
        /// The resulting parser ignores the return value of the separator parser.
        /// </summary>
        /// <typeparam name="U">The return type of the separator parser</typeparam>
        /// <param name="separator">A parser which parses a separator to be interleaved with the current parser</param>
        /// <returns>A parser which applies the current parser at least once, interleaved and optionally terminated by <paramref name="separator"/></returns>
        public Parser<TToken, IEnumerable<T>> SeparatedAndOptionallyTerminatedAtLeastOnce<U>(Parser<TToken, U> separator)
        {
            if (separator == null)
            {
                throw new ArgumentNullException(nameof(separator));
            }
            return new SeparatedAndOptionallyTerminatedAtLeastOnceParser<TToken, T, U>(this, separator);
        }
    }

    internal sealed class SeparatedAtLeastOnceParser<TToken, T, U> : Parser<TToken, IEnumerable<T>>
    {
        private readonly Parser<TToken, T> _parser;
        private readonly Parser<TToken, T> _remainderParser;

        public SeparatedAtLeastOnceParser(Parser<TToken, T> parser, Parser<TToken, U> separator)
        {
            _parser = parser;
            _remainderParser = separator.Then(parser);
        }

        internal override InternalResult<IEnumerable<T>> Parse(ref ParseState<TToken> state, ref ExpectedCollector<TToken> expecteds)
        {
            var result = _parser.Parse(ref state, ref expecteds);
            if (!result.Success)
            {
                // state.Error set by _parser
                return InternalResult.Failure<IEnumerable<T>>();
            }
            return Rest(_remainderParser, ref state, ref expecteds, new List<T> { result.Value });
        }

        private InternalResult<IEnumerable<T>> Rest(Parser<TToken, T> parser, ref ParseState<TToken> state, ref ExpectedCollector<TToken> expecteds, List<T> ts)
        {
            var lastStartingLoc = state.Location;
            var childExpecteds = new ExpectedCollector<TToken>();
            var result = parser.Parse(ref state, ref childExpecteds);
            while (result.Success)
            {
                var endingLoc = state.Location;
                childExpecteds.Clear();

                if (endingLoc <= lastStartingLoc)
                {
                    childExpecteds.Dispose();
                    throw new InvalidOperationException("Many() used with a parser which consumed no input");
                }

                ts.Add(result.Value);

                lastStartingLoc = endingLoc;
                result = parser.Parse(ref state, ref childExpecteds);
            }
            var lastParserConsumedInput = state.Location > lastStartingLoc;
            expecteds.AddIf(ref childExpecteds, lastParserConsumedInput);
            childExpecteds.Dispose();

            if (lastParserConsumedInput)  // the most recent parser failed after consuming input
            {
                // state.Error set by parser
                return InternalResult.Failure<IEnumerable<T>>();
            }
            return InternalResult.Success<IEnumerable<T>>(ts);
        }
    }

    internal sealed class SeparatedAndOptionallyTerminatedAtLeastOnceParser<TToken, T, U> : Parser<TToken, IEnumerable<T>>
    {
        private readonly Parser<TToken, T> _parser;
        private readonly Parser<TToken, U> _separator;

        public SeparatedAndOptionallyTerminatedAtLeastOnceParser(Parser<TToken, T> parser, Parser<TToken, U> separator)
        {
            _parser = parser;
            _separator = separator;
        }

        internal override InternalResult<IEnumerable<T>> Parse(ref ParseState<TToken> state, ref ExpectedCollector<TToken> expecteds)
        {
            var result = _parser.Parse(ref state, ref expecteds);
            if (!result.Success)
            {
                // state.Error set by _parser
                return InternalResult.Failure<IEnumerable<T>>();
            }
            var ts = new List<T> { result.Value };

            var childExpecteds = new ExpectedCollector<TToken>();
            while (true)
            {
                var sepStartLoc = state.Location;
                var sepResult = _separator.Parse(ref state, ref childExpecteds);
                var sepConsumedInput = state.Location > sepStartLoc;

                expecteds.AddIf(ref childExpecteds, !sepResult.Success && sepConsumedInput);
                childExpecteds.Clear();

                if (!sepResult.Success)
                {
                    childExpecteds.Dispose();
                    if (sepConsumedInput)
                    {
                        // state.Error set by _separator
                        return InternalResult.Failure<IEnumerable<T>>();
                    }
                    return InternalResult.Success<IEnumerable<T>>(ts);
                }


                var itemStartLoc = state.Location;
                var itemResult = _parser.Parse(ref state, ref childExpecteds);
                var itemConsumedInput = state.Location > itemStartLoc;

                expecteds.AddIf(ref childExpecteds, !itemResult.Success && itemConsumedInput);
                childExpecteds.Clear();

                if (!itemResult.Success)
                {
                    childExpecteds.Dispose();
                    return itemConsumedInput
                        ? InternalResult.Failure<IEnumerable<T>>()  // state.Error set by _parser
                        : InternalResult.Success<IEnumerable<T>>(ts);
                }
                ts.Add(itemResult.Value);
            }
        }
    }
}