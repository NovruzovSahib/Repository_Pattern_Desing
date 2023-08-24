using Repository_Pattern_Desing.Model;
using Repository_Pattern_Desing.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repository_Pattern_Desing
{
    public partial class Form1 : Form
    {
        private EmployerRepositoryModel employerRepositoryModel;
        public Form1()
        {
            InitializeComponent();
            employerRepositoryModel = new EmployerRepositoryModel();
        }
        #region SELECTBUTTON
        private void selectbtn_Click(object sender, EventArgs e)
        {
            IEmployer employer = new EmployerRepositoryModel();
            var list = employer.GetAllEmployers();
            dataGridView1.DataSource = list;
        }
        #endregion

        #region INSERTBUTTON
        private void insertbtn_Click(object sender, EventArgs e)
        {
            try
            {
                EMPLOYER employer = new EMPLOYER
                {
                    FName = FNametxt.Text.Trim(),
                    SName = SNametxt.Text.Trim(),
                    Age = Convert.ToInt16(Agetxt.Text.Trim()),
                };
                bool result = employerRepositoryModel.AddEmployer(employer);
                if (result)
                {
                    MessageBox.Show("Employer successfully added");
                    ClearBoxes();
                }
                else
                {
                    MessageBox.Show("Problem occured. Employer is not added");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter Data to Add", ex.Message);
            }
        }
        #endregion

        #region UPDATEBUTTON
        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(IDtxt.Text.Trim()))
                {
                    EMPLOYER employer = new EMPLOYER()
                    {
                        FName = FNametxt.Text.Trim(),
                        SName = SNametxt.Text.Trim(),
                        Age = Convert.ToInt16(Agetxt.Text.Trim())
                    };
                    employerRepositoryModel.UpdateEmployer(Convert.ToInt16(IDtxt.Text.Trim()), employer);
                    MessageBox.Show("Employer successfully updated");
                    ClearBoxes();
                }
                else
                {
                    MessageBox.Show("Please enter ID");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please provide a valid ID", ex.Message);
            }
        }
        #endregion

        #region SEARCHBUTTON
        private void searchbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(IDtxt.Text.Trim()))
            {
                EmployerRepositoryModel employerRepositoryModel = new EmployerRepositoryModel();
                var foundemployer = employerRepositoryModel.SearchEmployer(Convert.ToInt16(IDtxt.Text.Trim()));

                if (foundemployer != null)
                {
                    dataGridView1.DataSource = new List<EMPLOYER> { foundemployer };
                    FNametxt.Text = foundemployer.FName;
                    SNametxt.Text = foundemployer.SName;
                    Agetxt.Text = foundemployer.Age.ToString();
                }
                else
                {
                    MessageBox.Show("Employer is not found");
                }
            }
            else
            {
                MessageBox.Show("Please enter ID");

            }

        }
        #endregion

        #region DELETEBUTTON
        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                EmployerRepositoryModel employerRepositoryModel = new EmployerRepositoryModel();
                bool result = employerRepositoryModel.DeleteEmployer(Convert.ToInt16(IDtxt.Text.Trim()));

                if (result)
                {
                    MessageBox.Show("Item successfully deleted");
                }
                else
                {
                    MessageBox.Show("Employer not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter ID", ex.Message);
            }
        }
        #endregion

        void ClearBoxes()
        {
            FNametxt.Clear();
            SNametxt.Clear();
            Agetxt.Clear();
        }
    }
}

