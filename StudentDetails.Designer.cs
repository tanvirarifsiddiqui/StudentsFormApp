using System;
using System.Linq;
using System.Windows.Forms;

namespace StudentsFormApp
{
    partial class StudentDetails : Form
    {
        // Load event handler for the form
        private void StudentDetails_Load()
        {
            LoadStudentData(); // Load student data when the form is loaded
        }

        // Load student data into the DataGridView
        private void LoadStudentData()
        {
            using (var context = new StudentDBEntities())
            {
                // Query the database to retrieve student records along with the associated class names
                var studentData = (from student in context.Student_Tables
                                   join classTable in context.Class_Tables
                                   on student.ClassId equals classTable.Id
                                   select new
                                   {
                                       student.Name,
                                       ClassName = classTable.Name, // Assuming the class name is stored in the Name column of the Class table
                                       student.DOB,
                                       Gender = student.Gender == 0 ? "Male" : "Female", // Convert gender int to string
                                       Action = "Edit | Details | Delete" // Assuming these are buttons or links
                                   }).ToList();

                // Bind the retrieved data to the DataGridView
                dataGridViewStudents.DataSource = studentData;
            }
        }

        // Button click event handler for adding new student information
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.ShowDialog();
        }

        // Handle the click event of the refresh button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Call the method to reload student data
            LoadStudentData();
        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Blue;
            this.labelTitle.Location = new System.Drawing.Point(300, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(366, 26);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Dhaka Regency Hotel and Resort";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.BackColor = System.Drawing.Color.Green;
            this.btnAddStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStudent.ForeColor = System.Drawing.Color.Green;
            this.btnAddStudent.Location = new System.Drawing.Point(400, 60);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(160, 30);
            this.btnAddStudent.TabIndex = 1;
            this.btnAddStudent.Text = "Add New Student Info";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click); // Wire up the event handler here

            // Initialize the refresh button
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(100, 60); // Adjust the location as needed
            this.btnRefresh.Size = new System.Drawing.Size(100, 30); // Adjust the size as needed
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // Add the refresh button to the form's controls
            this.Controls.Add(this.btnRefresh);
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.AllowUserToAddRows = false;
            this.dataGridViewStudents.AllowUserToDeleteRows = false;
            this.dataGridViewStudents.BackgroundColor = System.Drawing.Color.LightGray; // Set background color
            this.dataGridViewStudents.BorderStyle = System.Windows.Forms.BorderStyle.None; // Remove border
            this.dataGridViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Adjust column width to fill the available space
            this.dataGridViewStudents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Adjust row height
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize; // Keep the auto size behavior if needed

            // Set the new size and position of the DataGridView
            this.dataGridViewStudents.Size = new System.Drawing.Size(800, 450);
            this.dataGridViewStudents.Location = new System.Drawing.Point(100, 110); // Adjust the position as needed
            this.dataGridViewStudents.TabIndex = 2;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 626);
            this.Controls.Add(this.dataGridViewStudents);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.labelTitle);
            this.Name = "Form1";
            this.Text = "Student List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            //retriving data
            this.StudentDetails_Load();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dataGridViewStudents;

    }
}
