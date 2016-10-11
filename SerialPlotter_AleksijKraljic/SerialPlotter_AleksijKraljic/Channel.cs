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
        // Properties
        public LineItem curve { get; set; }
        public int lineID { get; set; }
        public Color lineColor { get; set; }

        public RollingPointPairList ringBuffer;
        public double timeStamp { get; set; }
        public string measured_data { get; set; }

        // Methods
        public Channel(int ID, Int32 bufferSize)
        {
            lineID = ID;
            ringBuffer = new RollingPointPairList(bufferSize);
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
