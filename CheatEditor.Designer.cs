
namespace Nitro_AR_Cheat_Manager
{
    partial class CheatEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheatEditor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lineCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.codeText = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.descriptionText = new System.Windows.Forms.TextBox();
            this.saveCheatButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lineCountLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nameText);
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox1.Size = new System.Drawing.Size(193, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Code Name";
            // 
            // lineCountLabel
            // 
            this.lineCountLabel.AutoSize = true;
            this.lineCountLabel.Location = new System.Drawing.Point(158, 18);
            this.lineCountLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lineCountLabel.Name = "lineCountLabel";
            this.lineCountLabel.Size = new System.Drawing.Size(13, 13);
            this.lineCountLabel.TabIndex = 2;
            this.lineCountLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lines:";
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(6, 16);
            this.nameText.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(121, 20);
            this.nameText.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.codeText);
            this.groupBox2.Location = new System.Drawing.Point(4, 49);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox2.Size = new System.Drawing.Size(193, 140);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cheat Code";
            // 
            // codeText
            // 
            this.codeText.Location = new System.Drawing.Point(6, 17);
            this.codeText.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.codeText.Multiline = true;
            this.codeText.Name = "codeText";
            this.codeText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.codeText.Size = new System.Drawing.Size(181, 118);
            this.codeText.TabIndex = 0;
            this.codeText.TextChanged += new System.EventHandler(this.codeText_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.descriptionText);
            this.groupBox3.Location = new System.Drawing.Point(200, 49);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox3.Size = new System.Drawing.Size(193, 140);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Code Description";
            // 
            // descriptionText
            // 
            this.descriptionText.Location = new System.Drawing.Point(7, 17);
            this.descriptionText.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.descriptionText.Multiline = true;
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionText.Size = new System.Drawing.Size(181, 118);
            this.descriptionText.TabIndex = 1;
            // 
            // saveCheatButton
            // 
            this.saveCheatButton.Location = new System.Drawing.Point(298, 11);
            this.saveCheatButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.saveCheatButton.Name = "saveCheatButton";
            this.saveCheatButton.Size = new System.Drawing.Size(94, 36);
            this.saveCheatButton.TabIndex = 3;
            this.saveCheatButton.Text = "Save Code";
            this.saveCheatButton.UseVisualStyleBackColor = true;
            this.saveCheatButton.Click += new System.EventHandler(this.saveCheatButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(200, 11);
            this.exitButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(94, 36);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Exit Editor";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // CheatEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 208);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.saveCheatButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheatEditor";
            this.Text = "CheatEditor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lineCountLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox codeText;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox descriptionText;
        private System.Windows.Forms.Button saveCheatButton;
        private System.Windows.Forms.Button exitButton;
    }
}