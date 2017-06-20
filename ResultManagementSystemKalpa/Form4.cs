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
using System.Data.Sql;
using System.Data.SqlClient;

namespace ResultManagementSystemKalpa
{
   

    public partial class frmadmin : Form
    {
        private string imglocation = "";
        private Boolean saved = false;
        private List<string> students = new List<string>();

        public frmadmin()
        {
            InitializeComponent();
            updatelist(); 
        }
        private void updatelist()
        {
            comboBoxStudent.Items.Clear();
            try
            {
                Connection con = new Connection();
                SqlConnection x = con.connect();
               
                SqlCommand cmd = new SqlCommand("select s.StNo from STUDENT s", x);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    students.Add(rdr.GetValue(0).ToString());
                    comboBoxStudent.Items.Add(rdr.GetValue(0).ToString());
                }
                x.Close();
            }
            catch(Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            /*foreach (string student in students)
                Console.Out.WriteLine(student);*/
            
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
            panel1.Visible = false;
            panel2.Visible = false;
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
            //labeladdprofilepic.ForeColor = Color.Blue;
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
            //labeladdprofilepic.ForeColor = Color.Blue;
            //labeladdprofilepic.Font = new Font(labeladdprofilepic.Font.Name, 9, FontStyle.Underline);

        }

        private void labeladdprofilepic_MouseLeave(object sender, EventArgs e)
        {
            //labeladdprofilepic.ForeColor = Color.Black;
            //labeladdprofilepic.Font = new Font(labeladdprofilepic.Font.Name, 9, FontStyle.Regular);
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
            PanelStaffAdd.BringToFront();
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
            PanelStudent.BringToFront();
        }

