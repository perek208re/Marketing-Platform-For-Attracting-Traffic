namespace Spam
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnOpenEmailSpam = new System.Windows.Forms.Button();
            this.btnOpenTelegramSpam = new System.Windows.Forms.Button();
            this.databaseDataSet1 = new Spam.DatabaseDataSet1();
            this.таблицаBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.таблицаTableAdapter = new Spam.DatabaseDataSet1TableAdapters.ТаблицаTableAdapter();
            this.tableAdapterManager = new Spam.DatabaseDataSet1TableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.таблицаBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenEmailSpam
            // 
            this.btnOpenEmailSpam.Location = new System.Drawing.Point(12, 12);
            this.btnOpenEmailSpam.Name = "btnOpenEmailSpam";
            this.btnOpenEmailSpam.Size = new System.Drawing.Size(276, 124);
            this.btnOpenEmailSpam.TabIndex = 0;
            this.btnOpenEmailSpam.Text = "Email spam";
            this.btnOpenEmailSpam.UseVisualStyleBackColor = true;
            this.btnOpenEmailSpam.Click += new System.EventHandler(this.btnOpenEmailSpam_Click);
            // 
            // btnOpenTelegramSpam
            // 
            this.btnOpenTelegramSpam.Location = new System.Drawing.Point(294, 12);
            this.btnOpenTelegramSpam.Name = "btnOpenTelegramSpam";
            this.btnOpenTelegramSpam.Size = new System.Drawing.Size(276, 124);
            this.btnOpenTelegramSpam.TabIndex = 1;
            this.btnOpenTelegramSpam.Text = "Telegram spam";
            this.btnOpenTelegramSpam.UseVisualStyleBackColor = true;
            this.btnOpenTelegramSpam.Click += new System.EventHandler(this.btnOpenTelegramSpam_Click);
            // 
            // databaseDataSet1
            // 
            this.databaseDataSet1.DataSetName = "DatabaseDataSet1";
            this.databaseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // таблицаBindingSource
            // 
            this.таблицаBindingSource.DataMember = "Таблица";
            this.таблицаBindingSource.DataSource = this.databaseDataSet1;
            // 
            // таблицаTableAdapter
            // 
            this.таблицаTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = Spam.DatabaseDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.ТаблицаTableAdapter = this.таблицаTableAdapter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 145);
            this.Controls.Add(this.btnOpenTelegramSpam);
            this.Controls.Add(this.btnOpenEmailSpam);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.таблицаBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenEmailSpam;
        private System.Windows.Forms.Button btnOpenTelegramSpam;
        private DatabaseDataSet1 databaseDataSet1;
        private System.Windows.Forms.BindingSource таблицаBindingSource;
        private DatabaseDataSet1TableAdapters.ТаблицаTableAdapter таблицаTableAdapter;
        private DatabaseDataSet1TableAdapters.TableAdapterManager tableAdapterManager;
    }
}

