using MarsRovers.Contracts;
using MarsRovers.Infrastructure.DI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRovers.Application.Test
{
    [TestClass]
    public class RunCommandTest
    {
        IRover rover;
        IPlateau plateau;

        [TestInitialize]
        public void TestInit()
        {
            var serviceProvider = Installer.Configure();
            plateau = serviceProvider.GetService<IPlateau>();
            rover = serviceProvider.GetService<IRover>();

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RunCommand_NullCheck_Test()
        {

            #region Arrange
            rover.Commands = "".ToCharArray();
            #endregion

            #region Act
            rover.RunCommand(rover.Commands);
            #endregion


        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void RunCommand_Cast_Test()
        {

            #region Arrange
            rover.Commands = "g".ToCharArray();
            #endregion

            #region Act
            rover.RunCommand(rover.Commands);
            #endregion


        }

        [TestMethod]
        public void RunCommand_Result_Test1()
        {

            #region Arrange
            var expectedx = "1";
            var expectedy = "3";
            var expecteddirection = "n".ToUpper();
            plateau.ValidatePlateauSizeInput("5 5");
            rover.Plateau = plateau;
            rover.ValidateRoverCurrentPositionInput("1 2 n");
            rover.Commands = "lmlmlmlmm".ToCharArray();
            #endregion

            #region Act
            rover.RunCommand(rover.Commands);
            var act1 = rover.CurrentPosition.X.ToString();
            var act2 = rover.CurrentPosition.Y.ToString();
            var act3 = rover.CurrentPosition.RoverDirection.ToString();
            #endregion

            #region Assert
            Assert.AreEqual(expectedx, act1);
            Assert.AreEqual(expectedy, act2);
            Assert.AreEqual(expecteddirection, act3);
            #endregion

        }

        [TestMethod]
        public void RunCommand_Result_Test2()
        {

            #region Arrange
            var expectedx = "5";
            var expectedy = "1";
            var expecteddirection = "e".ToUpper();
            plateau.ValidatePlateauSizeInput("5 5");
            rover.Plateau = plateau;
            rover.ValidateRoverCurrentPositionInput("3 3 e");
            rover.Commands = "MMRMMRMRRM".ToCharArray();
            #endregion

            #region Act
            rover.RunCommand(rover.Commands);
            var act1 = rover.CurrentPosition.X.ToString();
            var act2 = rover.CurrentPosition.Y.ToString();
            var act3 = rover.CurrentPosition.RoverDirection.ToString();
            #endregion

            #region Assert
            Assert.AreEqual(expectedx, act1);
            Assert.AreEqual(expectedy, act2);
            Assert.AreEqual(expecteddirection, act3);
            #endregion

        }


    }
}
