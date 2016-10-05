using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;
using System.Drawing;

namespace SerialPlotter_AleksijKraljic
{
    class Channel
    {
        public List<double> recordedValues = new List<double>();
        public RollingPointPairList ringBuffer = new RollingPointPairList(500);
        public LineItem curve;
        public int lineID = 0;
        public Color lineColor;
        public double timeStamp = 0; // USED BY ALL INSTANCES
        public List<double> recordedTime = new List<double>(); // USED BY ALL INSTANCES
        public string[] splittedData; // USED BY ALL INSTANCES

        public Channel(int ID)
        {
            lineID = ID;
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
