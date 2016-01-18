namespace Corsair_Utils
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
            this.NumpadColorPicker = new System.Windows.Forms.ColorDialog();
            this.btnColorPicker = new System.Windows.Forms.Button();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnColorPicker
            // 
            this.btnColorPicker.Location = new System.Drawing.Point(137, 39);
            this.btnColorPicker.Name = "btnColorPicker";
            this.btnColorPicker.Size = new System.Drawing.Size(110, 41);
            this.btnColorPicker.TabIndex = 0;
            this.btnColorPicker.Text = "Pick color";
            this.btnColorPicker.UseVisualStyleBackColor = true;
            this.btnColorPicker.Click += new System.EventHandler(this.btnColorPicker_Click);
            // 
            // colorPanel
            // 
            this.colorPanel.Location = new System.Drawing.Point(12, 12);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(108, 103);
            this.colorPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 127);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.btnColorPicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Corsair num lock state";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog NumpadColorPicker;
        private System.Windows.Forms.Button btnColorPicker;
        private System.Windows.Forms.Panel colorPanel;
    }
}

