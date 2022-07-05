using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace GD.Extensions
{
    public static class StringExt
    {
        public static Func<object[], object> BuildFunction(this string source, params Tuple<string, Type>[] paramters)
        {
            var pattern = @"{(?<body>[^}]*)}";
            var rgx = new Regex(pattern);
            var match = rgx.Match(source);
            if (!match.Success)
            {
                throw new InvalidDataException(source);
            }
 
            var prs = new List<ParameterExpression>();
            foreach (var a in paramters)
            {
                prs.Add(Expression.Parameter(a.Item2, a.Item1));
            }
            var e = DynamicExpressionParser.ParseLambda(prs.ToArray(), null, match.Groups["body"].Value);
            var d = e.Compile();
            return (r) => d.DynamicInvoke(r);
        }

        public static Func<object[], string> BuildInterpolator(this string source, params Tuple<string, Type>[] paramters)
        {
            List<Func<object[], string>> producer = new List<Func<object[], string>>();
            var pattern = @"(?<var>{(?<body>[^}]*)})|(?<literal>(?:\\.|{{|}}|[^\\{}])*)";
            var rgx = new Regex(pattern);
            var matches = rgx.Matches(source);
 
            foreach (Match m in matches)
            {
                if (m.Groups["literal"].Success)
                {
                    var text = m.Value;
                    producer.Add((_) => text);
                }
                else
                {
                    var prs = new List<ParameterExpression>();
                    foreach (var a in paramters)
                    {
                        prs.Add(Expression.Parameter(a.Item2, a.Item1));
                    }
                    var e = DynamicExpressionParser.ParseLambda(prs.ToArray(), null, m.Groups["body"].Value);
                    var d = e.Compile();
                    producer.Add((r) => d.DynamicInvoke(r)?.ToString());
                }
            }
            string func(object[] r) => string.Join("", producer.Select(f => f(r)));
            return func;
        }
    }
}