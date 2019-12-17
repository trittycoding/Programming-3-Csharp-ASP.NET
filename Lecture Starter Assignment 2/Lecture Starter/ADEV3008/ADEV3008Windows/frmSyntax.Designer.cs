namespace ADEV3000Windows
{
    partial class frmSyntax
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
            this.lblBind = new System.Windows.Forms.Label();
            this.btnMessagebox = new System.Windows.Forms.Button();
            this.btnBindings = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnShared = new System.Windows.Forms.Button();
            this.btnException = new System.Windows.Forms.Button();
            this.rtxtLoopResults = new System.Windows.Forms.RichTextBox();
            this.btnLoops = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnIfAndCase = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBind
            // 
            this.lblBind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBind.Location = new System.Drawing.Point(15, 276);
            this.lblBind.Name = "lblBind";
            this.lblBind.Size = new System.Drawing.Size(100, 23);
            this.lblBind.TabIndex = 22;
            // 
            // btnMessagebox
            // 
            this.btnMessagebox.Location = new System.Drawing.Point(137, 221);
            this.btnMessagebox.Name = "btnMessagebox";
            this.btnMessagebox.Size = new System.Drawing.Size(86, 34);
            this.btnMessagebox.TabIndex = 21;
            this.btnMessagebox.Text = "&Messagebox";
            this.btnMessagebox.UseVisualStyleBackColor = true;
            this.btnMessagebox.Click += new System.EventHandler(this.btnMessagebox_Click);
            // 
            // btnBindings
            // 
            this.btnBindings.Location = new System.Drawing.Point(15, 221);
            this.btnBindings.Name = "btnBindings";
            this.btnBindings.Size = new System.Drawing.Size(86, 34);
            this.btnBindings.TabIndex = 20;
            this.btnBindings.Text = "&Data Bindings";
            this.btnBindings.UseVisualStyleBackColor = true;
            this.btnBindings.Click += new System.EventHandler(this.btnBindings_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(348, 424);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(86, 34);
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnShared
            // 
            this.btnShared.Location = new System.Drawing.Point(137, 160);
            this.btnShared.Name = "btnShared";
            this.btnShared.Size = new System.Drawing.Size(86, 34);
            this.btnShared.TabIndex = 18;
            this.btnShared.Text = "&Shared Event";
            this.btnShared.UseVisualStyleBackColor = true;
            // 
            // btnException
            // 
            this.btnException.Location = new System.Drawing.Point(15, 160);
            this.btnException.Name = "btnException";
            this.btnException.Size = new System.Drawing.Size(86, 34);
            this.btnException.TabIndex = 17;
            this.btnException.Text = "&Exception Handling";
            this.btnException.UseVisualStyleBackColor = true;
            this.btnException.Click += new System.EventHandler(this.btnException_Click);
            // 
            // rtxtLoopResults
            // 
            this.rtxtLoopResults.Location = new System.Drawing.Point(246, 99);
            this.rtxtLoopResults.Name = "rtxtLoopResults";
            this.rtxtLoopResults.Size = new System.Drawing.Size(188, 120);
            this.rtxtLoopResults.TabIndex = 16;
            this.rtxtLoopResults.Text = "";
            // 
            // btnLoops
            // 
            this.btnLoops.Location = new System.Drawing.Point(137, 99);
            this.btnLoops.Name = "btnLoops";
            this.btnLoops.Size = new System.Drawing.Size(86, 34);
            this.btnLoops.TabIndex = 15;
            this.btnLoops.Text = "&Loops";
            this.btnLoops.UseVisualStyleBackColor = true;
            this.btnLoops.Click += new System.EventHandler(this.btnLoops_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Location = new System.Drawing.Point(76, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 65);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Supplied Data:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(130, 28);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 2;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnIfAndCase
            // 
            this.btnIfAndCase.Location = new System.Drawing.Point(15, 99);
            this.btnIfAndCase.Name = "btnIfAndCase";
            this.btnIfAndCase.Size = new System.Drawing.Size(86, 34);
            this.btnIfAndCase.TabIndex = 13;
            this.btnIfAndCase.Text = "&If and Case";
            this.btnIfAndCase.UseVisualStyleBackColor = true;
            this.btnIfAndCase.Click += new System.EventHandler(this.btnIfAndCase_Click);
            // 
            // frmSyntax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 479);
            this.Controls.Add(this.lblBind);
            this.Controls.Add(this.btnMessagebox);
            this.Controls.Add(this.btnBindings);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnShared);
            this.Controls.Add(this.btnException);
            this.Controls.Add(this.rtxtLoopResults);
            this.Controls.Add(this.btnLoops);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnIfAndCase);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmSyntax";
            this.Text = "C# Syntax";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBind;
        private System.Windows.Forms.Button btnMessagebox;
        private System.Windows.Forms.Button btnBindings;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnShared;
        private System.Windows.Forms.Button btnException;
        private System.Windows.Forms.RichTextBox rtxtLoopResults;
        private System.Windows.Forms.Button btnLoops;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btnIfAndCase;
    }
}

