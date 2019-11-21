using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity_FameWork_Test
{
    public partial class UpdateStudentForm : Form
    {
        private int StudentId;
        private StudentManagement Business;
        public UpdateStudentForm(int id)
        {           
            InitializeComponent();
            this.StudentId = id;
            this.Business = new StudentManagement();
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.Load += UpdateStudentForm_Load;
            
        }

        void UpdateStudentForm_Load(object sender, EventArgs e)
        {
            var @student = this.Business.GetStudent(this.StudentId);
            this.txtCode.Text = @student.Code;
            this.txtName.Text = @student.Name;
            this.rtxHometown.Text = @student.Hometown;
            this.Controls.Add(rtnMale);
            this.Controls.Add(rtnFemale);

        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var code = this.txtCode.Text;
            var name = this.txtName.Text;
            var hometown = this.rtxHometown.Text;       
            string gender = "";
            bool isChecked = this.rtnFemale.Checked;
            if (isChecked)
                gender = this.rtnFemale.Text;
            else
                gender = this.rtnMale.Text;
            this.Business.UpdateStudent(this.StudentId, code,name, hometown, gender);
            MessageBox.Show("Update student successfully");
            this.Close();
        }
    }
}
