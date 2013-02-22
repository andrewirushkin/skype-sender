namespace skype_sender
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.notSendToOffline = new System.Windows.Forms.CheckBox();
            this.waiting = new System.Windows.Forms.Label();
            this.delay = new System.Windows.Forms.CheckBox();
            this.output = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 32);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(332, 84);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(350, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 84);
            this.button1.TabIndex = 1;
            this.button1.Text = "Отправить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // notSendToOffline
            // 
            this.notSendToOffline.AutoSize = true;
            this.notSendToOffline.Checked = true;
            this.notSendToOffline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.notSendToOffline.Location = new System.Drawing.Point(13, 123);
            this.notSendToOffline.Name = "notSendToOffline";
            this.notSendToOffline.Size = new System.Drawing.Size(232, 21);
            this.notSendToOffline.TabIndex = 2;
            this.notSendToOffline.Text = "Не слать тем, кто в оффлайне";
            this.notSendToOffline.UseVisualStyleBackColor = true;
            // 
            // waiting
            // 
            this.waiting.AutoSize = true;
            this.waiting.Location = new System.Drawing.Point(12, 9);
            this.waiting.Name = "waiting";
            this.waiting.Size = new System.Drawing.Size(241, 17);
            this.waiting.TabIndex = 3;
            this.waiting.Text = "Ожидание подключения к скайпу...";
            // 
            // delay
            // 
            this.delay.AutoSize = true;
            this.delay.Checked = true;
            this.delay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.delay.Location = new System.Drawing.Point(12, 151);
            this.delay.Name = "delay";
            this.delay.Size = new System.Drawing.Size(280, 21);
            this.delay.TabIndex = 5;
            this.delay.Text = "Задержка в 1сек между сообщениями";
            this.toolTip1.SetToolTip(this.delay, "Возможно, если слишком много и быстро отправлять сообщения,\r\nскайп может заблокир" +
                    "овать как спам. Задержка должна помочь.");
            this.delay.UseVisualStyleBackColor = true;
            // 
            // output
            // 
            this.output.AutoSize = true;
            this.output.Location = new System.Drawing.Point(10, 179);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(0, 17);
            this.output.TabIndex = 6;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(309, 179);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(153, 17);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Список отправленных";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);


            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(12, 229);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(332, 86);
            this.richTextBox2.TabIndex = 9;
            this.richTextBox2.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Автоответчик отключен";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(350, 229);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 86);
            this.button2.TabIndex = 11;
            this.button2.Tag = "0";
            this.button2.Text = "Включить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 326);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.output);
            this.Controls.Add(this.delay);
            this.Controls.Add(this.waiting);
            this.Controls.Add(this.notSendToOffline);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Скайп - отправляльщик, только для истинных манчкинов";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox notSendToOffline;
        private System.Windows.Forms.Label waiting;
        private System.Windows.Forms.CheckBox delay;
        private System.Windows.Forms.Label output;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}

