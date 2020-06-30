#region GeneratedCode
using System;

namespace Pidgin
{
    // Generated by Pidgin.CodeGen.
    // Each of these methods is equivalent to
    //     return
    //         from x1 in p1
    //         from x2 in p2
    //         ...
    //         from xn in pn
    //         select func(x1, x2, ..., xn)
    // but this lower-level approach saves on allocations
    public static partial class Parser
    {
        /// <summary>
        /// Creates a parser that applies the specified parsers sequentially and applies the specified transformation function to their results.
        /// </summary>
        /// <param name="func">A function to apply to the return values of the specified parsers</param>
        /// <param name="parser1">The first parser</param>
        /// <typeparam name="TToken">The type of tokens in the parser's input stream</typeparam>
        /// <typeparam name="T1">The return type of the first parser</typeparam>
        /// <typeparam name="R">The return type of the resulting parser</typeparam>
        public static Parser<TToken, R> Map<TToken, T1, R>(
            Func<T1, R> func,
            Parser<TToken, T1> parser1
        )
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            if (parser1 == null)
            {
                throw new ArgumentNullException(nameof(parser1));
            }

            return parser1 is MapParserBase<TToken, T1> p
                ? p.Map(func)
                : new Map1Parser<TToken, T1, R>(func, parser1);
        }

        /// <summary>
        /// Creates a parser that applies the specified parsers sequentially and applies the specified transformation function to their results.
        /// </summary>
        /// <param name="func">A function to apply to the return values of the specified parsers</param>
        /// <param name="parser1">The first parser</param>
        /// <param name="parser2">The second parser</param>
        /// <typeparam name="TToken">The type of tokens in the parser's input stream</typeparam>
        /// <typeparam name="T1">The return type of the first parser</typeparam>
        ///<typeparam name="T2">The return type of the second parser</typeparam>
        /// <typeparam name="R">The return type of the resulting parser</typeparam>
        public static Parser<TToken, R> Map<TToken, T1, T2, R>(
            Func<T1, T2, R> func,
            Parser<TToken, T1> parser1,
            Parser<TToken, T2> parser2
        )
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            if (parser1 == null)
            {
                throw new ArgumentNullException(nameof(parser1));
            }
            if (parser2 == null)
            {
                throw new ArgumentNullException(nameof(parser2));
            }

