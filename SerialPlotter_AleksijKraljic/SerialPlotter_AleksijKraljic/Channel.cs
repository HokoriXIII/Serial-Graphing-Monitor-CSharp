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
        public List<string> recordedValues = new List<string>();        
        public LineItem curve;
        public int lineID = 0;
        public Color lineColor;
        public RollingPointPairList ringBuffer = new RollingPointPairList(500);
        public double timeStamp = 0;
        public List<double> recordedTime = new List<double>();
        public string[] splittedData;

        public Channel(int ID)
        {
            lineID = ID;
        }
        public void recordData()
        {
            recordedTime.Add(timeStamp);
            try
            {
                recordedValues.Add(splittedData[lineID]);
            }
            catch 
            {
                recordedValues.Add("X");
            }
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
            try
            {
                ringBuffer.Add(timeStamp / 1000, Convert.ToDouble(splittedData[lineID]));
            }
            catch
            {
                ringBuffer.Add(timeStamp / 1000, 0);
            }
        }
    }
}
