using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;
using System.Drawing;

namespace SerialPlotter_AleksijKraljic
{
    class Measurement
    {
         // Fields
        public string RxString;
        public double timeStamp = 0;
        public List<double> recordedValues = new List<double>();
        public List<double> recordedTime = new List<double>();
        public RollingPointPairList ringBuffer = new RollingPointPairList(500);
        public LineItem curve;

        public string[] splittedData;
        public int numOfDataReceived;
        public int lineID = 0;
        public Color lineColor;

        // Methods
        public void splitReceivedString()
        {
            splittedData = RxString.Split('_');
            numOfDataReceived = splittedData.Length;
        }
        public void recordData()
        {
            recordedTime.Add(timeStamp);
            recordedValues.Add(Convert.ToDouble(splittedData[lineID]));
        }
        public void clearOnStart()
        {
            recordedValues.Clear();
            recordedTime.Clear();
            ringBuffer.Clear();
        }
        public void setLineWidth(Single lineWidth)
        {
            curve.Line.Width = lineWidth;
        }
        public void addToBuffer()
        {
            ringBuffer.Add(timeStamp / 1000, Convert.ToDouble(splittedData[lineID]));
        }
        
        
    }
}
