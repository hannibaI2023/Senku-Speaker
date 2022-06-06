
namespace boku_no_speaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.Input = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.execute = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS PMincho", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "インプット";
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(134, 41);
            this.Input.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(224, 20);
            this.Input.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("MS PMincho", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "ランゲージ";
            // 
            // execute
            // 
            this.execute.Font = new System.Drawing.Font("MS Mincho", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.execute.Location = new System.Drawing.Point(275, 122);
            this.execute.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.execute.Name = "execute";
            this.execute.Size = new System.Drawing.Size(82, 37);
            this.execute.TabIndex = 5;
            this.execute.Text = "魔法";
            this.execute.UseVisualStyleBackColor = true;
            this.execute.Click += new System.EventHandler(this.execute_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("MS PMincho", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 180);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "アウトプット";
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(134, 180);
            this.output.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(224, 68);
            this.output.TabIndex = 7;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(134, 78);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(224, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::boku_no_speaker.Properties.Resources.senku2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(542, 310);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.output);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.execute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "僕のスピーカー";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Input;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button execute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

