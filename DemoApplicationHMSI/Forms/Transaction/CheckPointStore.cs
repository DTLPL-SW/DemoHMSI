using AForge.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using DemoApplicationHMSI.BusinessLayer;
using DemoApplicationHMSI.DataLayer;
using DTPLLogs;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DemoApplicationHMSI.Forms.Transaction
{
    public partial class CheckPointStore : Form
    {
        DataTable dtPostData = new DataTable();
        WinFormCharpWebCam webcam;
        int iCellIndex = 0;
        DL_CheckPointList obj = new DL_CheckPointList();
        public CheckPointStore()
        {
            InitializeComponent();
            dtPostData = new DataTable();
            dtPostData.Columns.Add("Location", typeof(string));
            dtPostData.Columns.Add("SNO", typeof(int));
            dtPostData.Columns.Add("CheckingPoint", typeof(string));
            dtPostData.Columns.Add("CheckingMethod", typeof(string));
            dtPostData.Columns.Add("StandardValue", typeof(string));
            dtPostData.Columns.Add("Freq", typeof(string));
            dtPostData.Columns.Add("ActualValue", typeof(string));
            dtPostData.Columns.Add("Judge", typeof(string));
            dtPostData.Columns.Add("ActionPlan", typeof(string));
            dtPostData.Columns.Add("Remarks", typeof(string));
            dtPostData.Columns.Add("ImageData", typeof(byte[]));
            pnlCaptureImage.Visible = false;
            getListCameraUSB();
        }
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;
        private VideoCapabilities[] snapshotCapabilities;
        private ArrayList listCamera = new ArrayList();
        public string pathFolder = Application.StartupPath + @"\ImageCapture\";
        private Stopwatch stopWatch = null;
        private static bool needSnapshot = false;
        private static string _usbcamera;
        public string usbcamera
        {
            get { return _usbcamera; }
            set { _usbcamera = value; }
        }

        private void OpenCamera()
        {
            try
            {
                usbcamera = cmbCamra.SelectedIndex.ToString();
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count != 0)
                {
                    if (listCamera.Count == 0)
                    {
                        // add all devices to combo
                        foreach (FilterInfo device in videoDevices)
                        {
                            listCamera.Add(device.Name);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Camera devices found");
                }
                videoDevice = new VideoCaptureDevice(videoDevices[Convert.ToInt32(usbcamera)].MonikerString);
                snapshotCapabilities = videoDevice.SnapshotCapabilities;
                if (snapshotCapabilities.Length == 0)
                {
                    //MessageBox.Show("Camera Capture Not supported");
                }
                OpenVideoSource(videoDevice);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }//Delegate Untuk Capture, insert database, update ke grid 
        public delegate void CaptureSnapshotManifast(Bitmap image);
        public void UpdateCaptureSnapshotManifast(Bitmap image)
        {
            try
            {
                needSnapshot = false;
                imgCam.Image = image;
                imgCam.Update();
                string namaImage = "sampleImage";
                string nameCapture = namaImage + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bmp";
                if (Directory.Exists(pathFolder))
                {
                    imgCam.Image.Save(pathFolder + nameCapture, ImageFormat.Png);
                }
                else
                {
                    Directory.CreateDirectory(pathFolder);
                    imgCam.Image.Save(pathFolder + nameCapture, ImageFormat.Png);
                }
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    if (i == iCellIndex)
                    {
                        dgvData.Rows[i].Cells[10].Value = Bitmap.FromFile(pathFolder + nameCapture);
                        pnlCaptureImage.Visible = false;                       
                    }
                }
            }
            catch { }
        }
        public void OpenVideoSource(IVideoSource source)
        {
            try
            {
                // set busy cursor
                this.Cursor = Cursors.WaitCursor;
                // stop current video source
                CloseCurrentVideoSource();
                // start new video source
                videoSourcePlayer1.VideoSource = source;
                videoSourcePlayer1.Start();
                // reset stop watch
                stopWatch = null;
                this.Cursor = Cursors.Default;
            }
            catch { }
        }
        private void getListCameraUSB()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count != 0)
            {
                // add all devices to combo
                foreach (FilterInfo device in videoDevices)
                {
                    cmbCamra.Items.Add(device.Name);
                }
            }
            else
            {
                cmbCamra.Items.Add("No DirectShow devices found");
            }
            cmbCamra.SelectedIndex = 0;
        }
        public void CloseCurrentVideoSource()
        {
            try
            {
                if (videoSourcePlayer1.VideoSource != null)
                {
                    videoSourcePlayer1.SignalToStop();
                    // wait ~ 3 seconds
                    for (int i = 0; i < 30; i++)
                    {
                        if (!videoSourcePlayer1.IsRunning)
                            break;
                        System.Threading.Thread.Sleep(100);
                    }
                    if (videoSourcePlayer1.IsRunning)
                    {
                        videoSourcePlayer1.Stop();
                    }
                    videoSourcePlayer1.VideoSource = null;
                }
            }
            catch { }
        }
        private void videoSourcePlayer1_NewFrame_1(object sender, ref Bitmap image)
        {
            try
            {
                DateTime now = DateTime.Now;
                Graphics g = Graphics.FromImage(image);
                // paint current time
                SolidBrush brush = new SolidBrush(Color.Red);
                g.DrawString(now.ToString(), this.Font, brush, new PointF(5, 5));
                brush.Dispose();
                if (needSnapshot)
                {
                    this.Invoke(new CaptureSnapshotManifast(UpdateCaptureSnapshotManifast), image);
                }
                g.Dispose();
            }
            catch
            { }
        }

        public void BindCheckPointList()
        {
            try
            {
                DataTable dt = obj.BINDDATA();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvData.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(),
                            dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString()
                            , dt.Rows[i][5].ToString(), "", "", ""
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseCurrentVideoSource();
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtPostData.Rows.Clear();
            dgvData.Rows.Clear();
            BindCheckPointList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.Rows.Count == 0)
                {
                    blCommon.ShowMessage("No data found to save, Please contact admin",2);
                    return;
                }
                if (string.IsNullOrEmpty(txtRemarks.Text))
                {
                    blCommon.ShowMessage("Please enter remarks", 2);
                    txtRemarks.Focus(); 
                    return;
                }
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    if (dgvData.Rows[i].Cells[6].Value.ToString().Length > 0)
                    {
                        DataRow dr = dtPostData.NewRow();
                        dr[0] = dgvData.Rows[i].Cells[0].Value;
                        dr[1] = dgvData.Rows[i].Cells[1].Value;
                        dr[2] = dgvData.Rows[i].Cells[2].Value;
                        dr[3] = dgvData.Rows[i].Cells[3].Value;
                        dr[4] = dgvData.Rows[i].Cells[4].Value;
                        dr[5] = dgvData.Rows[i].Cells[5].Value;
                        dr[6] = dgvData.Rows[i].Cells[6].Value;
                        dr[7] = dgvData.Rows[i].Cells[7].Value;
                        dr[8] = dgvData.Rows[i].Cells[8].Value;
                        dr[9] = txtRemarks.Text;
                        if (dgvData.Rows[i].Cells[7].Value.ToString() == "Having Problem")
                        {
                            byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(dgvData.Rows[i].Cells[10].Value, typeof(byte[]));
                            dr[10] = bytes;
                        }
                        dtPostData.Rows.Add(dr);
                    }
                }
                DataTable dtSaveData = obj.SaveData(dtPostData,txtMachineNo.Text,txtmachineName.Text,txtLineCode.Text);
                if (dtSaveData.Rows.Count > 0)
                {
                    blCommon.ShowMessage(dtSaveData.Rows[0][0].ToString(),2);
                    dtPostData.Rows.Clear();
                    dgvData.Rows.Clear();
                    BindCheckPointList();
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void CheckPointStore_Load(object sender, EventArgs e)
        {
            try
            {
                BindCheckPointList();
                //if (webcam == null)
                //{
                //    webcam = new WinFormCharpWebCam();
                //    webcam.InitializeWebCam(ref imgCam);
                //}
                
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvData.Rows.Count > 0)
                {
                    if (e.ColumnIndex == 9)
                    {
                        pnlCaptureImage.Visible = true;
                        iCellIndex = e.RowIndex;
                        OpenCamera();
                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (dgvData.Rows.Count > 0)
                //{
                //    if (dgvData.Rows[e.RowIndex].Cells[6].Value.ToString() == "Having problem")
                //    {
                //        blCommon.ShowMessage("1", 2);
                //    }
                //}
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void btnCapImage_Click(object sender, EventArgs e)
        {
            try
            {
                needSnapshot = true;
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    if (i == iCellIndex)
                    {
                        dgvData.Rows[i].Cells[10].Value = imgCam.Image;
                        pnlCaptureImage.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }
    }
}
