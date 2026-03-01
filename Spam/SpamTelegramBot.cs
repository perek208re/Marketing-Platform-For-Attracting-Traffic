using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot.Types;

namespace Spam
{
    public partial class SpamTelegramBot : Form
    {
        private WatsonPlus bot;
        public SpamTelegramBot()
        {
            InitializeComponent();
        }
        private List<string> allColumns = new List<string>();

        private void таблицаBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.таблицаBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.databaseDataSet1);

        }

        private void SpamTelegramBot_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet1.Таблица". При необходимости она может быть перемещена или удалена.
            this.таблицаTableAdapter.Fill(this.databaseDataSet1.Таблица);
            {
                checkedListBox1.Items.Clear(); // Очищення перед додаванням


                foreach (DataTable table in databaseDataSet1.Tables)
                {
                    if (table.Columns.Count > 7)
                    {
                        for (int i = 7; i < table.Columns.Count-1; i++)
                        {
                            checkedListBox1.Items.Add($"{table.Columns[i].ColumnName}");
                            allColumns.Add(table.Columns[i].ColumnName);
                        }

                    }
                }


            }
        }
   

        private void таблицаBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
           
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.ToString() != "")
            {
                List<string> selectedColumns = new List<string>();
                List<string> filteredData = new List<string>();

                foreach (var item in checkedListBox1.CheckedItems)
                {
                    selectedColumns.Add(item.ToString());
                }
                foreach (DataRow row in databaseDataSet1.Таблица.Rows)
                {
                    bool match = false;

                    foreach (string column in selectedColumns)
                    {

                        if (row[column] is bool value && value)
                        {
                            match = true;
                            break;
                        }
                    }

                    if (match)
                    {
                        if (row[6].ToString() != "")
                            filteredData.Add(row[6].ToString());
                    }
                }
                foreach (string column in filteredData)
                {
                    long number = long.Parse(column);
                    Main.Instance?.SendMes(number, richTextBox1.Text.ToString());
                }
            }
            else  MessageBox.Show("Не можливо відправити пусте повідомлення!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public  void newClient(int number, string ID)
        {

            if (number >= 0 && number < databaseDataSet1.Таблица.Rows.Count)
            {
                databaseDataSet1.Таблица.Rows[--number]["Номер телефону"] = ID; 
            }
            else
            {
                checkedListBox1.Items.Clear();
            }
            Validate();
            таблицаBindingSource.EndEdit();
            tableAdapterManager.UpdateAll(databaseDataSet1);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
