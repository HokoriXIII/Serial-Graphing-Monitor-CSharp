using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;
using System.Drawing;

namespace SerialPlotter_AleksijKraljic
{
    public class Measurement
    {
         // Fields
        public string RxString;
        public string[] splittedData;
        public int numOfDataReceived;
        public double timeStamp = 0;
        public List<string> recordedString = new List<string>();
        private string temp_rec;

        // Methods
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
