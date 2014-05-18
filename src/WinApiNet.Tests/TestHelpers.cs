namespace WinApiNet.Tests
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Implements global unit test-related helper methods.
    /// </summary>
    public static class TestHelpers
    {
        /// <summary>
        /// Creates a string which contains the values of all fields and properties of the specified object.
        /// </summary>
        /// <param name="obj">The object instance.</param>
        /// <returns>The created <see cref="string"/>.</returns>
        public static string ObjectToString(object obj)
        {
            if (obj == null)
            {
                return "null";
            }

            var sb = new StringBuilder();

            var fields = obj.GetType().GetFields();
            var properties = obj.GetType().GetProperties();

            // Get the length of the longest label.
            int maxLength = Math.Max(
                fields.Length > 0 ? fields.Max(x => x.Name.Length) : 0,
                properties.Length > 0 ? properties.Max(x => x.Name.Length) : 0);

            foreach (var fieldInfo in fields)
            {
                object value;
                try
                {
                    value = fieldInfo.GetValue(obj);
                }
                catch (Exception ex)
                {
                    value = ex.Message;
                }
                
                sb.AppendLine(fieldInfo.Name.PadRight(maxLength + 4) + value);
            }

            foreach (var propertyInfo in properties)
            {
                object value;
                try
                {
                    value = propertyInfo.GetValue(obj, new object[0]);
                }
                catch (Exception ex)
                {
                    value = ex.Message;
                }

                sb.AppendLine(propertyInfo.Name.PadRight(maxLength + 4) + value);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Creates a string which contains the values of the specified array.
        /// </summary>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <param name="result">The array instance.</param>
        /// <returns>The created <see cref="string"/>.</returns>
        public static string ArrayToString<T>(T[] result)
        {
            if (result == null)
            {
                return null;
            }

            return "[" + string.Join(", ", result) + "]";
        }
    }
}