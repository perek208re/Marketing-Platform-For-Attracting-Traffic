namespace Spam
{
    partial class SpamEmail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbIncomeToCompare = new System.Windows.Forms.TextBox();
            this.cbTypeIncomeComparison = new System.Windows.Forms.ComboBox();
            this.lbIncome = new System.Windows.Forms.Label();
            this.tbSexToCompare = new System.Windows.Forms.ComboBox();
            this.lbAge = new System.Windows.Forms.Label();
            this.tbAgeToCompare = new System.Windows.Forms.TextBox();
            this.cbTypeAgeComparison = new System.Windows.Forms.ComboBox();
            this.lbSex = new System.Windows.Forms.Label();
            this.chlbFilterOptions = new System.Windows.Forms.CheckedListBox();
            this.btnLoadFromTxtFile = new System.Windows.Forms.Button();
            this.lbMessage = new System.Windows.Forms.Label();
            this.richtbMessage = new System.Windows.Forms.RichTextBox();
            this.btnShareToSelected = new System.Windows.Forms.Button();
            this.btnShareToAll = new System.Windows.Forms.Button();
            this.таблицаDataGridView = new System.Windows.Forms.DataGridView();
            this.databaseDataSet1 = new Spam.DatabaseDataSet1();
            this.таблицаBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.таблицаTableAdapter = new Spam.DatabaseDataSet1TableAdapters.ТаблицаTableAdapter();
            this.tableAdapterManager = new Spam.DatabaseDataSet1TableAdapters.TableAdapterManager();
            this.кодDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.пІБDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.вікDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.статьDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.еmailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.середнійДохідDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номерТелефонуDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.косметикаПісляГолінняДляЧоловіківDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.аксесуариДляВанниТаДушуDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.антибактеріальніЗасобиDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.аксесуариДляМакіяжуDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.капціЧоловічіDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.капціЖіночіDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.чоловічіПарфумиDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.косметикаДляОбличчяDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.оглядДляОбличчяDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.шампуньDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.засмагаТаЗахістВідСонцяDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.гельДляВмиванняDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.зубнаПастаDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.бонусніБалиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.таблицаDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.таблицаBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbIncomeToCompare);
            this.panel1.Controls.Add(this.cbTypeIncomeComparison);
            this.panel1.Controls.Add(this.lbIncome);
            this.panel1.Controls.Add(this.tbSexToCompare);
            this.panel1.Controls.Add(this.lbAge);
            this.panel1.Controls.Add(this.tbAgeToCompare);
            this.panel1.Controls.Add(this.cbTypeAgeComparison);
            this.panel1.Controls.Add(this.lbSex);
            this.panel1.Controls.Add(this.chlbFilterOptions);
            this.panel1.Controls.Add(this.btnLoadFromTxtFile);
            this.panel1.Controls.Add(this.lbMessage);
            this.panel1.Controls.Add(this.richtbMessage);
            this.panel1.Controls.Add(this.btnShareToSelected);
            this.panel1.Controls.Add(this.btnShareToAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 144);
            this.panel1.TabIndex = 0;
            // 
            // tbIncomeToCompare
            // 
            this.tbIncomeToCompare.Location = new System.Drawing.Point(549, 102);
            this.tbIncomeToCompare.Name = "tbIncomeToCompare";
            this.tbIncomeToCompare.Size = new System.Drawing.Size(78, 20);
            this.tbIncomeToCompare.TabIndex = 14;
            this.tbIncomeToCompare.Text = "27500";
            // 
            // cbTypeIncomeComparison
            // 
            this.cbTypeIncomeComparison.FormattingEnabled = true;
            this.cbTypeIncomeComparison.Items.AddRange(new object[] {
            ">",
            "<",
            "="});
            this.cbTypeIncomeComparison.Location = new System.Drawing.Point(498, 101);
            this.cbTypeIncomeComparison.Name = "cbTypeIncomeComparison";
            this.cbTypeIncomeComparison.Size = new System.Drawing.Size(45, 21);
            this.cbTypeIncomeComparison.TabIndex = 13;
            this.cbTypeIncomeComparison.Text = ">";
            // 
            // lbIncome
            // 
            this.lbIncome.AutoSize = true;
            this.lbIncome.Location = new System.Drawing.Point(457, 105);
            this.lbIncome.Name = "lbIncome";
            this.lbIncome.Size = new System.Drawing.Size(35, 13);
            this.lbIncome.TabIndex = 12;
            this.lbIncome.Text = "Дохід";
            // 
            // tbSexToCompare
            // 
            this.tbSexToCompare.FormattingEnabled = true;
            this.tbSexToCompare.Items.AddRange(new object[] {
            "ч",
            "ж"});
            this.tbSexToCompare.Location = new System.Drawing.Point(498, 47);
            this.tbSexToCompare.Name = "tbSexToCompare";
            this.tbSexToCompare.Size = new System.Drawing.Size(129, 21);
            this.tbSexToCompare.TabIndex = 10;
            this.tbSexToCompare.Text = "ч";
            // 
            // lbAge
            // 
            this.lbAge.AutoSize = true;
            this.lbAge.Location = new System.Drawing.Point(457, 77);
            this.lbAge.Name = "lbAge";
            this.lbAge.Size = new System.Drawing.Size(22, 13);
            this.lbAge.TabIndex = 9;
            this.lbAge.Text = "Вік";
            // 
            // tbAgeToCompare
            // 
            this.tbAgeToCompare.Location = new System.Drawing.Point(549, 74);
            this.tbAgeToCompare.Name = "tbAgeToCompare";
            this.tbAgeToCompare.Size = new System.Drawing.Size(78, 20);
            this.tbAgeToCompare.TabIndex = 8;
            this.tbAgeToCompare.Text = "10";
            // 
            // cbTypeAgeComparison
            // 
            this.cbTypeAgeComparison.FormattingEnabled = true;
            this.cbTypeAgeComparison.Items.AddRange(new object[] {
            ">",
            "<",
            "="});
            this.cbTypeAgeComparison.Location = new System.Drawing.Point(498, 74);
            this.cbTypeAgeComparison.Name = "cbTypeAgeComparison";
            this.cbTypeAgeComparison.Size = new System.Drawing.Size(45, 21);
            this.cbTypeAgeComparison.TabIndex = 7;
            this.cbTypeAgeComparison.Text = ">";
            // 
            // lbSex
            // 
            this.lbSex.AutoSize = true;
            this.lbSex.Location = new System.Drawing.Point(456, 50);
            this.lbSex.Name = "lbSex";
            this.lbSex.Size = new System.Drawing.Size(36, 13);
            this.lbSex.TabIndex = 6;
            this.lbSex.Text = "Стать";
            // 
            // chlbFilterOptions
            // 
            this.chlbFilterOptions.FormattingEnabled = true;
            this.chlbFilterOptions.Items.AddRange(new object[] {
            "стать",
            "вік",
            "середній дохід"});
            this.chlbFilterOptions.Location = new System.Drawing.Point(657, 32);
            this.chlbFilterOptions.Name = "chlbFilterOptions";
            this.chlbFilterOptions.Size = new System.Drawing.Size(138, 49);
            this.chlbFilterOptions.TabIndex = 5;
            // 
            // btnLoadFromTxtFile
            // 
            this.btnLoadFromTxtFile.Location = new System.Drawing.Point(300, 3);
            this.btnLoadFromTxtFile.Name = "btnLoadFromTxtFile";
            this.btnLoadFromTxtFile.Size = new System.Drawing.Size(138, 23);
            this.btnLoadFromTxtFile.TabIndex = 4;
            this.btnLoadFromTxtFile.Text = "Load from .txt file";
            this.btnLoadFromTxtFile.UseVisualStyleBackColor = true;
            this.btnLoadFromTxtFile.Click += new System.EventHandler(this.btnLoadFromTxtFile_Click);
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Location = new System.Drawing.Point(11, 8);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(79, 13);
            this.lbMessage.TabIndex = 3;
            this.lbMessage.Text = "Повідомлення";
            // 
            // richtbMessage
            // 
            this.richtbMessage.Location = new System.Drawing.Point(11, 32);
            this.richtbMessage.Name = "richtbMessage";
            this.richtbMessage.Size = new System.Drawing.Size(427, 107);
            this.richtbMessage.TabIndex = 2;
            this.richtbMessage.Text = "";
            // 
            // btnShareToSelected
            // 
            this.btnShareToSelected.Location = new System.Drawing.Point(657, 87);
            this.btnShareToSelected.Name = "btnShareToSelected";
            this.btnShareToSelected.Size = new System.Drawing.Size(142, 23);
            this.btnShareToSelected.TabIndex = 1;
            this.btnShareToSelected.Text = "Share to selected";
            this.btnShareToSelected.UseVisualStyleBackColor = true;
            this.btnShareToSelected.Click += new System.EventHandler(this.btnShareToSelected_Click);
            // 
            // btnShareToAll
            // 
            this.btnShareToAll.Location = new System.Drawing.Point(657, 116);
            this.btnShareToAll.Name = "btnShareToAll";
            this.btnShareToAll.Size = new System.Drawing.Size(138, 23);
            this.btnShareToAll.TabIndex = 0;
            this.btnShareToAll.Text = "Share to all";
            this.btnShareToAll.UseVisualStyleBackColor = true;
            this.btnShareToAll.Click += new System.EventHandler(this.btnShareToAll_Click);
            // 
            // таблицаDataGridView
            // 
            this.таблицаDataGridView.AutoGenerateColumns = false;
            this.таблицаDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.таблицаDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.кодDataGridViewTextBoxColumn,
            this.пІБDataGridViewTextBoxColumn,
            this.вікDataGridViewTextBoxColumn,
            this.статьDataGridViewTextBoxColumn,
            this.еmailDataGridViewTextBoxColumn,
            this.середнійДохідDataGridViewTextBoxColumn,
            this.номерТелефонуDataGridViewTextBoxColumn,
            this.косметикаПісляГолінняДляЧоловіківDataGridViewCheckBoxColumn,
            this.аксесуариДляВанниТаДушуDataGridViewCheckBoxColumn,
            this.антибактеріальніЗасобиDataGridViewCheckBoxColumn,
            this.аксесуариДляМакіяжуDataGridViewCheckBoxColumn,
            this.капціЧоловічіDataGridViewCheckBoxColumn,
            this.капціЖіночіDataGridViewCheckBoxColumn,
            this.чоловічіПарфумиDataGridViewCheckBoxColumn,
            this.косметикаДляОбличчяDataGridViewCheckBoxColumn,
            this.оглядДляОбличчяDataGridViewCheckBoxColumn,
            this.шампуньDataGridViewCheckBoxColumn,
            this.засмагаТаЗахістВідСонцяDataGridViewCheckBoxColumn,
            this.гельДляВмиванняDataGridViewCheckBoxColumn,
            this.зубнаПастаDataGridViewCheckBoxColumn,
            this.бонусніБалиDataGridViewTextBoxColumn});
            this.таблицаDataGridView.DataSource = this.таблицаBindingSource;
            this.таблицаDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.таблицаDataGridView.Location = new System.Drawing.Point(0, 144);
            this.таблицаDataGridView.Name = "таблицаDataGridView";
            this.таблицаDataGridView.Size = new System.Drawing.Size(800, 306);
            this.таблицаDataGridView.TabIndex = 2;
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
            // кодDataGridViewTextBoxColumn
            // 
            this.кодDataGridViewTextBoxColumn.DataPropertyName = "Код";
            this.кодDataGridViewTextBoxColumn.HeaderText = "Код";
            this.кодDataGridViewTextBoxColumn.Name = "кодDataGridViewTextBoxColumn";
            // 
            // пІБDataGridViewTextBoxColumn
            // 
            this.пІБDataGridViewTextBoxColumn.DataPropertyName = "ПІБ";
            this.пІБDataGridViewTextBoxColumn.HeaderText = "ПІБ";
            this.пІБDataGridViewTextBoxColumn.Name = "пІБDataGridViewTextBoxColumn";
            // 
            // вікDataGridViewTextBoxColumn
            // 
            this.вікDataGridViewTextBoxColumn.DataPropertyName = "Вік";
            this.вікDataGridViewTextBoxColumn.HeaderText = "Вік";
            this.вікDataGridViewTextBoxColumn.Name = "вікDataGridViewTextBoxColumn";
            // 
            // статьDataGridViewTextBoxColumn
            // 
            this.статьDataGridViewTextBoxColumn.DataPropertyName = "Стать";
            this.статьDataGridViewTextBoxColumn.HeaderText = "Стать";
            this.статьDataGridViewTextBoxColumn.Name = "статьDataGridViewTextBoxColumn";
            // 
            // еmailDataGridViewTextBoxColumn
            // 
            this.еmailDataGridViewTextBoxColumn.DataPropertyName = "е-mail";
            this.еmailDataGridViewTextBoxColumn.HeaderText = "е-mail";
            this.еmailDataGridViewTextBoxColumn.Name = "еmailDataGridViewTextBoxColumn";
            // 
            // середнійДохідDataGridViewTextBoxColumn
            // 
            this.середнійДохідDataGridViewTextBoxColumn.DataPropertyName = "Середній дохід";
            this.середнійДохідDataGridViewTextBoxColumn.HeaderText = "Середній дохід";
            this.середнійДохідDataGridViewTextBoxColumn.Name = "середнійДохідDataGridViewTextBoxColumn";
            // 
            // номерТелефонуDataGridViewTextBoxColumn
            // 
            this.номерТелефонуDataGridViewTextBoxColumn.DataPropertyName = "Номер телефону";
            this.номерТелефонуDataGridViewTextBoxColumn.HeaderText = "Номер телефону";
            this.номерТелефонуDataGridViewTextBoxColumn.Name = "номерТелефонуDataGridViewTextBoxColumn";
            // 
            // косметикаПісляГолінняДляЧоловіківDataGridViewCheckBoxColumn
            // 
            this.косметикаПісляГолінняДляЧоловіківDataGridViewCheckBoxColumn.DataPropertyName = "Косметика після гоління для чоловіків";
            this.косметикаПісляГолінняДляЧоловіківDataGridViewCheckBoxColumn.HeaderText = "Косметика після гоління для чоловіків";
            this.косметикаПісляГолінняДляЧоловіківDataGridViewCheckBoxColumn.Name = "косметикаПісляГолінняДляЧоловіківDataGridViewCheckBoxColumn";
            // 
            // аксесуариДляВанниТаДушуDataGridViewCheckBoxColumn
            // 
            this.аксесуариДляВанниТаДушуDataGridViewCheckBoxColumn.DataPropertyName = "Аксесуари для ванни та душу";
            this.аксесуариДляВанниТаДушуDataGridViewCheckBoxColumn.HeaderText = "Аксесуари для ванни та душу";
            this.аксесуариДляВанниТаДушуDataGridViewCheckBoxColumn.Name = "аксесуариДляВанниТаДушуDataGridViewCheckBoxColumn";
            // 
            // антибактеріальніЗасобиDataGridViewCheckBoxColumn
            // 
            this.антибактеріальніЗасобиDataGridViewCheckBoxColumn.DataPropertyName = "Антибактеріальні засоби";
            this.антибактеріальніЗасобиDataGridViewCheckBoxColumn.HeaderText = "Антибактеріальні засоби";
            this.антибактеріальніЗасобиDataGridViewCheckBoxColumn.Name = "антибактеріальніЗасобиDataGridViewCheckBoxColumn";
            // 
            // аксесуариДляМакіяжуDataGridViewCheckBoxColumn
            // 
            this.аксесуариДляМакіяжуDataGridViewCheckBoxColumn.DataPropertyName = "Аксесуари для макіяжу";
            this.аксесуариДляМакіяжуDataGridViewCheckBoxColumn.HeaderText = "Аксесуари для макіяжу";
            this.аксесуариДляМакіяжуDataGridViewCheckBoxColumn.Name = "аксесуариДляМакіяжуDataGridViewCheckBoxColumn";
            // 
            // капціЧоловічіDataGridViewCheckBoxColumn
            // 
            this.капціЧоловічіDataGridViewCheckBoxColumn.DataPropertyName = "Капці чоловічі";
            this.капціЧоловічіDataGridViewCheckBoxColumn.HeaderText = "Капці чоловічі";
            this.капціЧоловічіDataGridViewCheckBoxColumn.Name = "капціЧоловічіDataGridViewCheckBoxColumn";
            // 
            // капціЖіночіDataGridViewCheckBoxColumn
            // 
            this.капціЖіночіDataGridViewCheckBoxColumn.DataPropertyName = "Капці жіночі";
            this.капціЖіночіDataGridViewCheckBoxColumn.HeaderText = "Капці жіночі";
            this.капціЖіночіDataGridViewCheckBoxColumn.Name = "капціЖіночіDataGridViewCheckBoxColumn";
            // 
            // чоловічіПарфумиDataGridViewCheckBoxColumn
            // 
            this.чоловічіПарфумиDataGridViewCheckBoxColumn.DataPropertyName = "Чоловічі парфуми";
            this.чоловічіПарфумиDataGridViewCheckBoxColumn.HeaderText = "Чоловічі парфуми";
            this.чоловічіПарфумиDataGridViewCheckBoxColumn.Name = "чоловічіПарфумиDataGridViewCheckBoxColumn";
            // 
            // косметикаДляОбличчяDataGridViewCheckBoxColumn
            // 
            this.косметикаДляОбличчяDataGridViewCheckBoxColumn.DataPropertyName = "Косметика для обличчя";
            this.косметикаДляОбличчяDataGridViewCheckBoxColumn.HeaderText = "Косметика для обличчя";
            this.косметикаДляОбличчяDataGridViewCheckBoxColumn.Name = "косметикаДляОбличчяDataGridViewCheckBoxColumn";
            // 
            // оглядДляОбличчяDataGridViewCheckBoxColumn
            // 
            this.оглядДляОбличчяDataGridViewCheckBoxColumn.DataPropertyName = "Огляд для обличчя";
            this.оглядДляОбличчяDataGridViewCheckBoxColumn.HeaderText = "Огляд для обличчя";
            this.оглядДляОбличчяDataGridViewCheckBoxColumn.Name = "оглядДляОбличчяDataGridViewCheckBoxColumn";
            // 
            // шампуньDataGridViewCheckBoxColumn
            // 
            this.шампуньDataGridViewCheckBoxColumn.DataPropertyName = "Шампунь";
            this.шампуньDataGridViewCheckBoxColumn.HeaderText = "Шампунь";
            this.шампуньDataGridViewCheckBoxColumn.Name = "шампуньDataGridViewCheckBoxColumn";
            // 
            // засмагаТаЗахістВідСонцяDataGridViewCheckBoxColumn
            // 
            this.засмагаТаЗахістВідСонцяDataGridViewCheckBoxColumn.DataPropertyName = "Засмага та захіст від сонця";
            this.засмагаТаЗахістВідСонцяDataGridViewCheckBoxColumn.HeaderText = "Засмага та захіст від сонця";
            this.засмагаТаЗахістВідСонцяDataGridViewCheckBoxColumn.Name = "засмагаТаЗахістВідСонцяDataGridViewCheckBoxColumn";
            // 
            // гельДляВмиванняDataGridViewCheckBoxColumn
            // 
            this.гельДляВмиванняDataGridViewCheckBoxColumn.DataPropertyName = "Гель для вмивання";
            this.гельДляВмиванняDataGridViewCheckBoxColumn.HeaderText = "Гель для вмивання";
            this.гельДляВмиванняDataGridViewCheckBoxColumn.Name = "гельДляВмиванняDataGridViewCheckBoxColumn";
            // 
            // зубнаПастаDataGridViewCheckBoxColumn
            // 
            this.зубнаПастаDataGridViewCheckBoxColumn.DataPropertyName = "Зубна паста";
            this.зубнаПастаDataGridViewCheckBoxColumn.HeaderText = "Зубна паста";
            this.зубнаПастаDataGridViewCheckBoxColumn.Name = "зубнаПастаDataGridViewCheckBoxColumn";
            // 
            // бонусніБалиDataGridViewTextBoxColumn
            // 
            this.бонусніБалиDataGridViewTextBoxColumn.DataPropertyName = "Бонусні бали";
            this.бонусніБалиDataGridViewTextBoxColumn.HeaderText = "Бонусні бали";
            this.бонусніБалиDataGridViewTextBoxColumn.Name = "бонусніБалиDataGridViewTextBoxColumn";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SpamEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.таблицаDataGridView);
            this.Controls.Add(this.panel1);
            this.Name = "SpamEmail";
            this.Text = "SpamEmail";
            this.Load += new System.EventHandler(this.SpamEmail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.таблицаDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.таблицаBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView таблицаDataGridView;
        private System.Windows.Forms.Button btnShareToAll;
        private System.Windows.Forms.Button btnShareToSelected;
        private System.Windows.Forms.CheckedListBox chlbFilterOptions;
        private System.Windows.Forms.Button btnLoadFromTxtFile;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.RichTextBox richtbMessage;
        private System.Windows.Forms.TextBox tbAgeToCompare;
        private System.Windows.Forms.ComboBox cbTypeAgeComparison;
        private System.Windows.Forms.Label lbSex;
        private System.Windows.Forms.TextBox tbIncomeToCompare;
        private System.Windows.Forms.ComboBox cbTypeIncomeComparison;
        private System.Windows.Forms.Label lbIncome;
        private System.Windows.Forms.ComboBox tbSexToCompare;
        private System.Windows.Forms.Label lbAge;
        private DatabaseDataSet1 databaseDataSet1;
        private System.Windows.Forms.BindingSource таблицаBindingSource;
        private DatabaseDataSet1TableAdapters.ТаблицаTableAdapter таблицаTableAdapter;
        private DatabaseDataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn кодDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn пІБDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn вікDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn статьDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn еmailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn середнійДохідDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерТелефонуDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn косметикаПісляГолінняДляЧоловіківDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn аксесуариДляВанниТаДушуDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn антибактеріальніЗасобиDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn аксесуариДляМакіяжуDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn капціЧоловічіDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn капціЖіночіDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn чоловічіПарфумиDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn косметикаДляОбличчяDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn оглядДляОбличчяDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn шампуньDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn засмагаТаЗахістВідСонцяDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn гельДляВмиванняDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn зубнаПастаDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn бонусніБалиDataGridViewTextBoxColumn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}