            return new Map2Parser<TToken, T1, T2, R>(func, parser1, parser2);
        }

        /// <summary>
        /// Creates a parser that applies the specified parsers sequentially and applies the specified transformation function to their results.
        /// </summary>
        /// <param name="func">A function to apply to the return values of the specified parsers</param>
        /// <param name="parser1">The first parser</param>
        /// <param name="parser2">The second parser</param>
        /// <param name="parser3">The third parser</param>
        /// <typeparam name="TToken">The type of tokens in the parser's input stream</typeparam>
        /// <typeparam name="T1">The return type of the first parser</typeparam>
        ///<typeparam name="T2">The return type of the second parser</typeparam>
        ///<typeparam name="T3">The return type of the third parser</typeparam>
        /// <typeparam name="R">The return type of the resulting parser</typeparam>
        public static Parser<TToken, R> Map<TToken, T1, T2, T3, R>(
            Func<T1, T2, T3, R> func,
            Parser<TToken, T1> parser1,
            Parser<TToken, T2> parser2,
            Parser<TToken, T3> parser3
        )
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            if (parser1 == null)
            {
                throw new ArgumentNullException(nameof(parser1));
            }
            if (parser2 == null)
            {
                throw new ArgumentNullException(nameof(parser2));
            }
            if (parser3 == null)
            {
                throw new ArgumentNullException(nameof(parser3));
            }

            return new Map3Parser<TToken, T1, T2, T3, R>(func, parser1, parser2, parser3);
        }

        /// <summary>
        /// Creates a parser that applies the specified parsers sequentially and applies the specified transformation function to their results.
        /// </summary>
        /// <param name="func">A function to apply to the return values of the specified parsers</param>
        /// <param name="parser1">The first parser</param>
        /// <param name="parser2">The second parser</param>
        /// <param name="parser3">The third parser</param>
        /// <param name="parser4">The fourth parser</param>
        /// <typeparam name="TToken">The type of tokens in the parser's input stream</typeparam>
        /// <typeparam name="T1">The return type of the first parser</typeparam>
        ///<typeparam name="T2">The return type of the second parser</typeparam>
        ///<typeparam name="T3">The return type of the third parser</typeparam>
        ///<typeparam name="T4">The return type of the fourth parser</typeparam>
        /// <typeparam name="R">The return type of the resulting parser</typeparam>
        public static Parser<TToken, R> Map<TToken, T1, T2, T3, T4, R>(
            Func<T1, T2, T3, T4, R> func,
            Parser<TToken, T1> parser1,
            Parser<TToken, T2> parser2,
            Parser<TToken, T3> parser3,
            Parser<TToken, T4> parser4
        )
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            if (parser1 == null)
            {
                throw new ArgumentNullException(nameof(parser1));
            }
            if (parser2 == null)
            {
                throw new ArgumentNullException(nameof(parser2));
            }
            if (parser3 == null)
            {
                throw new ArgumentNullException(nameof(parser3));
            }
            if (parser4 == null)
            {
                throw new ArgumentNullException(nameof(parser4));
            }

            return new Map4Parser<TToken, T1, T2, T3, T4, R>(func, parser1, parser2, parser3, parser4);
        }

        /// <summary>
        /// Creates a parser that applies the specified parsers sequentially and applies the specified transformation function to their results.
        /// </summary>
        /// <param name="func">A function to apply to the return values of the specified parsers</param>
        /// <param name="parser1">The first parser</param>
        /// <param name="parser2">The second parser</param>
        /// <param name="parser3">The third parser</param>
        /// <param name="parser4">The fourth parser</param>
        /// <param name="parser5">The fifth parser</param>
        /// <typeparam name="TToken">The type of tokens in the parser's input stream</typeparam>
        /// <typeparam name="T1">The return type of the first parser</typeparam>
        ///<typeparam name="T2">The return type of the second parser</typeparam>
        ///<typeparam name="T3">The return type of the third parser</typeparam>
        ///<typeparam name="T4">The return type of the fourth parser</typeparam>
        ///<typeparam name="T5">The return type of the fifth parser</typeparam>
        /// <typeparam name="R">The return type of the resulting parser</typeparam>
        public static Parser<TToken, R> Map<TToken, T1, T2, T3, T4, T5, R>(
            Func<T1, T2, T3, T4, T5, R> func,
            Parser<TToken, T1> parser1,
            Parser<TToken, T2> parser2,
            Parser<TToken, T3> parser3,
            Parser<TToken, T4> parser4,
            Parser<TToken, T5> parser5
        )
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            if (parser1 == null)
            {
                throw new ArgumentNullException(nameof(parser1));
            }
            if (parser2 == null)
            {
                throw new ArgumentNullException(nameof(parser2));
            }
            if (parser3 == null)
            {
                throw new ArgumentNullException(nameof(parser3));
            }
            if (parser4 == null)
            {
                throw new ArgumentNullException(nameof(parser4));
            }
            if (parser5 == null)
            {
                throw new ArgumentNullException(nameof(parser5));
            }

            return new Map5Parser<TToken, T1, T2, T3, T4, T5, R>(func, parser1, parser2, parser3, parser4, parser5);
        }

        /// <summary>
        /// Creates a parser that applies the specified parsers sequentially and applies the specified transformation function to their results.
        /// </summary>
        /// <param name="func">A function to apply to the return values of the specified parsers</param>
        /// <param name="parser1">The first parser</param>
        /// <param name="parser2">The second parser</param>
        /// <param name="parser3">The third parser</param>
        /// <param name="parser4">The fourth parser</param>
        /// <param name="parser5">The fifth parser</param>
        /// <param name="parser6">The sixth parser</param>
        /// <typeparam name="TToken">The type of tokens in the parser's input stream</typeparam>
        /// <typeparam name="T1">The return type of the first parser</typeparam>
        ///<typeparam name="T2">The return type of the second parser</typeparam>
        ///<typeparam name="T3">The return type of the third parser</typeparam>
        ///<typeparam name="T4">The return type of the fourth parser</typeparam>
        ///<typeparam name="T5">The return type of the fifth parser</typeparam>
        ///<typeparam name="T6">The return type of the sixth parser</typeparam>
        /// <typeparam name="R">The return type of the resulting parser</typeparam>
        public static Parser<TToken, R> Map<TToken, T1, T2, T3, T4, T5, T6, R>(
            Func<T1, T2, T3, T4, T5, T6, R> func,
            Parser<TToken, T1> parser1,
            Parser<TToken, T2> parser2,
            Parser<TToken, T3> parser3,
            Parser<TToken, T4> parser4,
            Parser<TToken, T5> parser5,
            Parser<TToken, T6> parser6
        )
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            if (parser1 == null)
            {
                throw new ArgumentNullException(nameof(parser1));
            }
            if (parser2 == null)
            {
                throw new ArgumentNullException(nameof(parser2));
            }
            if (parser3 == null)
            {
                throw new ArgumentNullException(nameof(parser3));
            }
            if (parser4 == null)
            {
                throw new ArgumentNullException(nameof(parser4));
            }
            if (parser5 == null)
            {
                throw new ArgumentNullException(nameof(parser5));
            }
            if (parser6 == null)
            {
                throw new ArgumentNullException(nameof(parser6));
            }

            return new Map6Parser<TToken, T1, T2, T3, T4, T5, T6, R>(func, parser1, parser2, parser3, parser4, parser5, parser6);
        }

        /// <summary>
        /// Creates a parser that applies the specified parsers sequentially and applies the specified transformation function to their results.
        /// </summary>
        /// <param name="func">A function to apply to the return values of the specified parsers</param>
        /// <param name="parser1">The first parser</param>
        /// <param name="parser2">The second parser</param>
        /// <param name="parser3">The third parser</param>
        /// <param name="parser4">The fourth parser</param>
        /// <param name="parser5">The fifth parser</param>
        /// <param name="parser6">The sixth parser</param>
        /// <param name="parser7">The seventh parser</param>
        /// <typeparam name="TToken">The type of tokens in the parser's input stream</typeparam>
        /// <typeparam name="T1">The return type of the first parser</typeparam>
        ///<typeparam name="T2">The return type of the second parser</typeparam>
        ///<typeparam name="T3">The return type of the third parser</typeparam>
        ///<typeparam name="T4">The return type of the fourth parser</typeparam>
        ///<typeparam name="T5">The return type of the fifth parser</typeparam>
        ///<typeparam name="T6">The return type of the sixth parser</typeparam>
        ///<typeparam name="T7">The return type of the seventh parser</typeparam>
        /// <typeparam name="R">The return type of the resulting parser</typeparam>
        public static Parser<TToken, R> Map<TToken, T1, T2, T3, T4, T5, T6, T7, R>(
            Func<T1, T2, T3, T4, T5, T6, T7, R> func,
            Parser<TToken, T1> parser1,
            Parser<TToken, T2> parser2,
            Parser<TToken, T3> parser3,
            Parser<TToken, T4> parser4,
            Parser<TToken, T5> parser5,
            Parser<TToken, T6> parser6,
            Parser<TToken, T7> parser7
        )
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            if (parser1 == null)
            {
                throw new ArgumentNullException(nameof(parser1));
            }
            if (parser2 == null)
            {
                throw new ArgumentNullException(nameof(parser2));
            }
            if (parser3 == null)
            {
                throw new ArgumentNullException(nameof(parser3));
            }
            if (parser4 == null)
            {
                throw new ArgumentNullException(nameof(parser4));
            }
            if (parser5 == null)
            {
                throw new ArgumentNullException(nameof(parser5));
            }
            if (parser6 == null)
            {
                throw new ArgumentNullException(nameof(parser6));
            }
            if (parser7 == null)
            {
                throw new ArgumentNullException(nameof(parser7));
            }

            return new Map7Parser<TToken, T1, T2, T3, T4, T5, T6, T7, R>(func, parser1, parser2, parser3, parser4, parser5, parser6, parser7);
        }

        /// <summary>
        /// Creates a parser that applies the specified parsers sequentially and applies the specified transformation function to their results.
        /// </summary>
        /// <param name="func">A function to apply to the return values of the specified parsers</param>
        /// <param name="parser1">The first parser</param>
        /// <param name="parser2">The second parser</param>
        /// <param name="parser3">The third parser</param>
        /// <param name="parser4">The fourth parser</param>
        /// <param name="parser5">The fifth parser</param>
        /// <param name="parser6">The sixth parser</param>
        /// <param name="parser7">The seventh parser</param>
        /// <param name="parser8">The eighth parser</param>
        /// <typeparam name="TToken">The type of tokens in the parser's input stream</typeparam>
        /// <typeparam name="T1">The return type of the first parser</typeparam>
        ///<typeparam name="T2">The return type of the second parser</typeparam>
        ///<typeparam name="T3">The return type of the third parser</typeparam>
        ///<typeparam name="T4">The return type of the fourth parser</typeparam>
        ///<typeparam name="T5">The return type of the fifth parser</typeparam>
        ///<typeparam name="T6">The return type of the sixth parser</typeparam>
        ///<typeparam name="T7">The return type of the seventh parser</typeparam>
        ///<typeparam name="T8">The return type of the eighth parser</typeparam>
        /// <typeparam name="R">The return type of the resulting parser</typeparam>
        public static Parser<TToken, R> Map<TToken, T1, T2, T3, T4, T5, T6, T7, T8, R>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, R> func,
            Parser<TToken, T1> parser1,
            Parser<TToken, T2> parser2,
            Parser<TToken, T3> parser3,
            Parser<TToken, T4> parser4,
            Parser<TToken, T5> parser5,
            Parser<TToken, T6> parser6,
            Parser<TToken, T7> parser7,
            Parser<TToken, T8> parser8
        )
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            if (parser1 == null)
            {
                throw new ArgumentNullException(nameof(parser1));
            }
            if (parser2 == null)
            {
                throw new ArgumentNullException(nameof(parser2));
            }
            if (parser3 == null)
            {
                throw new ArgumentNullException(nameof(parser3));
            }
            if (parser4 == null)
            {
                throw new ArgumentNullException(nameof(parser4));
            }
            if (parser5 == null)
            {
                throw new ArgumentNullException(nameof(parser5));
            }
            if (parser6 == null)
            {
                throw new ArgumentNullException(nameof(parser6));
            }
            if (parser7 == null)
            {
                throw new ArgumentNullException(nameof(parser7));
            }
            if (parser8 == null)
            {
                throw new ArgumentNullException(nameof(parser8));
            }

            return new Map8Parser<TToken, T1, T2, T3, T4, T5, T6, T7, T8, R>(func, parser1, parser2, parser3, parser4, parser5, parser6, parser7, parser8);
        }
    }
    internal abstract class MapParserBase<TToken, T> : Parser<TToken, T>
    {
        internal new abstract MapParserBase<TToken, U> Map<U>(Func<T, U> func);
    }
    
    internal sealed class Map1Parser<TToken, T1, R> : MapParserBase<TToken, R>
    {
        private readonly Func<T1, R> _func;
        private readonly Parser<TToken, T1> _p1;

        public Map1Parser(
            Func<T1, R> func,
            Parser<TToken, T1> parser1
        )
        {
            _func = func;
            _p1 = parser1;
        }

        internal sealed override InternalResult<R> Parse(ref ParseState<TToken> state, ref ExpectedCollector<TToken> expecteds)
        {
            
            var result1 = _p1.Parse(ref state, ref expecteds);
            if (!result1.Success)
            {
                return InternalResult.Failure<R>();
            }

            return InternalResult.Success<R>(
                _func(
                    result1.Value
                )
            );
        }

        internal override MapParserBase<TToken, U> Map<U>(Func<R, U> func)
            => new Map1Parser<TToken, T1, U>(
                (x1) => func(_func(x1)),
                _p1
            );
    }

    internal sealed class Map2Parser<TToken, T1, T2, R> : MapParserBase<TToken, R>
    {
        private readonly Func<T1, T2, R> _func;
        private readonly Parser<TToken, T1> _p1;
        private readonly Parser<TToken, T2> _p2;

        public Map2Parser(
            Func<T1, T2, R> func,
            Parser<TToken, T1> parser1,
            Parser<TToken, T2> parser2
        )
        {
            _func = func;
            _p1 = parser1;
            _p2 = parser2;
        }

        internal sealed override InternalResult<R> Parse(ref ParseState<TToken> state, ref ExpectedCollector<TToken> expecteds)
        {
            
            var result1 = _p1.Parse(ref state, ref expecteds);
            if (!result1.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result2 = _p2.Parse(ref state, ref expecteds);
            if (!result2.Success)
            {
                return InternalResult.Failure<R>();
            }

            return InternalResult.Success<R>(
                _func(
                    result1.Value,
                    result2.Value
                )
            );
        }

        internal override MapParserBase<TToken, U> Map<U>(Func<R, U> func)
            => new Map2Parser<TToken, T1, T2, U>(
                (x1, x2) => func(_func(x1, x2)),
                _p1,
                _p2
            );
    }

    internal sealed class Map3Parser<TToken, T1, T2, T3, R> : MapParserBase<TToken, R>
    {
        private readonly Func<T1, T2, T3, R> _func;
        private readonly Parser<TToken, T1> _p1;
        private readonly Parser<TToken, T2> _p2;
        private readonly Parser<TToken, T3> _p3;

        public Map3Parser(
            Func<T1, T2, T3, R> func,
            Parser<TToken, T1> parser1,
            Parser<TToken, T2> parser2,
            Parser<TToken, T3> parser3
        )
        {
            _func = func;
            _p1 = parser1;
            _p2 = parser2;
            _p3 = parser3;
        }

        internal sealed override InternalResult<R> Parse(ref ParseState<TToken> state, ref ExpectedCollector<TToken> expecteds)
        {
            
            var result1 = _p1.Parse(ref state, ref expecteds);
            if (!result1.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result2 = _p2.Parse(ref state, ref expecteds);
            if (!result2.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result3 = _p3.Parse(ref state, ref expecteds);
            if (!result3.Success)
            {
                return InternalResult.Failure<R>();
            }

            return InternalResult.Success<R>(
                _func(
                    result1.Value,
                    result2.Value,
                    result3.Value
                )
            );
        }

        internal override MapParserBase<TToken, U> Map<U>(Func<R, U> func)
            => new Map3Parser<TToken, T1, T2, T3, U>(
                (x1, x2, x3) => func(_func(x1, x2, x3)),
                _p1,
                _p2,
                _p3
            );
    }

    internal sealed class Map4Parser<TToken, T1, T2, T3, T4, R> : MapParserBase<TToken, R>
    {
        private readonly Func<T1, T2, T3, T4, R> _func;
        private readonly Parser<TToken, T1> _p1;
        private readonly Parser<TToken, T2> _p2;
        private readonly Parser<TToken, T3> _p3;
        private readonly Parser<TToken, T4> _p4;

        public Map4Parser(
            Func<T1, T2, T3, T4, R> func,
            Parser<TToken, T1> parser1,
            Parser<TToken, T2> parser2,
            Parser<TToken, T3> parser3,
            Parser<TToken, T4> parser4
        )
        {
            _func = func;
            _p1 = parser1;
            _p2 = parser2;
            _p3 = parser3;
            _p4 = parser4;
        }

        internal sealed override InternalResult<R> Parse(ref ParseState<TToken> state, ref ExpectedCollector<TToken> expecteds)
        {
            
            var result1 = _p1.Parse(ref state, ref expecteds);
            if (!result1.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result2 = _p2.Parse(ref state, ref expecteds);
            if (!result2.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result3 = _p3.Parse(ref state, ref expecteds);
            if (!result3.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result4 = _p4.Parse(ref state, ref expecteds);
            if (!result4.Success)
            {
                return InternalResult.Failure<R>();
            }

            return InternalResult.Success<R>(
                _func(
                    result1.Value,
                    result2.Value,
                    result3.Value,
                    result4.Value
                )
            );
        }

        internal override MapParserBase<TToken, U> Map<U>(Func<R, U> func)
            => new Map4Parser<TToken, T1, T2, T3, T4, U>(
                (x1, x2, x3, x4) => func(_func(x1, x2, x3, x4)),
                _p1,
                _p2,
                _p3,
                _p4
            );
    }

    internal sealed class Map5Parser<TToken, T1, T2, T3, T4, T5, R> : MapParserBase<TToken, R>
    {
        private readonly Func<T1, T2, T3, T4, T5, R> _func;
        private readonly Parser<TToken, T1> _p1;
        private readonly Parser<TToken, T2> _p2;
        private readonly Parser<TToken, T3> _p3;
        private readonly Parser<TToken, T4> _p4;
        private readonly Parser<TToken, T5> _p5;

        public Map5Parser(
            Func<T1, T2, T3, T4, T5, R> func,
            Parser<TToken, T1> parser1,
            Parser<TToken, T2> parser2,
            Parser<TToken, T3> parser3,
            Parser<TToken, T4> parser4,
            Parser<TToken, T5> parser5
        )
        {
            _func = func;
            _p1 = parser1;
            _p2 = parser2;
            _p3 = parser3;
            _p4 = parser4;
            _p5 = parser5;
        }

        internal sealed override InternalResult<R> Parse(ref ParseState<TToken> state, ref ExpectedCollector<TToken> expecteds)
        {
            
            var result1 = _p1.Parse(ref state, ref expecteds);
            if (!result1.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result2 = _p2.Parse(ref state, ref expecteds);
            if (!result2.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result3 = _p3.Parse(ref state, ref expecteds);
            if (!result3.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result4 = _p4.Parse(ref state, ref expecteds);
            if (!result4.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result5 = _p5.Parse(ref state, ref expecteds);
            if (!result5.Success)
            {
                return InternalResult.Failure<R>();
            }

            return InternalResult.Success<R>(
                _func(
                    result1.Value,
                    result2.Value,
                    result3.Value,
                    result4.Value,
                    result5.Value
                )
            );
        }

        internal override MapParserBase<TToken, U> Map<U>(Func<R, U> func)
            => new Map5Parser<TToken, T1, T2, T3, T4, T5, U>(
                (x1, x2, x3, x4, x5) => func(_func(x1, x2, x3, x4, x5)),
                _p1,
                _p2,
                _p3,
                _p4,
                _p5
            );
    }

    internal sealed class Map6Parser<TToken, T1, T2, T3, T4, T5, T6, R> : MapParserBase<TToken, R>
    {
        private readonly Func<T1, T2, T3, T4, T5, T6, R> _func;
        private readonly Parser<TToken, T1> _p1;
        private readonly Parser<TToken, T2> _p2;
        private readonly Parser<TToken, T3> _p3;
        private readonly Parser<TToken, T4> _p4;
        private readonly Parser<TToken, T5> _p5;
        private readonly Parser<TToken, T6> _p6;

        public Map6Parser(
            Func<T1, T2, T3, T4, T5, T6, R> func,
            Parser<TToken, T1> parser1,
            Parser<TToken, T2> parser2,
            Parser<TToken, T3> parser3,
            Parser<TToken, T4> parser4,
            Parser<TToken, T5> parser5,
            Parser<TToken, T6> parser6
        )
        {
            _func = func;
            _p1 = parser1;
            _p2 = parser2;
            _p3 = parser3;
            _p4 = parser4;
            _p5 = parser5;
            _p6 = parser6;
        }

        internal sealed override InternalResult<R> Parse(ref ParseState<TToken> state, ref ExpectedCollector<TToken> expecteds)
        {
            
            var result1 = _p1.Parse(ref state, ref expecteds);
            if (!result1.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result2 = _p2.Parse(ref state, ref expecteds);
            if (!result2.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result3 = _p3.Parse(ref state, ref expecteds);
            if (!result3.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result4 = _p4.Parse(ref state, ref expecteds);
            if (!result4.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result5 = _p5.Parse(ref state, ref expecteds);
            if (!result5.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result6 = _p6.Parse(ref state, ref expecteds);
            if (!result6.Success)
            {
                return InternalResult.Failure<R>();
            }

            return InternalResult.Success<R>(
                _func(
                    result1.Value,
                    result2.Value,
                    result3.Value,
                    result4.Value,
                    result5.Value,
                    result6.Value
                )
            );
        }

        internal override MapParserBase<TToken, U> Map<U>(Func<R, U> func)
            => new Map6Parser<TToken, T1, T2, T3, T4, T5, T6, U>(
                (x1, x2, x3, x4, x5, x6) => func(_func(x1, x2, x3, x4, x5, x6)),
                _p1,
                _p2,
                _p3,
                _p4,
                _p5,
                _p6
            );
    }

    internal sealed class Map7Parser<TToken, T1, T2, T3, T4, T5, T6, T7, R> : MapParserBase<TToken, R>
    {
        private readonly Func<T1, T2, T3, T4, T5, T6, T7, R> _func;
        private readonly Parser<TToken, T1> _p1;
        private readonly Parser<TToken, T2> _p2;
        private readonly Parser<TToken, T3> _p3;
        private readonly Parser<TToken, T4> _p4;
        private readonly Parser<TToken, T5> _p5;
        private readonly Parser<TToken, T6> _p6;
        private readonly Parser<TToken, T7> _p7;

        public Map7Parser(
            Func<T1, T2, T3, T4, T5, T6, T7, R> func,
            Parser<TToken, T1> parser1,
            Parser<TToken, T2> parser2,
            Parser<TToken, T3> parser3,
            Parser<TToken, T4> parser4,
            Parser<TToken, T5> parser5,
            Parser<TToken, T6> parser6,
            Parser<TToken, T7> parser7
        )
        {
            _func = func;
            _p1 = parser1;
            _p2 = parser2;
            _p3 = parser3;
            _p4 = parser4;
            _p5 = parser5;
            _p6 = parser6;
            _p7 = parser7;
        }

        internal sealed override InternalResult<R> Parse(ref ParseState<TToken> state, ref ExpectedCollector<TToken> expecteds)
        {
            
            var result1 = _p1.Parse(ref state, ref expecteds);
            if (!result1.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result2 = _p2.Parse(ref state, ref expecteds);
            if (!result2.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result3 = _p3.Parse(ref state, ref expecteds);
            if (!result3.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result4 = _p4.Parse(ref state, ref expecteds);
            if (!result4.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result5 = _p5.Parse(ref state, ref expecteds);
            if (!result5.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result6 = _p6.Parse(ref state, ref expecteds);
            if (!result6.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result7 = _p7.Parse(ref state, ref expecteds);
            if (!result7.Success)
            {
                return InternalResult.Failure<R>();
            }

            return InternalResult.Success<R>(
                _func(
                    result1.Value,
                    result2.Value,
                    result3.Value,
                    result4.Value,
                    result5.Value,
                    result6.Value,
                    result7.Value
                )
            );
        }

        internal override MapParserBase<TToken, U> Map<U>(Func<R, U> func)
            => new Map7Parser<TToken, T1, T2, T3, T4, T5, T6, T7, U>(
                (x1, x2, x3, x4, x5, x6, x7) => func(_func(x1, x2, x3, x4, x5, x6, x7)),
                _p1,
                _p2,
                _p3,
                _p4,
                _p5,
                _p6,
                _p7
            );
    }

    internal sealed class Map8Parser<TToken, T1, T2, T3, T4, T5, T6, T7, T8, R> : MapParserBase<TToken, R>
    {
        private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, R> _func;
        private readonly Parser<TToken, T1> _p1;
        private readonly Parser<TToken, T2> _p2;
        private readonly Parser<TToken, T3> _p3;
        private readonly Parser<TToken, T4> _p4;
        private readonly Parser<TToken, T5> _p5;
        private readonly Parser<TToken, T6> _p6;
        private readonly Parser<TToken, T7> _p7;
        private readonly Parser<TToken, T8> _p8;

        public Map8Parser(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, R> func,
            Parser<TToken, T1> parser1,
            Parser<TToken, T2> parser2,
            Parser<TToken, T3> parser3,
            Parser<TToken, T4> parser4,
            Parser<TToken, T5> parser5,
            Parser<TToken, T6> parser6,
            Parser<TToken, T7> parser7,
            Parser<TToken, T8> parser8
        )
        {
            _func = func;
            _p1 = parser1;
            _p2 = parser2;
            _p3 = parser3;
            _p4 = parser4;
            _p5 = parser5;
            _p6 = parser6;
            _p7 = parser7;
            _p8 = parser8;
        }

        internal sealed override InternalResult<R> Parse(ref ParseState<TToken> state, ref ExpectedCollector<TToken> expecteds)
        {
            
            var result1 = _p1.Parse(ref state, ref expecteds);
            if (!result1.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result2 = _p2.Parse(ref state, ref expecteds);
            if (!result2.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result3 = _p3.Parse(ref state, ref expecteds);
            if (!result3.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result4 = _p4.Parse(ref state, ref expecteds);
            if (!result4.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result5 = _p5.Parse(ref state, ref expecteds);
            if (!result5.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result6 = _p6.Parse(ref state, ref expecteds);
            if (!result6.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result7 = _p7.Parse(ref state, ref expecteds);
            if (!result7.Success)
            {
                return InternalResult.Failure<R>();
            }

            var result8 = _p8.Parse(ref state, ref expecteds);
            if (!result8.Success)
            {
                return InternalResult.Failure<R>();
            }

            return InternalResult.Success<R>(
                _func(
                    result1.Value,
                    result2.Value,
                    result3.Value,
                    result4.Value,
                    result5.Value,
                    result6.Value,
                    result7.Value,
                    result8.Value
                )
            );
        }

        internal override MapParserBase<TToken, U> Map<U>(Func<R, U> func)
            => new Map8Parser<TToken, T1, T2, T3, T4, T5, T6, T7, T8, U>(
                (x1, x2, x3, x4, x5, x6, x7, x8) => func(_func(x1, x2, x3, x4, x5, x6, x7, x8)),
                _p1,
                _p2,
                _p3,
                _p4,
                _p5,
                _p6,
                _p7,
                _p8
            );
    }
}
#endregion
