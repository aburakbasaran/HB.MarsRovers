using MarsRovers.Contracts;
using MarsRovers.Infrastructure.DI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRovers.Application.Test
{
    [TestClass]
    public class RoverTest
    {
        [TestMethod]
        public void ValidateRoverCurrentPositionInput_NullCheck_Test()
        {
            var serviceProvider = Installer.Configure();
            var rover = serviceProvider.GetService<IRover>();
            #region Arrange
            var expected = false;
            var input = " ";
            var input2 = "1 2 e";
            #endregion

            #region Act
            var actual = rover.ValidateRoverCurrentPositionInput(input);
            var actual2 = rover.ValidateRoverCurrentPositionInput(input2);
            #endregion

            #region Assert
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(expected, actual2);
            #endregion
        }

        [TestMethod]
        public void ValidateRoverCurrentPositionInput_LengthCheck_Test()
        {
            var serviceProvider = Installer.Configure();
            var rover = serviceProvider.GetService<IRover>();
            #region Arrange
            var expected = false;
            var input = "5 ";
            var input2 = "544";
            var input3 = "544 2";
            var input4 = "1 2 e";
            #endregion

            #region Act
            var actual = rover.ValidateRoverCurrentPositionInput(input);
            var actual2 = rover.ValidateRoverCurrentPositionInput(input2);
            var actual3 = rover.ValidateRoverCurrentPositionInput(input3);
            var actual4 = rover.ValidateRoverCurrentPositionInput(input4);
            #endregion

            #region Assert
            Assert.AreEqual(expected, actual, "ValidateRoverCurrentPositionInput is not success");
            Assert.AreEqual(expected, actual2, "ValidateRoverCurrentPositionInput is not success");
            Assert.AreEqual(expected, actual3, "ValidateRoverCurrentPositionInput is not success");
            Assert.AreNotEqual(expected, actual4, "ValidateRoverCurrentPositionInput is success");
            #endregion
        }

        [TestMethod]
        public void ValidateRoverCurrentPositionInput_ParseInt_Test()
        {
            var serviceProvider = Installer.Configure();
            var rover = serviceProvider.GetService<IRover>();
            #region Arrange
            var expected = false;
         
            var input = "a ";
            var input2 = "asd";
            var input3 = "a a";
            var input4 = "1 a";
            var input5 = "a 1";
            var input6= "1 2 e";

            #endregion

            #region Act
            var actual = rover.ValidateRoverCurrentPositionInput(input);
            var actual2 = rover.ValidateRoverCurrentPositionInput(input2);
            var actual3 = rover.ValidateRoverCurrentPositionInput(input3);
            var actual4 = rover.ValidateRoverCurrentPositionInput(input4);
            var actual5 = rover.ValidateRoverCurrentPositionInput(input5);
            var actual6 = rover.ValidateRoverCurrentPositionInput(input6);
            #endregion

            #region Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, actual2);
            Assert.AreEqual(expected, actual3);
            Assert.AreEqual(expected, actual4);
            Assert.AreEqual(expected, actual5);
            Assert.AreNotEqual(expected, actual6);
            #endregion
        }

        [TestMethod]
        public void ValidateRoverCurrentPositionInput_ParseRoverDirectionEnum_Test()
        {
            var serviceProvider = Installer.Configure();
            var rover = serviceProvider.GetService<IRover>();
            #region Arrange
            var expected = false;

            var input = "1 1 2";
            var input2 = "1 1 ð";
            var input3 = "1 1 w";
            var input4 = "1 1 e";
            var input5 = "1 1 n";
            var input6 = "1 1 s";


            #endregion

            #region Act
            var actual = rover.ValidateRoverCurrentPositionInput(input);
            var actual2 = rover.ValidateRoverCurrentPositionInput(input2);
            var actual3 = rover.ValidateRoverCurrentPositionInput(input3);
            var actual4 = rover.ValidateRoverCurrentPositionInput(input4);
            var actual5 = rover.ValidateRoverCurrentPositionInput(input5);
            var actual6 = rover.ValidateRoverCurrentPositionInput(input6);
            #endregion

            #region Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, actual2);
            Assert.AreNotEqual(expected, actual3);
            Assert.AreNotEqual(expected, actual4);
            Assert.AreNotEqual(expected, actual5);
            Assert.AreNotEqual(expected, actual6);

            #endregion
        }

    }
}
