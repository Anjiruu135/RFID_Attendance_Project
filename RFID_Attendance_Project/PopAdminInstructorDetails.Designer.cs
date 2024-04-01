﻿namespace RFID_Attendance_Project
{
    partial class PopAdminInstructorDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopAdminInstructorDetails));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgvDetailsResult = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.instructor_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middlename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.advisory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.card_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailsResult)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 461);
            this.panel1.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 78);
            this.label1.TabIndex = 2;
            this.label1.Text = "Instructor Details\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(194, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 65;
            this.label4.Text = "Search:";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(502, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 35);
            this.btnExport.TabIndex = 64;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgvDetailsResult
            // 
            this.dgvDetailsResult.AllowUserToAddRows = false;
            this.dgvDetailsResult.AllowUserToDeleteRows = false;
            this.dgvDetailsResult.AllowUserToResizeRows = false;
            this.dgvDetailsResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetailsResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetailsResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.instructor_id,
            this.lastname,
            this.firstname,
            this.middlename,
            this.advisory,
            this.department,
            this.card_id,
            this.contact});
            this.dgvDetailsResult.Location = new System.Drawing.Point(202, 53);
            this.dgvDetailsResult.Name = "dgvDetailsResult";
            this.dgvDetailsResult.ReadOnly = true;
            this.dgvDetailsResult.RowHeadersVisible = false;
            this.dgvDetailsResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDetailsResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetailsResult.Size = new System.Drawing.Size(450, 396);
            this.dgvDetailsResult.TabIndex = 63;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(257, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 66;
            // 
            // instructor_id
            // 
            this.instructor_id.DataPropertyName = "instructor_id";
            this.instructor_id.HeaderText = "Instructor ID";
            this.instructor_id.Name = "instructor_id";
            this.instructor_id.ReadOnly = true;
            // 
            // lastname
            // 
            this.lastname.DataPropertyName = "lastname";
            this.lastname.HeaderText = "Lastname";
            this.lastname.Name = "lastname";
            this.lastname.ReadOnly = true;
            // 
            // firstname
            // 
            this.firstname.DataPropertyName = "firstname";
            this.firstname.HeaderText = "Firstname";
            this.firstname.Name = "firstname";
            this.firstname.ReadOnly = true;
            // 
            // middlename
            // 
            this.middlename.DataPropertyName = "middlename";
            this.middlename.HeaderText = "Middlename";
            this.middlename.Name = "middlename";
            this.middlename.ReadOnly = true;
            // 
            // advisory
            // 
            this.advisory.DataPropertyName = "advisory";
            this.advisory.HeaderText = "Advisory";
            this.advisory.Name = "advisory";
            this.advisory.ReadOnly = true;
            // 
            // department
            // 
            this.department.DataPropertyName = "department";
            this.department.HeaderText = "Department";
            this.department.Name = "department";
            this.department.ReadOnly = true;
            // 
            // card_id
            // 
            this.card_id.DataPropertyName = "card_id";
            this.card_id.HeaderText = "Card ID";
            this.card_id.Name = "card_id";
            this.card_id.ReadOnly = true;
            // 
            // contact
            // 
            this.contact.DataPropertyName = "contact";
            this.contact.HeaderText = "Contact";
            this.contact.Name = "contact";
            this.contact.ReadOnly = true;
            // 
            // PopAdminInstructorDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvDetailsResult);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PopAdminInstructorDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Admin Instructor Details";
            this.Load += new System.EventHandler(this.PopAdminInstructorDetails_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailsResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvDetailsResult;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn instructor_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn middlename;
        private System.Windows.Forms.DataGridViewTextBoxColumn advisory;
        private System.Windows.Forms.DataGridViewTextBoxColumn department;
        private System.Windows.Forms.DataGridViewTextBoxColumn card_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn contact;
    }
}