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
        public LineItem curve;
        public int lineID = 0;
        public Color lineColor;
        public RollingPointPairList ringBuffer = new RollingPointPairList(500);
        public double timeStamp = 0;
        public string measured_data;

        public Channel(int ID)
        {
            lineID = ID;
        }
        public void clearOnStart()
        {
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
                ringBuffer.Add(timeStamp / 1000, Convert.ToDouble(measured_data));
            }
            catch
            {
                ringBuffer.Add(timeStamp / 1000, 0);
            }
        }
    }
}
