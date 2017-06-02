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

namespace ResultManagementSystemKalpa
{
    // the label on the bottom is given relavant name and 1
    // label which on top is given relavant name and 2
    public partial class frmLecturers : Form
    {
        private string username = frmlogin.getUsername();
        private object Filestream;

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
            try
            {

                Connection conObj = new Connection();
                SqlConnection x = conObj.connect();
                SqlCommand cmd = new SqlCommand("select distinct t.acadamic_year from take_course t ; ", x);
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
                textBoxResearch.Text = sdr.GetValue(6).ToString();
                textBoxspecialise.Text = sdr.GetValue(7).ToString();
                // getiing the image from sql server
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
            FeedbackPanel.BringToFront();
        }

        private void addResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddResultsPanel.BringToFront();
        }

        private void checkResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultsPanel.BringToFront();
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
                SqlCommand cmd = new SqlCommand("update lecturer set profile_pic = @img  where lec_id = 'lec'", x);
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
                        specialisation = specialisation + "   ,   " + dataGridViewSpec.Rows[i].Cells[0].Value.ToString();
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
                        research = research + "  ,  " + dataGridViewResearch.Rows[i].Cells[0].Value.ToString();
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
            string[] curseid = new string[50];
            string[] cursename = new string[50];
            int i = 0;
            int j = 0;

            string level = comboBoxLevel.SelectedItem.ToString();
            string acyear = comboBoxViewResultsYear.SelectedItem.ToString();

            try
            {
                Connection conn = new Connection();
                SqlConnection x = conn.connect();
                SqlCommand cmd = new SqlCommand("select distinct c.course_id from lecturer l , courses c, take_course t " +
                    "where l.lec_id =@id and c.acadamic_level =@al and t.acadamic_year =@ay " +
                    "and l.lec_id = c.lec_id and c.course_id = t.course_id; ", x);

                cmd.Parameters.Add(new SqlParameter("@id", username.ToString()));
                cmd.Parameters.Add(new SqlParameter("@al", comboBoxLevel.SelectedItem.ToString()));
                cmd.Parameters.Add(new SqlParameter("@ay", comboBoxViewResultsYear.SelectedItem.ToString()));

                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read() && i < 50)
                {
                    curseid[i] = rdr.GetValue(0).ToString();
                    j++;
                }
                rdr.Close();



                for (i = 0; i < j; i++)
                {
                    SqlCommand cmd1 = new SqlCommand("select c.course_name from courses c where c.course_id = @id", x);
                    cmd1.Parameters.Add(new SqlParameter("@id", curseid[i].ToString()));
                    SqlDataReader rdr1 = cmd1.ExecuteReader();
                    while (rdr1.Read())
                    {
                        cursename[i] = rdr1.GetValue(0).ToString();
                    }


                    rdr1.Close();
                    //MessageBox.Show(curseid[i] + "   " + cursename[i]);
                }


                for (i = 0; i < j; i++)
                {
                    dataGridViewViewResultsCourse.Rows[i].Cells[0].Value = curseid[i].ToString();
                    dataGridViewViewResultsCourse.Rows[i].Cells[1].Value = cursename[i].ToString();
                }
                x.Close(); 

            }
            catch (Exception exe1)
            {
                MessageBox.Show(exe1.Message);

            }
        }

        private void comboBoxLevel_TextChanged(object sender, EventArgs e)
        {
            dataGridViewViewResultsCourse.Rows.Clear();
            dataGridViewStudents.Rows.Clear();
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
            try
            {
                
                Connection con = new Connection();
                SqlConnection x = con.connect();
                SqlCommand cmd;
                if (dataGridViewViewResultsCourse.CurrentCell.ColumnIndex.ToString() == "0")
                {
                    cmd = new SqlCommand("select s.stu_number , s.first_name ,s.last_name , t.result" +
                        " from Student s , take_course t " +
                        "where t.course_id =@id and s.stu_number = t.stu_number ", x);
                    cmd.Parameters.Add(new SqlParameter("@id", dataGridViewViewResultsCourse.SelectedCells[0].Value.ToString()));
                }
                else
                {
                    cmd = new SqlCommand("select s.stu_number , s.first_name ,s.last_name , t.result " +
                        "from Student s , take_course t, courses c where  c.course_name like @curse " +
                        "and s.stu_number = t.stu_number and t.course_id = c.course_id", x);
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
                MessageBox.Show(exe.Message);
            }
        }

        private void comboBoxAddResultsYear_SelectedIndexChanged(object sender, EventArgs e)
        {
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
    }
}
