using System;
using Stameska.Model;
using NUnit;
using NUnit.Framework;

namespace Stameska.Tests
{
    [TestFixture]
    public class UnitTest
    {

        [TestCase(true, 120, 120, 10, 11, 25, TestName = "Min parameters")]
        [TestCase(true, 200, 240, 20, 45, 50, TestName = "Max parameters")]
        [TestCase(true, 150, 160, 15, 24, 35, TestName = "Avarage parameters")]
        [TestCase(false, 200, 199, 20, 20, 25, TestName = "incorrect parameters")]
        [TestCase(false, double.PositiveInfinity, double.NegativeInfinity, double.PositiveInfinity,
            double.NegativeInfinity, double.PositiveInfinity, TestName = "Infinity values")]
        [TestCase(false, double.MaxValue+1, double.MaxValue + 1, double.MaxValue + 1,
            double.MaxValue + 1, double.MaxValue + 1, TestName = "More and less scceptable values")]
        public void TestValidation(bool expected, double handgleL, double bladeL,
            double bladeH, double ringd,  double chiselW)
        {
            bool actual = true;
            try
            {
                ChiselData chiselData = new ChiselData();

                chiselData.HandleL = handgleL;
                chiselData.BladeL = bladeL;
                chiselData.BladeH = bladeH;
                chiselData.ChiselW = chiselW;
                chiselData.RingD = ringd;
            }
            catch
            {
                actual = false;
            }
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Проверка зависимостей длины рукояти и лезвия
        /// </summary>
        /// <param name="exepted"></param>
        /// <param name="handleL"></param>
        /// <param name="bladeL"></param>
        [TestCase(true, 120,120, TestName = "(Handle-BladeLength) min value range ")]
        [TestCase(true,200,240,TestName = "(Handle-BladeLength) max value range")]
        [TestCase(false, 120,145, TestName = "(Handle-BladeLength) more than max value range")]
        [TestCase(false, 130,129, TestName = "(Handle-BladeLength) less than min valew range")]
        public void HandleL_BladeL_validator(bool exepted, double handleL, double bladeL)
        {
            bool actual = true;
            try
            {
                ChiselData chiselData = new ChiselData();

                chiselData.HandleL = handleL;
                chiselData.BladeL = bladeL;
            }
            catch
            {
                actual = false;
            }
            Assert.AreEqual(exepted, actual);
        }


        /// <summary>
        /// проверка зависимостей кольца, выосты лезвия и ширины стамески
        /// </summary>
        /// <param name="exepted"></param>
        /// <param name="bladeH"></param>
        /// <param name="ringD"></param>
        /// <param name="chiselW"></param>
        [TestCase(true, 10, 11, 25, TestName = "(BladeH-Ring-ChiselW) min value range")]
        [TestCase(true, 10, 22.5, 25, TestName = "(BladeH-Ring-ChiselW) max value range")]
        [TestCase(false, 10, 23, 30, TestName = "(BladeH-Ring-ChiselW) more than max value range")]
        [TestCase(false, 12, 11, 25, TestName = "(BladeH-Ring-ChiselW) less than min value range")]
        public void BladeH_RingD_ChiselW_Validator(bool exepted, double bladeH, double ringD, double chiselW)
        {
            bool actual = true;
            try
            {
                ChiselData chiselData = new ChiselData();

                chiselData.BladeH = bladeH;
                chiselData.ChiselW = chiselW;
                chiselData.RingD = ringD;
            }
            catch
            {
                actual = false;
            }
            Assert.AreEqual(exepted, actual);
        }
    }
}
