using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;  


using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
// for excel functions
using excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop;
using System.Data.OleDb;

namespace ResultManagementSystemKalpa
{
    // the label on the bottom is given relavant name and 1
    // label which on top is given relavant name and 2
    public partial class frmLecturers : Form
    {
        private string username = frmlogin.getUsername();
        private DataTable dtfeedback = new DataTable();
        private int fbkrecord = 0;
        //private object Filestream;

        public frmLecturers()
        {
            InitializeComponent();
            getxUserName();
            loaddata();
            
            loadcombo();
            comboBoxViewResultsYear.Hide(); // hides the combo box for acdamic results in view results pannel



        }

        private void getxUserName()
        {
            //string username = frmlogin.getUsername();
            //string this.username = "lec";
            // MessageBox.Show(username+"bb");

        }
        private void loadcombo()
            // this program loads the acadamic years to the combo box in results pannel
        {
           // MessageBox.Show("load");
            try
            {

                Connection conObj = new Connection();
                SqlConnection x = conObj.connect();
                SqlCommand cmd = new SqlCommand("select distinct r.acadamic_year from RESULTS r", x);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    comboBoxViewResultsYear.Items.Add(sdr.GetValue(0).ToString());
                }
                x.Close();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void loaddata()
            // this statement load data to the profile details of the user
        {
            string research = "";
            string specialise = "";
            try
            {
                
                Connection conObj = new Connection();
                SqlConnection x = conObj.connect();
                SqlCommand cmd = new SqlCommand("select l.prefix ,l.first_name , l.last_name , l.contact_number, l.email , l.extension ,l.research_details ,l.specialised_areas ,l.profile_pic from lecturer l where lec_id = @lecid", conObj.connect());
                cmd.Parameters.Add(new SqlParameter("@lecid", username.ToString()));
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    labelName.Text = sdr.GetValue(0).ToString() + " " + sdr.GetValue(1).ToString() + " " + sdr.GetValue(2).ToString();
                    labelContactNo.Text = sdr.GetValue(3).ToString();
                    labelEmail.Text = sdr.GetValue(4).ToString();
                    labelExtension.Text = sdr.GetValue(5).ToString();
                    research = sdr.GetValue(6).ToString();
                    specialise = sdr.GetValue(7).ToString();
                    // getiing the image from sql server
                    pictureBoxProfilepic.Image = null;
                    byte[] img = (byte[])sdr.GetValue(8);
                    if (img == null)
                        pictureBoxProfilepic.Image = null;
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pictureBoxProfilepic.Image = Image.FromStream(ms);

                    }

                }
                sdr.Close();
                x.Close();
            }
            catch (InvalidCastException c) { }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n loaddata");

            }
            string[] re = research.Split(',');
                string[] spec = specialise.Split(',');
                foreach (string word in re)
                {
                    textBoxResearch.Text += System.Environment.NewLine + word;
                }
            foreach (string word in spec)
            {
                textBoxspecialise.Text +=  System.Environment.NewLine + word;
            }

        }
            

        

        private void frmstudents_Load(object sender, EventArgs e)
        {
            ProfilePanel.BringToFront();
        }

        private void labelback1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmlogin frm1 = new frmlogin();
            frm1.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            //labelProfile2.Visible = true;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            // labelProfile2.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            //labelResManager2.Visible = false;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            //labelResManager2.Visible = true;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            //labelAnalize2.Visible = false;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            //panelProfile.Visible = false;
            // panelResultsManager.Visible = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            // panelProfile.Visible = false;
            //panelResultsManager.Visible = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

            //panelResultsManager.Visible = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //panelResultsManager.Visible = false;
            //panelProfile.Visible = true;
        }

        private void labelProfile1_MouseEnter(object sender, EventArgs e)
        {
        }

        private void labelProfile2_MouseLeave(object sender, EventArgs e)
        {

        }

        private void labelProfile2_Click(object sender, EventArgs e)
        {

        }

        private void labelResultsManager1_MouseEnter(object sender, EventArgs e)
        {
        }

        private void labelResultsManager2_MouseLeave(object sender, EventArgs e)
        {

        }

        private void labelResultsManager2_Click(object sender, EventArgs e)
        {



        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfilePanel.BringToFront();
        }

        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void feedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                FeedbackPanel.BringToFront();
                loadFeedbackDetails('1', dataGridViewYear1);
                //MessageBox.Show(dataGridViewYear1.Rows[0].Cells[0].Value.ToString());
                loadRatings(dataGridViewYear1.Rows[0].Cells[0].Value.ToString());
            }
            catch (Exception exe)
            {

                
            }
                

        }
        // load the course details to the left data grid
        private void loadFeedbackDetails(char level , DataGridView gridview)
        {
            dataGridViewFbk.Rows.Clear(); // clears the rows in the right datagrid
            feedbackTxt.Text = ""; // clear the feedback label
            try
            {
                Connection con = new Connection();
                SqlConnection x = con.connect();
                SqlCommand cmd = new SqlCommand("select c.course_id , c.course_name " +
                    " from courses c where c.acadamic_level =@level and c.lec_id =@id", x);
                cmd.Parameters.Add(new SqlParameter("@id", username.ToString()));
                cmd.Parameters.Add(new SqlParameter("@level", level.ToString()));
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("course_id");
                dt.Columns.Add("course name");

                while (rdr.Read())
                {
                    DataRow row = dt.NewRow();
                    row["Course_id"] = rdr.GetValue(0);
                    row["course Name"] = rdr.GetValue(1);
                    dt.Rows.Add(row);
                    int num = gridview.Rows.Add(row);
                    foreach (DataRow drow in dt.Rows)
                    {

                        gridview.Rows[num].Cells[0].Value = drow["Course_id"].ToString();
                        gridview.Rows[num].Cells[1].Value = drow["Course Name"].ToString();

                    }

                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
                
        }

        private void addResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddResultsPanel.BringToFront();
        }

        private void checkResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultsPanel.BringToFront();
            loadcombo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //RatingsPanel.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Feedbacks.BringToFront();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmlogin frm1 = new frmlogin();
            frm1.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PercentageForm frm5 = new PercentageForm();
            frm5.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void buttonProfilepic_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            string imglocation = "";
            // to open the image in a file
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Select Lecturer Image";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imglocation = dlg.FileName.ToString();
                    pictureBoxProfilepic.ImageLocation = imglocation;
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            try
            {
                // to send the image format to the database
                byte[] img = null;
                FileStream fs = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);

                SqlConnection x = con.connect();
                if (x.State != ConnectionState.Open)
                    x.Open();
                SqlCommand cmd = new SqlCommand("update lecturer set profile_pic = @img  where lec_id = @un", x);
                cmd.Parameters.Add(new SqlParameter("@un", username.ToString()));
                cmd.Parameters.Add(new SqlParameter("@img", img));
                int temp = cmd.ExecuteNonQuery();
                x.Close();
                MessageBox.Show("picture saved succesfully");
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            
        }

        private void resultManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddResultsPanel.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private Boolean hasusername()
        {
            Connection con = new Connection();
            SqlConnection x = con.connect();

            if (x.State != ConnectionState.Open)
                x.Open();
            SqlCommand cmd = new SqlCommand("select i.lec_id from lectureinquiry i where lec_id = @un ", x);
            cmd.Parameters.Add(new SqlParameter("@un", username.ToString()));
            //SqlDataReader rdr = cmd.ExecuteScalar();
            if (cmd.ExecuteScalar() != null)
                return true;
            else
                return false;
        }

        private void InquireBtn_Click(object sender, EventArgs e)
        {

            Connection con = new Connection();
            SqlConnection x = con.connect();
            Boolean inquired = false;

            if (x.State != ConnectionState.Open)
                x.Open();

            
            if (comboBoxPrefix.SelectedIndex != -1 || textBoxFirstname.Text != null || textBoxLastname.Text != null ||
                maskedTextBoxContactno.Text != null || textBoxEmail.Text != null || dataGridViewSpec.Rows.Count > 1 || dataGridViewResearch.Rows.Count > 1)
            {
                if (!hasusername())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("insert into lectureinquiry (lec_id) values ( @lecid ) ", x);
                        cmd.Parameters.Add(new SqlParameter("@lecid", username.ToString()));
                        int temp = cmd.ExecuteNonQuery();
                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show(exe.Message);
                    }
                }
            }

            if (dataGridViewSpec.RowCount > 1)
            {
                string specialisation = "";

                SqlCommand cmd = new SqlCommand("select l.specialisations from lectureinquiry l where lec_id = @lecid ", x);
                cmd.Parameters.Add(new SqlParameter("@lecid", username.ToString()));
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    specialisation = rdr.GetValue(0).ToString();
                rdr.Close();

                
                for ( int i = 0; i < dataGridViewSpec.RowCount;i++)
                {
                    try
                    {
                        specialisation = specialisation +  dataGridViewSpec.Rows[i].Cells[0].Value.ToString()  + "   ,   " ;
                        //MessageBox.Show(specialisation);
                    }
                    catch(Exception exe)
                    {
                        Console.Out.Write(exe.Message);
                    }

                }
                SqlCommand cmd1 = new SqlCommand("update lectureinquiry set specialisations = @spec where lec_id = @lecid", x);
                cmd1.Parameters.Add(new SqlParameter("@spec", specialisation));
                cmd1.Parameters.Add(new SqlParameter("@lecid", username.ToString()));
                int temp = cmd1.ExecuteNonQuery();
                inquired = true;

            }
            if (dataGridViewResearch.RowCount > 1)
            {
                string research = "";

                SqlCommand cmd = new SqlCommand("select l.research from lectureinquiry l where lec_id = @lecid ", x);
                cmd.Parameters.Add(new SqlParameter("@lecid", username.ToString()));
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    research = rdr.GetValue(0).ToString();
                rdr.Close();

                for (int i = 0; i < dataGridViewResearch.RowCount; i++)
                {
                    try
                    {
                        research = research + dataGridViewResearch.Rows[i].Cells[0].Value.ToString() + " , ";
                        //MessageBox.Show(specialisation);
                    }
                    catch (Exception exe)
                    {
                        Console.Out.Write(exe.Message);
                    }

                }
                SqlCommand cmd1 = new SqlCommand("update lectureinquiry set research = @spec where lec_id = @lecid", x);
                cmd1.Parameters.Add(new SqlParameter("@spec", research));
                cmd1.Parameters.Add(new SqlParameter("@lecid", username.ToString()));
                int temp = cmd1.ExecuteNonQuery();
                inquired = true;

            }




            if (comboBoxPrefix.SelectedIndex > -1)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update lectureinquiry set prefix = @prefix where lec_id = @lecid", x);
                    cmd.Parameters.Add(new SqlParameter("@prefix", comboBoxPrefix.SelectedItem.ToString()));
                    cmd.Parameters.Add(new SqlParameter("@lecid", username.ToString()));
                    int temp = cmd.ExecuteNonQuery();
                    inquired = true;
                    // MessageBox.Show("Inquire submitted succesfully");
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message);
                }



            }

            if (textBoxFirstname.Text != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update lectureinquiry set first_name = @fn where lec_id = @lecid", x);
                    cmd.Parameters.Add(new SqlParameter("@fn", textBoxFirstname.Text));
                    cmd.Parameters.Add(new SqlParameter("@lecid", username.ToString()));
                    int temp = cmd.ExecuteNonQuery();
                    inquired = true;
                    // MessageBox.Show("Inquire submitted succesfully");
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message);
                }

            }
            if (textBoxLastname.Text != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update lectureinquiry set last_name = @ln where lec_id = @lecid", x);
                    cmd.Parameters.Add(new SqlParameter("@ln", textBoxLastname.Text));
                    cmd.Parameters.Add(new SqlParameter("@lecid", username.ToString()));
                    int temp = cmd.ExecuteNonQuery();
                    inquired = true;
                    // MessageBox.Show("Inquire submitted succesfully");
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message);
                }

            }
            if (maskedTextBoxContactno.Text != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update lectureinquiry set contact_number = @cn where lec_id = @lecid", x);
                    // MessageBox.Show("h" + maskedTextBoxContactno.Text + "h");
                    cmd.Parameters.Add(new SqlParameter("@cn", maskedTextBoxContactno.Text));
                    cmd.Parameters.Add(new SqlParameter("@lecid", username.ToString()));
                    int temp = cmd.ExecuteNonQuery();
                    inquired = true;
                    // MessageBox.Show("Inquire submitted succesfully");
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message);
                }

            }
            if (textBoxEmail.Text != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update lectureinquiry set email = @em where lec_id = @lecid", x);
                    cmd.Parameters.Add(new SqlParameter("@em", textBoxEmail.Text));
                    cmd.Parameters.Add(new SqlParameter("@lecid", username.ToString()));
                    int temp = cmd.ExecuteNonQuery();
                    inquired = true;
                    // MessageBox.Show("Inquire submitted succesfully");
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message);
                }

            }
            if (inquired == true)
                MessageBox.Show("Inquire is submitted succesfully");
            x.Close();

        }

        
        private void pictureBoxResearchAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridViewResearch.Rows.Add(textBoxInqReasearch.Text);
            }
            catch(Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void pictureBoxResearchDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewResearch.Rows.Remove(dataGridViewResearch.SelectedRows[0]);
            }
            catch(Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void pictureBoxSpecAdd_Click(object sender, EventArgs e)
        {
            this.dataGridViewSpec.Rows.Add(textBoxInqSpecilaise.Text);
        }

        private void pictureBoxSpecDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewSpec.Rows.Remove(dataGridViewSpec.SelectedRows[0]);
            }
            catch(Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void comboBoxViewResultsYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            dataGridViewViewResultsCourse.Rows.Clear();
            dataGridViewStudents.Rows.Clear();
            update();
            
        }
        private void update()
        {
            
            List<string> curseid = new List<string>() ;
            List<string> cursename = new List<string>();

           

            string level = comboBoxLevel.SelectedItem.ToString();
            string acyear = comboBoxViewResultsYear.SelectedItem.ToString();
            MessageBox.Show("update");

            try
            {
                Connection conn = new Connection();
                SqlConnection x = conn.connect();
                //SqlCommand cmd = new SqlCommand("select distinct c.course_id from lecturer l , courses c, take_course t " +
                  //"where l.lec_id =@id and c.acadamic_level =@al and t.acadamic_year =@ay " +
                  //"and l.lec_id = c.lec_id and c.course_id = t.course_id; ", x);

                SqlCommand cmd = new SqlCommand("select distinct c.course_id  from lecturer l , courses c, RESULTS r " +
                    "where l.lec_id =@id and c.acadamic_level =@al and r.acadamic_year =@ay " +
                    "and l.lec_id = c.lec_id and c.course_id = r.CourseID " , x);

                cmd.Parameters.Add(new SqlParameter("@id", username.ToString()));
                cmd.Parameters.Add(new SqlParameter("@al", comboBoxLevel.SelectedItem.ToString()));
               cmd.Parameters.Add(new SqlParameter("@ay", comboBoxViewResultsYear.SelectedItem.ToString()));

                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    curseid.Add(rdr.GetValue(0).ToString());
                    //MessageBox.Show("**" + curseid[j] + "**");

                    
                    
                }
                rdr.Close();



                foreach (string cid in curseid)
                {
                    SqlCommand cmd1 = new SqlCommand("select c.course_name from courses c where c.course_id =@id", x);
                    cmd1.Parameters.Add(new SqlParameter("@id", cid.ToString()));
                    SqlDataReader rdr1 = cmd1.ExecuteReader();
                    while (rdr1.Read())
                    {
                        cursename.Add(rdr1.GetValue(0).ToString());
                        //MessageBox.Show("**" + cursename[i] + "**");
                    }


                    rdr1.Close();
                    
                }


                int r = 0;
                foreach(string cid in curseid)
                {
                    MessageBox.Show(cid);
                    dataGridViewViewResultsCourse.Rows.Add(cid,cursename[r]);
                    r++;
                    //dataGridViewViewResultsCourse.Rows[i].Cells[1].Value = cid.ToString();

                }
                x.Close(); 

            }
            catch (Exception exe1)
            {
                MessageBox.Show(exe1.ToString());

            }
        }

        private void comboBoxLevel_TextChanged(object sender, EventArgs e)
        {
            dataGridViewViewResultsCourse.Rows.Clear();
            dataGridViewStudents.Rows.Clear();
            //comboBoxViewResultsYear.Show();
             //Update();
            if (comboBoxViewResultsYear.SelectedItem == null)
                comboBoxViewResultsYear.Show();
            else
                update();
        }

        private void dataGridViewViewResultsCourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(dataGridViewViewResultsCourse.SelectedCells[0].Value.ToString());
            //MessageBox.Show(dataGridViewViewResultsCourse.CurrentCell.ColumnIndex.ToString());
            //if (dataGridViewViewResultsCourse.SelectedCells[0].GetType.)
            dataGridViewStudents.Rows.Clear();
            try
            {
                
                Connection con = new Connection();
                SqlConnection x = con.connect();
                SqlCommand cmd;
                if (dataGridViewViewResultsCourse.CurrentCell.ColumnIndex.ToString() == "0")
                {
                    cmd = new SqlCommand("select s.StNo , s.firstName,s.lastName ,r.Grade from Student s, RESULTS r where  r.CourseID =@id and s.StNo = r.StNo", x);
                    cmd.Parameters.Add(new SqlParameter("@id", dataGridViewViewResultsCourse.SelectedCells[0].Value.ToString()));
                }
                else
                {
                    cmd = new SqlCommand("select s.StNo , s.firstName,s.lastName ,r.Grade from Student s, RESULTS r where  r.CourseID =@curse and s.StNo = r.StNo", x);
                    cmd.Parameters.Add(new SqlParameter("@curse", dataGridViewViewResultsCourse.SelectedCells[0].Value.ToString()));
                }
                SqlDataReader rdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Columns.Add("stu_number");
                dt.Columns.Add("first_name");
                dt.Columns.Add("last_name");
                dt.Columns.Add("result");

                while (rdr.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["stu_number"] = rdr.GetValue(0);
                    dr["first_name"] = rdr.GetValue(1);
                    dr["last_name"] = rdr.GetValue(2);
                    dr["result"] = rdr.GetValue(3);
                    dt.Rows.Add(dr);
                    int num = dataGridViewStudents.Rows.Add(dr);
                    foreach (DataRow drow in dt.Rows)
                    {
                        dataGridViewStudents.Rows[num].Cells[0].Value = dr["stu_number"].ToString();
                        dataGridViewStudents.Rows[num].Cells[1].Value = dr["first_name"].ToString() +"   " + dr["last_name"].ToString();
                        dataGridViewStudents.Rows[num].Cells[2].Value = dr["result"].ToString();
                    }
                }

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.ToString());
            }
        }

        private void comboBoxAddResultsYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewAddResultsCourse.Rows.Clear();
           Connection con = new Connection();
            SqlConnection x = con.connect();
            SqlCommand cmd = new SqlCommand("select c.course_id  , c.course_name from courses c " +
                "where c.lec_id = @lecid and c.acadamic_level = @al",x);
            cmd.Parameters.Add(new SqlParameter("@lecid", username.ToString()));
            cmd.Parameters.Add(new SqlParameter("@al", comboBoxAddResultsYear.SelectedItem.ToString()));

            DataTable dt = new DataTable();
            dt.Columns.Add("Course_id");
            dt.Columns.Add("Course Name");
            SqlDataReader rdr = cmd.ExecuteReader(); 
            while(rdr.Read())
            {
                DataRow dr = dt.NewRow();
                dr["Course_id"] = rdr.GetValue(0);
                dr["Course Name"]= rdr.GetValue(1);
                dt.Rows.Add(dr);
                int num = dataGridViewAddResultsCourse.Rows.Add(dr);
                foreach (DataRow drow in dt.Rows)
                {

                    dataGridViewAddResultsCourse.Rows[num].Cells[0].Value = drow["Course_id"].ToString();
                    dataGridViewAddResultsCourse.Rows[num].Cells[1].Value = drow["Course Name"].ToString();
                    
                }


            }
            rdr.Close();
            x.Close();
        }

        private void dataGridViewAddResultsCourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridViewFnalMks.Rows.Clear();
        }

        private void dataGridViewYear1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            loadFeedbackSummary(dataGridViewYear1);
            loadRatings(dataGridViewYear1.SelectedCells[0].Value.ToString());
            

        }

        // this table load the summarised feedback to the datagrd on the right

        private void loadFeedbackSummary(DataGridView datagrid)
        {
            dataGridViewFbk.Rows.Clear(); // clearing right data grid when loading different details of courses
            dtfeedback.Clear(); // clearing the data table feedback
            feedbackTxt.Text = ""; // clearing the feedback label 
            try
            {
                feedbackTxt.Text = "";
                Connection con = new Connection();
                SqlConnection x = con.connect();
                SqlCommand cmd;
                if (datagrid.CurrentCell.ColumnIndex.ToString() == "0")
                {
                    cmd = new SqlCommand("select f.feedback from feedback f where f.course_id =@id", x);
                    cmd.Parameters.Add(new SqlParameter("@id", datagrid.SelectedCells[0].Value.ToString()));


                }
                else
                {
                    cmd = new SqlCommand("select f.feedback from feedback f , courses c " +
                        "where c.course_name like @cn and f.course_id = c.course_id", x);
                    cmd.Parameters.Add(new SqlParameter("@cn", datagrid.SelectedCells[0].Value.ToString()));

                }
                SqlDataReader rdr = cmd.ExecuteReader();

                // only if there isnt new row a new row is created
                if (dtfeedback.Columns.Count == 0)
                    dtfeedback.Columns.Add("feedback");
                while (rdr.Read())
                {
                    DataRow dr = dtfeedback.NewRow();
                    dr["feedback"] = rdr.GetValue(0);
                    dtfeedback.Rows.Add(dr);
                    int num = dataGridViewFbk.Rows.Add(dr);

                    foreach (DataRow drow in dtfeedback.Rows)
                    {
                        dataGridViewFbk.Rows[num].Cells[0].Value = dr["feedback"].ToString();

                    }
                }
                feedbackTxt.Text = dtfeedback.Rows[0].ItemArray[0].ToString();
                pictureBoxFirst.Hide();
                pictureBoxPrevious.Hide();
                
                //MessageBox.Show("row count" + dtfeedback.Rows.Count.ToString());
                if (fbkrecord == dtfeedback.Rows.Count)
                {
                    pictureBoxNext.Hide();
                    pictureBoxLast.Hide();
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }

        }
    

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
            
        {
           // MessageBox.Show("loaded");
            
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            
            loadFeedbackDetails('2', dataGridViewYear2);

            // to clear the course items repeatedly generating 
            dataGridViewYear3.Rows.Clear();
            dataGridViewYear4.Rows.Clear();
            //dataGridViewYear1.Rows[0].Selected = false;
            loadRatings(dataGridViewYear2.Rows[0].Cells[0].Value.ToString());
            

        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            loadFeedbackDetails('3', dataGridViewYear3);

            // to clear the course items repeatedly generating 
            dataGridViewYear2.Rows.Clear();
            dataGridViewYear4.Rows.Clear();
            loadRatings(dataGridViewYear3.Rows[0].Cells[0].Value.ToString());


        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            loadFeedbackDetails('4', dataGridViewYear4);

            // to clear the course items repeatedly generating 
            dataGridViewYear2.Rows.Clear();
            dataGridViewYear3.Rows.Clear();
            loadRatings(dataGridViewYear4.Rows[0].Cells[0].Value.ToString());

            //pbSetZero(); 
        }

        private void dataGridViewYear2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            loadFeedbackSummary(dataGridViewYear2);
            loadRatings(dataGridViewYear2.SelectedCells[0].Value.ToString());
        }

        private void dataGridViewYear3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            loadFeedbackSummary(dataGridViewYear3);
            loadRatings(dataGridViewYear3.SelectedCells[0].Value.ToString());
        }

        private void dataGridViewYear4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            loadFeedbackSummary(dataGridViewYear4);
            loadRatings(dataGridViewYear4.SelectedCells[0].Value.ToString());
        }

        private void dataGridViewFbk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBoxFirst.Show();
            pictureBoxPrevious.Show();
            pictureBoxNext.Show();
            pictureBoxLast.Show();
            
            fbkrecord = dataGridViewFbk.CurrentCell.RowIndex;
            feedbackTxt.Text = dtfeedback.Rows[fbkrecord].ItemArray[0].ToString();
            if (fbkrecord == 0)
            {
                pictureBoxFirst.Hide();
                pictureBoxPrevious.Hide();
            }
           // MessageBox.Show(dtfeedback.Rows.Count.ToString());
           if ( fbkrecord == dtfeedback.Rows.Count-1)
            {
                pictureBoxNext.Hide();
                pictureBoxLast.Hide(); 
            }
        }

        private void pictureBoxFirst_Click(object sender, EventArgs e)
        {
            pictureBoxFirst.Hide();
            pictureBoxPrevious.Hide();
            dataGridViewFbk.Rows[fbkrecord].Selected = false;
            fbkrecord = 0;
            feedbackTxt.Text = dtfeedback.Rows[fbkrecord].ItemArray[0].ToString();
            pictureBoxLast.Show();
            pictureBoxNext.Show();
            dataGridViewFbk.Rows[0].Selected = true;


        }

        private void pictureBoxPrevious_Click(object sender, EventArgs e)
        {
            feedbackTxt.Text = dtfeedback.Rows[--fbkrecord].ItemArray[0].ToString();
            pictureBoxNext.Show();
            pictureBoxLast.Show();
            dataGridViewFbk.Rows[fbkrecord+1].Selected = false;
            dataGridViewFbk.Rows[fbkrecord].Selected = true;
            if (fbkrecord == 0)
            {
                pictureBoxFirst.Hide();
                pictureBoxPrevious.Hide();
            }
        }

        private void pictureBoxNext_Click(object sender, EventArgs e)
        {
            feedbackTxt.Text = dtfeedback.Rows[++fbkrecord].ItemArray[0].ToString();
            pictureBoxFirst.Show();
            pictureBoxPrevious.Show();
            dataGridViewFbk.Rows[fbkrecord - 1].Selected = false;
            dataGridViewFbk.Rows[fbkrecord].Selected = true;
            if (fbkrecord == dtfeedback.Rows.Count - 1)
            {
                pictureBoxNext.Hide();
                pictureBoxLast.Hide();
            }

        }

        private void pictureBoxLast_Click(object sender, EventArgs e)
        {
            pictureBoxFirst.Show();
            pictureBoxPrevious.Show();
            dataGridViewFbk.Rows[fbkrecord].Selected = false;
            fbkrecord = dtfeedback.Rows.Count-1;
            feedbackTxt.Text = dtfeedback.Rows[fbkrecord].ItemArray[0].ToString();
            dataGridViewFbk.Rows[fbkrecord].Selected = true;
            pictureBoxNext.Hide();
            pictureBoxLast.Hide();
        }

        private void loadRatings(string cid)
        {
            int total = 0;
            int[] ratings = new int [] { 0, 0, 0, 0, 0 };
            //progressBar1.Dispose();
            //MessageBox.Show(cid);
            
            Connection con = new Connection();
            SqlConnection x = con.connect();
            SqlCommand cmd = new SqlCommand("select count(r.rating)  from Ratings r , courses c " +
                "where c.lec_id = 'lec' and r.course_id = @cid and " +
                "c.course_id = r.course_id group by rating ", x);
            cmd.Parameters.Add(new SqlParameter("@lec", username.ToString()));
            cmd.Parameters.Add(new SqlParameter("@cid", cid.ToString()));


            SqlDataReader rdr = cmd.ExecuteReader();
            int j = 0;
            while(rdr.Read())
            {
                ratings[j++] = (int)rdr.GetValue(0);
               /// MessageBox.Show(ratings[j- 1].ToString());
                total = total + (int)rdr.GetValue(0);
                             
            }
            rdr.Close();
            x.Close();
            

            showProgresbar(progressBar1, total, ratings[0]);
            showProgresbar(progressBar2, total, ratings[1]);
            showProgresbar(progressBar3, total, ratings[2]);
            showProgresbar(progressBar4, total, ratings[3]);
            showProgresbar(progressBar5, total, ratings[4]);

        }
       
        private void showProgresbar(ProgressBar pb, int max , int count)
        {
            pb.Value = 0; 
            pb.Maximum = max;
            pb.Step = 1;
            for (int i = 0; i < count; i++)
                pb.PerformStep(); 
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            dataGridViewYear2.Rows.Clear();
            dataGridViewYear3.Rows.Clear();
            dataGridViewYear4.Rows.Clear();
           
            loadRatings(dataGridViewYear1.Rows[0].Cells[0].Value.ToString());
        }

        private void textBoxspecialise_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelEmail_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string location = "";
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                location = fd.FileName;
            }
            try
            {
                var exapp = new excel.Application();
                exapp.Visible = true;
                exapp.Workbooks.Open(location);

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.ToString());
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            //dataGridViewFnalMks.Rows.Clear();
            DataTable mks = new DataTable();
            string location = "";
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                location = fd.FileName;
            }
            try
            {
                OleDbConnection excon = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + location + ";Extended Properties=Excel 8.0;");
                OleDbDataAdapter adap = new OleDbDataAdapter("select [Student Number] , [final marks] from[Sheet1$]", excon);
                adap.Fill(mks);
                mks.Columns.Add("grade", typeof(System.String));
                foreach(DataRow dr in mks.Rows)
                {
                    if (Convert.ToInt32(dr[1]) >= 85)
                        dr["grade"] = "A+";

                   else  if (Convert.ToInt32(dr[1]) >= 70)
                        dr["grade"] = "A";

                   else if (Convert.ToInt32(dr[1]) >= 65)
                        dr["grade"] = "A-";

                    else if (Convert.ToInt32(dr[1]) >= 60)
                        dr["grade"] = "B+";

                    else if (Convert.ToInt32(dr[1]) >= 55)
                        dr["grade"] = "B";

                    else if (Convert.ToInt32(dr[1]) >= 50)
                        dr["grade"] = "B-";

                    else if (Convert.ToInt32(dr[1]) >= 45)
                        dr["grade"] = "C+";

                    else if (Convert.ToInt32(dr[1]) >= 40)
                        dr["grade"] = "C";

                    else if (Convert.ToInt32(dr[1]) >= 35)
                        dr["grade"] = "C-";

                    else if (Convert.ToInt32(dr[1]) >= 30)
                        dr["grade"] = "D+";
                    else if (Convert.ToInt32(dr[1]) >= 25)
                        dr["grade"] = "D";
                    else
                        dr["grade"] = "D-";


                }
                dataGridViewFnalMks.DataSource = mks;

            }
            catch  (System.Data.OleDb.OleDbException ex1 )
            {
                MessageBox.Show("pls select 2003 excel version ");
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.ToString());
            }
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            int r = 0;
            //MessageBox.Show(comboBoxAddResultsYear.SelectedIndex.ToString());
            //MessageBox.Show(dataGridViewAddResultsCourse.CurrentCell.RowIndex.ToString());

            try
             {
                    Connection conObj = new Connection();
                    SqlConnection x = conObj.connect();
               



                foreach (DataGridViewRow row in dataGridViewFnalMks.Rows)
                    {
                        try
                         {
                        SqlCommand cmd = new SqlCommand("insert into RESULTS(CourseID ,StNo ,acadamic_year,Grade) " +
                       "values(@cid, @sid, @ay, @gr) ", x);
                        //MessageBox.Show(r.ToString());
                            cmd.Parameters.Add(new SqlParameter("@cid", dataGridViewAddResultsCourse.CurrentCell.Value.ToString()));
                             //MessageBox.Show(dataGridViewAddResultsCourse.CurrentCell.Value.ToString());
                            cmd.Parameters.Add(new SqlParameter("@ay", Convert.ToInt32(comboBoxAddResultsYear.Text)));
                            //MessageBox.Show(comboBoxAddResultsYear.Text);
                            cmd.Parameters.Add(new SqlParameter("@sid", dataGridViewFnalMks[0,r].Value.ToString()));
                            //MessageBox.Show(dataGridViewFnalMks[0, r].Value.ToString());
                            //char [] grade = .ToCharArray();
                            cmd.Parameters.Add(new SqlParameter("@gr", dataGridViewFnalMks[2, r].Value.ToString()));
                           
                            cmd.ExecuteNonQuery();
                            dataGridViewFnalMks.Rows.RemoveAt(r);
                            r++;
                            
                         }
                        catch (System.Data.SqlClient.SqlException sql)
                        {
                        //MessageBox.Show(sql.ToString());
                        MessageBox.Show("you have already added the result row number " + (r + 1) + "to the list");
                          r++;
                        }
                         
                    }
                        x.Close();
                         MessageBox.Show("addition of data is complete ");
            }
            
                catch(System.NullReferenceException nulexe)
            {
                if (comboBoxAddResultsYear.SelectedIndex == -1 )
                    MessageBox.Show("please fill acadamic year  ");

                if (dataGridViewAddResultsCourse.SelectedCells.Count == 0)
                    MessageBox.Show("please select the relavant course");
            }
                catch (Exception exe)
                {
                    Console.Out.WriteLine(exe.ToString());
                }
                

            
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox22_Click(object sender, EventArgs e)

        {
            try
            {
                dataGridViewFnalMks.Rows.RemoveAt(dataGridViewFnalMks.SelectedRows[0].Index);
            }
            catch(IndexOutOfRangeException ioexe )
            {
                MessageBox.Show("please select the correct row");
            }
            catch(Exception exe )
            {

            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }
    }
}
