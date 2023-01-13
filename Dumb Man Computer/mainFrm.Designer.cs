
namespace Dumb_Man_Computer
{
    partial class mainFrm
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
            this.codeTxt = new System.Windows.Forms.TextBox();
            this.loadToRamBtn = new System.Windows.Forms.Button();
            this.RAMCommandsTxt = new System.Windows.Forms.TextBox();
            this.RAMBinaryTxt = new System.Windows.Forms.TextBox();
            this.runBtn = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.ListBox();
            this.inputNum = new System.Windows.Forms.NumericUpDown();
            this.enterBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inputNum)).BeginInit();
            this.SuspendLayout();
            // 
            // codeTxt
            // 
            this.codeTxt.AcceptsReturn = true;
            this.codeTxt.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeTxt.Location = new System.Drawing.Point(12, 12);
            this.codeTxt.Multiline = true;
            this.codeTxt.Name = "codeTxt";
            this.codeTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.codeTxt.Size = new System.Drawing.Size(303, 420);
            this.codeTxt.TabIndex = 0;
            // 
            // loadToRamBtn
            // 
            this.loadToRamBtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadToRamBtn.Location = new System.Drawing.Point(12, 438);
            this.loadToRamBtn.Name = "loadToRamBtn";
            this.loadToRamBtn.Size = new System.Drawing.Size(303, 55);
            this.loadToRamBtn.TabIndex = 1;
            this.loadToRamBtn.Text = "LOAD TO RAM";
            this.loadToRamBtn.UseVisualStyleBackColor = true;
            this.loadToRamBtn.Click += new System.EventHandler(this.loadToRamBtn_Click);
            // 
            // RAMCommandsTxt
            // 
            this.RAMCommandsTxt.AcceptsReturn = true;
            this.RAMCommandsTxt.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RAMCommandsTxt.Location = new System.Drawing.Point(321, 12);
            this.RAMCommandsTxt.Multiline = true;
            this.RAMCommandsTxt.Name = "RAMCommandsTxt";
            this.RAMCommandsTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RAMCommandsTxt.Size = new System.Drawing.Size(122, 420);
            this.RAMCommandsTxt.TabIndex = 2;
            // 
            // RAMBinaryTxt
            // 
            this.RAMBinaryTxt.AcceptsReturn = true;
            this.RAMBinaryTxt.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RAMBinaryTxt.Location = new System.Drawing.Point(449, 12);
            this.RAMBinaryTxt.Multiline = true;
            this.RAMBinaryTxt.Name = "RAMBinaryTxt";
            this.RAMBinaryTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RAMBinaryTxt.Size = new System.Drawing.Size(200, 420);
            this.RAMBinaryTxt.TabIndex = 3;
            // 
            // runBtn
            // 
            this.runBtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runBtn.Location = new System.Drawing.Point(321, 438);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(328, 55);
            this.runBtn.TabIndex = 4;
            this.runBtn.Text = "RUN";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // output
            // 
            this.output.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output.FormattingEnabled = true;
            this.output.Location = new System.Drawing.Point(655, 12);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(146, 420);
            this.output.TabIndex = 5;
            // 
            // inputNum
            // 
            this.inputNum.Location = new System.Drawing.Point(655, 438);
            this.inputNum.Maximum = new decimal(new int[] {
            2047,
            0,
            0,
            0});
            this.inputNum.Minimum = new decimal(new int[] {
            2047,
            0,
            0,
            -2147483648});
            this.inputNum.Name = "inputNum";
            this.inputNum.Size = new System.Drawing.Size(146, 20);
            this.inputNum.TabIndex = 6;
            // 
            // enterBtn
            // 
            this.enterBtn.Enabled = false;
            this.enterBtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterBtn.Location = new System.Drawing.Point(655, 464);
            this.enterBtn.Name = "enterBtn";
            this.enterBtn.Size = new System.Drawing.Size(146, 29);
            this.enterBtn.TabIndex = 7;
            this.enterBtn.Text = "ENTER";
            this.enterBtn.UseVisualStyleBackColor = true;
            this.enterBtn.Click += new System.EventHandler(this.enterBtn_Click);
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 505);
            this.Controls.Add(this.enterBtn);
            this.Controls.Add(this.inputNum);
            this.Controls.Add(this.output);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.RAMBinaryTxt);
            this.Controls.Add(this.RAMCommandsTxt);
            this.Controls.Add(this.loadToRamBtn);
            this.Controls.Add(this.codeTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainFrm";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.mainFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codeTxt;
        private System.Windows.Forms.Button loadToRamBtn;
        private System.Windows.Forms.TextBox RAMCommandsTxt;
        private System.Windows.Forms.TextBox RAMBinaryTxt;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.ListBox output;
        private System.Windows.Forms.NumericUpDown inputNum;
        private System.Windows.Forms.Button enterBtn;
    }
}

