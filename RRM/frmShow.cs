using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QLCF
{
    public partial class frmShow : Form
    {
        BusinessLayer.Ban table = new BusinessLayer.Ban();
        List<string> tableid = new List<string>();
        List<string> tablestt = new List<string>();
        DevComponents.DotNetBar.ButtonX[] btnArray;
        int a;
        string role;
        DataTable dt;
        public frmShow(string ro)
        {
            InitializeComponent();
            //var timer = new Timer();
            //timer.Tick += new EventHandler(timer1_Tick);
            //timer.Interval = 5000; //5 seconds
            //timer.Start();
            role = ro;
        }

        public void load_table()
        {
            dt = table.Load_BanID();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            dt = null;
            tablestt.Clear();
            tableid.Clear();
            load_table();
            a = dt.Rows.Count;
            btnArray = null;
            foreach (DataRow row in dt.Rows)
            {
                tableid.Add(row["ID"].ToString());
                tablestt.Add(row["Status"].ToString());
            }
            AddButtons();
        }

        private void AddButtons()
        {
            int xPos = 0;
            int yPos = 3;
            // Declare and assign number of buttons = 26 
            btnArray = new DevComponents.DotNetBar.ButtonX[a];
            // Create (26) Buttons: 
            for (int i = 0; i < a; i++)
            {
                // Initialize one variable 
                btnArray[i] = new DevComponents.DotNetBar.ButtonX();
            }
            int n = 0;

            while (n < a)
            {
                btnArray[n].Tag = n + 1; // Tag of button 
                btnArray[n].Width = 110; // Width of button 
                btnArray[n].Height = 90; // Height of button 
                if (n == 10) // Location of second line of buttons: 
                {
                    xPos = 0;
                    yPos = 97;
                }
                if (n == 20) // Location of second line of buttons: 
                {
                    xPos = 0;
                    yPos = 194;
                }
                if (n == 30) // Location of second line of buttons: 
                {
                    xPos = 0;
                    yPos = 289;
                }
                if (n == 40) // Location of second line of buttons: 
                {
                    xPos = 0;
                    yPos = 386;
                }
                // Location of button: 
                btnArray[n].Left = xPos;
                btnArray[n].Top = yPos;
                btnArray[n].Font = new Font(btnArray[n].Font.Name, btnArray[n].Font.Size, FontStyle.Bold); ;
               
                // Add buttons to a Panel: 
                //btnArray[n].FlatStyle = System.Windows.Forms.FlatStyle.Popup;

                if (tablestt[n] == "False")
                {
                    btnArray[n].Image = Image.FromFile("users.ico");
                    btnArray[n].ImageFixedSize = new System.Drawing.Size(50, 50);
                }
                else
                {
                    btnArray[n].Image = Image.FromFile("red_chair.ico");
                    btnArray[n].ImageFixedSize = new System.Drawing.Size(50, 50);
                }

               // btnArray[n].UseVisualStyleBackColor = false;
                this.Controls.Add(btnArray[n]); // Let panel hold the Buttons 
                xPos = xPos + btnArray[n].Width + 5; // Left of next button 
                // Write English Character: 
                btnArray[n].Text = tableid[n].ToString();

   
                btnArray[n].Click += new System.EventHandler(ClickButton);
                n++;

            }
            

        }
        public void removectrl()
        {
            int d = 0;
            while (d < a)
            {
                this.Controls.Remove(btnArray[d]);
            }
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

        public void ClickButton(Object sender, System.EventArgs e)
        {
            if (!this.IsLoaded("frmGoiMon"))
            {
                DevComponents.DotNetBar.ButtonX btn = (DevComponents.DotNetBar.ButtonX)sender;
                frmGoiMon goi = new frmGoiMon(btn.Text, role);
                goi.MdiParent = this.ParentForm;
                goi.Show();
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Form1_Load(sender, e);
        }

        private void frmShow_FormClosing(object sender, FormClosingEventArgs e)
        {
           // timer1.Stop();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
    }
}
