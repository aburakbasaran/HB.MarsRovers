using MarsRovers.Contracts;
using MarsRovers.Infrastructure.DI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRovers.Domain.Test
{
    [TestClass]
    public class PlateauTest
    {
        [TestMethod]
        public void ValidatePlateauSizeInput_NullCheck_Test()
        {
            var serviceProvider = Installer.Configure();
            var plateau = serviceProvider.GetService<IPlateau>();
            #region Arrange
            var expected = false;
            var input = " ";
            #endregion

            #region Act
            var actual = plateau.ValidatePlateauSizeInput(input);
            #endregion

            #region Assert
            Assert.AreEqual(expected, actual);
            #endregion
        }

        [TestMethod]
        public void ValidatePlateauSizeInput_LengthCheck_Test()
        {
            var serviceProvider = Installer.Configure();
            var plateau = serviceProvider.GetService<IPlateau>();
            #region Arrange
            var expected = false;
            var input = "5 ";
            var input2 = "544";
            var input3 = "544 2 3";
            #endregion

            #region Act
            var actual = plateau.ValidatePlateauSizeInput(input);
            var actual2 = plateau.ValidatePlateauSizeInput(input2);
            var actual3 = plateau.ValidatePlateauSizeInput(input3);
            #endregion

            #region Assert
            Assert.AreEqual(expected, actual, "ValidatePlateauSizeInput is not success");
            Assert.AreEqual(expected, actual2, "ValidatePlateauSizeInput is not success");
            Assert.AreEqual(expected, actual3, "ValidatePlateauSizeInput is not success");

            
            #endregion
        }

        [TestMethod]
        public void ValidatePlateauSizeInput_ParseInt_Test()
        {
            var serviceProvider = Installer.Configure();
            var plateau = serviceProvider.GetService<IPlateau>();
            #region Arrange
            var expected = false;
            var input = "a ";
            var input2 = "asd";
            var input3 = "a a";
            var input4 = "1 a";
            var input5 = "a 1";

            #endregion

            #region Act
            var actual = plateau.ValidatePlateauSizeInput(input);
            var actual2 = plateau.ValidatePlateauSizeInput(input2);
            var actual3 = plateau.ValidatePlateauSizeInput(input3);
            var actual4 = plateau.ValidatePlateauSizeInput(input4);
            var actual5 = plateau.ValidatePlateauSizeInput(input5);
            #endregion

            #region Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, actual2);
            Assert.AreEqual(expected, actual3);
            Assert.AreEqual(expected, actual4);
            Assert.AreEqual(expected, actual5);

            #endregion
        }
    }
}
