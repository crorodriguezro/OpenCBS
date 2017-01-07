using System;
using System.Collections.Generic;

namespace OpenCBS.Extension.Accounting.View.UserControl
{
    /// <summary>
    /// Possible ways of matching methods
    /// </summary>
    public enum StringMatchingMethod
    {
        NoWildcards
    }

    /// <summary>
    /// Allows to decompose a strings against a pattern
    /// </summary>
    public class StringMatcher
    {
        #region fields
        public delegate StringMatch MatchDelegate(string source);
        private readonly object m_pattern;
        #endregion

        /// <summary>
        /// Match against a string
        /// </summary>
        public MatchDelegate Match { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public StringMatcher(StringMatchingMethod method, string pattern)
        {
            switch (method)
            {
                case StringMatchingMethod.NoWildcards:
                    m_pattern = prepareNoWildcard(pattern);
                    Match = buildNoWildcard;
                    break;
                default:
                    throw new ArgumentException("Unknown StringMatchingMethod value");
            }
        }

        #region No wildcards
        /// <summary>
        /// Prepare the pattern for a "non wildcard" match
        /// </summary>
        private static object prepareNoWildcard(string pattern)
        {
            return pattern.ToLower();
        }

        /// <summary>
        /// Compare the source against the pattern and if successfull returns a StringMatch
        /// 
        /// There is a match if source contains all the characters of pattern in the right order
        /// but not consecutively
        /// </summary>
        private StringMatch buildNoWildcard(string source)
        {
            string pattern = (string)m_pattern;
            string lsource = source.ToLower();

            List<string> segments = new List<string>();
            int i = 0, j;
            int NP = pattern.Length, NS = source.Length;
            bool startsOnMatch = false, isMatch = false;
            for (j = 0; j < NP; j++)
            {
                int s = i;
                // skip characters until we have a match
                for (; i < NS; i++)
                {
                    if (lsource[i] == pattern[j])
                    {
                        isMatch = (j == NP - 1);
                        if (s != i)
                        {
                            segments.Add(source.Substring(s, i - s));
                            segments.Add(source.Substring(i, 1));
                        }
                        else
                        {
                            if (segments.Count == 0)
                            {
                                segments.Add(source.Substring(i, 1));
                                startsOnMatch = true;
                            }
                            else
                            {
                                segments[segments.Count - 1] += source[i];
                            }
                        }
                        i++;
                        break; // i loop
                    }
                }
                if (i >= NS)
                {
                    break; // j loop
                }
            }

            if (!isMatch)
            {
                return null;
            }
            if (i < NS)
            {
                segments.Add(source.Substring(i, NS - i));
            }
            return new StringMatch
            {
                Text = source,
                Segments = segments,
                StartsOnMatch = startsOnMatch,
            };
        }
        #endregion
    }

    /// <summary>
    /// The result of a match
    /// There are the items we store in the suggestion listbox
    /// </summary>
    public class StringMatch
    {
        /// <summary>
        /// The original source
        /// </summary>
        public string Text { get; internal set; }
        /// <summary>
        /// The source decomposed on match/non matches against the pattern
        /// </summary>
        public List<string> Segments { get; internal set; }
        /// <summary>
        /// Is the first segment a match?
        /// </summary>
        public bool StartsOnMatch { get; internal set; }
    }
}
