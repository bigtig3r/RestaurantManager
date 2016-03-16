using System;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace QLCF
{
    public partial class frmThongKe : Form
    {
        BusinessLayer.ThongKe thongke = new BusinessLayer.ThongKe();
        BusinessLayer.QuanTri quantri = new BusinessLayer.QuanTri();

        public DataTable dt;
        string title = "";
        public string quyen = "";
        public frmThongKe()
        {
            InitializeComponent();
        }
        public bool getban()
        {
            bool kq = true;
            DataTable dt = thongke.Load_chuathanhtoan();
            if (dt.Rows.Count >= 1)
                kq = false;
            return kq;

        }
        public void check_process_Excel()
        {
            Process[] processes = Process.GetProcesses();
            if (processes.Length > 1)
            {
                int num = 0;
                for (int i = 0; i <= (processes.Length - 1); i++)
                {
                    if (processes[i].ProcessName == "EXCEL")
                    {
                        num++;
                        processes[i].Kill();
                    }
                }
            }
        }

        public void ExportToExcel(DataTable dt, string sheetName, string title)
        {
            check_process_Excel();
            //Tạo các đối tượng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetName;

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "F1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Bill ID";
            cl1.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range c12 = oSheet.get_Range("B3", "B3");
            c12.Value2 = "Table";
            c12.ColumnWidth = 13.5;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Date";
            cl3.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "SUB-TOTAL";
            cl4.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range c15 = oSheet.get_Range("E3", "E3");
            c15.Value2 = "Service";
            c15.ColumnWidth = 8;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "Delivery";
            cl6.ColumnWidth = 8;

            Microsoft.Office.Interop.Excel.Range c17 = oSheet.get_Range("G3", "G3");
            c17.Value2 = "Discount Food";
            c17.ColumnWidth = 8;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "Discount Drink";
            cl8.ColumnWidth = 8;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");
            cl9.Value2 = "TOTAL";
            cl9.ColumnWidth = 10;

           
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "I3");
            rowHead.Font.Bold = true;
            // Kẻ viền
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < dt.Rows.Count; r++)
            {

                DataRow dr = dt.Rows[r];
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    arr[r, c] = dr[c];
                }
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = dt.Columns.Count;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;

            // Kẻ viền
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Căn giữa cột STT
            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];
            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);
            oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

        }
        int i = 0;
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DialogResult h = new DialogResult();
            h = MessageBox.Show("Are you sure print " + cbbThongKe.Text + " report " + dtpDate.Text + "?!", "Messages", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (h.ToString() == "OK")
            {

                if (!getban())
                {
                    MessageBox.Show("Sorry ! Have table not payment and print bill !", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string ngay = dtpDate.Text.Substring(0, 2);
                string thang = dtpDate.Text.Substring(3, 2);
                string nam = dtpDate.Text.Substring(6, 4);
                if (cbbThongKe.Text == "Menu")
                {
                    ThongKeNgayCrystalReport tkng = new ThongKeNgayCrystalReport();
                    tkng.SetDataSource(thongke.merge(thongke.Load_TKMonNgay(ngay, thang, nam), thongke.Load_TKMonNgay_Ser(ngay, thang, nam)));
                    ThongKeCrystalReportViewer.ReportSource = tkng;
                    ThongKeCrystalReportViewer.Refresh();

                    PrinterSettings settings = new PrinterSettings();
                    tkng.PrintOptions.PrinterName = settings.PrinterName;

                    tkng.PrintToPrinter(1, false, 0, 0);
                    lblStatus.Text = "You have printed report Menu !";
                    i++;
                    if (i == 2)
                    {
                        //DeleteData(dtpDate.Value);
                        email_send(dtpDate.Value);
                        //DeleteXLS();

                    }


                }
                if (cbbThongKe.Text == "Bill")
                {
                    ThongKeNgayCrytalReportBill tkt = new ThongKeNgayCrytalReportBill();
                    tkt.SetDataSource(thongke.merge(thongke.Load_TKNgay(ngay, thang, nam), thongke.Load_TKMonNgay_Ser(ngay, thang, nam)));
                    ThongKeCrystalReportViewer.ReportSource = tkt;
                    ThongKeCrystalReportViewer.Refresh();

                    PrinterSettings settings = new PrinterSettings();
                    tkt.PrintOptions.PrinterName = settings.PrinterName;

                    tkt.PrintToPrinter(1, false, 0, 0);
                    lblStatus.Text = "You have printed report Bill !";
                    i++;
                    if (i == 2)
                    {
                        //DeleteData(dtpDate.Value);
                        email_send(dtpDate.Value);
                        //DeleteXLS();
                    }
                    

                }


            }
            //if (quyen == "1")
            //{
            //    h = MessageBox.Show("Are you sure DELETE database date  " + dtpDate.Text + "?!", "Messages", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //    if (h.ToString() == "OK")
            //    {
            //        thongke.LamMoi();
            //        //thongke.Reset_ID();
            //    }
            //}

        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            btnExport.Enabled = false;
            btnThongKe.Enabled = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string ngay = dtpDate.Text.Substring(0, 2);
            string thang = dtpDate.Text.Substring(3, 2);
            string nam = dtpDate.Text.Substring(6, 4);
            if (cbbThongKe.Text == "Bill" || cbbThongKe.Text == "Menu")
            {

                dt = thongke.Load_EXNgay(ngay, thang, nam);


            }
            if (cbbThongKe.Text == "Month")
            {
                dt = thongke.Load_EXThang(thang, nam);

            }
            if (cbbThongKe.Text == "Year")
            {
                dt = thongke.Load_EXNam(nam);

            }
            ExportToExcel(dt, "DAILY REPORT", "INCOME REPORT - " + ngay + "/" + thang + "/" + nam);
        }

        private void cbbThongKe_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnExport.Enabled = true;
            btnThongKe.Enabled = true;
            btnpre.Enabled = true;
        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            string ngay = dtpDate.Text.Substring(0, 2);
            string thang = dtpDate.Text.Substring(3, 2);
            string nam = dtpDate.Text.Substring(6, 4);
            if (cbbThongKe.Text == "Menu")
            {
                ThongKeNgayCrystalReport tkng = new ThongKeNgayCrystalReport();
                tkng.SetDataSource(thongke.merge(thongke.Load_TKMonNgay(ngay, thang, nam), thongke.Load_TKMonNgay_Ser(ngay, thang, nam)));
                ThongKeCrystalReportViewer.ReportSource = tkng;
                ThongKeCrystalReportViewer.ShowPrintButton = false;
                ThongKeCrystalReportViewer.Refresh();

            }
            if (cbbThongKe.Text == "Bill")
            {
                ThongKeNgayCrytalReportBill tkt = new ThongKeNgayCrytalReportBill();
                tkt.SetDataSource(thongke.merge(thongke.Load_TKNgay(ngay, thang, nam), thongke.Load_TKMonNgay_Ser(ngay, thang, nam)));
                ThongKeCrystalReportViewer.ReportSource = tkt;
                ThongKeCrystalReportViewer.ShowPrintButton = false;
                ThongKeCrystalReportViewer.Refresh();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

        }
        public void DeleteData(DateTime ngay)
        {
            string name = @"C:/Logs/" + DateTime.Now.Day.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Year + ".txt";
            try
            {
                string path = "C:/Logs/" + ngay.Day.ToString().PadLeft(2, '0') + "-" + ngay.Month.ToString().PadLeft(2, '0') + "-" + ngay.Year + ".xls";
                if (!System.IO.Directory.Exists("C:/Logs/"))
                    System.IO.Directory.CreateDirectory("C:/Logs/");

                frmExport frm = new frmExport();
                frm.ExportFile(ngay);
                frm.Delete(ngay);
                frm.Dispose();

                if (File.Exists(name))
                    File.Delete(name);
                Thread.Sleep(2000);
                Application.DoEvents();
                lblStatus.Text = "Delete Data Successful ! ";
            }
            catch
            {
                string name2 = @"C:/Logs/" + DateTime.Now.Day.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Year + ".txt";
                File.CreateText(name2);
                lblStatus.Text = "Delete False !";
                MessageBox.Show("Please ! Restart Application ! Thank you !");
            }
        }
        public void email_send(DateTime ngay)
        {
            if (quantri.YourEmail == "" || quantri.ToEmail == "") return;
            if (!PingTest())
            {
                lblStatus.Text = "Please ! Check Connect with Internet and Restart Application ! Thank you !";
                string name2 = @"C:/Logs/" + DateTime.Now.Day.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Year + ".txt";
                if (!File.Exists(name2))
                    File.CreateText(name2);
                return;
            }
            lblStatus.Text = "Sending Email........Waiting...";
            string name = @"C:/Logs/" + DateTime.Now.Day.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Year + ".txt";
            //if (File.Exists(@"C:/Logs/ok.txt")) return;
            try
            {
                string path = "C:/Logs/" + ngay.Day.ToString().PadLeft(2, '0') + "-" + ngay.Month.ToString().PadLeft(2, '0') + "-" + ngay.Year + ".xls";
                if (!System.IO.Directory.Exists("C:/Logs/"))
                    System.IO.Directory.CreateDirectory("C:/Logs/");

                //export file
                frmExport frm = new frmExport();
                frm.ExportFile(ngay);
                //goi mail

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(quantri.YourEmail);
                mail.To.Add(quantri.ToEmail);
                mail.Subject = "GANGES RESTAURANT - DAILY  REPORT - '" + ngay.Date.ToShortDateString() + "'";
                mail.Body = "GANGES RESTAURANT - DAILY REPORT - '" + ngay.Date.ToShortDateString() + "'";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(path);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(quantri.YourEmail, quantri.Pass);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                lblStatus.Text = "Send Successful ! ";
                frm.Delete(ngay);
                frm.Dispose();
                lblStatus.Text = "Delete Data Successful ! ";

                if (File.Exists(name))
                    File.Delete(name);
                Thread.Sleep(2000);
                Application.DoEvents();
                lblStatus.Text = "Send Successful ! Thank you !";
            }
            catch
            {
                string name2 = @"C:/Logs/" + DateTime.Now.Day.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Year + ".txt";
                File.CreateText(name2);
                lblStatus.Text = "Send False !";
                MessageBox.Show("Please ! Check Connect with Internet and Restart Application ! Thank you !");
            }

        }

        public void DeleteXLS()
        {
            try
            {
                DirectoryInfo NewDir = new DirectoryInfo("C:/Logs/");
                FileInfo[] files = NewDir.GetFiles("*.xls");
                foreach (var item in files)
                {
                    string strFile = "C:/Logs/" + "\\" + item.ToString();
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                    }
                }
            }
            catch { }
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

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
    }
}
