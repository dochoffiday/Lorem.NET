using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LoremNET
{
    /// <summary>
    /// Class to generate random values of various types.
    /// </summary>
    public class Lorem
    {
        /// <summary>
        /// Returns true <paramref name="successes"/> times out of <paramref name="attempts"/>.
        /// </summary>
        /// <param name="successes">The number of successes per <paramref name="attempts"/>.</param>
        /// <param name="attempts">The attempts.</param>
        /// <returns><c>true</c> on success, otherwise <c>false</c></returns>
        public static bool Chance(int successes, int attempts)
        {
            var number = Number(1, attempts);

            return number <= successes;
        }

        /// <summary>
        /// Creates a random DateTime between the given date and now.
        /// </summary>
        /// <param name="startYear">The minimum year.</param>
        /// <param name="startMonth">The minimum month.</param>
        /// <param name="startDay">The minimum day.</param>
        /// <returns>A DateTime</returns>
        public static DateTime DateTime(int startYear = 1950, int startMonth = 1, int startDay = 1)
        {
            return DateTime(new DateTime(startYear, startMonth, startDay), System.DateTime.Now);
        }

        /// <summary>
        /// Creates a random DateTime between the given date and now.
        /// </summary>
        /// <param name="min">The minimum date.</param>
        /// <returns>A DateTime</returns>
        public static DateTime DateTime(DateTime min)
        {
            return DateTime(min, System.DateTime.Now);
        }

        /// <summary>
        /// Creates a random DateTime between the given minimum and maximum dates.
        /// </summary>
        /// <param name="min">The minimum date.</param>
        /// <param name="max">The maximum date.</param>
        /// <returns>A DateTime</returns>
        /// <remarks>From http://stackoverflow.com/a/1483677/234132 </remarks>
        public static DateTime DateTime(DateTime min, DateTime max)
        {
            TimeSpan timeSpan = max - min;
            TimeSpan newSpan = new TimeSpan(0, RandomHelper.Instance.Next(0, (int)timeSpan.TotalMinutes), 0);

            return min + newSpan;
        }

        /// <summary>
        /// Creates a random email address of the type random1@random2.com
        /// </summary>
        /// <returns>A random email address</returns>
        public static string Email()
        {
            return $"{Words(1, false)}@{Words(1, false)}.com";
        }

        /// <summary>
        /// Creates a random item from the given enum.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <returns>A random <typeparamref name="TEnum"/></returns>
        /// <exception cref="ArgumentException">Generic type must be an enum.</exception>
        public static TEnum Enum<TEnum>() where TEnum : struct, IConvertible
        {
#if PCL
            if (typeof(TEnum).IsEnum)
            {
                var v = System.Enum.GetValues(typeof(TEnum));
                return (TEnum)v.GetValue(RandomHelper.Instance.Next(v.Length));
            }
#else
            if (typeof(TEnum).GetTypeInfo().IsEnum)
            {
                var v = System.Enum.GetValues(typeof(TEnum));
                return (TEnum)v.GetValue(RandomHelper.Instance.Next(v.Length));
            }
#endif
            throw new ArgumentException("Generic type must be an enum.");
        }

        /// <summary>
        /// Creates a random hexidecimal number in string format
        /// </summary>
        /// <param name="digits">The number of digits required.</param>
        /// <returns>A string created using the 'X' format string</returns>
        /// <remarks>From http://stackoverflow.com/a/1054087/234132 </remarks>
        public static string HexNumber(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            RandomHelper.Instance.NextBytes(buffer);
            string result = string.Concat(buffer.Select(x => x.ToString("X2")).ToArray());

            if (digits % 2 == 0)
            {
                return result;
            }

            return result + RandomHelper.Instance.Next(16).ToString("X");
        }

        /// <summary>
        /// Creates a random lowercase letter.
        /// </summary>
        /// <returns>A random character between 'a' and 'z' (inclusive)</returns>
        public static char Letter()
        {
            var charNumber = RandomHelper.Instance.Next(0, 26);
            return (char)('a' + charNumber);
        }

        /// <summary>
        /// Creates a random number between min and max
        /// </summary>
        /// <param name="min">The minimum number.</param>
        /// <param name="max">The maximum number.</param>
        /// <returns>A long integer</returns>
        /// <remarks>From http://stackoverflow.com/a/6651661/234132 </remarks>
        public static long Number(long min, long max)
        {
            byte[] buf = new byte[8];
            RandomHelper.Instance.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % ((max + 1) - min)) + min);
        }

        /// <summary>
        /// Creates a random paragraph with <paramref name="sentenceCount"/> sentences and <paramref name="wordCount"/> words per sentence.
        /// </summary>
        /// <param name="wordCount">The number of words per sentence.</param>
        /// <param name="sentenceCount">The number of sentences.</param>
        /// <returns>A string containing the generated paragraph</returns>
        public static string Paragraph(int wordCount, int sentenceCount)
        {
            return Paragraph(wordCount, wordCount, sentenceCount, sentenceCount);
        }

        /// <summary>
        /// Creates a random paragraph with <paramref name="sentenceCount"/> sentences and between <paramref name="wordCountMin" /> and <paramref name="wordCountMax" /> words per sentence.
        /// </summary>
        /// <param name="wordCountMin">The minimum number of words per sentence.</param>
        /// <param name="wordCountMax">The maximum number of words per sentence.</param>
        /// <param name="sentenceCount">The number of sentences.</param>
        /// <returns>A string containing the generated paragraph</returns>
        public static string Paragraph(int wordCountMin, int wordCountMax, int sentenceCount)
        {
            return Paragraph(wordCountMin, wordCountMax, sentenceCount, sentenceCount);
        }

        /// <summary>
        /// Creates a random paragraph with between <paramref name="sentenceCountMin" /> and <paramref name="sentenceCountMax" /> sentences and between <paramref name="wordCountMin" /> and <paramref name="wordCountMax" /> words per sentence.
        /// </summary>
        /// <param name="wordCountMin">The minimum number of words per sentence.</param>
        /// <param name="wordCountMax">The maximum number of words per sentence.</param>
        /// <param name="sentenceCountMin">The minimum number of sentences.</param>
        /// <param name="sentenceCountMax">The maximum number of sentences.</param>
        /// <returns>A string containing the generated paragraph</returns>
        public static string Paragraph(int wordCountMin, int wordCountMax, int sentenceCountMin, int sentenceCountMax)
        {
            var source = string.Join(" ", Enumerable.Range(0, RandomHelper.Instance.Next(sentenceCountMin, sentenceCountMax)).Select(x => Sentence(wordCountMin, wordCountMax)));

            //remove traililng space
            return source.Trim();
        }

        /// <summary>
        /// Creates <paramref name="paragraphCount"/> paragraphs with <paramref name="sentenceCount"/> sentences and <paramref name="wordCount"/> words per sentence.
        /// </summary>
        /// <param name="paragraphCount">The number of paragraphcs</param>
        /// <param name="wordCount">The number of words per sentence.</param>
        /// <param name="sentenceCount">The number of sentences.</param>
        /// <returns>An IEnumerable containing the generated paragraphs</returns>
        public static IEnumerable<string> Paragraphs(int wordCount, int sentenceCount, int paragraphCount)
        {
            return Paragraphs(wordCount, wordCount, sentenceCount, sentenceCount, paragraphCount, paragraphCount);
        }

        /// <summary>
        /// Creates <paramref name="paragraphCount"/> paragraphs with <paramref name="sentenceCount"/> sentences and between <paramref name="wordCountMin" /> and <paramref name="wordCountMax" /> words per sentence.
        /// </summary>
        /// <param name="wordCountMin">The minimum number of words per sentence.</param>
        /// <param name="wordCountMax">The maximum number of words per sentence.</param>
        /// <param name="sentenceCount">The number of sentences.</param>
        /// <param name="paragraphCount">The paragraph count.</param>
        /// <returns>An IEnumerable containing the generated paragraphs</returns>
        public static IEnumerable<string> Paragraphs(int wordCountMin, int wordCountMax, int sentenceCount, int paragraphCount)
        {
            return Paragraphs(wordCountMin, wordCountMax, sentenceCount, sentenceCount, paragraphCount, paragraphCount);
        }

        /// <summary>
        /// Creates <paramref name="paragraphCount"/> paragraphs with between <paramref name="sentenceCountMin" /> and <paramref name="sentenceCountMax" /> sentences and between <paramref name="wordCountMin" /> and <paramref name="wordCountMax" /> words per sentence.
        /// </summary>
        /// <param name="wordCountMin">The minimum number of words per sentence.</param>
        /// <param name="wordCountMax">The maximum number of words per sentence.</param>
        /// <param name="sentenceCountMin">The minimum number of sentences.</param>
        /// <param name="sentenceCountMax">The maximum number of sentences.</param>
        /// <param name="paragraphCount">The paragraph count.</param>
        /// <returns>An IEnumerable containing the generated paragraphs</returns>
        public static IEnumerable<string> Paragraphs(int wordCountMin, int wordCountMax, int sentenceCountMin, int sentenceCountMax, int paragraphCount)
        {
            return Paragraphs(wordCountMin, wordCountMax, sentenceCountMin, sentenceCountMax, paragraphCount, paragraphCount);
        }

        /// <summary>
        /// Creates between <paramref name="paragraphCountMin"/> and <paramref name="paragraphCountMin"/> paragraphs with between <paramref name="sentenceCountMin" /> and <paramref name="sentenceCountMax" /> sentences and between <paramref name="wordCountMin" /> and <paramref name="wordCountMax" /> words per sentence.
        /// </summary>
        /// <param name="wordCountMin">The minimum number of words per sentence.</param>
        /// <param name="wordCountMax">The maximum number of words per sentence.</param>
        /// <param name="sentenceCountMin">The minimum number of sentences.</param>
        /// <param name="sentenceCountMax">The maximum number of sentences.</param>
        /// <param name="paragraphCountMin">The minimum number of paragraphs.</param>
        /// <param name="paragraphCountMax">The maximum number of paragraphs.</param>
        /// <returns>An IEnumerable containing the generated paragraphs</returns>
        public static IEnumerable<string> Paragraphs(int wordCountMin, int wordCountMax, int sentenceCountMin, int sentenceCountMax, int paragraphCountMin, int paragraphCountMax)
        {
            return Enumerable.Range(0, RandomHelper.Instance.Next(paragraphCountMin, paragraphCountMax)).Select(p => Paragraph(wordCountMin, wordCountMax, sentenceCountMin, sentenceCountMax)).ToArray();
        }

        /// <summary>
        /// Picks a random item from the provided array
        /// </summary>
        /// <typeparam name="T">The type of the item.</typeparam>
        /// <param name="items">The items to pick from.</param>
        /// <returns>A random element from <paramref name="items"/></returns>
        public static T Random<T>(T[] items)
        {
            var index = RandomHelper.Instance.Next(items.Length);

            return items[index];
        }

        /// <summary>
        /// Creates a random sentence with <paramref name="wordCount"/> words.
        /// </summary>
        /// <param name="wordCount">The word count for the sentence.</param>
        /// <returns>A string containing the generated sentence</returns>
        public static string Sentence(int wordCount)
        {
            return Sentence(wordCount, wordCount);
        }

        /// <summary>
        /// Creates a random sentence with between <paramref name="wordCountMin"/> and <paramref name="wordCountMax" /> words.
        /// </summary>
        /// <param name="wordCountMin">The minimum word count for the sentence.</param>
        /// <param name="wordCountMax">The maximum word count for the sentence.</param>
        /// <returns>A string containing the generated words</returns>
        public static string Sentence(int wordCountMin, int wordCountMax)
        {
            return $"{Words(wordCountMin, wordCountMax, true, true)}.".Replace(",.", ".").Remove("..");
        }

        /// <summary>
        /// Creates a string containing <paramref name="wordCount"/> words.
        /// </summary>
        /// <param name="wordCount">The number of words to generate.</param>
        /// <param name="uppercaseFirstLetter">if set to <c>true</c>, capitalises the first letter.</param>
        /// <param name="includePunctuation">if set to <c>true</c>, includes punctuation in the string.</param>
        /// <returns>A string containing the generated words</returns>
        public static string Words(int wordCount, bool uppercaseFirstLetter = true, bool includePunctuation = false)
        {
            return Words(wordCount, wordCount, uppercaseFirstLetter, includePunctuation);
        }

        /// <summary>
        /// Creates a string containing between <paramref name="wordCountMin"/> and <paramref name="wordCountMax"/> words.
        /// </summary>
        /// <param name="wordCountMin">The minimum number of words.</param>
        /// <param name="wordCountMax">The maximum number of words.</param>
        /// <param name="uppercaseFirstLetter">if set to <c>true</c> capitalises the first letter.</param>
        /// <param name="includePunctuation">if set to <c>true</c> includes punctuation in the string.</param>
        /// <returns></returns>
        public static string Words(int wordCountMin, int wordCountMax, bool uppercaseFirstLetter = true, bool includePunctuation = false)
        {
            var source = string.Join(" ", Source.WordList(includePunctuation).Take(RandomHelper.Instance.Next(wordCountMin, wordCountMax)));

            if (uppercaseFirstLetter)
            {
                source = source.UppercaseFirst();
            }

            return source;
        }
    }
}