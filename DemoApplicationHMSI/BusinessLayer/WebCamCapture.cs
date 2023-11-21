using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DemoApplicationHMSI.BusinessLayer
{
    [Designer("Sytem.Windows.Forms.Design.ParentControlDesigner,System.Design", typeof(IDesigner))]
    [ToolboxBitmap(typeof(WebCamCapture), "CAMERA.ICO")]
    public class WebCamCapture : UserControl
    {
        public delegate void WebCamEventHandler(object source, WebcamEventArgs e);

        public const int WM_USER = 1024;

        public const int WM_CAP_CONNECT = 1034;

        public const int WM_CAP_DISCONNECT = 1035;

        public const int WM_CAP_GET_FRAME = 1084;

        public const int WM_CAP_COPY = 1054;

        public const int WM_CAP_START = 1024;

        public const int WM_CAP_DLG_VIDEOFORMAT = 1065;

        public const int WM_CAP_DLG_VIDEOSOURCE = 1066;

        public const int WM_CAP_DLG_VIDEODISPLAY = 1067;

        public const int WM_CAP_GET_VIDEOFORMAT = 1068;

        public const int WM_CAP_SET_VIDEOFORMAT = 1069;

        public const int WM_CAP_DLG_VIDEOCOMPRESSION = 1070;

        public const int WM_CAP_SET_PREVIEW = 1074;

        private IContainer components;

        private Timer timer1;

        private int m_TimeToCapture_milliseconds = 100;

        private int m_Width = 320;

        private int m_Height = 240;

        private int mCapHwnd;

        private ulong m_FrameNumber = 0uL;

        private WebcamEventArgs x = new WebcamEventArgs();

        private IDataObject tempObj;

        private Image tempImg;

        private bool bStopped = true;

        public int TimeToCapture_milliseconds
        {
            get
            {
                return m_TimeToCapture_milliseconds;
            }
            set
            {
                m_TimeToCapture_milliseconds = value;
            }
        }

        public int CaptureHeight
        {
            get
            {
                return m_Height;
            }
            set
            {
                m_Height = value;
            }
        }

        public int CaptureWidth
        {
            get
            {
                return m_Width;
            }
            set
            {
                m_Width = value;
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

        public event WebCamEventHandler ImageCaptured;

        [DllImport("user32")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        [DllImport("avicap32.dll")]
        public static extern int capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int X, int Y, int nWidth, int nHeight, int hwndParent, int nID);

        [DllImport("user32")]
        public static extern int OpenClipboard(int hWnd);

        [DllImport("user32")]
        public static extern int EmptyClipboard();

        [DllImport("user32")]
        public static extern int CloseClipboard();

        public WebCamCapture()
        {
            InitializeComponent();
        }

        ~WebCamCapture()
        {
            Stop();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            timer1.Tick += new System.EventHandler(timer1_Tick);
            base.Name = "WebCamCapture";
            base.Size = new System.Drawing.Size(342, 252);
            base.Load += new System.EventHandler(WebCamCapture_Load);
        }

        public void Start(ulong FrameNum)
        {
            try
            {
                Stop();
                mCapHwnd = capCreateCaptureWindowA("WebCap", 0, 0, 0, m_Width, m_Height, base.Handle.ToInt32(), 0);
                Application.DoEvents();
                SendMessage(mCapHwnd, 1034u, 0, 0);
                SendMessage(mCapHwnd, 1074u, 0, 0);
                m_FrameNumber = FrameNum;
                timer1.Interval = m_TimeToCapture_milliseconds;
                bStopped = false;
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error ocurred while starting the video capture. Check that your webcamera is connected properly and turned on.\r\n\n" + ex.Message);
                Stop();
            }
        }

        public void Stop()
        {
            try
            {
                bStopped = true;
                timer1.Stop();
                Application.DoEvents();
                SendMessage(mCapHwnd, 1035u, 0, 0);
            }
            catch (Exception)
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                SendMessage(mCapHwnd, 1084u, 0, 0);
                SendMessage(mCapHwnd, 1054u, 0, 0);
                if (this.ImageCaptured != null)
                {
                    tempObj = Clipboard.GetDataObject();
                    tempImg = (Bitmap)tempObj.GetData(DataFormats.Bitmap);
                    x.WebCamImage = tempImg.GetThumbnailImage(m_Width, m_Height, null, IntPtr.Zero);
                    this.ImageCaptured(this, x);
                }

                Application.DoEvents();
                if (!bStopped)
                {
                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error ocurred while capturing the video image. The video capture will now be terminated.\r\n\n" + ex.Message);
                Stop();
            }
        }

        private void WebCamCapture_Load(object sender, EventArgs e)
        {
        }

        public void Config()
        {
            SendMessage(mCapHwnd, 1065u, 0, 0);
        }

        public void Config2()
        {
            SendMessage(mCapHwnd, 1066u, 0, 0);
        }
    }
}
