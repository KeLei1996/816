using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SVGFormTest
{
	[System.Runtime.InteropServices.ComVisibleAttribute(true)]
	public partial class Form1 : Form
	{
       
		public Form1()
		{ 
			InitializeComponent();
            //ScriptMessageManager.Instance.SetWebbrowser(webBrowser1);

            //ScriptMessageManager.SwitchClick += On_SwitchClick;
            webBrowser1.ObjectForScripting = this;
		}

		private void 弹框ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			object[] objects = new object[1];
			this.webBrowser1.Document.InvokeScript("OnClick_function", objects);
		}

		public void WindowsF(String mess)
		{
			MessageBox.Show("ID:"+mess+"已经闭合");          
		}
        public void WindowsD(String mess)
        {
            String ID = mess;
            this.webBrowser1.Document.InvokeScript("FindID_function", new string[] { ID });
            MessageBox.Show("ID:" + mess + "已经变红");

        }
        public bool openI()
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定打开开关吗?", "打开开关", messButton);
            if (dr == DialogResult.OK) { return true; }
            else { return false; }
        }
		public void On_SwitchClick(object sender)
		{
			MessageBox.Show(sender.ToString());
		}

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object[] objects = new object[1];
            this.webBrowser1.Document.InvokeScript("ConnectFloor_function", objects);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void  iD检索ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ISVGForm f = new Form1();
            //f.SwitchClose("102001");
            SwitchClose("102001");
            String PM = Microsoft.VisualBasic.Interaction.InputBox("请输入相应设备的ID号以执行相应设备的相关动作", "输入ID号", "", 100, 100);
            String ID =  PM ;
            this.webBrowser1.Document.InvokeScript("FindId_function",new string[]{ID});
            //ISVGForm f = new Form1();
            //
            
            // if (PM != "123456")
            //{
            //    MessageBox.Show("请输入正确的密码谢谢！！！！！");             
            //}

        }

       

        private void iD回复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String PM = Microsoft.VisualBasic.Interaction.InputBox("请输入相应设备的ID号以执行相应设备的相关动作", "输入ID号", "", 100, 100);
            String ID = PM;
            this.webBrowser1.Document.InvokeScript("BackId_function", new string[] { ID });
        }


        //开关打开，只需输入相应隔离开关ID以实现
        void SwitchOpen(String id)
        {
            this.webBrowser1.Document.InvokeScript("BackId_function", new string[] { id });
        }
        //开关闭合，只需输入相应隔离开关ID以实现
        void SwitchClose(String id)
        {         
            this.webBrowser1.Document.InvokeScript("FindId_function", new string[] {id} );
        }
        //断路器打开，只需输入相应断路器ID以实现
        void CircuitBreakerOpen(String id)
        {
            this.webBrowser1.Document.InvokeScript("FindId_function", new string[] { id });
        }
        //断路器关闭，只需输入相应断路器ID以实现
        void CircuitBreakerClose(String id)
        {
            //this.webBrowser1.Document.InvokeScript("BackId_function", new string[] { id });
        }
    }
}
