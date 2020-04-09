using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Msi.UtilityKit
{
    public static class StringUtilities
    {

        public static string RemoveSpecialChars(this string value)
        {
            var newValue = value;
            //Checks for last character is special charact
            var regexItem = new Regex("[^a-zA-Z0-9_.]+");
            //remove last character if its special
            if (regexItem.IsMatch(value[value.Length - 1].ToString()))
            {
                newValue = value.Remove(value.Length - 1);
            }
            string replaceStr = Regex.Replace(newValue, "[^a-zA-Z0-9_]+", "_");

            return replaceStr;

        }

        public static string ToUpperFirstLetter(this string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        public static string Replace(this string str, char item, Func<char> character)
        {
            StringBuilder builder = new StringBuilder(str.Length);

            foreach (char c in str.ToCharArray())
            {
                builder.Append(c == item ? character() : c);
            }

            return builder.ToString();
        }

        public static string Numerify(this string numberString)
        {
            return numberString.Replace('#', () => new Random().Next(10).ToString().ToCharArray()[0]);
        }

        public static string Letterify(this string letterString)
        {
            return letterString.Replace('?', () => 'a'.To('z').Rand());
        }

        public static string Bothify(this string str)
        {
            return Letterify(Numerify(str));
        }

        public static IEnumerable<char> To(this char from, char to)
        {
            for (char i = from; i <= to; i++)
            {
                yield return i;
            }
        }

        public static string ToLowerAndAppend(this string str, string appendBeforeCapitalLetter = ".")
        {
            StringBuilder builder = new StringBuilder(str.Length);
            bool isFirstLetter = true;
            foreach (var c in str)
            {
                if(char.IsUpper(c))
                {
                    if(!isFirstLetter)
                    {
                        builder.Append(appendBeforeCapitalLetter);
                    }
                    builder.Append(char.ToLower(c));
                }
                else
                {
                    builder.Append(c);
                }
                isFirstLetter = false;
            }
            return builder.ToString();
        }

        public static bool IsHexDigit(this char character)
        {
            return ((character >= '0') && (character <= '9'))
                || ((character >= 'A') && (character <= 'F'))
                || ((character >= 'a') && (character <= 'f'));
        }

        /// <summary>
        /// Converts a string to a bool.  We consider "true/false", "on/off", and 
        /// "yes/no" to be valid boolean representations in the XML.
        /// </summary>
        /// <param name="parameterValue">The string to convert.</param>
        /// <returns>Boolean true or false, corresponding to the string.</returns>
        public static bool ConvertStringToBool(string parameterValue)
        {
            if (IsValidBooleanTrue(parameterValue))
            {
                return true;
            }
            else if (IsValidBooleanFalse(parameterValue))
            {
                return false;
            }
            else
            {
                // Unsupported boolean representation.
                return false;
            }
        }

        /// <summary>
        /// Returns a hex representation of a byte array.
        /// </summary>
        /// <param name="bytes">The bytes to convert</param>
        /// <returns>A string byte types formated as X2.</returns>
        public static string ConvertByteArrayToHex(this byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.AppendFormat("{0:X2}", b);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns true if the string can be successfully converted to a bool,
        /// such as "on" or "yes"
        /// </summary>
        public static bool CanConvertStringToBool(this string parameterValue)
        {
            return (IsValidBooleanTrue(parameterValue) || IsValidBooleanFalse(parameterValue));
        }

        /// <summary>
        /// Returns true if the string represents a valid MSBuild boolean true value,
        /// such as "on", "!false", "yes"
        /// </summary>
        public static bool IsValidBooleanTrue(this string parameterValue)
        {
            return String.Equals(parameterValue, "true", StringComparison.OrdinalIgnoreCase) ||
                   String.Equals(parameterValue, "on", StringComparison.OrdinalIgnoreCase) ||
                   String.Equals(parameterValue, "yes", StringComparison.OrdinalIgnoreCase) ||
                   String.Equals(parameterValue, "!false", StringComparison.OrdinalIgnoreCase) ||
                   String.Equals(parameterValue, "!off", StringComparison.OrdinalIgnoreCase) ||
                   String.Equals(parameterValue, "!no", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Returns true if the string represents a valid MSBuild boolean false value,
        /// such as "!on" "off" "no" "!true"
        /// </summary>
        public static bool IsValidBooleanFalse(this string parameterValue)
        {
            return String.Equals(parameterValue, "false", StringComparison.OrdinalIgnoreCase) ||
                   String.Equals(parameterValue, "off", StringComparison.OrdinalIgnoreCase) ||
                   String.Equals(parameterValue, "no", StringComparison.OrdinalIgnoreCase) ||
                   String.Equals(parameterValue, "!true", StringComparison.OrdinalIgnoreCase) ||
                   String.Equals(parameterValue, "!on", StringComparison.OrdinalIgnoreCase) ||
                   String.Equals(parameterValue, "!yes", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Converts a string like "123.456" into a double. Leading sign is allowed.
        /// </summary>
        public static double ConvertDecimalToDouble(this string number)
        {
            return Double.Parse(number, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture.NumberFormat);
        }

        /// <summary>
        /// Converts a hex string like "0xABC" into a double.
        /// </summary>
        public static double ConvertHexToDouble(this string number)
        {
            return (double)Int32.Parse(number.Substring(2), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture.NumberFormat);
        }

        /// <summary>
        /// Converts a string like "123.456" or "0xABC" into a double.
        /// Tries decimal conversion first.
        /// </summary>
        public static double ConvertDecimalOrHexToDouble(this string number)
        {
            if (IsValidDecimalNumber(number))
            {
                return ConvertDecimalToDouble(number);
            }
            else if (IsValidHexNumber(number))
            {
                return ConvertHexToDouble(number);
            }
            else
            {
                return 0.0D;
            }
        }

        /// <summary>
        /// Returns true if the string is a valid hex number, like "0xABC"
        /// </summary>
        public static bool IsValidHexNumber(this string number)
        {
            bool canConvert = false;
            if (number.Length >= 3 && number[0] == '0' && (number[1] == 'x' || number[1] == 'X'))
            {
                int value;
                canConvert = Int32.TryParse(number.Substring(2), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture.NumberFormat, out value);
            }
            return canConvert;
        }

        /// <summary>
        /// Returns true if the string is a valid decimal number, like "-123.456"
        /// </summary>
        public static bool IsValidDecimalNumber(this string number)
        {
            double value;
            return Double.TryParse(number, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture.NumberFormat, out value);
        }

        /// <summary>
        /// Returns true if the string is a valid decimal or hex number
        /// </summary>
        public static bool IsValidDecimalOrHexNumber(this string number)
        {
            return IsValidDecimalNumber(number) || IsValidHexNumber(number);
        }

    }
}
