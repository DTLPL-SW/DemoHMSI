using System;
using System.Drawing;

namespace DemoApplicationHMSI.BusinessLayer
{
    public class WebcamEventArgs : EventArgs
    {
        private Image m_Image;

        private ulong m_FrameNumber = 0uL;

        public Image WebCamImage
        {
            get
            {
                return m_Image;
            }
            set
            {
                m_Image = value;
            }
        }

        public ulong FrameNumber
        {
            get
            {
                return m_FrameNumber;
            }
            set
            {
                m_FrameNumber = value;
            }
        }
    }
}
