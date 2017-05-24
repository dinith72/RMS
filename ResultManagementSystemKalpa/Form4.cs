using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ResultManagementSystemKalpa
{
    public partial class frmadmin : Form
    {
        public frmadmin()
        {
            InitializeComponent();

            PanelStaffAdd.Visible = false;
           
            panelCourses.Visible = false;
           
            PanelStudent.Visible = false;




        }


        private void labelstaff1_MouseLeave(object sender, EventArgs e)
        {


        }

        private void labelstaff2_MouseLeave(object sender, EventArgs e)
        {
            // labelstaff2.Visible = false;
            ///labelstaff1.Visible = true;

        }






        private void labelcourses2_MouseLeave(object sender, EventArgs e)
        {
            // labelcourses2.Visible = false;
            // labelcourses1.Visible = true;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void frmadmin_MouseEnter(object sender, EventArgs e)
        {

        }

        private void frmadmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database81DataSet1.courses' table. You can move, or remove it, as needed.
            try
            {
                this.coursesTableAdapter1.Fill(this.database81DataSet1.courses);
                // TODO: This line of code loads data into the 'database81DataSet.courses' table. You can move, or remove it, as needed.
                this.coursesTableAdapter.Fill(this.database81DataSet.courses);
            }
            catch(Exception ex)
            { };
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            // label1.BackColor = Color.DarkRed;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }



        private void label2_DragEnter(object sender, DragEventArgs e)
        {

        }






        private void label2_DragLeave(object sender, EventArgs e)
        {

        }





        private void labelstaff2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void imagestaff_Click(object sender, EventArgs e)
        {

        }

        private void labeladdprofilepic_DragEnter(object sender, DragEventArgs e)
        {
            labeladdprofilepic.ForeColor = Color.Blue;
        }

        private void labeladdprofilepic_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(open.FileName);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, img.RawFormat);
            }
        }

        private void labeladdprofilepic_MouseEnter(object sender, EventArgs e)
        {
            labeladdprofilepic.ForeColor = Color.Blue;
            labeladdprofilepic.Font = new Font(labeladdprofilepic.Font.Name, 9, FontStyle.Underline);

        }

        private void labeladdprofilepic_MouseLeave(object sender, EventArgs e)
        {
            labeladdprofilepic.ForeColor = Color.Black;
            labeladdprofilepic.Font = new Font(labeladdprofilepic.Font.Name, 9, FontStyle.Regular);
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {

        }



        private void panel4_MouseEnter(object sender, EventArgs e)
        {

        }

        private void texsearch_TextChanged(object sender, EventArgs e)
        {

        }



        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void buttondelete_Click(object sender, EventArgs e)
        {

        }

       

        

        private void panel6_MouseEnter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelStudent.Visible = false;
            panelCourses.Visible = false;
            PanelStaffAdd.Visible = true;
        }

      

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

       

       

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

       

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
          
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
           
        }

       

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {


        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnaddstudent_Click(object sender, EventArgs e)
        {

        }

        private void btnClearstudent_Click(object sender, EventArgs e)
        {

        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            panelCourses.Visible = false;
            PanelStaffAdd.Visible = false;
           
            PanelStudent.Visible = true;
        }

        private void PanelStudent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void studentsMenuItem_Click(object sender, EventArgs e)
        {
            panelCourses.Visible = false;
            PanelStaffAdd.Visible = false;
            PanelStudent.Visible = true;
        }

        private void coursesMenuItem_Click(object sender, EventArgs e)
        {
           
            PanelStaffAdd.Visible = false;
            PanelStudent.Visible =false;
            panelCourses.Visible = true;
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }
    }
}
