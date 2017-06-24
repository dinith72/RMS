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
        private Boolean savedstu = false;
        private Boolean saveled = false;
        private List<string> students = new List<string>();
        private List<string> lecturer = new List<string>();
        private List<string> lecinquiry = new List<string>();
        private List<string> stuinquiry = new List<string>();
        private int stuinqpos = 0;
        private int lecinqpos = 0;



        public frmadmin()
        {
            InitializeComponent();
            updatelist();
            staffMenuItem.PerformClick();
           
        }
      
        private void updatelist()
        {
            comboBoxStudent.Items.Clear();
            comboBoxLecturer.Items.Clear();

            // getting the students on the drop down menue
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
                MessageBox.Show(exe.Message + "\n update list student");
            }

            //  // getting the lecturer on the drop down menue
            try
            {
                Connection con = new Connection();
                SqlConnection x = con.connect();

                SqlCommand cmd = new SqlCommand("select l.lec_id from lecturer l ", x);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lecturer.Add(rdr.GetValue(0).ToString());
                    comboBoxLecturer.Items.Add(rdr.GetValue(0).ToString());
                }
                x.Close();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message + " \n update list add lecturer");
            }

            /*foreach (string student in students)
                Console.Out.WriteLine(student);*/

        }

        private void loadInquiryLists()
        {
            lecinquiry.Clear();
            stuinquiry.Clear();
            try
            {
                Connection con = new Connection();
                SqlConnection x = con.connect();
                SqlCommand cmdlec = new SqlCommand("select l.lec_id from lectureinquiry l ", x);
                SqlCommand cmdstu = new SqlCommand("select i.StNo from INQUIRY i  ", x);
                SqlDataReader rdrlec = cmdlec.ExecuteReader();
                while (rdrlec.Read())
                {
                    lecinquiry.Add(rdrlec.GetValue(0).ToString());
                }
                rdrlec.Close();
                SqlDataReader rdrstu = cmdstu.ExecuteReader();


                while (rdrstu.Read())
                {
                    stuinquiry.Add(rdrstu.GetValue(0).ToString());
                }
                //MessageBox.Show(lecinquiry.Count.ToString());
                txtAmtLec.Text = lecinquiry.Count.ToString();
                txtAmtStu.Text = stuinquiry.Count.ToString();
               
            }
            catch(Exception exe)
            {
                MessageBox.Show(exe.Message + " \n load inquiry list");
            }
                getStuInquiry(0);
                getLecInq(0);   
        }
      
        private void labelcourses2_MouseLeave(object sender, EventArgs e)
        {
            // labelcourses2.Visible = false;
            // labelcourses1.Visible = true;

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
            imglocation = null; 
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
            imglocation = null;
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

        

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            InquiriesPanel.BringToFront();
            loadInquiryLists();
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

        // button add student
        private void pictureBox6_Click(object sender, EventArgs e)
        {   
            if (savedstu == false )
            {
               DialogResult dr =  MessageBox.Show("your work is not saved \n Save now ?", "",MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    savedstu = true;
                    savestu();
                }
                if (dr == DialogResult.No)
                   clearstu();
                
                if ( dr == DialogResult.Cancel)
                    this.DialogResult = System.Windows.Forms.DialogResult.No;



            }
            else
            {
                clearstu(); 
            }
                
            
        }

        // button add lec
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (saveled == false)
            {
                DialogResult dr = MessageBox.Show("your work is not saved \n Save now ?", "", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    saveled = true;
                    savelec();
                    clearlec();
                }
                if (dr == DialogResult.No)
                    clearlec();

                if (dr == DialogResult.Cancel)
                    this.DialogResult = System.Windows.Forms.DialogResult.No;
                
            }
            else
            {
                clearlec();
            }
        }
        private void clearstu()
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
        private void clearlec()
        {
            comboBoxLecturer.Text = "";
            comboBoxTitle.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtRegNo.Text = "";
            doblec.Value = DateTime.Today;
            maskedTextBoxContactNo.Text = "";
            textemailLec.Text = "";
            maskedTextBoxContactNo.Text = "";
            imagestaff.Image = null;
            dataGridResearch.Rows.Clear();
            dataGridspecialisation.Rows.Clear();
            dataGridCourses.Rows.Clear();


        }

        private void savestu ()
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
                        updatestu();
                    }
                        
                    else
                    {
                        //MessageBox.Show("add");
                        addstu();
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
                MessageBox.Show(exe.Message + " \n savestu");
            }

           // MessageBox.Show("Student Added successfully", "Student", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void savelec()
        {
            try
            {
                Connection conObj = new Connection();
                SqlConnection x = conObj.connect();
                SqlCommand cmd = new SqlCommand("select count (l.lec_id) from lecturer l where l.lec_id = @id", x);
                MessageBox.Show(txtRegNo.Text.ToString());
                cmd.Parameters.Add(new SqlParameter("@id", txtRegNo.Text.ToString()));
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if ((int)rdr.GetValue(0) == 1)
                    {
                        MessageBox.Show("update");
                        updatelec();
                    }

                    else
                    {
                        MessageBox.Show("add");
                       addlec();
                        updatelec();
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
                    SqlCommand cmd2 = new SqlCommand("update lecturer  set profile_pic = @img where lec_id = @un ", x);
                    cmd2.Parameters.Add(new SqlParameter("@un", txtRegNo.Text.ToString()));
                    //cmd.Parameters.Add(new SqlParameter("@un", mskStuNo.Text.ToString()));

                    cmd2.Parameters.Add(new SqlParameter("@img", img));
                    int temp = cmd2.ExecuteNonQuery();
                    x.Close();
                }




                MessageBox.Show("details saved succesfully");
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message + " \n savelec");
            }
        }

        private void addstu()
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

        private void addlec()
        {
            try
            {
                Connection conObj = new Connection();
                SqlCommand cmdlog = new SqlCommand("insert into LOGIN ( username , password ) values ( @lecid, 'lec')", conObj.connect());
                cmdlog.Parameters.Add(new SqlParameter("@lecid", txtRegNo.Text.ToString()));
                cmdlog.ExecuteNonQuery();


                SqlCommand cmd = new SqlCommand("insert into lecturer (lec_id , first_name ,last_name ) " +
                    "values (@lecid , @fn , @ln )", conObj.connect());
                
                  
                cmd.Parameters.Add(new SqlParameter("@lecid",txtRegNo.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("@fn", txtFirstName.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("@ln", txtLastName.Text.ToString()));
                cmd.ExecuteNonQuery();

                /*
                cmd.Parameters.Add(new SqlParameter("@prefix", comboBoxTitle.Text.ToString()));

                cmd.Parameters.Add(new SqlParameter("@gen", gender.ToString()));
                cmd.Parameters.Add(new SqlParameter("@dob", doblec.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("@cno", maskedTextBoxContactNo.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("@email", textemailLec.Text.ToString()));
                //adding research 
                string research = "";
                string specialise = "";

                //int col;
                // MessageBox.Show(dataGridExtra.Rows.Count.ToString());

                foreach (DataGridViewRow row in dataGridResearch.Rows)
                {
                    try
                    {
                        research = research + row.Cells[0].Value.ToString() + " , ";

                        //extra = extra + dataGridExtra.Rows[row].Cells[0].Value.ToString() + " , ";
                        MessageBox.Show(research);
                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show(exe.Message + "\n addlec");
                    }
                }
                foreach (DataGridViewRow row in dataGridspecialisation.Rows)
                {
                    specialise = specialise + row.Cells[0].Value.ToString() + " , ";
                }
                cmd.Parameters.Add(new SqlParameter("@re", research.ToString()));
                cmd.Parameters.Add(new SqlParameter("@sp", specialise.ToString()));*/

                //end of adding extra Curricular




            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message + "\n add lec");

            }

        }

        private void updatestu()
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

        private void updatelec()
        {
            try
            {

                Connection conObj = new Connection();
                SqlConnection x = conObj.connect();
                // SqlCommand cmd = new SqlCommand("  ,@fn , @ln , @gen , @dob , @cno , @email  , @re , @sp", x);

                SqlCommand cmd = new SqlCommand("update lecturer set prefix = @prefix , first_name = @fn , last_name = @ln , " +
                    "gender = @gen, dob = @dob , contact_number = @cno , email = @email , research_details = @re, specialised_areas = @sp " +
                    "where lec_id = @lecid; ", x);
                char gender = '0';
                if (radioButtonMale.Checked == true)
                    gender = 'f';
                if (radioButtonFemale.Checked == true)
                    gender = 'm';
                cmd.Parameters.Add(new SqlParameter("@lecid", txtRegNo.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("@prefix", comboBoxTitle.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("@fn", txtFirstName.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("@ln", txtLastName.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("@gen", gender.ToString()));
                cmd.Parameters.Add(new SqlParameter("@dob", doblec.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("@cno", maskedTextBoxContactNo.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("@email", textemailLec.Text.ToString()));
                //adding research and specialisations 
                string research = "";
                string specialise = "";

                //int col;
                // MessageBox.Show(dataGridExtra.Rows.Count.ToString());

                foreach (DataGridViewRow row in dataGridResearch.Rows)
                {
                    try
                    {

                        if (row.Cells[0].Value != null)
                            research = research + row.Cells[0].Value.ToString() + " , ";


                       // MessageBox.Show(research);
                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show(exe.Message + "\n updatelec");
                    }
                }
                foreach (DataGridViewRow row in dataGridspecialisation.Rows)
                {
                    try
                    {
                        //MessageBox.Show(row.Cells[0].Value.ToString());
                        if (row.Cells[0].Value != null)
                            specialise = specialise + row.Cells[0].Value.ToString() + " , ";
                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show(exe.Message + "\n updatelec");
                    }
                }
                cmd.Parameters.Add(new SqlParameter("@re", research.ToString()));
                cmd.Parameters.Add(new SqlParameter("@sp", specialise.ToString()));
                cmd.ExecuteNonQuery();
                x.Close();

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message + "\n upadate lecturer");
            }

        }
        

        // save button clck student
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            savestu();
            savedstu = true;
            
        }

        // save button click lecturer
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            savelec();
            saveled = true;
            updatelist();
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
        // dlete a row on extra activiteis pf student
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
        // to open the image in a file student
        private void btnStuPic_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            
            
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Select Student Image";
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
        // adds the image to the lecture profile picturebox
        private void button1_Click(object sender, EventArgs e)
        {
             
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Select Lecturer Image";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imglocation = dlg.FileName.ToString();
                    imagestaff.ImageLocation = imglocation;
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void comboBoxStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearstu();
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

        private void comboBoxLecturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearlec();
            pictureBoxnextLec.Show();
            pictureBoxlastLec.Show();
            pictureBoxfirstLec.Show();
            pictureBoxprevousLec.Show();
            // load the lectrer details
            try
            {
                Connection con = new Connection();
                SqlConnection x = con.connect();

                SqlCommand cmd = new SqlCommand("select l.prefix, l.first_name , l.last_name , l.gender ,l.dob ,l.contact_number , l.email ," +
                    " l.profile_pic,l.research_details,l.specialised_areas" +
                    " from lecturer l where l.lec_id = @id", x);
                cmd.Parameters.Add(new SqlParameter("@id", comboBoxLecturer.SelectedItem.ToString()));
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtRegNo.Text = comboBoxLecturer.SelectedItem.ToString();
                    comboBoxTitle.Text = rdr.GetValue(0).ToString();
                    txtFirstName.Text = rdr.GetValue(1).ToString();
                    txtLastName.Text = rdr.GetValue(2).ToString();
                    doblec.Text = rdr.GetValue(4).ToString();
                    
                    maskedTextBoxContactNo.Text = rdr.GetValue(5).ToString();
                    textemailLec.Text = rdr.GetValue(6).ToString();
                   

                    radioButtonMale.Checked = false;
                    radioButtonFemale.Checked = false;


                    if (rdr.GetValue(3).ToString().Contains("m"))
                        radioButtonMale.Checked = true;


                    if (rdr.GetValue(3).ToString().Contains("f"))
                        radioButtonFemale.Checked = true;


                    string spec = rdr.GetValue(9).ToString();
                    string research = rdr.GetValue(8).ToString();
                    // List<string> excur = new List<string>() ;
                    string[] specarr = spec.Split(',');
                    string[] resarr = research.Split(',');
                    foreach (string item in specarr)
                    {
                        dataGridspecialisation.Rows.Add(item);
                    }
                    foreach (string item in resarr)
                    {
                        dataGridResearch.Rows.Add(item);
                    }



                    // MessageBox.Show(rdr.GetValue(11).ToString());
                    imagestaff.Image = null;



                    byte[] img = (byte[])rdr.GetValue(7);
                    MemoryStream ms = new MemoryStream(img);
                    imagestaff.Image = Image.FromStream(ms);

                }
            }
            catch (InvalidCastException cst)
            {
                MessageBox.Show(cst.Message);
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message + "\n combo box lectrer ");
            }

            //load the course details

            try
            {
                Connection con = new Connection();
                SqlConnection x = con.connect();

                SqlCommand cmd = new SqlCommand("select c.course_id , c.course_name from courses c where c.lec_id = @id", x);
                cmd.Parameters.Add(new SqlParameter("@id", comboBoxLecturer.SelectedItem.ToString()));
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dataGridCourses.Rows.Add(rdr.GetValue(0).ToString(),rdr.GetValue(1).ToString());
                }
                x.Close();
            }
            catch( Exception exe)
            {
                MessageBox.Show(exe.Message + " \adding courses - combo box selected idex changed");
            }

            if (txtRegNo.Text.Equals(lecturer.Last()))
            {
                pictureBoxlastLec.Hide();
                pictureBoxnextLec.Hide();
            }

            if (txtRegNo.Text.Equals(lecturer.First()))
            {
                pictureBoxfirstLec.Hide();
                pictureBoxprevousLec.Hide();
            }
        }

        // delete button student
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // delete button 
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            
             // delete button 
            DialogResult dr = MessageBox.Show("you are going to delete " + txtRegNo.Text.ToString() + "  \n delete ?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
              try
                 {
                        Connection con = new Connection();
                        SqlCommand cmd = new SqlCommand("delete from LOGIN  where username = @lecid", con.connect());
                        cmd.Parameters.Add(new SqlParameter("@lecid", txtRegNo.Text.ToString()));
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

        // picture box next student
        private void pictureBox11_Click(object sender, EventArgs e)
        {
                 pictureBoxprevious.Show();
                 pictureBoxfirst.Show();
                pictureBoxnext.Show();
                pictureBoxlast.Show(); 

            
                int position = students.FindIndex(stu => stu == mskStuNo.Text);
                //MessageBox.Show(position.ToString());
                 getfromdbstu(position+1);
                if ( mskStuNo.Text.Equals(students.Last()))
                {
                pictureBoxlast.Hide();
                pictureBoxnext.Hide();
                }
        }

        // picture box next lecturer
        private void pictureBoxnextLec_Click(object sender, EventArgs e)
        {
            pictureBoxprevousLec.Show();
            pictureBoxfirstLec.Show();
            pictureBoxnextLec.Show();
            pictureBoxlastLec.Show();

            
            int position = lecturer.FindIndex(lec => lec == txtRegNo.Text);
            //MessageBox.Show(position.ToString());
            getfromdblec(position + 1);
            if (txtRegNo.Text.Equals(lecturer.Last()))
            {
                pictureBoxlastLec.Hide();
                pictureBoxnextLec.Hide();
            }
        }


        // picture bo last student
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBoxprevious.Show();
            pictureBoxfirst.Show();
            pictureBoxnext.Show();
            pictureBoxlast.Show();

            int position = students.FindIndex(stu => stu == students.Last());
          //  MessageBox.Show(position.ToString());
            getfromdbstu(position);
            pictureBoxlast.Hide();
            pictureBoxnext.Hide();
            
        }
         // picture box last lecturer
        private void pictureBoxlastLec_Click(object sender, EventArgs e)
        {
            pictureBoxprevousLec.Show();
            pictureBoxfirstLec.Show();
            pictureBoxnextLec.Show();
            pictureBoxlastLec.Show();

            int position = lecturer.FindIndex(lec => lec == lecturer.Last());
            getfromdblec(position);
            pictureBoxnextLec.Hide();
            pictureBoxlastLec.Hide();
        }

        // picture bo previous student
        private void pictureBoxprevious_Click(object sender, EventArgs e)
        {
            pictureBoxprevious.Show();
            pictureBoxfirst.Show();
            pictureBoxnext.Show();
            pictureBoxlast.Show();
            int position = students.FindIndex(stu => stu == mskStuNo.Text);
            //MessageBox.Show(position.ToString());
            getfromdbstu(position - 1);
            if (mskStuNo.Text.Equals(students.First()))
            {
                pictureBoxfirst.Hide();
                pictureBoxprevious.Hide();
            }
        }

        // picture box previous lecturer
        private void pictureBoxprevousLec_Click(object sender, EventArgs e)
        {

            pictureBoxprevousLec.Show();
            pictureBoxfirstLec.Show();
            pictureBoxnextLec.Show();
            pictureBoxlastLec.Show();

            int position = lecturer.FindIndex(lec => lec == txtRegNo.Text);
            getfromdblec(position - 1);

            if (txtRegNo.Text.Equals(lecturer.First()))
            {
                pictureBoxprevousLec.Hide();
                pictureBoxfirstLec.Hide();
            }
        }

        // picture bo first student
        private void pictureBoxfirst_Click(object sender, EventArgs e)
        {
            pictureBoxprevious.Show();
            pictureBoxfirst.Show();
            pictureBoxnext.Show();
            pictureBoxlast.Show();

            int position = students.FindIndex(stu => stu == students.First());
            //  MessageBox.Show(position.ToString());
            getfromdbstu(position);
            pictureBoxfirst.Hide();
            pictureBoxprevious.Hide();
        }

        // picture box first lecturer
        private void pictureBoxfirstLec_Click(object sender, EventArgs e)
        {
            pictureBoxprevousLec.Show();
            pictureBoxfirstLec.Show();
            pictureBoxnextLec.Show();
            pictureBoxlastLec.Show();


            int position = lecturer.FindIndex(lec => lec == lecturer.First());
            //  MessageBox.Show(position.ToString());
            getfromdblec(position);
            pictureBoxfirstLec.Hide();
            pictureBoxprevousLec.Hide();
        }





        private void getfromdbstu(int stid)
        {
            clearstu();
            comboBoxStudent.Text = students[stid];

        }



        private void getfromdblec(int lecid)
        {
            clearlec();
            comboBoxLecturer.Text = lecturer[lecid];

        }

      

        private void tabControl4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBoxContactNo_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        // add the research items in datagrid view lecturer
        private void pictureBox36_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridResearch.Rows.Add(textresearch.Text);
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }


         // delete research item from the gridview lecturer
        private void pictureBoxDelRe_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridResearch.Rows.Remove(dataGridResearch.SelectedRows[0]);
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }


        // add the specialise items in datagrid view lecturer
        private void pictureBoxAddSpec_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridspecialisation.Rows.Add(textspec.Text);
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }


        // delete the specialise items in datagrid view lecturer
        private void pictureBoxDelSpec_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridspecialisation.Rows.Remove(dataGridspecialisation.SelectedRows[0]);
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        // clearing the student inquiry details 
        private void clearStuInq()
        {
            labelfnStu.Text = "";
            labellnStu.Text = "";
            labelContactNoStu.Text = "";
            labelEmailStu.Text = "";
            textBoxExtraStu.Text = "";
        }

        private void clearLecInq()
        {
            lblLecInqFn.Text = "";
            lblLeqInqLn.Text = "";
            lblLecInqEmail.Text = "";
            lblLecInqCno.Text = "";
            txtLecInqRe.Text = "";
            txtLecInqSp.Text = "";
        }

        // adding the student inquries to the form 
        private void getStuInquiry(int itemno)
        {
            clearStuInq();
            stuinqpos = itemno;
            try
            {
                Connection con = new Connection();
                SqlConnection x = con.connect();
                SqlCommand cmdstu = new SqlCommand("select i.firstName , i.lastName ,i.contactNo , i.email ,i.extraCurricularActivities " +
                    "from INQUIRY i where i.StNo = @stno ; ", x);
                cmdstu.Parameters.Add(new SqlParameter("@stno", stuinquiry[itemno]));
                SqlDataReader rdr = cmdstu.ExecuteReader();
                string extra = "";

                while (rdr.Read())
                {
                    labelfnStu.Text = rdr.GetValue(0).ToString();
                    labellnStu.Text = rdr.GetValue(1).ToString();
                    labelContactNoStu.Text = rdr.GetValue(2).ToString();
                    labelEmailStu.Text = rdr.GetValue(3).ToString();
                    extra = rdr.GetValue(4).ToString();
                    

                }
                string[] extrarr = extra.Split(',');
                foreach (string activity in extrarr)
                {
                    textBoxExtraStu.Text +=  activity + System.Environment.NewLine ;
                }
            }
            catch(Exception exe)
            {
                MessageBox.Show(exe.Message + " \n getStuInquiry");
            }
            
        }

        //addong the lecture inquiries to the form
        private void getLecInq(int itemno)
        {
            clearLecInq();
            lecinqpos = itemno;
            try
            {
                Connection con = new Connection();
                SqlConnection x = con.connect();
                SqlCommand cmdstu = new SqlCommand("select l.prefix , l.first_name , l.last_name , l.contact_number , l.email , l.research , l.specialisations " +
                    "from lectureinquiry l where l.lec_id = @lecid ", x);
                cmdstu.Parameters.Add(new SqlParameter("@lecid", lecinquiry[itemno]));
                SqlDataReader rdr = cmdstu.ExecuteReader();
                string sp = "";
                string re = "";

                while (rdr.Read())
                {
                  
                    lblLecInqFn.Text = rdr.GetValue(1).ToString();
                    lblLeqInqLn.Text = rdr.GetValue(2).ToString();
                    lblLecInqCno.Text = rdr.GetValue(3).ToString();
                    lblLecInqEmail.Text = rdr.GetValue(4).ToString();
                    sp = rdr.GetValue(6).ToString();
                    re = rdr.GetValue(5).ToString();


                }
                rdr.Close();
                string[] sparr = sp.Split(',');
                string[] rearr = re.Split(',');
                foreach (string activity in sparr)
                {
                   txtLecInqSp.Text += activity + System.Environment.NewLine;
                }
                foreach (string activity in rearr)
                {
                    txtLecInqRe.Text += activity + System.Environment.NewLine;
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message + " \n getStuInquiry");
            }
        }

        // picture box inquiry student last
        private void pictureBox45_Click(object sender, EventArgs e)
        {
            pbInqStuFirst.Show();
            pbInqStuPrevious.Show();
            //pbInqStuLast.Show();
            pbInqStuNext.Show();

            getStuInquiry(stuinquiry.FindIndex(i => i == stuinquiry.Last()));

            pbInqStuLast.Hide();
            pbInqStuNext.Hide();
        }

        private void pbInqStuNext_Click(object sender, EventArgs e)
        {
            pbInqStuFirst.Show();
            pbInqStuPrevious.Show();
            pbInqStuLast.Show();
          //  pbInqStuNext.Show();

            getStuInquiry(stuinqpos + 1);

            if (stuinqpos  == stuinquiry.FindIndex(i => i == stuinquiry.Last()))
            {
                pbInqStuLast.Hide();
                pbInqStuNext.Hide();
            }
            

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void pbInqStuPrevious_Click(object sender, EventArgs e)
        {
            pbInqStuFirst.Show();
            //pbInqStuPrevious.Show();
            pbInqStuLast.Show();
            pbInqStuNext.Show();
            getStuInquiry(stuinqpos - 1);
            if (stuinqpos == stuinquiry.FindIndex(i => i == stuinquiry.First()))
            {
                pbInqStuFirst.Hide();
                pbInqStuPrevious.Hide();
            }
        }

        private void pbInqStuFirst_Click(object sender, EventArgs e)
        {
           // pbInqStuFirst.Show();
            pbInqStuPrevious.Show();
            pbInqStuLast.Show();
            pbInqStuNext.Show();
            getStuInquiry(stuinquiry.FindIndex(i => i == stuinquiry.First()));
            pbInqStuFirst.Hide();
            pbInqStuPrevious.Hide();
        }

        private void pbLecInqFirst_Click(object sender, EventArgs e)
        {
            //pbLecInqFirst.Show();
           // pbLecInqPrevious.Show();
            pbLecInqNext.Show();
            pbLecInqLast.Show();
            getLecInq(lecinquiry.FindIndex(i => i == lecinquiry.First()));

            pbLecInqFirst.Hide();
            pbLecInqPrevious.Hide();

        }

        private void pbLecInqPrevious_Click(object sender, EventArgs e)
        {
            pbLecInqFirst.Show();
            //pbLecInqPrevious.Show();
            pbLecInqNext.Show();
            pbLecInqLast.Show();

            getLecInq(lecinqpos - 1);

            if (lecinqpos == lecinquiry.FindIndex(i => i == lecinquiry.First()))
            {

                pbLecInqFirst.Hide();
                pbLecInqPrevious.Hide();
            }
        }

        private void pbLecInqNext_Click(object sender, EventArgs e)
        {
            pbLecInqFirst.Show();
            pbLecInqPrevious.Show();
           // pbLecInqNext.Show();
            pbLecInqLast.Show();

            getLecInq(lecinqpos + 1);

            if (lecinqpos == lecinquiry.FindIndex(i => i == lecinquiry.Last()))
            {
                pbLecInqLast.Hide();
                pbLecInqNext.Hide();
            }
        }

        private void pbLecInqLast_Click(object sender, EventArgs e)
        {
            pbLecInqFirst.Show();
            pbLecInqPrevious.Show();
            // pbLecInqNext.Show();
            //pbLecInqLast.Show();
            getLecInq(lecinquiry.FindIndex(i => i == lecinquiry.Last()));

            pbLecInqLast.Hide();
            pbLecInqNext.Hide();

        }

        private void btnStuAccept_Click(object sender, EventArgs e)
        {
            try
            {
                Connection con = new Connection();
                SqlConnection x = con.connect();

                SqlCommand cmd = new SqlCommand("update STUDENT  set firstName = @fn, lastName = @ln, contactNo = @cn, " +
                    "email = @gm, extra_curricular = @ex where STUDENT.StNo = @sn", x);
                cmd.Parameters.Add(new SqlParameter("@sn", stuinquiry[stuinqpos]));
                cmd.Parameters.Add(new SqlParameter("@fn", labelfnStu.Text));
                cmd.Parameters.Add(new SqlParameter("@ln", labellnStu.Text));
                cmd.Parameters.Add(new SqlParameter("@cn", labelContactNoStu.Text));
                cmd.Parameters.Add(new SqlParameter("@gm", labelEmailStu.Text));
                // MessageBox.Show(textBoxExtraStu.Text);
                string extra = "";
                //MessageBox.Show(textBoxExtraStu.Lines[0]);
                for (int i = 0; i < textBoxExtraStu.Lines.Length - 1; i++)
                    extra += textBoxExtraStu.Lines[i] + ',';
                MessageBox.Show(extra);
                cmd.Parameters.Add(new SqlParameter("@ex", extra));
                cmd.ExecuteNonQuery();



                // MessageBox.Show(stuinquiry[stuinqpos]);
                x.Close();
                deleterecordStu();
            }
            catch( Exception exe)
            {
                MessageBox.Show(exe.Message + " \n accept inquiry button record");
            }
            
        }

        private void deleterecordStu()
        {
            try
            {
                Connection con = new Connection();
                SqlConnection x = con.connect();

                SqlCommand cmd = new SqlCommand("delete INQUIRY where StNo = @id ", x);
                cmd.Parameters.Add(new SqlParameter("@id", stuinquiry[stuinqpos]));
               
                cmd.ExecuteNonQuery();
                MessageBox.Show("record updated successfully");
                toolStripMenuItem1.PerformClick();
            }
            catch( Exception exe)
            {
                MessageBox.Show(exe.Message + " \n delete record");
            }
           

        }

        private void btnStuDiscard_Click(object sender, EventArgs e)
        {
            deleterecordStu();
        }

        private void buttonLecInqAccept_Click(object sender, EventArgs e)
        {
            try
            {
                Connection con = new Connection();
                SqlConnection x = con.connect();

                SqlCommand cmd = new SqlCommand("update lecturer set first_name = @fn, last_name = @ln, contact_number = @cn, " +
                    "email = @gm, research_details = @re, specialised_areas = @sp where lec_id = @lid ", x);
                cmd.Parameters.Add(new SqlParameter("@lid", lecinquiry[lecinqpos]));
                cmd.Parameters.Add(new SqlParameter("@fn", lblLecInqFn.Text));
                cmd.Parameters.Add(new SqlParameter("@ln", lblLeqInqLn.Text));
                cmd.Parameters.Add(new SqlParameter("@cn", lblLecInqCno.Text));
                cmd.Parameters.Add(new SqlParameter("@gm", lblLecInqEmail.Text));
                // MessageBox.Show(textBoxExtraStu.Text);
                string re = "";
                string sp = "";
                //MessageBox.Show(textBoxExtraStu.Lines[0]);

                for (int i = 0; i < txtLecInqRe.Lines.Length - 1; i++)
                    re += txtLecInqRe.Lines[i] + ',';

                for (int i = 0; i < txtLecInqSp.Lines.Length - 1; i++)
                   sp += txtLecInqSp.Lines[i] + ',';

                MessageBox.Show(re);
                MessageBox.Show(sp);

                cmd.Parameters.Add(new SqlParameter("@sp", sp));
                cmd.Parameters.Add(new SqlParameter("@re", re));

                cmd.ExecuteNonQuery();



                // MessageBox.Show(stuinquiry[stuinqpos]);
                x.Close();
                deleterecordLec();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message + " \n accept inquiry button record");
            }
        }

        private void deleterecordLec()
        {
            try
            {
                Connection con = new Connection();
                SqlConnection x = con.connect();

                SqlCommand cmd = new SqlCommand("delete lectureinquiry  where lec_id = @id ", x);
                cmd.Parameters.Add(new SqlParameter("@id", lecinquiry[lecinqpos]));

                cmd.ExecuteNonQuery();
                MessageBox.Show("record updated successfully");
                toolStripMenuItem1.PerformClick();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message + " \n delete recordlec");
            }
        }

        private void buttonLecInqDec_Click(object sender, EventArgs e)
        {
            deleterecordLec();
        }
    }
}
