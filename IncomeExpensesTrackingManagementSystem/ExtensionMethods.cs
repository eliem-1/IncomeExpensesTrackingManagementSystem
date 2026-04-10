using System;
using System.Windows.Forms;

namespace IncomeExpensesTrackingManagementSystem
{
    /// <summary>
    /// Extension methods for common utility operations.
    /// </summary>
    internal static class ExtensionMethods
    {
        /// <summary>
        /// Shows an error message dialog with standard formatting.
        /// </summary>
        /// <param name="parent">The parent form or control.</param>
        /// <param name="message">The error message to display.</param>
        public static void ShowError(this Form parent, string message)
        {
            MessageBox.Show(message, AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Shows an error message dialog with exception details.
        /// </summary>
        /// <param name="parent">The parent form or control.</param>
        /// <param name="exception">The exception to display.</param>
        public static void ShowError(this Form parent, Exception exception)
        {
            MessageBox.Show($"Error: {exception.Message}", AppConstants.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Shows a success message dialog.
        /// </summary>
        /// <param name="parent">The parent form or control.</param>
        /// <param name="message">The success message to display.</param>
        public static void ShowSuccess(this Form parent, string message)
        {
            MessageBox.Show(message, AppConstants.InfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows a confirmation dialog and returns the user's response.
        /// </summary>
        /// <param name="parent">The parent form or control.</param>
        /// <param name="message">The confirmation message to display.</param>
        /// <returns>True if user clicked Yes; otherwise false.</returns>
        public static bool ShowConfirmation(this Form parent, string message)
        {
            return MessageBox.Show(message, AppConstants.ConfirmationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>
        /// Validates that a string is not empty and displays an error if it is.
        /// </summary>
        /// <param name="parent">The parent form or control.</param>
        /// <param name="value">The string to validate.</param>
        /// <param name="fieldName">The name of the field being validated.</param>
        /// <returns>True if the string is valid; otherwise false.</returns>
        public static bool ValidateNotEmpty(this Form parent, string value, string fieldName = "")
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                parent.ShowError($"Please enter a valid {fieldName}".TrimEnd());
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates that a decimal value is positive and displays an error if it isn't.
        /// </summary>
        /// <param name="parent">The parent form or control.</param>
        /// <param name="value">The decimal value to validate.</param>
        /// <returns>True if the value is valid; otherwise false.</returns>
        public static bool ValidatePositiveDecimal(this Form parent, decimal value)
        {
            if (value <= 0)
            {
                parent.ShowError(AppConstants.InvalidAmountError);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Capitalizes the first letter of a string.
        /// </summary>
        /// <param name="str">The string to capitalize.</param>
        /// <returns>The capitalized string.</returns>
        public static string CapitalizeFirst(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;
            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}
