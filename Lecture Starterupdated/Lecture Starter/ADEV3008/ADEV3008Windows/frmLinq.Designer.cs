namespace ADEV3000Windows
{
    partial class frmLinq
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
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblValue = new System.Windows.Forms.Label();
            this.btnWhere = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnLet = new System.Windows.Forms.Button();
            this.btnLambda = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(87, 54);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(61, 29);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "SELECT";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblValue
            // 
            this.lblValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValue.Location = new System.Drawing.Point(24, 223);
            this.lblValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(300, 116);
            this.lblValue.TabIndex = 1;
            // 
            // btnWhere
            // 
            this.btnWhere.Location = new System.Drawing.Point(87, 110);
            this.btnWhere.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnWhere.Name = "btnWhere";
            this.btnWhere.Size = new System.Drawing.Size(61, 29);
            this.btnWhere.TabIndex = 2;
            this.btnWhere.Text = "WHERE";
            this.btnWhere.UseVisualStyleBackColor = true;
            this.btnWhere.Click += new System.EventHandler(this.btnWhere_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(87, 167);
            this.btnJoin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(61, 29);
            this.btnJoin.TabIndex = 3;
            this.btnJoin.Text = "JOIN";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // btnLet
            // 
            this.btnLet.Location = new System.Drawing.Point(195, 54);
            this.btnLet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLet.Name = "btnLet";
            this.btnLet.Size = new System.Drawing.Size(61, 29);
            this.btnLet.TabIndex = 4;
            this.btnLet.Text = "LET";
            this.btnLet.UseVisualStyleBackColor = true;
            this.btnLet.Click += new System.EventHandler(this.btnLet_Click);
            // 
            // btnLambda
            // 
            this.btnLambda.Location = new System.Drawing.Point(195, 110);
            this.btnLambda.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLambda.Name = "btnLambda";
            this.btnLambda.Size = new System.Drawing.Size(61, 29);
            this.btnLambda.TabIndex = 5;
            this.btnLambda.Text = "LAMBDA";
            this.btnLambda.UseVisualStyleBackColor = true;
            this.btnLambda.Click += new System.EventHandler(this.btnLambda_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(195, 167);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(61, 29);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmLinq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 372);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnLambda);
            this.Controls.Add(this.btnLet);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.btnWhere);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.btnSelect);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmLinq";
            this.Text = "Linq Examples";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Button btnWhere;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Button btnLet;
        private System.Windows.Forms.Button btnLambda;
        private System.Windows.Forms.Button btnClear;
    }
}