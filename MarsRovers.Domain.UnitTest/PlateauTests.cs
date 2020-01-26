using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRovers.Domain.UnitTest
{
    [TestClass]
    public class PlateauTests
    {
        [TestMethod]
        public void ValidatePlateauSizeInput_NullCheck_Test()
        {
            var serviceProvider = MarsRovers.Infrastructure.DI.Installer.Configure();

            #region Arrange

            var expected = false;
            var input = " ";

            #endregion

            #region Act
           
            #endregion

            #region Assert

            #endregion
        }
    }
}
