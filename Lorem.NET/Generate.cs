using System;
using System.Collections.Generic;
using System.Linq;

namespace LoremNET
{
    public static class Generate
    {
        public static bool Chance(int successes, int attempts)
        {
            var number = Number(1, attempts);

            return number <= successes;
        }

        public static T Random<T>(T[] items)
        {
            var index = RandomHelper.Instance.Next(items.Length);

            return items[index];
        }

        public static TEnum Enum<TEnum>() where TEnum : struct, IConvertible
        {
            if (typeof(TEnum).IsEnum)
            {
                var v = System.Enum.GetValues(typeof(TEnum));
                return (TEnum)v.GetValue(RandomHelper.Instance.Next(v.Length));
            }
            else
            {
                throw new ArgumentException("Generic type must be an enum.");
            }
        }

        /* http://stackoverflow.com/a/6651661/234132 */
        public static long Number(long min, long max)
        {
            byte[] buf = new byte[8];
            RandomHelper.Instance.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % ((max + 1) - min)) + min);
        }

        #region DateTime

        public static DateTime DateTime(int startYear = 1950, int startMonth = 1, int startDay = 1)
        {
            return DateTime(new System.DateTime(startYear, startMonth, startDay), System.DateTime.Now);
        }

        public static DateTime DateTime(DateTime min)
        {
            return DateTime(min, System.DateTime.Now);
        }

        /* http://stackoverflow.com/a/1483677/234132 */
        public static DateTime DateTime(DateTime min, DateTime max)
        {
            TimeSpan timeSpan = max - min;
            TimeSpan newSpan = new TimeSpan(0, RandomHelper.Instance.Next(0, (int)timeSpan.TotalMinutes), 0);

            return min + newSpan;
        }

        #endregion

        #region Text

        public static string Email()
        {
            return string.Format("{0}@{1}.com", Generate.Words(1, false), Generate.Words(1, false));
        }

        public static string Words(int wordCount, bool uppercaseFirstLetter = true, bool includePunctuation = false)
        {
            return Words(wordCount, wordCount, uppercaseFirstLetter, includePunctuation);
        }

        public static string Words(int wordCountMin, int wordCountMax, bool uppercaseFirstLetter = true, bool includePunctuation = false)
        {
            var source = string.Join(" ", Source.WordList(includePunctuation).Take(RandomHelper.Instance.Next(wordCountMin, wordCountMax)));

            if (uppercaseFirstLetter)
            {
                source = source.UppercaseFirst();
            }

            return source;
        }

        public static string Sentence(int wordCount)
        {
            return Sentence(wordCount, wordCount);
        }

        public static string Sentence(int wordCountMin, int wordCountMax)
        {
            return string.Format("{0}.", Words(wordCountMin, wordCountMax, true, true)).Replace(",.", ".").Remove("..");
        }

        public static string Paragraph(int wordCount, int sentenceCount)
        {
            return Paragraph(wordCount, wordCount, sentenceCount, sentenceCount);
        }

        public static string Paragraph(int wordCountMin, int wordCountMax, int sentenceCount)
        {
            return Paragraph(wordCountMin, wordCountMax, sentenceCount, sentenceCount);
        }

        public static string Paragraph(int wordCountMin, int wordCountMax, int sentenceCountMin, int sentenceCountMax)
        {
            var source = string.Join(" ", Enumerable.Range(0, RandomHelper.Instance.Next(sentenceCountMin, sentenceCountMax)).Select(x => Sentence(wordCountMin, wordCountMax)));

            //remove traililng space
            return source.Remove(source.Length - 1);
        }

        public static IEnumerable<string> Paragraphs(int wordCount, int sentenceCount, int paragraphCount)
        {
            return Paragraphs(wordCount, wordCount, sentenceCount, sentenceCount, paragraphCount, paragraphCount);
        }

        public static IEnumerable<string> Paragraphs(int wordCountMin, int wordCountMax, int sentenceCount, int paragraphCount)
        {
            return Paragraphs(wordCountMin, wordCountMax, sentenceCount, sentenceCount, paragraphCount, paragraphCount);
        }

        public static IEnumerable<string> Paragraphs(int wordCountMin, int wordCountMax, int sentenceCountMin, int sentenceCountMax, int paragraphCount)
        {
            return Paragraphs(wordCountMin, wordCountMax, sentenceCountMin, sentenceCountMax, paragraphCount, paragraphCount);
        }

        public static IEnumerable<string> Paragraphs(int wordCountMin, int wordCountMax, int sentenceCountMin, int sentenceCountMax, int paragraphCountMin, int paragraphCountMax)
        {
            return Enumerable.Range(0, RandomHelper.Instance.Next(paragraphCountMin, paragraphCountMax)).Select(p => Paragraph(wordCountMin, wordCountMax, sentenceCountMin, sentenceCountMax)).ToArray();
        }

        #endregion

        #region Color

        /* http://stackoverflow.com/a/1054087/234132 */
        public static string HexNumber(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            RandomHelper.Instance.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());

            if (digits % 2 == 0)
            {
                return result;
            }

            return result + RandomHelper.Instance.Next(16).ToString("X");
        }

        #endregion
    }
}