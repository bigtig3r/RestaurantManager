using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using BusinessLayer;
using System.IO;


namespace QLCF
{
    public partial class frmMain : Form
    {
        string role = "";
        BusinessLayer.QuanTri quantri = new BusinessLayer.QuanTri();
        BusinessLayer.ThongKe tk = new BusinessLayer.ThongKe();
        public frmMain()
        {
            InitializeComponent();
           
        }
        Timer timer;
        public frmMain(string quyen)
        {
            InitializeComponent();
            role = quyen;
            //timer = new Timer();
            //timer.Tick += new EventHandler(timer1_Tick);
            //timer.Interval = 1000; //1 seconds
            //timer.Start();
        }
        public void check_quyen()
        {
            if (role == "2")
            {
                btTaiKhoan.Enabled = false;
                btDMBan.Enabled = false;
                btThucDon.Enabled = false;
                btnMenuType.Enabled = false;
                //bnFind.Enabled = false;
                //tabReport.Visible = false;
            }

        }
        public void closeUC()
        {
            this.Close();
        }

        private bool IsLoaded(string frm)
        {
            Form[] mdiChildren = base.MdiChildren;
            foreach (Form form in mdiChildren)
            {
                if (form.Name.Equals(frm))
                {
                    form.Activate();
                    return true;
                }
            }
            return false;
        }

        private bool IsClose(string frm)
        {
            Form[] mdiChildren = base.MdiChildren;
            foreach (Form form in mdiChildren)
            {
                if (form.Name.Equals(frm))
                {
                    form.Close();
                    return true;
                }
            }
            return false;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            check_quyen();
            btScreen_Click(sender, e);
            if (PingTest())
            {
                for (DateTime date = DateTime.Now.AddDays(-1); date.Date <= DateTime.Now.Date; date = date.AddDays(1))
                {
                    email_send(date);
                }
            }
            DeleteFile();
        }

