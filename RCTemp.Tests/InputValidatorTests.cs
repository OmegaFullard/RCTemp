using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace RCTemp.Tests
{
    /// <summary>
    /// Unit tests for input validation rules used by the Contact form
    /// and any other forms requiring the same field constraints.
    /// </summary>
    [TestClass]
    public class InputValidatorTests
    {
        // ---------------------------------------------------------------
        // Email validation  (mirrors RegularExpressionValidator on form)
        // ---------------------------------------------------------------
        private static readonly Regex EmailRegex =
            new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        private static bool IsValidEmail(string value) =>
            !string.IsNullOrWhiteSpace(value) && EmailRegex.IsMatch(value);

        // ---------------------------------------------------------------
        // Required field validation  (mirrors RequiredFieldValidator)
        // ---------------------------------------------------------------
        private static bool IsRequiredFieldValid(string value) =>
            !string.IsNullOrWhiteSpace(value);

        // ---------------------------------------------------------------
        // Length constraints (applied in code-behind before DB operations)
        // ---------------------------------------------------------------
        private const int MaxNameLength    = 100;
        private const int MaxSubjectLength = 200;
        private const int MaxMessageLength = 2000;

        private static bool IsWithinMaxLength(string value, int maxLength) =>
            value != null && value.Length <= maxLength;

        // ===============================================================
        // Name field
        // ===============================================================

        [TestMethod]
        public void Name_ValidValue_PassesRequiredCheck()
        {
            Assert.IsTrue(IsRequiredFieldValid("Jane Doe"));
        }

        [TestMethod]
        public void Name_EmptyString_FailsRequiredCheck()
        {
            Assert.IsFalse(IsRequiredFieldValid(""));
        }

        [TestMethod]
        public void Name_Whitespace_FailsRequiredCheck()
        {
            Assert.IsFalse(IsRequiredFieldValid("   "));
        }

        [TestMethod]
        public void Name_Null_FailsRequiredCheck()
        {
            Assert.IsFalse(IsRequiredFieldValid(null));
        }

        [TestMethod]
        public void Name_ExactlyAtMaxLength_PassesLengthCheck()
        {
            string value = new string('A', MaxNameLength);
            Assert.IsTrue(IsWithinMaxLength(value, MaxNameLength));
        }

        [TestMethod]
        public void Name_ExceedsMaxLength_FailsLengthCheck()
        {
            string value = new string('A', MaxNameLength + 1);
            Assert.IsFalse(IsWithinMaxLength(value, MaxNameLength));
        }

        // ===============================================================
        // Email field
        // ===============================================================

        [TestMethod]
        public void Email_ValidFormat_PassesValidation()
        {
            Assert.IsTrue(IsValidEmail("user@example.com"));
        }

        [TestMethod]
        public void Email_ValidFormatWithSubdomain_PassesValidation()
        {
            Assert.IsTrue(IsValidEmail("user@mail.example.com"));
        }

        [TestMethod]
        public void Email_ValidFormatWithPlusSign_PassesValidation()
        {
            Assert.IsTrue(IsValidEmail("user+tag@example.com"));
        }

        [TestMethod]
        public void Email_MissingAtSign_FailsValidation()
        {
            Assert.IsFalse(IsValidEmail("userexample.com"));
        }

        [TestMethod]
        public void Email_MissingDomain_FailsValidation()
        {
            Assert.IsFalse(IsValidEmail("user@"));
        }

        [TestMethod]
        public void Email_MissingTopLevelDomain_FailsValidation()
        {
            Assert.IsFalse(IsValidEmail("user@example"));
        }

        [TestMethod]
        public void Email_EmptyString_FailsValidation()
        {
            Assert.IsFalse(IsValidEmail(""));
        }

        [TestMethod]
        public void Email_Null_FailsValidation()
        {
            Assert.IsFalse(IsValidEmail(null));
        }

        [TestMethod]
        public void Email_WithSpaces_FailsValidation()
        {
            Assert.IsFalse(IsValidEmail("user name@example.com"));
        }

        [TestMethod]
        public void Email_OnlyAtSign_FailsValidation()
        {
            Assert.IsFalse(IsValidEmail("@"));
        }

        // ===============================================================
        // Subject field
        // ===============================================================

        [TestMethod]
        public void Subject_ValidValue_PassesRequiredCheck()
        {
            Assert.IsTrue(IsRequiredFieldValid("Job Inquiry"));
        }

        [TestMethod]
        public void Subject_EmptyString_FailsRequiredCheck()
        {
            Assert.IsFalse(IsRequiredFieldValid(""));
        }

        [TestMethod]
        public void Subject_Whitespace_FailsRequiredCheck()
        {
            Assert.IsFalse(IsRequiredFieldValid("   "));
        }

        [TestMethod]
        public void Subject_ExactlyAtMaxLength_PassesLengthCheck()
        {
            string value = new string('S', MaxSubjectLength);
            Assert.IsTrue(IsWithinMaxLength(value, MaxSubjectLength));
        }

        [TestMethod]
        public void Subject_ExceedsMaxLength_FailsLengthCheck()
        {
            string value = new string('S', MaxSubjectLength + 1);
            Assert.IsFalse(IsWithinMaxLength(value, MaxSubjectLength));
        }

        // ===============================================================
        // Message field
        // ===============================================================

        [TestMethod]
        public void Message_ValidValue_PassesRequiredCheck()
        {
            Assert.IsTrue(IsRequiredFieldValid("Hello, I would like more information."));
        }

        [TestMethod]
        public void Message_EmptyString_FailsRequiredCheck()
        {
            Assert.IsFalse(IsRequiredFieldValid(""));
        }

        [TestMethod]
        public void Message_Whitespace_FailsRequiredCheck()
        {
            Assert.IsFalse(IsRequiredFieldValid("   "));
        }

        [TestMethod]
        public void Message_ExactlyAtMaxLength_PassesLengthCheck()
        {
            string value = new string('M', MaxMessageLength);
            Assert.IsTrue(IsWithinMaxLength(value, MaxMessageLength));
        }

        [TestMethod]
        public void Message_ExceedsMaxLength_FailsLengthCheck()
        {
            string value = new string('M', MaxMessageLength + 1);
            Assert.IsFalse(IsWithinMaxLength(value, MaxMessageLength));
        }

        // ===============================================================
        // Combined full-form validation
        // ===============================================================

        [TestMethod]
        public void FullForm_AllValidInputs_PassesAllChecks()
        {
            string name    = "Jane Doe";
            string email   = "jane@example.com";
            string subject = "Job Inquiry";
            string message = "I would like to know more about open positions.";

            Assert.IsTrue(IsRequiredFieldValid(name),    "Name should be valid.");
            Assert.IsTrue(IsValidEmail(email),            "Email should be valid.");
            Assert.IsTrue(IsRequiredFieldValid(subject),  "Subject should be valid.");
            Assert.IsTrue(IsRequiredFieldValid(message),  "Message should be valid.");
        }

        [TestMethod]
        public void FullForm_AllEmptyInputs_FailsAllChecks()
        {
            string name    = "";
            string email   = "";
            string subject = "";
            string message = "";

            Assert.IsFalse(IsRequiredFieldValid(name),    "Empty name should fail.");
            Assert.IsFalse(IsValidEmail(email),            "Empty email should fail.");
            Assert.IsFalse(IsRequiredFieldValid(subject),  "Empty subject should fail.");
            Assert.IsFalse(IsRequiredFieldValid(message),  "Empty message should fail.");
        }

        [TestMethod]
        public void FullForm_ValidNameEmailSubject_InvalidMessage_FailsFormCheck()
        {
            string name    = "Jane Doe";
            string email   = "jane@example.com";
            string subject = "Hello";
            string message = "";

            bool formIsValid =
                IsRequiredFieldValid(name) &&
                IsValidEmail(email) &&
                IsRequiredFieldValid(subject) &&
                IsRequiredFieldValid(message);

            Assert.IsFalse(formIsValid, "Form should fail when message is empty.");
        }

        [TestMethod]
        public void FullForm_InvalidEmailOnly_FailsFormCheck()
        {
            string name    = "Jane Doe";
            string email   = "not-an-email";
            string subject = "Hello";
            string message = "Some message text.";

            bool formIsValid =
                IsRequiredFieldValid(name) &&
                IsValidEmail(email) &&
                IsRequiredFieldValid(subject) &&
                IsRequiredFieldValid(message);

            Assert.IsFalse(formIsValid, "Form should fail when email format is invalid.");
        }
    }
}
