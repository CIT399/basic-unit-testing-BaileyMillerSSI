using System;
using System.Text;

namespace TelephoneLib
{
    public class Telephone
    {
        // These constant fields hold the valid lengths of
        // strings that are formatted and unformatted.
        public static int FORMATTED_LENGTH = 13;
        public static int UNFORMATTED_LENGTH = 10;

        /**
         * The isFormatted method accepts a string argument
         * and determines whether it is properly formatted as
         * a US telephone number in the following manner:
         * (XXX)XXX-XXXX
         * If the argument is properly formatted, the method
         * returns true, otherwise false.
         */

        public static bool isFormatted(String str)
        {
            try
            {
                bool valid;  // Flag to indicate valid format
                char[] charcaters = str.ToCharArray();
                // Determine whether str is properly formatted.
                if (str.Length == FORMATTED_LENGTH &&
                    charcaters.GetValue(0).Equals('(') &&
                    charcaters.GetValue(4).Equals(')') &&
                    charcaters.GetValue(8).Equals('-'))
                    valid = true;
                else
                    valid = false;
                // Return the value of the valid flag.
                return valid;

            }
            catch (Exception)
            {
                return false;
            }
        }

        /**
         * The unformat method accepts a string containing
         * a telephone number formatted as:
         * (XXX)XXX-XXXX.
         * If the argument is formatted in this way, the
         * method returns an unformatted string where the
         * parentheses and hyphen have been removed. Otherwise,
         * it returns the original argument.
         */

        public static String unformat(String str)
        {
            // Create a StringBuilder initialized with str.
            StringBuilder strb = new StringBuilder(str);

            // If the argument is properly formatted, then
            // unformat it.
            if (isFormatted(str))
            {
                // First, delete the left paren at position 0.
                strb.Remove(0, 1);

                // Next, delete the right paren. Because of the
                // previous deletion it is now located at
                // position 3.
                strb.Remove(3,1);

                // Next, delete the hyphen. Because of the
                // previous deletions it is now located at
                // position 6.
                strb.Remove(6, 1);
            }

            // Return the unformatted string.
            return strb.ToString();
        }

        /**
         * The format method formats a string as: 
         * (XXX)XXX-XXXX.
         * If the length of the argument is UNFORMATTED_LENGTH
         * the method returns the formatted string. Otherwise,
         * it returns the original argument.
         */

        public static String format(String str)
        {
            // Added this block to help meet Test Case 'HandlesNullValues'
            if (String.IsNullOrEmpty(str))
            {
                return null;
            }

            // Create a StringBuilder initialized with str.
            StringBuilder strb = new StringBuilder(str);

            // If the argument is the correct length, then
            // format it.
            if (str.Length == UNFORMATTED_LENGTH)
            {
                // First, insert the left parentat position 0.
                strb.Insert(0,"(");

                // Next, insert the right paren at position 4. 
                strb.Insert(4, ")");

                // Next, insert the hyphen at position 8.
                strb.Insert(8,"-");
            }

            // Return the formatted string.
            return strb.ToString();
        }
    }
}
