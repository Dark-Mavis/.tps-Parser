using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tps_Parser
{
    [TestFixture]
    class tpsParserTest
    {
        tpsParser file3 = new tpsParser("C:/Users/Cerullium/OneDrive/Work/.tps Parser/3.tps");
        tpsParser file102815 = new tpsParser("C:/Users/Cerullium/OneDrive/Work/.tps Parser/102815R-CDE.tps");
        [Test]
        public void TestTrussID()
        {
            Assert.AreEqual("C3_SP_24", file3.Trusses[0].TrussID);
            Assert.AreEqual("C-1", file102815.Trusses[0].TrussID);
        }
        [Test]
        public void Component0TestFile102815()
        {
            Assert.AreEqual(ComponentID.TopChord, file102815.Trusses[0].Components[0].ID);
            Assert.AreEqual(1,      file102815.Trusses[0].Components[0].ComponentNumber);
            Assert.AreEqual(0.00,   file102815.Trusses[0].Components[0].XY[0][0]);
            Assert.AreEqual(0.25,   file102815.Trusses[0].Components[0].XY[0][1]);
            Assert.AreEqual(0.00,   file102815.Trusses[0].Components[0].XY[1][0]);
            Assert.AreEqual(4.456,  file102815.Trusses[0].Components[0].XY[1][1]);
            Assert.AreEqual(57.625,    file102815.Trusses[0].Components[0].XY[2][0]);
            Assert.AreEqual(42.873, file102815.Trusses[0].Components[0].XY[2][1]);
            Assert.AreEqual(57.625,    file102815.Trusses[0].Components[0].XY[3][0]);
            Assert.AreEqual(38.667,  file102815.Trusses[0].Components[0].XY[3][1]);
        }
        [Test]
        public void Component1TestFile3()
        {
            Assert.AreEqual(ComponentID.TopChord, file3.Trusses[0].Components[1].ID);
            Assert.AreEqual(2,      file3.Trusses[0].Components[1].ComponentNumber);
            Assert.AreEqual(144,    file3.Trusses[0].Components[1].XY[0][0]);
            Assert.AreEqual(48.25,  file3.Trusses[0].Components[1].XY[0][1]);
            Assert.AreEqual(144,    file3.Trusses[0].Components[1].XY[1][0]);
            Assert.AreEqual(51.939, file3.Trusses[0].Components[1].XY[1][1]);
            Assert.AreEqual(288,    file3.Trusses[0].Components[1].XY[2][0]);
            Assert.AreEqual(3.939,  file3.Trusses[0].Components[1].XY[2][1]);
            Assert.AreEqual(288,    file3.Trusses[0].Components[1].XY[3][0]);
            Assert.AreEqual(0.25,   file3.Trusses[0].Components[1].XY[3][1]);
        }
        [Test]
        public void Component2TestFile102815()
        {
            Assert.AreEqual(ComponentID.BottomChord, file102815.Trusses[0].Components[2].ID);
            Assert.AreEqual(3,         file102815.Trusses[0].Components[2].ComponentNumber);
            Assert.AreEqual(0.00000,   file102815.Trusses[0].Components[2].XY[0][0]);
            Assert.AreEqual(0.00000,   file102815.Trusses[0].Components[2].XY[0][1]);
            Assert.AreEqual(0.00000,   file102815.Trusses[0].Components[2].XY[1][0]);
            Assert.AreEqual(0.25000,   file102815.Trusses[0].Components[2].XY[1][1]);
            Assert.AreEqual(4.87500,   file102815.Trusses[0].Components[2].XY[2][0]);
            Assert.AreEqual(3.50000,   file102815.Trusses[0].Components[2].XY[2][1]);
            Assert.AreEqual(110.375,   file102815.Trusses[0].Components[2].XY[3][0]);
            Assert.AreEqual(3.50000,   file102815.Trusses[0].Components[2].XY[3][1]);
            Assert.AreEqual(115.250,   file102815.Trusses[0].Components[2].XY[4][0]);
            Assert.AreEqual(0.25000,   file102815.Trusses[0].Components[2].XY[4][1]);
            Assert.AreEqual(115.250,   file102815.Trusses[0].Components[2].XY[5][0]);
            Assert.AreEqual(0.00000,   file102815.Trusses[0].Components[2].XY[5][1]);
        }
        [Test]
        public void Component3TestFile3()
        {
            Assert.AreEqual(ComponentID.BottomChord, file3.Trusses[0].Components[3].ID);
            Assert.AreEqual(4, file3.Trusses[0].Components[3].ComponentNumber);
            Assert.AreEqual(96.000, file3.Trusses[0].Components[3].XY[0][0]);
            Assert.AreEqual(0.0000, file3.Trusses[0].Components[3].XY[0][1]);
            Assert.AreEqual(96.000, file3.Trusses[0].Components[3].XY[1][0]);
            Assert.AreEqual(3.5000, file3.Trusses[0].Components[3].XY[1][1]);
            Assert.AreEqual(278.25, file3.Trusses[0].Components[3].XY[2][0]);
            Assert.AreEqual(3.5000, file3.Trusses[0].Components[3].XY[2][1]);
            Assert.AreEqual(288.00, file3.Trusses[0].Components[3].XY[3][0]);
            Assert.AreEqual(0.2500, file3.Trusses[0].Components[3].XY[3][1]);
            Assert.AreEqual(288.00, file3.Trusses[0].Components[3].XY[4][0]);
            Assert.AreEqual(0.0000, file3.Trusses[0].Components[3].XY[4][1]);
        }
        [Test]
        public void Component4TestFile102815()
        {
            Assert.AreEqual(ComponentID.Plate, file102815.Trusses[0].Components[4].ID);
            Assert.AreEqual(1, file102815.Trusses[0].Components[4].ComponentNumber);
            Assert.AreEqual(0.43800, file102815.Trusses[0].Components[4].XY[0][0]);
            Assert.AreEqual(3.37500, file102815.Trusses[0].Components[4].XY[0][1]);
            Assert.AreEqual(4.43800, file102815.Trusses[0].Components[4].XY[1][0]);
            Assert.AreEqual(3.37500, file102815.Trusses[0].Components[4].XY[1][1]);
            Assert.AreEqual(5.18800, file102815.Trusses[0].Components[4].XY[2][0]);
            Assert.AreEqual(1.87500, file102815.Trusses[0].Components[4].XY[2][1]);
            Assert.AreEqual(4.43800, file102815.Trusses[0].Components[4].XY[3][0]);
            Assert.AreEqual(0.37500, file102815.Trusses[0].Components[4].XY[3][1]);
            Assert.AreEqual(0.43800, file102815.Trusses[0].Components[4].XY[4][0]);
            Assert.AreEqual(0.37500, file102815.Trusses[0].Components[4].XY[4][1]);
        }
        [Test]
        public void Component5TestFile3()
        {
            Assert.AreEqual(ComponentID.Web, file3.Trusses[0].Components[5].ID);
            Assert.AreEqual(6,      file3.Trusses[0].Components[5].ComponentNumber);
            Assert.AreEqual(78.625,    file3.Trusses[0].Components[5].XY[0][0]);
            Assert.AreEqual(24.598,  file3.Trusses[0].Components[5].XY[0][1]);
            Assert.AreEqual(78.625,    file3.Trusses[0].Components[5].XY[1][0]);
            Assert.AreEqual(26.458, file3.Trusses[0].Components[5].XY[1][1]);
            Assert.AreEqual(81.305,    file3.Trusses[0].Components[5].XY[2][0]);
            Assert.AreEqual(27.352,  file3.Trusses[0].Components[5].XY[2][1]);
            Assert.AreEqual(142.25,    file3.Trusses[0].Components[5].XY[3][0]);
            Assert.AreEqual(5.3600,   file3.Trusses[0].Components[5].XY[3][1]);
            Assert.AreEqual(142.25,    file3.Trusses[0].Components[5].XY[4][0]);
            Assert.AreEqual(3.5000,   file3.Trusses[0].Components[5].XY[4][1]);
            Assert.AreEqual(137.094,    file3.Trusses[0].Components[5].XY[5][0]);
            Assert.AreEqual(3.5000,   file3.Trusses[0].Components[5].XY[5][1]);
        }
        [Test]
        public void Component6TestFile102815()
        {
            Assert.AreEqual(ComponentID.Plate, file102815.Trusses[0].Components[6].ID);
            Assert.AreEqual(3, file102815.Trusses[0].Components[6].ComponentNumber);
            Assert.AreEqual(56.8750, file102815.Trusses[0].Components[6].XY[0][0]);
            Assert.AreEqual(1.50000, file102815.Trusses[0].Components[6].XY[0][1]);
            Assert.AreEqual(56.8750, file102815.Trusses[0].Components[6].XY[1][0]);
            Assert.AreEqual(5.50000, file102815.Trusses[0].Components[6].XY[1][1]);
            Assert.AreEqual(57.6250, file102815.Trusses[0].Components[6].XY[2][0]);
            Assert.AreEqual(5.87500, file102815.Trusses[0].Components[6].XY[2][1]);
            Assert.AreEqual(58.3750, file102815.Trusses[0].Components[6].XY[3][0]);
            Assert.AreEqual(5.50000, file102815.Trusses[0].Components[6].XY[3][1]);
            Assert.AreEqual(58.3750, file102815.Trusses[0].Components[6].XY[4][0]);
            Assert.AreEqual(1.50000, file102815.Trusses[0].Components[6].XY[4][1]);
        }
        [Test]
        public void Component7TestFile3()
        {
            Assert.AreEqual(ComponentID.Web, file3.Trusses[0].Components[7].ID);
            Assert.AreEqual(8, file3.Trusses[0].Components[7].ComponentNumber);
            Assert.AreEqual(150.906, file3.Trusses[0].Components[7].XY[0][0]);
            Assert.AreEqual(3.50000, file3.Trusses[0].Components[7].XY[0][1]);
            Assert.AreEqual(145.750, file3.Trusses[0].Components[7].XY[1][0]);
            Assert.AreEqual(3.50000, file3.Trusses[0].Components[7].XY[1][1]);
            Assert.AreEqual(145.750, file3.Trusses[0].Components[7].XY[2][0]);
            Assert.AreEqual(5.36000, file3.Trusses[0].Components[7].XY[2][1]);
            Assert.AreEqual(206.695, file3.Trusses[0].Components[7].XY[3][0]);
            Assert.AreEqual(27.3520, file3.Trusses[0].Components[7].XY[3][1]);
            Assert.AreEqual(209.375, file3.Trusses[0].Components[7].XY[4][0]);
            Assert.AreEqual(26.4580, file3.Trusses[0].Components[7].XY[4][1]);
            Assert.AreEqual(209.375, file3.Trusses[0].Components[7].XY[5][0]);
            Assert.AreEqual(24.5980, file3.Trusses[0].Components[7].XY[5][1]);
        }
        [Test]
        public void Component9TestFile3()
        {
            Assert.AreEqual(ComponentID.Plate, file3.Trusses[0].Components[9].ID);
            Assert.AreEqual(1, file3.Trusses[0].Components[9].ComponentNumber);
            Assert.AreEqual(1.875, file3.Trusses[0].Components[9].XY[0][0]);
            Assert.AreEqual(3.375, file3.Trusses[0].Components[9].XY[0][1]);
            Assert.AreEqual(7.875, file3.Trusses[0].Components[9].XY[1][0]);
            Assert.AreEqual(3.375, file3.Trusses[0].Components[9].XY[1][1]);
            Assert.AreEqual(8.625, file3.Trusses[0].Components[9].XY[2][0]);
            Assert.AreEqual(1.875, file3.Trusses[0].Components[9].XY[2][1]);
            Assert.AreEqual(7.875, file3.Trusses[0].Components[9].XY[3][0]);
            Assert.AreEqual(0.375, file3.Trusses[0].Components[9].XY[3][1]);
            Assert.AreEqual(1.875, file3.Trusses[0].Components[9].XY[4][0]);
            Assert.AreEqual(0.375, file3.Trusses[0].Components[9].XY[4][1]);
        }
        [Test]
        public void Component11TestFile3()
        {
            Assert.AreEqual(ComponentID.Plate, file3.Trusses[0].Components[11].ID);
            Assert.AreEqual(3, file3.Trusses[0].Components[11].ComponentNumber);
            Assert.AreEqual(76.253, file3.Trusses[0].Components[11].XY[0][0]);
            Assert.AreEqual(27.249, file3.Trusses[0].Components[11].XY[0][1]);
            Assert.AreEqual(80.048, file3.Trusses[0].Components[11].XY[1][0]);
            Assert.AreEqual(28.514, file3.Trusses[0].Components[11].XY[1][1]);
            Assert.AreEqual(81.234, file3.Trusses[0].Components[11].XY[2][0]);
            Assert.AreEqual(27.328, file3.Trusses[0].Components[11].XY[2][1]);
            Assert.AreEqual(80.997, file3.Trusses[0].Components[11].XY[3][0]);
            Assert.AreEqual(25.668, file3.Trusses[0].Components[11].XY[3][1]);
            Assert.AreEqual(77.202, file3.Trusses[0].Components[11].XY[4][0]);
            Assert.AreEqual(24.403, file3.Trusses[0].Components[11].XY[4][1]);
        }
        [Test]
        public void Component13TestFile3()
        {
            Assert.AreEqual(ComponentID.Plate, file3.Trusses[0].Components[13].ID);
            Assert.AreEqual(5, file3.Trusses[0].Components[13].ComponentNumber);
            Assert.AreEqual(141.172, file3.Trusses[0].Components[13].XY[0][0]);
            Assert.AreEqual(49.1110, file3.Trusses[0].Components[13].XY[0][1]);
            Assert.AreEqual(144.000, file3.Trusses[0].Components[13].XY[1][0]);
            Assert.AreEqual(51.9390, file3.Trusses[0].Components[13].XY[1][1]);
            Assert.AreEqual(146.121, file3.Trusses[0].Components[13].XY[2][0]);
            Assert.AreEqual(51.2320, file3.Trusses[0].Components[13].XY[2][1]);
            Assert.AreEqual(146.828, file3.Trusses[0].Components[13].XY[3][0]);
            Assert.AreEqual(49.1110, file3.Trusses[0].Components[13].XY[3][1]);
            Assert.AreEqual(144.000, file3.Trusses[0].Components[13].XY[4][0]);
            Assert.AreEqual(46.2830, file3.Trusses[0].Components[13].XY[4][1]);
        }
        [Test]
        public void Component15TestFile3()
        {
            Assert.AreEqual(ComponentID.Plate, file3.Trusses[0].Components[15].ID);
            Assert.AreEqual(7, file3.Trusses[0].Components[15].ComponentNumber);
            Assert.AreEqual(210.798, file3.Trusses[0].Components[15].XY[0][0]);
            Assert.AreEqual(24.4030, file3.Trusses[0].Components[15].XY[0][1]);
            Assert.AreEqual(207.003, file3.Trusses[0].Components[15].XY[1][0]);
            Assert.AreEqual(25.6680, file3.Trusses[0].Components[15].XY[1][1]);
            Assert.AreEqual(206.766, file3.Trusses[0].Components[15].XY[2][0]);
            Assert.AreEqual(27.3280, file3.Trusses[0].Components[15].XY[2][1]);
            Assert.AreEqual(207.952, file3.Trusses[0].Components[15].XY[3][0]);
            Assert.AreEqual(28.5140, file3.Trusses[0].Components[15].XY[3][1]);
            Assert.AreEqual(211.747, file3.Trusses[0].Components[15].XY[4][0]);
            Assert.AreEqual(27.2490, file3.Trusses[0].Components[15].XY[4][1]);
        }
        [Test]
        public void Component17TestFile3()
        {
            Assert.AreEqual(ComponentID.Plate, file3.Trusses[0].Components[17].ID);
            Assert.AreEqual(9, file3.Trusses[0].Components[17].ComponentNumber);
            Assert.AreEqual(286.125, file3.Trusses[0].Components[17].XY[0][0]);
            Assert.AreEqual(0.37500, file3.Trusses[0].Components[17].XY[0][1]);
            Assert.AreEqual(280.125, file3.Trusses[0].Components[17].XY[1][0]);
            Assert.AreEqual(0.37500, file3.Trusses[0].Components[17].XY[1][1]);
            Assert.AreEqual(279.375, file3.Trusses[0].Components[17].XY[2][0]);
            Assert.AreEqual(1.87500, file3.Trusses[0].Components[17].XY[2][1]);
            Assert.AreEqual(280.125, file3.Trusses[0].Components[17].XY[3][0]);
            Assert.AreEqual(3.37500, file3.Trusses[0].Components[17].XY[3][1]);
            Assert.AreEqual(286.125, file3.Trusses[0].Components[17].XY[4][0]);
            Assert.AreEqual(3.37500, file3.Trusses[0].Components[17].XY[4][1]);
        }
    }
}
