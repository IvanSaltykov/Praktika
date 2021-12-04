using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAsynchMethod_4_
{
    public partial class Form1 : Form
    {
        private delegate int AsyncSumm(int a, int b);
        public Form1()
        {
            InitializeComponent();
        }

        private int Summ(int a, int b)
        {
            System.Threading.Thread.Sleep(9000);
            return a + b;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            int a, b;
            try
            {
                a = Int32.Parse(txbA.Text);
                b = Int32.Parse(txbB.Text);
            }
            catch
            {
                MessageBox.Show("При выполнение преобразований типов возникла ошибка");
            }
            txbA.Text = txbB.Text = "";
            return;
            AsyncSumm summdelegate = new AsyncSumm(Summ);
            AsyncCallback cd = new AsyncCallback(CallBackMethod);
            summdelegate.BeginInvoke(a, b, cd, summdelegate);
        }
        private void CallBackMethod(IAsyncResult ar)
        {
            string str;
            AsyncSumm summdelegate = (AsyncSumm)ar.AsyncState;
            str = String.Format("Сумма введенных чисел равна {0}", summdelegate.EndInvoke(ar));
            MessageBox.Show(str, "Результат отношений");
        }

        private void btnWork_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Работа кипит!!!!!!!!!!!");
        }

        private void help_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace);
        }
    }
}
