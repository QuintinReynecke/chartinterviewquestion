
namespace InterviewQuestion1
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
            this.BtnGet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOutputData = new System.Windows.Forms.Label();
            this.lblLoading = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnGet
            // 
            this.BtnGet.Location = new System.Drawing.Point(60, 267);
            this.BtnGet.Name = "BtnGet";
            this.BtnGet.Size = new System.Drawing.Size(211, 30);
            this.BtnGet.TabIndex = 0;
            this.BtnGet.Text = "Update Data";
            this.BtnGet.UseVisualStyleBackColor = true;
            this.BtnGet.Click += new System.EventHandler(this.BtnGet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 136);
            this.label1.TabIndex = 10;
            this.label1.Text = "Name :\r\nType :\r\nIssuer : \r\nIsin : \r\nClass : \r\nPrice : \r\nDaily movement : \r\nMornin" +
    "g star rating :";
            // 
            // lblOutputData
            // 
            this.lblOutputData.AutoSize = true;
            this.lblOutputData.Location = new System.Drawing.Point(208, 86);
            this.lblOutputData.Name = "lblOutputData";
            this.lblOutputData.Size = new System.Drawing.Size(85, 17);
            this.lblOutputData.TabIndex = 11;
            this.lblOutputData.Text = "Output Data";
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Location = new System.Drawing.Point(139, 237);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(71, 17);
            this.lblLoading.TabIndex = 12;
            this.lblLoading.Text = "Loading...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 32);
            this.label2.TabIndex = 13;
            this.label2.Text = "Data from website";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 319);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.lblOutputData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnGet);
            this.Name = "Form1";
            this.Text = "Interview Test - Get data from website";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOutputData;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Label label2;
    }
}

