namespace TFYAiG_analizator_var13
{
    partial class mainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.разработчикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заданиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stroka = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.TextBox();
            this.identifikator = new System.Windows.Forms.ListBox();
            this.constant = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.iterations = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(585, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.разработчикToolStripMenuItem,
            this.заданиеToolStripMenuItem});
            this.оПрограммеToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(102, 21);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // разработчикToolStripMenuItem
            // 
            this.разработчикToolStripMenuItem.Name = "разработчикToolStripMenuItem";
            this.разработчикToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.разработчикToolStripMenuItem.Text = "Разработчик";
            this.разработчикToolStripMenuItem.Click += new System.EventHandler(this.разработчикToolStripMenuItem_Click);
            // 
            // заданиеToolStripMenuItem
            // 
            this.заданиеToolStripMenuItem.Name = "заданиеToolStripMenuItem";
            this.заданиеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.заданиеToolStripMenuItem.Text = "Задание";
            this.заданиеToolStripMenuItem.Click += new System.EventHandler(this.заданиеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(57, 21);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // stroka
            // 
            this.stroka.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.stroka.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stroka.Location = new System.Drawing.Point(8, 47);
            this.stroka.Multiline = true;
            this.stroka.Name = "stroka";
            this.stroka.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.stroka.Size = new System.Drawing.Size(566, 119);
            this.stroka.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Входная строка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(4, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Сообщение анализатора";
            // 
            // message
            // 
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.message.Location = new System.Drawing.Point(8, 192);
            this.message.Name = "message";
            this.message.ReadOnly = true;
            this.message.Size = new System.Drawing.Size(563, 22);
            this.message.TabIndex = 5;
            // 
            // identifikator
            // 
            this.identifikator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.identifikator.FormattingEnabled = true;
            this.identifikator.ItemHeight = 16;
            this.identifikator.Location = new System.Drawing.Point(8, 238);
            this.identifikator.Name = "identifikator";
            this.identifikator.Size = new System.Drawing.Size(160, 164);
            this.identifikator.TabIndex = 6;
            // 
            // constant
            // 
            this.constant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.constant.FormattingEnabled = true;
            this.constant.ItemHeight = 16;
            this.constant.Location = new System.Drawing.Point(184, 238);
            this.constant.Name = "constant";
            this.constant.Size = new System.Drawing.Size(160, 164);
            this.constant.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Индетификаторы";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(180, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Константы";
            // 
            // start
            // 
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start.Location = new System.Drawing.Point(364, 238);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(197, 123);
            this.start.TabIndex = 10;
            this.start.Text = "Выполнить";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(346, 394);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Число выполнений цикла";
            // 
            // iterations
            // 
            this.iterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.iterations.Location = new System.Drawing.Point(8, 417);
            this.iterations.Name = "iterations";
            this.iterations.ReadOnly = true;
            this.iterations.Size = new System.Drawing.Size(563, 22);
            this.iterations.TabIndex = 12;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 444);
            this.Controls.Add(this.iterations);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.start);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.constant);
            this.Controls.Add(this.identifikator);
            this.Controls.Add(this.message);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stroka);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "Analizator";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem разработчикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заданиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.TextBox stroka;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.ListBox identifikator;
        private System.Windows.Forms.ListBox constant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox iterations;
    }
}

