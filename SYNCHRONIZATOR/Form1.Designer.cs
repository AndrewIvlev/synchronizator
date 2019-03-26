namespace SYNCHRONIZATOR
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
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.label1 = new System.Windows.Forms.Label();
            this.w1TextBox = new System.Windows.Forms.TextBox();
            this.trySync = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // plotView1
            // 
            this.plotView1.Location = new System.Drawing.Point(12, 12);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(560, 337);
            this.plotView1.TabIndex = 0;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(584, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "ω₁=";
            // 
            // w1TextBox
            // 
            this.w1TextBox.Location = new System.Drawing.Point(637, 40);
            this.w1TextBox.Name = "w1TextBox";
            this.w1TextBox.Size = new System.Drawing.Size(39, 20);
            this.w1TextBox.TabIndex = 2;
            // 
            // trySync
            // 
            this.trySync.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trySync.Location = new System.Drawing.Point(589, 231);
            this.trySync.Name = "trySync";
            this.trySync.Size = new System.Drawing.Size(133, 40);
            this.trySync.TabIndex = 3;
            this.trySync.Text = "Try To Sync";
            this.trySync.UseVisualStyleBackColor = true;
            this.trySync.Click += new System.EventHandler(this.trySync_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(584, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "d=";
            // 
            // dTextBox
            // 
            this.dTextBox.Location = new System.Drawing.Point(631, 86);
            this.dTextBox.Name = "dTextBox";
            this.dTextBox.Size = new System.Drawing.Size(39, 20);
            this.dTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(584, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "time=";
            // 
            // tTextBox
            // 
            this.tTextBox.Location = new System.Drawing.Point(654, 134);
            this.tTextBox.Name = "tTextBox";
            this.tTextBox.Size = new System.Drawing.Size(43, 20);
            this.tTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(584, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "ω₂=";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 361);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trySync);
            this.Controls.Add(this.w1TextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.plotView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.Text = "SYNCHRONIZATOR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox w1TextBox;
        private System.Windows.Forms.Button trySync;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tTextBox;
        private System.Windows.Forms.Label label4;
    }
}

