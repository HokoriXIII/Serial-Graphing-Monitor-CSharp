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
        public bool RxStringComplete = false;
        public string[] splittedData;
        public int numOfDataReceived;
        public double timeStamp = 0;

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
        public void cleanUpReceivedData()
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
