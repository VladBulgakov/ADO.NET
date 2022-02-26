using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Data.Entity;
//using System.Data.Entity.Core.Objects;
//using System.Data.Entity.Core.Objects.DataClasses;
//using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CourseManager
{
    public partial class CourseViewer : Form
    {
        private SchoolEntities schoolContext;
        public CourseViewer()
        {
            InitializeComponent();
        }

        private void CourseViewer_Load(object sender, EventArgs e)
        {
            schoolContext = new SchoolEntities();

            IOrderedQueryable<Department> departmentQuery = from d in schoolContext.Departments
                                          orderby d.Name
                                          select d;
            List<Department> departmentList = departmentQuery.ToList();

            /*
            //Проверка
            string str = String.Empty;
            foreach (Department d in departmentList)
            {
                str += $"{d.DepartmentID} {d.Name} {d.Budget} {d.StartDate} {d.Administrator}\n";
            }
            MessageBox.Show(str);*/

            try
            {
                this.departmentList.DisplayMember = "Name";
                this.departmentList.DataSource = departmentList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void departmentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Department department = (Department)this.departmentList.SelectedItem;
                //Проверка
                /*string str = String.Empty;
                str += department.DepartmentID + department.Name;
                MessageBox.Show(str);*/

                /*string str = String.Empty;
                foreach (Course c in department.Courses)
                {
                    str += c.Title + "\n";
                }
                MessageBox.Show(str);*/

                courseGridView.DataSource = department.Courses.ToList();
                
                courseGridView.Columns["Department"].Visible = false;
                courseGridView.Columns["StudentGrades"].Visible = false;
                courseGridView.Columns["OnlineCourse"].Visible = false;
                courseGridView.Columns["OnsiteCourse"].Visible = false;
                courseGridView.Columns["People"].Visible = false;
                courseGridView.Columns["DepartmentId"].Visible = false;

                courseGridView.AllowUserToDeleteRows = false;
                courseGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                schoolContext.SaveChanges();
                MessageBox.Show("Changes saved to the database.");
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void closeForm_Click(object sender, EventArgs e)
        {
            this.Close();
            schoolContext.Dispose();
        }
    }
}
