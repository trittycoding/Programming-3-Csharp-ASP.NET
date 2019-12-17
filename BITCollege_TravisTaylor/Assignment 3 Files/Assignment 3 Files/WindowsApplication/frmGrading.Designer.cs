namespace WindowsApplication
{
    partial class frmGrading
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
            System.Windows.Forms.Label studentNumberLabel;
            System.Windows.Forms.Label courseNumberLabel;
            System.Windows.Forms.Label courseTypeLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label gradeLabel;
            this.gbxStudent = new System.Windows.Forms.GroupBox();
            this.descriptionLabel1 = new System.Windows.Forms.Label();
            this.registrationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fullNameLabel1 = new System.Windows.Forms.Label();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentNumberLabel1 = new System.Windows.Forms.Label();
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbxGrade = new System.Windows.Forms.GroupBox();
            this.gradeTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel1 = new System.Windows.Forms.Label();
            this.courseTypeLabel1 = new System.Windows.Forms.Label();
            this.courseNumberLabel1 = new System.Windows.Forms.Label();
            this.lnkReturn = new System.Windows.Forms.LinkLabel();
            this.lnkUpdate = new System.Windows.Forms.LinkLabel();
            this.lblExisting = new System.Windows.Forms.Label();
            studentNumberLabel = new System.Windows.Forms.Label();
            courseNumberLabel = new System.Windows.Forms.Label();
            courseTypeLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            gradeLabel = new System.Windows.Forms.Label();
            this.gbxStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            this.gbxGrade.SuspendLayout();
            this.SuspendLayout();
            // 
            // studentNumberLabel
            // 
            studentNumberLabel.AutoSize = true;
            studentNumberLabel.Location = new System.Drawing.Point(116, 77);
            studentNumberLabel.Name = "studentNumberLabel";
            studentNumberLabel.Size = new System.Drawing.Size(229, 32);
            studentNumberLabel.TabIndex = 0;
            studentNumberLabel.Text = "Student Number:";
            // 
            // courseNumberLabel
            // 
            courseNumberLabel.AutoSize = true;
            courseNumberLabel.Location = new System.Drawing.Point(71, 86);
            courseNumberLabel.Name = "courseNumberLabel";
            courseNumberLabel.Size = new System.Drawing.Size(221, 32);
            courseNumberLabel.TabIndex = 12;
            courseNumberLabel.Text = "Course Number:";
            // 
            // courseTypeLabel
            // 
            courseTypeLabel.AutoSize = true;
            courseTypeLabel.Location = new System.Drawing.Point(71, 158);
            courseTypeLabel.Name = "courseTypeLabel";
            courseTypeLabel.Size = new System.Drawing.Size(184, 32);
            courseTypeLabel.TabIndex = 13;
            courseTypeLabel.Text = "Course Type:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(179, 168);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(131, 32);
            descriptionLabel.TabIndex = 3;
            descriptionLabel.Text = "Program:";
            // 
            // gradeLabel
            // 
            gradeLabel.AutoSize = true;
            gradeLabel.Location = new System.Drawing.Point(393, 369);
            gradeLabel.Name = "gradeLabel";
            gradeLabel.Size = new System.Drawing.Size(102, 32);
            gradeLabel.TabIndex = 15;
            gradeLabel.Text = "Grade:";
            // 
            // gbxStudent
            // 
            this.gbxStudent.Controls.Add(descriptionLabel);
            this.gbxStudent.Controls.Add(this.descriptionLabel1);
            this.gbxStudent.Controls.Add(this.fullNameLabel1);
            this.gbxStudent.Controls.Add(studentNumberLabel);
            this.gbxStudent.Controls.Add(this.studentNumberLabel1);
            this.gbxStudent.Location = new System.Drawing.Point(72, 62);
            this.gbxStudent.Margin = new System.Windows.Forms.Padding(8);
            this.gbxStudent.Name = "gbxStudent";
            this.gbxStudent.Padding = new System.Windows.Forms.Padding(8);
            this.gbxStudent.Size = new System.Drawing.Size(1496, 238);
            this.gbxStudent.TabIndex = 0;
            this.gbxStudent.TabStop = false;
            this.gbxStudent.Text = "Student Data";
            // 
            // descriptionLabel1
            // 
            this.descriptionLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "course.program.Description", true));
            this.descriptionLabel1.Location = new System.Drawing.Point(351, 168);
            this.descriptionLabel1.Name = "descriptionLabel1";
            this.descriptionLabel1.Size = new System.Drawing.Size(435, 34);
            this.descriptionLabel1.TabIndex = 4;
            // 
            // registrationBindingSource
            // 
            this.registrationBindingSource.DataSource = typeof(BITCollege_TravisTaylor.Models.Registration);
            // 
            // fullNameLabel1
            // 
            this.fullNameLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fullNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "FullName", true));
            this.fullNameLabel1.Location = new System.Drawing.Point(630, 77);
            this.fullNameLabel1.Name = "fullNameLabel1";
            this.fullNameLabel1.Size = new System.Drawing.Size(420, 36);
            this.fullNameLabel1.TabIndex = 3;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(BITCollege_TravisTaylor.Models.Student);
            // 
            // studentNumberLabel1
            // 
            this.studentNumberLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.studentNumberLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "StudentNumber", true));
            this.studentNumberLabel1.Location = new System.Drawing.Point(351, 77);
            this.studentNumberLabel1.Name = "studentNumberLabel1";
            this.studentNumberLabel1.Size = new System.Drawing.Size(199, 36);
            this.studentNumberLabel1.TabIndex = 1;
            // 
            // programBindingSource
            // 
            this.programBindingSource.DataSource = typeof(BITCollege_TravisTaylor.Models.Program);
            // 
            // gbxGrade
            // 
            this.gbxGrade.Controls.Add(gradeLabel);
            this.gbxGrade.Controls.Add(this.gradeTextBox);
            this.gbxGrade.Controls.Add(this.titleLabel1);
            this.gbxGrade.Controls.Add(courseTypeLabel);
            this.gbxGrade.Controls.Add(this.courseTypeLabel1);
            this.gbxGrade.Controls.Add(courseNumberLabel);
            this.gbxGrade.Controls.Add(this.courseNumberLabel1);
            this.gbxGrade.Controls.Add(this.lnkReturn);
            this.gbxGrade.Controls.Add(this.lnkUpdate);
            this.gbxGrade.Controls.Add(this.lblExisting);
            this.gbxGrade.Location = new System.Drawing.Point(208, 417);
            this.gbxGrade.Margin = new System.Windows.Forms.Padding(8);
            this.gbxGrade.Name = "gbxGrade";
            this.gbxGrade.Padding = new System.Windows.Forms.Padding(8);
            this.gbxGrade.Size = new System.Drawing.Size(1224, 541);
            this.gbxGrade.TabIndex = 1;
            this.gbxGrade.TabStop = false;
            this.gbxGrade.Text = "Grade Information";
            // 
            // gradeTextBox
            // 
            this.gradeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Grade", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "P2"));
            this.gradeTextBox.Location = new System.Drawing.Point(501, 366);
            this.gradeTextBox.Name = "gradeTextBox";
            this.gradeTextBox.Size = new System.Drawing.Size(241, 38);
            this.gradeTextBox.TabIndex = 16;
            // 
            // titleLabel1
            // 
            this.titleLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "course.Title", true));
            this.titleLabel1.Location = new System.Drawing.Point(561, 86);
            this.titleLabel1.Name = "titleLabel1";
            this.titleLabel1.Size = new System.Drawing.Size(353, 36);
            this.titleLabel1.TabIndex = 15;
            // 
            // courseTypeLabel1
            // 
            this.courseTypeLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.courseTypeLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "course.CourseType", true));
            this.courseTypeLabel1.Location = new System.Drawing.Point(298, 153);
            this.courseTypeLabel1.Name = "courseTypeLabel1";
            this.courseTypeLabel1.Size = new System.Drawing.Size(197, 37);
            this.courseTypeLabel1.TabIndex = 14;
            // 
            // courseNumberLabel1
            // 
            this.courseNumberLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.courseNumberLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "course.CourseNumber", true));
            this.courseNumberLabel1.Location = new System.Drawing.Point(298, 86);
            this.courseNumberLabel1.Name = "courseNumberLabel1";
            this.courseNumberLabel1.Size = new System.Drawing.Size(197, 34);
            this.courseNumberLabel1.TabIndex = 13;
            // 
            // lnkReturn
            // 
            this.lnkReturn.AutoSize = true;
            this.lnkReturn.Location = new System.Drawing.Point(584, 463);
            this.lnkReturn.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lnkReturn.Name = "lnkReturn";
            this.lnkReturn.Size = new System.Drawing.Size(304, 32);
            this.lnkReturn.TabIndex = 12;
            this.lnkReturn.TabStop = true;
            this.lnkReturn.Text = "Return to Student Data";
            this.lnkReturn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReturn_LinkClicked);
            // 
            // lnkUpdate
            // 
            this.lnkUpdate.AutoSize = true;
            this.lnkUpdate.Location = new System.Drawing.Point(302, 463);
            this.lnkUpdate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lnkUpdate.Name = "lnkUpdate";
            this.lnkUpdate.Size = new System.Drawing.Size(193, 32);
            this.lnkUpdate.TabIndex = 2;
            this.lnkUpdate.TabStop = true;
            this.lnkUpdate.Text = "Update Grade";
            this.lnkUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdate_LinkClicked);
            // 
            // lblExisting
            // 
            this.lblExisting.AutoSize = true;
            this.lblExisting.Location = new System.Drawing.Point(724, 266);
            this.lblExisting.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblExisting.Name = "lblExisting";
            this.lblExisting.Size = new System.Drawing.Size(468, 32);
            this.lblExisting.TabIndex = 10;
            this.lblExisting.Text = "Existing grades cannot be overriden";
            this.lblExisting.Visible = false;
            // 
            // frmGrading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1674, 1081);
            this.Controls.Add(this.gbxGrade);
            this.Controls.Add(this.gbxStudent);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "frmGrading";
            this.Text = "Student Grading";
            this.Load += new System.EventHandler(this.frmGrading_Load);
            this.gbxStudent.ResumeLayout(false);
            this.gbxStudent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            this.gbxGrade.ResumeLayout(false);
            this.gbxGrade.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxStudent;
        private System.Windows.Forms.GroupBox gbxGrade;
        private System.Windows.Forms.LinkLabel lnkReturn;
        private System.Windows.Forms.LinkLabel lnkUpdate;
        private System.Windows.Forms.Label lblExisting;
        private System.Windows.Forms.Label fullNameLabel1;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private System.Windows.Forms.Label studentNumberLabel1;
        private System.Windows.Forms.BindingSource programBindingSource;
        private System.Windows.Forms.Label courseNumberLabel1;
        private System.Windows.Forms.BindingSource registrationBindingSource;
        private System.Windows.Forms.Label titleLabel1;
        private System.Windows.Forms.Label courseTypeLabel1;
        private System.Windows.Forms.Label descriptionLabel1;
        private System.Windows.Forms.TextBox gradeTextBox;
    }
}