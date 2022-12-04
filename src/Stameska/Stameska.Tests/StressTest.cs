using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;
using Stameska.Model;
using System.Diagnostics;
using System.IO;

namespace Stameska.Tests
{
    public class StressTest
    {
        public void TestAddIn()
        {
            ChiselData _chiselData = new ChiselData();
            _chiselData.HandleL = 150;
            _chiselData.BladeL = 170;
            _chiselData.BladeH = 15;
            _chiselData.RingD = 17;
            _chiselData.ChiselW = 27;
            KompasConnector _kompasApp = new KompasConnector();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var streamWriter = new StreamWriter($"log.txt", true);
            var count = 0;
            while (true)
            {
                _kompasApp.CreateDocument3D();
                Manager _manager = new Manager(_kompasApp);
                _manager.BuildModel(_chiselData);
                var computerInfo = new ComputerInfo();
                var usedMemory = (computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory) *
                0.000000000931322574615478515625;
                streamWriter.WriteLine(
                $"{++count}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory}");
                streamWriter.Flush();
            }
        }
    }
}
