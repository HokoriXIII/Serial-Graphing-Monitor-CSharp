using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;
using System.Drawing;
using System.Diagnostics;

namespace SerialPlotter_AleksijKraljic
{
    public class Measurement
    {
         // Properites
        public string RxString {get;set;}
        public string[] splittedData {get; set;}
        public int numOfDataReceived {get; set;}
        public double timeStamp { get; set; }
        public List<string> recordedString = new List<string>();

        Stopwatch s_watch = new Stopwatch();

        // Fields
        private string temp_rec;

        // Methods
        public void start()
        {
            s_watch.Start();
        }
        public void stop()
        {
            s_watch.Stop();
            s_watch.Reset();
        }
        public void setTimeStamp()
        {
            timeStamp = Convert.ToDouble(s_watch.ElapsedMilliseconds);
        }
        public void splitReceivedString()
        {
            splittedData = RxString.Split('_');
            numOfDataReceived = splittedData.Length;
        }
        public void clearRxString()
        {
            RxString = "";
        }
        public void recordData()
        {
            temp_rec = Convert.ToString(timeStamp);
            for (int i = 0; i < numOfDataReceived; i++)
            {
                temp_rec = temp_rec + "," + splittedData[i];
            }
            recordedString.Add(temp_rec);
            temp_rec = "";
        }
        public void clearOnStart()
        {
            recordedString.Clear();
        }
    }
}
