using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Skycop.Common.Extenstions
{
    public static class StringExtenstions
    {
        public static string StripCharacters(this string input, params char[] charactersToStrip)
        {
            string newPhoneNumber = string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                string temp = input;
                foreach (char character in charactersToStrip)
                {
                    temp = temp.Replace(character.ToString(), "");
                }
                newPhoneNumber = temp;
            }
            return newPhoneNumber;
        }

        public static string ToRelativeDateString(this DateTime? inputValue, bool approximate)
        {
            if (inputValue == null)
            {
                return string.Empty;
            }

            var value = (DateTime)inputValue;
            StringBuilder sb = new StringBuilder();
            string suffix = (value > DateTime.Now) ? " from now" : " ago";
            TimeSpan timeSpan = new TimeSpan(Math.Abs(DateTime.Now.Subtract(value).Ticks));

            if (timeSpan.Days > 365)
            {
                var year = Math.Abs(timeSpan.Days / 365);
                sb.AppendFormat("{0} {1}", year,
                  (year > 1) ? "years" : "year");
                if (approximate)
                    return sb.ToString() + suffix;
            }

            if (timeSpan.Days > 30)
            {
                var month = Math.Abs(timeSpan.Days / 30);
                sb.AppendFormat("{0} {1}", month,
                  (month > 1) ? "months" : "month");
                if (approximate)
                    return sb.ToString() + suffix;
            }

            if (timeSpan.Days > 0)
            {
                sb.AppendFormat("{0} {1}", timeSpan.Days,
                  (timeSpan.Days > 1) ? "days" : "day");
                if (approximate)
                    return sb.ToString() + suffix;
            }

            if (timeSpan.Hours > 0)
            {
                sb.AppendFormat("{0}{1} {2}", (sb.Length > 0) ? ", " : string.Empty,
                  timeSpan.Hours, (timeSpan.Hours > 1) ? "hours" : "hour");
                if (approximate)
                    return sb.ToString() + suffix;
            }

            if (timeSpan.Minutes > 0)
            {
                sb.AppendFormat("{0}{1} {2}", (sb.Length > 0) ? ", " : string.Empty,
                  timeSpan.Minutes, (timeSpan.Minutes > 1) ? "minutes" : "minute");
                if (approximate)
                    return sb.ToString() + suffix;
            }

            if (timeSpan.Seconds > 0)
            {
                sb.AppendFormat("{0}{1} {2}", (sb.Length > 0) ? ", " : string.Empty,
                  timeSpan.Seconds, (timeSpan.Seconds > 1) ? "seconds" : "second");
                if (approximate)
                    return sb.ToString() + suffix;
            }

            if (sb.Length == 0)
                return "right now";

            sb.Append(suffix);
            return sb.ToString();
        }

        public static string PostCharaters(this string str, int numberOfCharacters)
        {
            var returnVal = str;
            if (!string.IsNullOrEmpty(str) && str.Length > numberOfCharacters)
            {
                returnVal = str.Substring(numberOfCharacters);
            }
            return returnVal;
        }

        public static string PreCharaters(this string str, int numberOfCharacters)
        {
            var returnVal = str;
            if (!string.IsNullOrEmpty(str) && str.Length > numberOfCharacters)
            {
                returnVal = str.Substring(0, numberOfCharacters);
            }
            return returnVal;
        }

        public static string ToTitleCase(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return value;
            //title case normally ignores words in all caps, but value.ToLower() gets around that.
            return new CultureInfo("en-US", false).TextInfo.ToTitleCase(value.ToLower());
        }

        public static string Truncate(this string value, int toLength)
        {
            if (!string.IsNullOrEmpty(value) && value.Length > toLength)
            {
                return value.Substring(0, toLength);
            }
            else
            {
                return value;
            }
        }

        public static string Break(this string toBreak, int breakLength)
        {
            string toReturn = string.Empty;

            if (breakLength > 0 && !string.IsNullOrEmpty(toBreak))
            {
                string temp = toBreak;
                while (temp.Length > 0)
                {
                    if (temp.Length > breakLength)
                    {
                        toReturn += temp.Substring(0, breakLength) + "\r\n";
                        temp = temp.Substring(breakLength);
                    }
                    else
                    {
                        toReturn += temp;
                        temp = string.Empty;
                    }
                }
            }

            return toReturn;
        }

        public static string TrimSafe(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return value;
            return value.Trim();
        }

        public static string StripNonDigits(this string str)
        {
            if (String.IsNullOrEmpty(str))
                return str;

            return Regex.Replace(str, "[^0-9]", "");
        }

        public static string StripProtocolFromUrl(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                var index = str.IndexOf("://");
                if (index > 0)
                    str = str.Substring(index + 3);
            }
            return str;
        }

        public static string GetLastCharacters(this string str, int numberOfCharacters)
        {
            if (!string.IsNullOrEmpty(str) && numberOfCharacters < str.Length)
            {
                str = str.Substring(str.Length - numberOfCharacters);
            }
            return str;
        }

        public static string ToLowerCase(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return value;
            return value.ToLower();
        }

        public static int ToStringInt(this string value)
        {
            var returnValue = 0;
            if (!string.IsNullOrEmpty(value))
            {
                returnValue = Convert.ToInt32(value);
            }
            return returnValue;
        }

        public static int? ToNullableInt32(this string s)
        {
            int i;
            if (Int32.TryParse(s, out i))
                return i;
            return null;
        }

        public static bool ToStringBool(this string value)
        {
            var returnValue = false;
            if (!string.IsNullOrEmpty(value))
            {
                if ("True".Equals(value) || "true".Equals(value) || "1".Equals(value))
                    returnValue = true;
            }
            return returnValue;
        }

        public static int ToForceStringInt(this string value)
        {
            int returnValue = 0;
            if (!string.IsNullOrEmpty(value))
            {
                bool res = int.TryParse(value, out returnValue);
            }
            return returnValue;
        }

        public static string CaseInsensitiveComparableString(this string str)
        {
            if (string.IsNullOrEmpty(str)) { return string.Empty; }

            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString().ToLower();
        }
    }
}
