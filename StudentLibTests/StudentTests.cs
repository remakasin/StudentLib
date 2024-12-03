using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentLib;
using System;

namespace StudentLibTests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void CheckName_ValidName_ReturnsTrue()
        {
            // Arrange
            var student = new Student("John1", "Doe", new DateTime(2005, 5, 20), 2, "Computer Science");

            // Act
            bool result = student.CheckName();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckName_InvalidNameWithMultipleDigits_ReturnsFalse()
        {
            // Arrange
            var student = new Student("John12", "Doe", new DateTime(2005, 5, 20), 2, "Computer Science");

            // Act
            bool result = student.CheckName();

            // Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void TransformSpecialty_ValidInput_ReturnsTransformedSpecialty()
        {
            // Arrange
            var student = new Student("John", "Doe", new DateTime(2005, 5, 20), 2, "   computer   science  ");

            // Act
            string result = student.TransformSpecialty();

            // Assert
            Assert.AreEqual("COMPUTER SCIENCE", result);
        }

        [TestMethod]
        public void CheckBirthday_AgeUnder16_Returns0()
        {
            // Arrange
            var student = new Student("John", "Doe", new DateTime(2010, 5, 20), 1, "Computer Science");

            // Act
            int result = student.CheckBirthday();

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CheckBirthday_AgeBetween18And22_Returns2()
        {
            // Arrange
            var student = new Student("John", "Doe", new DateTime(2003, 5, 20), 4, "Computer Science");

            // Act
            int result = student.CheckBirthday();

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void CheckBirthday_DateInFuture_ReturnsMinus1()
        {
            // Arrange
            var student = new Student("John", "Doe", new DateTime(2030, 5, 20), 1, "Computer Science");

            // Act
            int result = student.CheckBirthday();

            // Assert
            Assert.AreEqual(-1, result);
        }
    }
}
