using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spam
{
    public partial class Main : Form
    {
        public static Main Instance { get; private set; }
        private WatsonPlus bot;
        string APIkey = "token";

        public Main()
        {
            InitializeComponent();
            Instance = this;
        }

        // Метод для запуску бота в окремому потоці
        private void StartBot()
        {
                Task.Run(() => bot.Start());
                Console.WriteLine("Bot started.");
        
        }

        private void btnOpenEmailSpam_Click(object sender, EventArgs e)
        {
            SpamEmail spamEmail = new SpamEmail();
            spamEmail.Show();
        }

        private void btnOpenTelegramSpam_Click(object sender, EventArgs e)
        {
            SpamTelegramBot spamTelegram = new SpamTelegramBot();
            spamTelegram.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.таблицаTableAdapter.Fill(this.databaseDataSet1.Таблица);
            bot = new WatsonPlus(APIkey, this); // Передаємо поточний Main
            StartBot();
        }


        private void таблицаBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.таблицаBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.databaseDataSet1);

        }
      
      public bool newClient(int number, string ID)
      {
            if (this.databaseDataSet1.Таблица.Rows[--number]["Номер телефону"] == null)
            {
                if (number >= 0 && number < this.databaseDataSet1.Таблица.Rows.Count)
                {
                    this.databaseDataSet1.Таблица.Rows[--number]["Номер телефону"] = ID;
                }
                else

                    this.Validate();
                this.таблицаBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.databaseDataSet1);
                return true;
            }
               return false;
      }
        public void SendMes(long number, string Text)
        {
            bot.SendCustomMessageAsync(number, Text);
        }
    }
}