        private void coursesMenuItem_Click(object sender, EventArgs e)
        {
            panelCourses.BringToFront();
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

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(open.FileName);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, img.RawFormat);
            }
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            InquiriesPanel.BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmlogin frm1 = new frmlogin();
            frm1.Visible = true;
        }

        private void semesterDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SemPanel.BringToFront();
        }

        private void graduationCriteriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            CriteriaPanel.BringToFront();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
        }

        private void bScDegreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.BringToFront();            
        }

        private void bscHonoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel2.BringToFront();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {   
            if (saved == false )
            {
               DialogResult dr =  MessageBox.Show("your work is not saved \n Save now ?", "",MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    saved = true;
                    save();
                }
                if (dr == DialogResult.No)
                   clear();
                
                if ( dr == DialogResult.Cancel)
                    this.DialogResult = System.Windows.Forms.DialogResult.No;



            }
            else
            {
                clear(); 
            }
                
            
        }
        private void clear()
        {
            mskStuNo.Text = "";
            txtFNameS.Text = "";
            txtLNameS.Text = "";
            cmbAcdYear.Text = "";
            mskContactNoS.Text = "";
            cmbDistrict.Text = "";
            mskZScore.Text = "";
            cmbStream.Text = "";
            dtDOBS.Value = DateTime.Today;
            txtAddExtra.Text = "";
            dataGridExtra.Rows.Clear();
            pictureBoxStupic.Image = null;
        }

        private void save ()
        {
            try
            {
                Connection conObj = new Connection();
                SqlConnection x = conObj.connect();
                SqlCommand cmd = new SqlCommand("select count(s.StNo) from STUDENT s where s.StNo = @id", x);
                MessageBox.Show(mskStuNo.Text.ToString());
                cmd.Parameters.Add(new SqlParameter("@id", mskStuNo.Text.ToString()));
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if ((int)rdr.GetValue(0) == 1)
                    {
                        //MessageBox.Show("update");
                        update();
                    }
                        
                    else
                    {
                        //MessageBox.Show("add");
                        add();
                    }
                        

                }
                rdr.Close();
                // to send the image format to the database
               
                if (imglocation != "")
                {
                    byte[] img = null;
                    FileStream fs = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                    SqlCommand cmd2 = new SqlCommand("update STUDENT set image = @img  where StNo = @un", x);
                    cmd2.Parameters.Add(new SqlParameter("@un", mskStuNo.Text.ToString()));
                    //cmd.Parameters.Add(new SqlParameter("@un", mskStuNo.Text.ToString()));

                    cmd2.Parameters.Add(new SqlParameter("@img", img));
                    int temp = cmd2.ExecuteNonQuery();
                    x.Close();
                }



               
                MessageBox.Show("details saved succesfully");
            }
            catch(Exception exe)
            {
                MessageBox.Show(exe.Message + " \n save");
            }




            // MessageBox.Show("Student Added successfully", "Student", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void add()
        {
            try
            {
                Connection conObj = new Connection();
                SqlCommand cmdlog = new SqlCommand("insert into LOGIN (username ,password ) values(@stno, 'cha')", conObj.connect());
                cmdlog.Parameters.Add(new SqlParameter("@stno", mskStuNo.Text.ToString()));
                cmdlog.ExecuteNonQuery(); 

                string sql = "insert into Student ([StNo],[firstName],[lastName],[contactNo],[email],[AcademicYear],[DOB],[Gender],[District],[ZScore],[extra_curricular])" +
                    " values(@StNo,@first,@last,@contact,@email,@acadYear,@DOB,@gender,@district,@zscore,@extraC)";
                conObj.connect();
                using (SqlCommand cmd = new SqlCommand(sql, conObj.connect()))
                {
                    char gender = '0';
                    if (rdFemaleS.Checked == true)
                        gender = 'f';
                    if (rdMaleS.Checked == true)
                        gender = 'm';
                    cmd.Parameters.AddWithValue("@StNo", mskStuNo.Text.ToString());
                    cmd.Parameters.AddWithValue("@first", txtFNameS.Text);
                    cmd.Parameters.AddWithValue("@last", txtLNameS.Text);
                    cmd.Parameters.AddWithValue("@contact", mskContactNoS.Text.ToString());
                    //cmd.Parameters.AddWithValue("@email",txtemail.Text);
                    cmd.Parameters.AddWithValue("@acadYear", cmbAcdYear.Text.ToString());
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@DOB", dtDOBS.Text.ToString());
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@district", cmbDistrict.Text.ToString());
                    cmd.Parameters.AddWithValue("@zscore", mskZScore.Text);
                    //adding extra curricular
                    string extra = "";
                    //int col;
                    // MessageBox.Show(dataGridExtra.Rows.Count.ToString());
                   
                    for (int row = 0; row < dataGridExtra.Rows.Count - 1; row++)
                    {
                        try
                        {


                            extra = extra + dataGridExtra.Rows[row].Cells[0].Value.ToString() + " , ";
                            MessageBox.Show(extra);
                        }
                        catch (Exception exe)
                        {
                            MessageBox.Show(exe.Message + "\n datagrid to databse ");
                        }
                    }
                    cmd.Parameters.AddWithValue("@extraC", extra);
                    cmd.ExecuteNonQuery();
                    //end of adding extra Curricular



                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);

            }
            updatelist();
        }

        private void update()
        {
            //MessageBox.Show("update entered");
            try
            {
                Connection conObj = new Connection();
                SqlConnection x = conObj.connect();
               

                SqlCommand cmd = new SqlCommand("update Student set firstName = @first, lastName = @last, " +
                    "contactNo = @contact, AcademicYear = @acadYear, email = @email, DOB = @DOB, Gender = @gender, ZScore = @zscore," +
                    " District = @district , extra_curricular = @extraC where StNo = @StNo", x);


                string gender = "";
                if (rdFemaleS.Checked)
                    gender = "f";
                if (rdMaleS.Checked)
                    gender = "m";
                
                cmd.Parameters.Add(new SqlParameter("@StNo", mskStuNo.Text.ToString()));
                cmd.Parameters.AddWithValue("@first", txtFNameS.Text);
                cmd.Parameters.AddWithValue("@last", txtLNameS.Text);
                cmd.Parameters.AddWithValue("@contact", mskContactNoS.Text.ToString());
                //cmd.Parameters.AddWithValue("@email",txtemail.Text);
                cmd.Parameters.AddWithValue("@acadYear", cmbAcdYear.Text.ToString());
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@DOB", dtDOBS.Text.ToString());
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@district", cmbDistrict.Text.ToString());
                cmd.Parameters.AddWithValue("@zscore", mskZScore.Text);
                //adding extra curricular
                string extra = "";
                for (int row = 0; row < dataGridExtra.Rows.Count - 1; row++)
                {
                    try
                    {


                        extra = extra + dataGridExtra.Rows[row].Cells[0].Value.ToString() + " , ";
                        MessageBox.Show(extra);
                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show(exe.Message + "\n datagrid to databse ");
                    }
                }
                cmd.Parameters.AddWithValue("@extraC", extra);
                cmd.ExecuteNonQuery();
                //end of adding extra Curricular
              //  MessageBox.Show(" update succesful");
            }

            catch (Exception exe)
            {
                MessageBox.Show(exe.Message + "\n update");
            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            save();
            saved = true;
            
        }

        private void btnAddExtra_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridExtra.Rows.Add(txtAddExtra.Text);
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void btnDltExtra_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridExtra.Rows.Remove(dataGridExtra.SelectedRows[0]);
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void rdMaleS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnStuPic_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            
            // to open the image in a file
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Select Lecturer Image";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imglocation = dlg.FileName.ToString();
                    pictureBoxStupic.ImageLocation = imglocation;
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            
            
        }

        private void comboBoxStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            clear();
            pictureBoxprevious.Show();
            pictureBoxfirst.Show();
            pictureBoxnext.Show();
            pictureBoxlast.Show();
            try
            {
                Connection con = new Connection();
                SqlConnection x = con.connect();

                SqlCommand cmd = new SqlCommand("select s.StNo , s.firstName ,s.lastName ,s.AcademicYear ,s.contactNo,s.District,s.ZScore,s.stream,s.DOB ,s.email,s.Gender ,s.image ,s.extra_curricular " +
                    "from STUDENT s where s.StNo = @id ", x);
                cmd.Parameters.Add(new SqlParameter("@id", comboBoxStudent.SelectedItem.ToString()));
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    mskStuNo.Text = rdr.GetValue(0).ToString();
                    txtFNameS.Text = rdr.GetValue(1).ToString();
                    txtLNameS.Text = rdr.GetValue(2).ToString();
                    cmbAcdYear.Text = rdr.GetValue(3).ToString();
                    mskContactNoS.Text = rdr.GetValue(4).ToString();
                    cmbDistrict.Text = rdr.GetValue(5).ToString();
                    mskZScore.Text = rdr.GetValue(6).ToString();
                    cmbStream.Text = rdr.GetValue(7).ToString();
                    dtDOBS.Text = rdr.GetValue(8).ToString();
                    txtemail.Text = rdr.GetValue(9).ToString();

                    rdMaleS.Checked = false;
                    rdFemaleS.Checked = false;


                    if (rdr.GetValue(10).ToString().Contains("m"))
                        rdMaleS.Checked = true;
                    
                        
                    if (rdr.GetValue(10).ToString().Contains("f"))
                        rdFemaleS.Checked = true;


                    string extra = rdr.GetValue(12).ToString();
                    // List<string> excur = new List<string>() ;
                    string[] excur = extra.Split(',');
                    foreach (string activity in excur)
                    {
                        dataGridExtra.Rows.Add(activity);
                    }


                    // MessageBox.Show(rdr.GetValue(11).ToString());
                    pictureBoxStupic.Image = null;
                  
                    
                    
                        byte[] img = (byte[])rdr.GetValue(11);
                        MemoryStream ms = new MemoryStream(img);
                        pictureBoxStupic.Image = Image.FromStream(ms);

                    

                    MessageBox.Show(extra);




                }
            }
            catch (InvalidCastException cst)
            {
               // MessageBox.Show(cst.Message);
            }
            catch(Exception exe)
            {
                MessageBox.Show(exe.Message);
            }

            if (mskStuNo.Text.Equals(students.Last()))
            {
                pictureBoxlast.Hide();
                pictureBoxnext.Hide();
            }

            if (mskStuNo.Text.Equals(students.First()))
            {
                pictureBoxfirst.Hide();
                pictureBoxprevious.Hide();
            }



        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("you are going to delete "+ mskStuNo.Text.ToString() + "  \n delete ?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {


                try
                {
                    Connection con = new Connection();
                    SqlCommand cmd = new SqlCommand("delete from LOGIN  where username = @stno", con.connect());
                    cmd.Parameters.Add(new SqlParameter("@stno", mskStuNo.Text.ToString()));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("delete seccesful");
                    updatelist();

                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message + "\n delete button click");
                }
            }

            if (dr == DialogResult.No)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.No;

            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
                 pictureBoxprevious.Show();
                 pictureBoxfirst.Show();
                pictureBoxnext.Show();
                pictureBoxlast.Show(); 

            
                int position = students.FindIndex(stu => stu == mskStuNo.Text);
                //MessageBox.Show(position.ToString());
                 getfromdb(position+1);
                if ( mskStuNo.Text.Equals(students.Last()))
                {
                pictureBoxlast.Hide();
                pictureBoxnext.Hide();
                }
        }

      

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBoxprevious.Show();
            pictureBoxfirst.Show();
            pictureBoxnext.Show();
            pictureBoxlast.Show();

            int position = students.FindIndex(stu => stu == students.Last());
          //  MessageBox.Show(position.ToString());
            getfromdb(position);
            pictureBoxlast.Hide();
            pictureBoxnext.Hide();
            


        }
        private void pictureBoxprevious_Click(object sender, EventArgs e)
        {
            pictureBoxprevious.Show();
            pictureBoxfirst.Show();
            pictureBoxnext.Show();
            pictureBoxlast.Show();
            int position = students.FindIndex(stu => stu == mskStuNo.Text);
            //MessageBox.Show(position.ToString());
            getfromdb(position - 1);
            if (mskStuNo.Text.Equals(students.First()))
            {
                pictureBoxfirst.Hide();
                pictureBoxprevious.Hide();
            }
        }
        private void getfromdb(int stid)
        {
            try
            {
                Connection con = new Connection();
                SqlConnection x = con.connect();

                SqlCommand cmd = new SqlCommand("select s.StNo , s.firstName ,s.lastName ,s.AcademicYear ,s.contactNo,s.District,s.ZScore,s.stream,s.DOB ,s.email,s.Gender ,s.image " +
                    "from STUDENT s where s.StNo = @id ", x);
                cmd.Parameters.Add(new SqlParameter("@id", students[stid]));
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    mskStuNo.Text = rdr.GetValue(0).ToString();
                    txtFNameS.Text = rdr.GetValue(1).ToString();
                    txtLNameS.Text = rdr.GetValue(2).ToString();
                    cmbAcdYear.Text = rdr.GetValue(3).ToString();
                    mskContactNoS.Text = rdr.GetValue(4).ToString();
                    cmbDistrict.Text = rdr.GetValue(5).ToString();
                    mskZScore.Text = rdr.GetValue(6).ToString();
                    cmbStream.Text = rdr.GetValue(7).ToString();
                    dtDOBS.Text = rdr.GetValue(8).ToString();
                    txtemail.Text = rdr.GetValue(9).ToString();

                    rdMaleS.Checked = false;
                    rdFemaleS.Checked = false;


                    if (rdr.GetValue(10).ToString().Contains("m"))
                        rdMaleS.Checked = true;


                    if (rdr.GetValue(10).ToString().Contains("f"))
                        rdFemaleS.Checked = true;





                    // MessageBox.Show(rdr.GetValue(11).ToString());
                    pictureBoxStupic.Image = null;



                    byte[] img = (byte[])rdr.GetValue(11);
                    MemoryStream ms = new MemoryStream(img);
                    pictureBoxStupic.Image = Image.FromStream(ms);




                }
            }
            catch (InvalidCastException cst)
            {

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message + "\n picture box next");
            }
            comboBoxStudent.Text = mskStuNo.Text;

        }

        private void pictureBoxfirst_Click(object sender, EventArgs e)
        {
            pictureBoxprevious.Show();
            pictureBoxfirst.Show();
            pictureBoxnext.Show();
            pictureBoxlast.Show();

            int position = students.FindIndex(stu => stu == students.First());
            //  MessageBox.Show(position.ToString());
            getfromdb(position);
            pictureBoxfirst.Hide();
            pictureBoxprevious.Hide();
        }
    }
}