        public void XoaNgay()
        {
            try
            {
                frmExport frm = new frmExport();
                frm.XoaThang();
                frm.Dispose();
            }
            catch
            {

            }
        }
        public bool PingTest()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();

            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("208.69.34.231"), 1000);

            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void email_send(DateTime ngayin)
        {
            string name_old = @"C:/Logs/" + ngayin.Day.ToString().PadLeft(2, '0') + "-" + ngayin.Month.ToString().PadLeft(2, '0') + "-" + ngayin.Year + ".txt";//ngay 13
            //string name = @"C:/Logs/" + DateTime.Now.Day.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Year + ".txt";//ngayin 14
            #region
            //if (File.Exists(name))
            //{
            //    try
            //    {
            //        string path = "C:/Logs/" + DateTime.Now.Day.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Year + ".xls";
            //        if (!System.IO.Directory.Exists("C:/Logs/"))
            //            System.IO.Directory.CreateDirectory("C:/Logs/");

            //        //export file
            //        frmExport frm = new frmExport();
            //        frm.ExportFile(DateTime.Now);
            //        //goi mail

            //        MailMessage mail = new MailMessage();
            //        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            //        mail.From = new MailAddress(quantri.YourEmail);
            //        mail.To.Add(quantri.ToEmail);
            //        mail.Subject = "GANESH RESTAURANT - DAILY  REPORT - '" + DateTime.Now.ToShortDateString() + "'";
            //        mail.Body = "GANESH RESTAURANT - DAILY REPORT - '" + DateTime.Now.ToShortDateString() + "'";

            //        System.Net.Mail.Attachment attachment;
            //        attachment = new System.Net.Mail.Attachment(path);
            //        mail.Attachments.Add(attachment);

            //        SmtpServer.Port = 587;
            //        SmtpServer.Credentials = new System.Net.NetworkCredential(quantri.YourEmail, quantri.Pass);
            //        SmtpServer.EnableSsl = true;

            //        SmtpServer.Send(mail);

            //        frm.Delete(DateTime.Now);
            //        frm.Dispose();
            //        if (File.Exists(name))
            //            File.Delete(name);
            //        return;
            //    }
            //    catch
            //    {
            //        File.CreateText(name);
            //        return;
            //    }
            //}
#endregion
            if (File.Exists(name_old))
            {
                try
                {
                    string path = "C:/Logs/" + ngayin.Day.ToString().PadLeft(2, '0') + "-" + ngayin.Month.ToString().PadLeft(2, '0') + "-" + ngayin.Year + ".xls";
                    if (!System.IO.Directory.Exists("C:/Logs/"))
                        System.IO.Directory.CreateDirectory("C:/Logs/");

                    //export file
                    frmExport frm = new frmExport();
                    frm.ExportFile(ngayin);
                    //goi mail

                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress(quantri.YourEmail);
                    mail.To.Add(quantri.ToEmail);
                    mail.Subject = "GANGES RESTAURANT - DAILY  REPORT - '" + ngayin.ToShortDateString() + "'";
                    mail.Body = "GANGES RESTAURANT - DAILY REPORT - '" + ngayin.ToShortDateString() + "'";

                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(path);
                    mail.Attachments.Add(attachment);

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(quantri.YourEmail, quantri.Pass);
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);

                    frm.Delete(ngayin);
                    frm.Dispose();
                    if (File.Exists(name_old))
                        File.Delete(name_old);
                }
                catch
                {
                    File.CreateText(name_old);
                }
            }
        }
     
        private void btDMBan_Click(object sender, EventArgs e)
        {
            if (!this.IsLoaded("frmBan"))
            {
                frmBan ban = new frmBan();
                ban.MdiParent = this;
                ban.Show();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult h = new DialogResult();
            h = MessageBox.Show("Are you ready Exit Application ?!", "Messages", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (h.ToString() == "OK")
            {
                Application.Exit();
            }
        }

        private void btThucDon_Click(object sender, EventArgs e)
        {
            if (!this.IsLoaded("frmThucDon"))
            {
                frmThucDon td = new frmThucDon();
                td.MdiParent = this;
                td.Show();
            }
        }

        private void btnDoiBan_Click(object sender, EventArgs e)
        {
            if (!this.IsLoaded("frmDoiBan"))
            {
                frmDoiBan doi = new frmDoiBan();
                doi.MdiParent = this;
                doi.Show();
            }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            if (!this.IsLoaded("frmHoaDon"))
            {
                frmHoaDon hd = new frmHoaDon();
                hd.MdiParent = this;
                hd.Show();
            }
        }

        private void btnNhapHoaDon_Click(object sender, EventArgs e)
        {
            if (!this.IsLoaded("frmGoiMon"))
            {
                frmGoiMon goi = new frmGoiMon();
                goi.MdiParent = this;
                goi.Show();
            }
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult h = new DialogResult();
            h = MessageBox.Show("Are you ready Logout ?", "Messages", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (h.ToString() == "OK")
            {
                frmLogin f = new frmLogin();
                f.Show();
                this.Hide();
                role = "";
            }
        }

        private void btTaiKhoan_Click(object sender, EventArgs e)
        {
            if (!this.IsLoaded("frmTaiKhoan"))
            {
                frmUser tk = new frmUser(role);
                tk.MdiParent = this;
                tk.Show();
            }
        }

        private void btTroGiup_Click(object sender, EventArgs e)
        {
            if (!this.IsLoaded("frmHelp"))
            {
                //frmHelp he = new frmHelp();
                //he.Show();
            }
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            if (!this.IsLoaded("frmThongKe"))
            {
                frmThongKe tk = new frmThongKe();
                tk.quyen = role;
                tk.MdiParent = this;
                tk.Show();
            }
        }

        private void bnFind_Click(object sender, EventArgs e)
        {
            if (!this.IsLoaded("frmFind"))
            {
                frmFind find = new frmFind();
                find.MdiParent = this;
                find.Show();
            }
        }

        private void btnMenuType_Click(object sender, EventArgs e)
        {
            if (!this.IsLoaded("frmType"))
            {
                frmType ty = new frmType();
                ty.MdiParent = this;
                ty.Show();
            }
        }

        private void btScreen_Click(object sender, EventArgs e)
        {
            if (this.IsLoaded("frmGoiMon"))
            {
                IsClose("frmGoiMon");
            }
            if (!this.IsLoaded("frmShow"))
            {
                frmShow ty2 = new frmShow(role);
                ty2.MdiParent = this;
                ty2.Show();

            }           

        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (this.IsLoaded("frmShow"))
            {
                IsClose("frmShow");
            }
            if (!this.IsLoaded("frmMerge"))
            {

                frmMerge ty = new frmMerge();
                ty.MdiParent = this;
                ty.Show();
            }
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            if (!this.IsLoaded("frmExport"))
            {
                frmExport tk = new frmExport();
                tk.quyen = role;
                tk.MdiParent = this;
                tk.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (DateTime.Now.ToString() == date.ToString())
            //{
            //    email_send();
            //    timer.Stop();
            //}
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                //DialogResult h = new DialogResult();
                //h = MessageBox.Show("Are you ready Exit ?", "Messages", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                //if (h.ToString() != "OK") { return; }

                //DirectoryInfo NewDir = new DirectoryInfo("C:/Logs/");
                //FileInfo[] files = NewDir.GetFiles("*.xls");
                //foreach (var item in files)
                //{
                //    string strFile = "C:/Logs/" + "\\" + item.ToString();
                //    if (File.Exists(strFile))
                //    {
                //        File.Delete(strFile);
                //    }
                //}

                Process[] processes = Process.GetProcesses();
                if (processes.Length > 1)
                {
                    int num = 0;
                    for (int i = 0; i <= (processes.Length - 1); i++)
                    {
                        if (processes[i].ProcessName == "QLCF")
                        {
                            num++;
                            processes[i].Kill();
                        }
                    }
                }

            }
            catch
            {

            }
        }
        void DeleteFile()
        {
            try
            {
                DirectoryInfo NewDir = new DirectoryInfo("C:/Logs/");
                FileInfo[] files = NewDir.GetFiles("*.xls");
                foreach (var item in files)
                {
                    string strFile = "C:/Logs/" + item.ToString();
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                    }
                }
            }
            catch { }
        }
    }
    public class Extend
    {
        private static string thongbao = "";
        public static void ShowProcess(string _thongbao)
        {
            //try
            //{
            //    Extend.thongbao = _thongbao;
            //    //Extend.frmProg = new FrmProcess();
            //    BackgroundWorker backgroundWorker = new BackgroundWorker();
            //    backgroundWorker.DoWork += new DoWorkEventHandler(Extend.brProg_DoWork);
            //    backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Extend.brProg_RunWorkerCompleted);
            //    backgroundWorker.RunWorkerAsync(Extend.frmProg);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private static void brProg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //try
            //{
            //    ((FrmProcess)e.Result).CloseForm();
            //    ((BackgroundWorker)sender).Dispose();
            //}
            //catch
            //{
            //}
        }
        private static void brProg_DoWork(object sender, DoWorkEventArgs e)
        {
            //try
            //{
            //    Extend.frmProg.SetTextStatus(Extend.thongbao);
            //    ((FrmProcess)e.Argument).ShowDialog();
            //    e.Result = e.Argument;
            //}
            //catch
            //{
            //}
        }
        public static void ClosProcess()
        {
            //try
            //{
            //    if (Extend.frmProg != null)
            //    {
            //        Extend.frmProg.CloseForm();
            //    }
            //}
            //catch
            //{
            //}
        }
    }
}

