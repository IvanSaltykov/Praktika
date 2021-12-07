using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDB_3_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        DataView ЗаказчикиDataView;
        private void button1_Click(object sender, EventArgs e)
        {

            oleDbDataAdapter1.Fill(productDataSet1.Заказчики);
            // Загрузка таблицы данными:
            заказчикиTableAdapter1.Fill(productDataSet1.Заказчики);
            // Настройка объекта DataView
            ЗаказчикиDataView = new
            DataView(productDataSet1.Заказчики);
            // Настройка dataGridView для отображения данных
            dataGridView1.DataSource = ЗаказчикиDataView;
            // Присвоения исходного порядка сортировки
            ЗаказчикиDataView.Sort = "Фамилия";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            oleDbDataAdapter1.Update(productDataSet1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ЗаказчикиDataView.Sort = SortTextBox.Text;
            ЗаказчикиDataView.RowFilter = FilterTextBox.Text;
        }
    }
}
