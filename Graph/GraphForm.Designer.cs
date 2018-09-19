namespace Graph
{
    partial class GraphForm
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
            this.Add = new System.Windows.Forms.ComboBox();
            this.ND = new System.Windows.Forms.ComboBox();
            this.Image = new System.Windows.Forms.PictureBox();
            this.OpenBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InputValue = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Image)).BeginInit();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.DisplayMember = "0";
            this.Add.FormattingEnabled = true;
            this.Add.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.Add.Items.AddRange(new object[] {
            "добавить",
            "удалить"});
            this.Add.Location = new System.Drawing.Point(12, 12);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(121, 21);
            this.Add.TabIndex = 0;
            this.Add.SelectedIndexChanged += new System.EventHandler(this.Add_SelectedIndexChanged);
            // 
            // ND
            // 
            this.ND.DisplayMember = "0";
            this.ND.FormattingEnabled = true;
            this.ND.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.ND.Items.AddRange(new object[] {
            "город",
            "дорогу"});
            this.ND.Location = new System.Drawing.Point(139, 12);
            this.ND.Name = "ND";
            this.ND.Size = new System.Drawing.Size(121, 21);
            this.ND.TabIndex = 1;
            this.ND.SelectedIndexChanged += new System.EventHandler(this.ND_SelectedIndexChanged);
            // 
            // Image
            // 
            this.Image.Location = new System.Drawing.Point(12, 39);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(776, 399);
            this.Image.TabIndex = 2;
            this.Image.TabStop = false;
            this.Image.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Image_MouseClick);
            // 
            // OpenBtn
            // 
            this.OpenBtn.Location = new System.Drawing.Point(266, 10);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(75, 23);
            this.OpenBtn.TabIndex = 3;
            this.OpenBtn.Text = "открыть";
            this.OpenBtn.UseVisualStyleBackColor = true;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(347, 10);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(660, 10);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(128, 23);
            this.Search.TabIndex = 5;
            this.Search.Text = "найти город";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(428, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "длинна новой дороги";
            // 
            // InputValue
            // 
            this.InputValue.Location = new System.Drawing.Point(545, 12);
            this.InputValue.Name = "InputValue";
            this.InputValue.Size = new System.Drawing.Size(100, 20);
            this.InputValue.TabIndex = 7;
            this.InputValue.Text = "1";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Граф (*.dat)|*.dat|Все файлы|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Граф (*.dat)|*.dat|Все файлы|*.*";
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InputValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.OpenBtn);
            this.Controls.Add(this.Image);
            this.Controls.Add(this.ND);
            this.Controls.Add(this.Add);
            this.Name = "GraphForm";
            this.Text = "Graph";
            this.Load += new System.EventHandler(this.GraphForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Add;
        private System.Windows.Forms.ComboBox ND;
        private System.Windows.Forms.PictureBox Image;
        private System.Windows.Forms.Button OpenBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputValue;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

