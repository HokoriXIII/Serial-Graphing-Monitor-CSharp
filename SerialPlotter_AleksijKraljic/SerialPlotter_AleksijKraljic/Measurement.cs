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
        public string RxString; // USED BY ALL INSTANCES
        public bool RxStringComplete = false; // USED BY ALL INSTANCES
        public string[] splittedData; // USED BY ALL INSTANCES
        public int numOfDataReceived; // USED BY ALL INSTANCES
        public double timeStamp = 0; // USED BY ALL INSTANCES

        // Methods
        public void splitReceivedString() // USED BY ALL INSTANCES
        {
            splittedData = RxString.Split('_');
            numOfDataReceived = splittedData.Length;
        }
        public void clearRxString() // USED BY ALL INSTANCES
        {
            RxString = "";
        }
        public void cleanUpReceivedData() // USED BY ALL INSTANCES
        {
            if (RxString.Length > 2)
            {
                if (RxString.IndexOf("\n") != -1)
                {
                    RxStringComplete = true;
                    RxString = RxString.Replace("\r\n", "");
                }
            }
        }
        
    }
}
