using System;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace QLCF
{
    public partial class frmExport : Form
    {
        BusinessLayer.ThongKe thongke = new BusinessLayer.ThongKe();

        public DataTable dt;
        string title = "";
        public string quyen = "";
        public frmExport()
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
        Microsoft.Office.Interop.Excel.Workbooks oBooks;
        Microsoft.Office.Interop.Excel.Sheets oSheets;
        Microsoft.Office.Interop.Excel.Workbook oBook;
        Microsoft.Office.Interop.Excel.Worksheet oSheet;
        public void ExportToExcel(DataTable dt, string sheetName, string title, bool newsheet, int sheetid,int item)
        {

            if (!newsheet) check_process_Excel();
            //Tạo các đối tượng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            if (!newsheet)
            {
                //Tạo mới một Excel WorkBook 
                oExcel.Visible = true;
                oExcel.DisplayAlerts = false;
                oExcel.Application.SheetsInNewWorkbook = sheetid;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;

                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.Add(Type.Missing, oBook.Worksheets[oBook.Worksheets.Count], Type.Missing, Type.Missing);
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(item);
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
                cl3.ColumnWidth = 25;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
                cl4.Value2 = "SUB-TOTAL";
                cl4.ColumnWidth = 22;

                Microsoft.Office.Interop.Excel.Range c15 = oSheet.get_Range("E3", "E3");
                c15.Value2 = "Service";
                c15.ColumnWidth = 0;

                Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
                cl6.Value2 = "Delivery";
                cl6.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range c17 = oSheet.get_Range("G3", "G3");
                c17.Value2 = "Discount Food";
                c17.ColumnWidth = 22;

                Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
                cl8.Value2 = "Discount Drink";
                cl8.ColumnWidth = 22;

                Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");
                cl9.Value2 = "TOTAL";
                cl9.ColumnWidth = 15;


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
            else
            {
                //oExcel.Visible = true;
                //oExcel.DisplayAlerts = false;
                //oExcel.Application.SheetsInNewWorkbook = sheetid;
                //oBooks = oExcel.Workbooks;

                //oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                //oSheets = oBook.Worksheets;

                //oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.Add();
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(item);
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
                cl3.ColumnWidth = 25;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
                cl4.Value2 = "SUB-TOTAL";
                cl4.ColumnWidth = 22;

                Microsoft.Office.Interop.Excel.Range c15 = oSheet.get_Range("E3", "E3");
                c15.Value2 = "Service";
                c15.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
                cl6.Value2 = "Delivery";
                cl6.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range c17 = oSheet.get_Range("G3", "G3");
                c17.Value2 = "Discount Food";
                c17.ColumnWidth = 22;

                Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
                cl8.Value2 = "Discount Drink";
                cl8.ColumnWidth = 22;

                Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");
                cl9.Value2 = "TOTAL";
                cl9.ColumnWidth = 15;


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
            //oExcel.ActiveWorkbook.SaveCopyAs(@"C:\Intel\" + DateTime.Now.AddDays(-1).Day.ToString().PadLeft(2, '0') + "-" + DateTime.Now.AddDays(-1).Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.AddDays(-1).Year.ToString().PadLeft(2, '0') + ".xls");
        }

        public void ExportToExcelFile(DataTable dt, string sheetName, string title, bool newsheet, int sheetid,DateTime ngay)
        {

            if (!newsheet) check_process_Excel();
            //Tạo các đối tượng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            if (!newsheet)
            {
                //Tạo mới một Excel WorkBook 
                oExcel.Visible = false;
                oExcel.DisplayAlerts = false;
                oExcel.Application.SheetsInNewWorkbook = sheetid;
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
                cl3.ColumnWidth = 25;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
                cl4.Value2 = "SUB-TOTAL";
                cl4.ColumnWidth = 22;

                Microsoft.Office.Interop.Excel.Range c15 = oSheet.get_Range("E3", "E3");
                c15.Value2 = "Service";
                c15.ColumnWidth = 0;

                Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
                cl6.Value2 = "Delivery";
                cl6.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range c17 = oSheet.get_Range("G3", "G3");
                c17.Value2 = "Discount Food";
                c17.ColumnWidth = 22;

                Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
                cl8.Value2 = "Discount Drink";
                cl8.ColumnWidth = 22;

                Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");
                cl9.Value2 = "TOTAL";
                cl9.ColumnWidth = 15;


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
            oExcel.ActiveWorkbook.SaveCopyAs(@"C:\Logs\" + ngay.Day.ToString().PadLeft(2, '0') + "-" + ngay.Month.ToString().PadLeft(2, '0') + "-" + ngay.Year.ToString().PadLeft(2, '0') + ".xls");
            check_process_Excel();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DialogResult h = new DialogResult();
            h = MessageBox.Show("Are you sure print report " + dtpDate.Text + "?!", "Messages", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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

                    tkng.PrintToPrinter(1, false, 0, 0);

                }
                if (cbbThongKe.Text == "Bill")
                {
                    ThongKeNgayCrytalReportBill tkt = new ThongKeNgayCrytalReportBill();
                    tkt.SetDataSource(thongke.merge(thongke.Load_TKNgay(ngay, thang, nam), thongke.Load_TKMonNgay_Ser(ngay, thang, nam)));
                    ThongKeCrystalReportViewer.ReportSource = tkt;
                    ThongKeCrystalReportViewer.Refresh();

                    tkt.PrintToPrinter(1, false, 0, 0);
                }


            }
            //if (quyen == "1")
            //{
            //    h = MessageBox.Show("Are you sure DELETE database date  " + dtpDate.Text + "?!", "Messages", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //    if (h.ToString() == "OK")
            //    {
            //        thongke.LamMoi();
            //    }
            //}

        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            cbbThongKe.SelectedIndex = 0;
            //btnExport.Enabled = false;
            //btnThongKe.Enabled = false;
            Load_Thang();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dtpTodate.Value.Date < dtpDate.Value.Date)
            {
                MessageBox.Show("Please ! Check again From Date and To Date!"); return;
            }
            if (dtpTodate.Value.AddDays(-5) > dtpDate.Value.Date)
            {
                MessageBox.Show("Please ! Select Maximum in 5 days!"); return;
            }
            string title = "";
            try
            {
                DateTime date = dtpDate.Value;
                bool newsheet = false;
                int sheetid = 1, item = 1;

                //tinh ngay
                TimeSpan span = dtpTodate.Value - dtpDate.Value;
                if (span.Days > 0) sheetid = span.Days;
                do
                {
                    double t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0;
                    //string ngay = dtpDate.Text.Substring(0, 2);
                    //string thang = dtpDate.Text.Substring(3, 2);
                    //string nam = dtpDate.Text.Substring(6, 4);
                    string ngay = date.Day.ToString();
                    string thang = date.Month.ToString();
                    string nam = date.Year.ToString();
                    if (cbbThongKe.Text == "Bill" || cbbThongKe.Text == "Menu")
                    {

                        dt = thongke.Load_EXNgay(ngay, thang, nam);
                        if (dt.Rows.Count == 0)
                        {
                            date = date.AddDays(1);
                            continue;
                        }
                        foreach (DataRow r in dt.Rows)
                        {
                            t3 += double.Parse(r[3].ToString() == "" ? "0" : r[3].ToString());
                            t4 += double.Parse(r[4].ToString() == "" ? "0" : r[4].ToString());
                            t5 += double.Parse(r[5].ToString() == "" ? "0" : r[5].ToString());
                            t6 += double.Parse(r[6].ToString() == "" ? "0" : r[6].ToString());
                            t7 += double.Parse(r[7].ToString() == "" ? "0" : r[7].ToString());
                            t8 += double.Parse(r[8].ToString() == "" ? "0" : r[8].ToString());
                        }
                        DataRow rownew = dt.NewRow();

                        rownew["Date"] = "TOTAL";
                        rownew["Amounti"] = t3.ToString();
                        rownew["Service"] = t4.ToString();
                        rownew["Delivery"] = t5.ToString();
                        rownew["MFood"] = t6.ToString();
                        rownew["MDrink"] = t7.ToString();
                        rownew["Total"] = t8.ToString();
                        dt.Rows.Add(rownew);

                    }
                    if (cbbThongKe.Text == "Month")
                    {
                        dt = thongke.Load_EXThang(thang, nam);

                    }
                    if (cbbThongKe.Text == "Year")
                    {
                        dt = thongke.Load_EXNam(nam);

                    }
                    title = "[HOIAN]-DAILY REPORT - " + ngay + "/" + thang + "/" + nam;

                    ExportToExcel(dt, "" + ngay + "." + thang + "." + nam, title, newsheet, sheetid + 1, item);

                    date = date.AddDays(1);
                    newsheet = true; item++;
                    Thread.Sleep(800);
                }
                while (date.Date < dtpTodate.Value.Date.AddDays(1));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry ! Micosoft Excel in corrupt ! \n'" + ex.ToString() + "' ", "SYSTEM");//
            }
            if (dtpDate.Value.Date != dtpTodate.Value.Date)
                title = " From date'" + dtpDate.Text + "' to date '" + dtpTodate.Text + "'";
            else
                title = " date '" + dtpDate.Text + "'";
            //if (quyen == "1")
            //{
            //    DialogResult h = new DialogResult();
            //    h = MessageBox.Show("Are you sure DELETE database \n" + title + "?!", "Messages", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //    if (h.ToString() == "OK")
            //    {
            //        thongke.LamMoi(dtpDate.Value, dtpTodate.Value);
            //        thongke.Reset_ID();
            //        MessageBox.Show("Successful !");
            //    }
            //}

        }

        private void cbbThongKe_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //btnExport.Enabled = true;
            //btnThongKe.Enabled = true;
            //btnpre.Enabled = true;
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
                ThongKeCrystalReportViewer.Refresh();


            }
            if (cbbThongKe.Text == "Bill")
            {
                ThongKeNgayCrytalReportBill tkt = new ThongKeNgayCrytalReportBill();
                tkt.SetDataSource(thongke.merge(thongke.Load_TKNgay(ngay, thang, nam), thongke.Load_TKMonNgay_Ser(ngay, thang, nam)));
                ThongKeCrystalReportViewer.ReportSource = tkt;
                ThongKeCrystalReportViewer.Refresh();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

        }

        public void ExportFile(DateTime ngayin)
        {
            DateTime date = ngayin;
            bool newsheet = false;
            int sheetid = 1;
            string title = "";
            double t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0;
            //string ngay = dtpDate.Text.Substring(0, 2);
            //string thang = dtpDate.Text.Substring(3, 2);
            //string nam = dtpDate.Text.Substring(6, 4);
            string ngay = date.Day.ToString();
            string thang = date.Month.ToString();
            string nam = date.Year.ToString();
            dt = thongke.Load_EXNgay(ngay, thang, nam);
            foreach (DataRow r in dt.Rows)
            {
                t3 += double.Parse(r[3].ToString());
                t4 += double.Parse(r[4].ToString());
                t5 += double.Parse(r[5].ToString());
                t6 += double.Parse(r[6].ToString());
                t7 += double.Parse(r[7].ToString());
                t8 += double.Parse(r[8].ToString());
            }
            DataRow rownew = dt.NewRow();

            rownew["Date"] = "TOTAL";
            rownew["Amounti"] = t3.ToString();
            rownew["Service"] = t4.ToString();
            rownew["Delivery"] = t5.ToString();
            rownew["MFood"] = t6.ToString();
            rownew["MDrink"] = t7.ToString();
            rownew["Total"] = t8.ToString();
            dt.Rows.Add(rownew);

            title = "[HOIAN]-DAILY REPORT - " + ngay + "/" + thang + "/" + nam;

            ExportToExcelFile(dt, "[HOIAN]-DAILY REPORT", title, newsheet, sheetid, ngayin);



        }

        public void ResetID()
        {
            thongke.Reset_ID();
        }
        public void Delete(DateTime date)
        {
            thongke.LamMoi(date, date);
            //thongke.LamMoi(date);
        }

        public void Lammoi()
        {
            thongke.LamMoi();
        }

        public void Reset_ID()
        {
            thongke.Reset_ID();
        }

        public void Load_Thang()
        {
            string txt = "";
            DataTable dttable = thongke.Load_NgaychuaExport();
            foreach (DataRow r in dttable.Rows)
            {
                txt += r["Ngay"].ToString() + "\n";
            }
            lblngay.Text = txt;
        }

        public void XoaThang()
        {
            DataTable dttable = thongke.Load_NgaychuaExport();
            if (dttable.Rows.Count <=2 ) return;
            thongke.LamMoi();
        }

        private void btnpre_Click_1(object sender, EventArgs e)
        {
            string title = "", title_delete = "";
            try
            {
                DateTime date = dtpDate.Value;
                bool newsheet = false;
                int item = 1;

                DataTable dtdate = thongke.Load_NgaychuaExport();
                int sheetid = dtdate.Rows.Count + 1;

                foreach (DataRow dr in dtdate.Rows)
                {
                    title_delete += dr["Ngay"].ToString() + " \n ";
                    double t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0;
                    string ngay = dr["Ngay"].ToString().Substring(0, 2);
                    string thang = dr["Ngay"].ToString().Substring(3, 2);
                    string nam = dr["Ngay"].ToString().Substring(6, 4);
                    if (cbbThongKe.Text == "Bill" || cbbThongKe.Text == "Menu")
                    {

                        dt = thongke.Load_EXNgay(ngay, thang, nam);
                        if (dt.Rows.Count == 0)
                        {
                            date = date.AddDays(1);
                            continue;
                        }
                        foreach (DataRow r in dt.Rows)
                        {
                            t3 += double.Parse(r[3].ToString() == "" ? "0" : r[3].ToString());
                            t4 += double.Parse(r[4].ToString() == "" ? "0" : r[4].ToString());
                            t5 += double.Parse(r[5].ToString() == "" ? "0" : r[5].ToString());
                            t6 += double.Parse(r[6].ToString() == "" ? "0" : r[6].ToString());
                            t7 += double.Parse(r[7].ToString() == "" ? "0" : r[7].ToString());
                            t8 += double.Parse(r[8].ToString() == "" ? "0" : r[8].ToString());
                        }
                        DataRow rownew = dt.NewRow();

                        rownew["Date"] = "TOTAL";
                        rownew["Amounti"] = t3.ToString();
                        rownew["Service"] = t4.ToString();
                        rownew["Delivery"] = t5.ToString();
                        rownew["MFood"] = t6.ToString();
                        rownew["MDrink"] = t7.ToString();
                        rownew["Total"] = t8.ToString();
                        dt.Rows.Add(rownew);

                    }
                    //if (cbbThongKe.Text == "Month")
                    //{
                    //    dt = thongke.Load_EXThang(thang, nam);

                    //}
                    //if (cbbThongKe.Text == "Year")
                    //{
                    //    dt = thongke.Load_EXNam(nam);
                    //}
                    title = "DAILY REPORT - " + ngay + "/" + thang + "/" + nam;

                    ExportToExcel(dt, "" + ngay + "." + thang + "." + nam, title, newsheet, sheetid + 1, item);

                    date = date.AddDays(1);
                    Thread.Sleep(800);
                    newsheet = true; item++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry ! Micosoft Excel in corrupt! \n'" + ex.ToString() + "' ", "GANESH");
            }
            //if (quyen == "1")
            //{
            //    if (dtpDate.Value.Date != dtpTodate.Value.Date)
            //        title = " From date'" + dtpDate.Text + "' to date '" + dtpTodate.Text + "'";
            //    else
            //        title = " date '" + dtpDate.Text + "'";
            //    DialogResult h = new DialogResult();
            //    h = MessageBox.Show("Are you sure DELETE ALL data in date \n" + title_delete + "?!", "Messages", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //    if (h.ToString() == "OK")
            //    {
            //        thongke.LamMoi();
            //        thongke.Reset_ID();
            //        MessageBox.Show("Successful !");
            //    }
            //}
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
