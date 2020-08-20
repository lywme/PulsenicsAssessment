using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace pulsenicsQ1
{
    public partial class Form1 : Form
    {
        String path = @"c:\testP\";
        //Store all the file info from the given path
        FileInfo[] files = null;

        //Store all users
        List<String> allUsers;
        //ComputerName\instance name
        String strConnection = @"Server=WIN-6T88S75M201\SQLEXPRESS;initial catalog=testP;user id=sa;password=123456;Connect Timeout=5";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //A> load all the files into ListBox
            aLabel.Text += " " + path;
            loadFiles();
            //D> load users from DB
            loadUsers();
        }

        private void loadFiles()
        {
            //Load files from the directory
            fileListBox.Items.Clear();
            try
            {
                DirectoryInfo theFolder = new DirectoryInfo(path);
                files = theFolder.GetFiles();
                foreach (FileInfo file in files)
                {
                    fileListBox.Items.Add(file.Name);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Load files error, the path may not exist", "Error!");
            }
            finally
            {
                storeFilesIntoDB();
            }
        }

        private void storeFilesIntoDB()
        {
            //B> Save filename and details into sql DB
            //Save files to the files table
            if(files!=null)
            {
                SqlConnection conn = new SqlConnection(strConnection);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    foreach(FileInfo file in files)
                    {
                        
                        cmd.CommandText = "select count(*) from files where fileName='"+file.Name+"';";
                        int count = 0;
                        SqlDataReader sdrr = cmd.ExecuteReader();
                        while (sdrr.Read())
                        {
                            count = (int)sdrr[0];
                        }
                        sdrr.Close();
                        //MessageBox.Show(count.ToString());
                        //if the file does not exist in the table, but exists in Directory then insert file entry into DB
                        if (count == 1)
                        {
                            //file exists in Directory and exists in DB, determine if file info matches DB, if not update it(Update fileSize)
                            cmd.CommandText = "update files set fileSize=" + file.Length + " where fileName='" + file.Name + "'";
                            cmd.ExecuteNonQuery();


                            //if exists in DB but not exists in Directory, then delete file entry from DB
                            //Load all files from DB,store names into list
                            List<String> fileNameList = new List<string>();
                            cmd.CommandText = "select * from files";
                            SqlDataReader sdr = cmd.ExecuteReader();
                            while (sdr.Read())
                            {
                                fileNameList.Add((String)sdr[1]);
                            }
                            sdr.Close();
                            List<String> delList = new List<string>();
                            foreach (String eachFile in fileNameList)
                            {
                                bool exists = false;
                                foreach (FileInfo everyFile in files)
                                {
                                    if (everyFile.Name.Equals(eachFile))
                                    {
                                        exists = true;
                                    }
                                }
                                if (exists == false)
                                {
                                    //put file into delete list
                                    delList.Add(eachFile);
                                }
                            }


                            foreach (String delFile in delList)
                            {
                                //MessageBox.Show(delFile);
                                cmd.CommandText = "delete from files where fileName='" + delFile + "'";
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            cmd.CommandText = "insert into files values ('" + file.Name + "'," + file.Length + ");";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Encounter error when inserting files to database" + ex.Message);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                } 
            }
        }

        private void generateCheckBox()
        {
            //remove all checkBox
            foreach (Control control in this.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox t=(CheckBox)control;
                    this.Controls.Remove(t);
                }
            }


            int startY = 86;
            foreach (String user in allUsers)
            {
                CheckBox ckb = new CheckBox();
                ckb.AutoSize = true;
                ckb.Name = user;
                ckb.Text = user;
                //ckb.Location = new System.Drawing.Point(224, 86);
                //ckb.Size = new System.Drawing.Size(78, 16);
                //ckb.Size = new Size(78,16);
                ckb.Location = new Point(224,startY);
                Controls.Add(ckb);
                ckb.Click+=new EventHandler(ckb_Click);
                startY += 18;
            }
        }

        private void ckb_Click(object sender,EventArgs e)
        {
            CheckBox ckb = (CheckBox)sender;
            //MessageBox.Show(ckb.Text);

            //get the selected file name
            if(fileListBox.SelectedItem!=null)
            {
                String selectedFileName=fileListBox.SelectedItem.ToString();
                String clickedUser = ckb.Text;
                //MessageBox.Show(selectedFileName+"  clicked by  "+clickedUser);
                SqlConnection conn = new SqlConnection(strConnection);
                try
                {

                    long userId = -1;
                    long fileId = -1;
                    
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    //get fileId and userId
                    cmd.CommandText = "select * from users where userName='" + clickedUser + "'";
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        userId = (long)sdr[0];
                    }
                    sdr.Close();

                    cmd.CommandText = "select * from files where fileName='" + selectedFileName + "';";
                    SqlDataReader sdrr = cmd.ExecuteReader();
                    while (sdrr.Read())
                    {
                        fileId = (long)sdrr[0];
                    }
                    sdrr.Close();
                    //MessageBox.Show(userId.ToString() + " : " + fileId.ToString());

                    if (ckb.Checked == true)
                    {
                        //set the owner of a file
                        //save file owner relationship into DB
                        cmd.CommandText = "insert into fileOwner values(" + fileId + "," + userId + ");";
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        //remove owner entry
                        //MessageBox.Show("remove user entry");

                        cmd.CommandText = "delete from fileOwner where fileId="+fileId+" and userId="+userId+"";
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Encounter error when insert file owner" + ex.Message);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
        }
        

        private void loadUsers()
        {
            allUsers = new List<string>();
            SqlConnection conn = new SqlConnection(strConnection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from users";
                cmd.Connection = conn;
                SqlDataReader sdr = cmd.ExecuteReader();
                userlistBox.Items.Clear();
                while(sdr.Read())
                {
                    allUsers.Add((String)sdr[1]);
                    userlistBox.Items.Add(sdr[1]);
                }
                sdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Encounter error when connecting database"+ex.Message);
            }
            finally 
            {
                if (conn != null)
                {
                    conn.Close();
                }
                generateCheckBox();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            loadFileTimer.Enabled = false;
            if (searchTextBox.Text.Trim()=="")
            {
                loadFileTimer.Enabled = true;
            }
            fileListBox.Items.Clear();
            foreach (FileInfo f in files)
            {
                if (f.Name.Contains(searchTextBox.Text))
                {

                    fileListBox.Items.Add(f.Name);
                }
            }
   
        }

        static String GetLength(long lengthOfDocument)
        {

            if (lengthOfDocument < 1024)
                return string.Format(lengthOfDocument.ToString() + 'B');
            else if (lengthOfDocument > 1024 && lengthOfDocument <= Math.Pow(1024, 2))
                return string.Format((lengthOfDocument / 1024.0).ToString() + "KB");
            else if (lengthOfDocument > Math.Pow(1024, 2) && lengthOfDocument <= Math.Pow(1024, 3))
                return string.Format((lengthOfDocument / 1024.0 / 1024.0).ToString() + "M");
            else
                return string.Format((lengthOfDocument / 1024.0 / 1024.0 / 1024.0).ToString() + "GB");
        }

        private void loadFileTimer_Tick(object sender, EventArgs e)
        {
            loadFiles();
        }

        private void addUpdateBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strConnection);
            int numOfUser = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                if (userName.Text != "")
                {
                    cmd.CommandText = "select count(*) from users where userName='" + userName.Text + "'";
                    cmd.Connection = conn;
                    SqlDataReader sdr=cmd.ExecuteReader();
                    
                    while (sdr.Read())
                    {
                        numOfUser = (int)sdr[0];
                    }

                    sdr.Close();
                }

                if (userName.Text != "" && email.Text != "" && phone.Text != "")
                {
                    if (numOfUser == 0)
                    {
                        //if the userName does not exist, insert new user
                        cmd.CommandText = "insert into users values('" + userName.Text + "','" + email.Text + "','" + phone.Text + "')";
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully inserted a new user: "+userName.Text);
                    }
                    else
                    {
                        //if the userName exists, then update exist user info

                        cmd.CommandText = "update users set userName='"+userName.Text+"',email='"+email.Text+"',phone='"+phone.Text+"' where userName='"+userName.Text+"'";
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully updated user: " + userName.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Encounter error when inserting users" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

                clearinputUser();
                loadUsers();
            }
        }

        //remove all the userName,email,phone from input bar
        private void clearinputUser()
        {
                userName.Text = "";
                email.Text = "";
                phone.Text = "";
        }

        private void userlistBox_MouseClick(object sender, MouseEventArgs e)
        {
            String selectName=null;
            int index=userlistBox.IndexFromPoint(e.X,e.Y);
            userlistBox.SelectedIndex=index;
            if(userlistBox.SelectedIndex!=-1)
            {
                selectName=userlistBox.SelectedItem.ToString();
                //MessageBox.Show(selectName);


                SqlConnection conn = new SqlConnection(strConnection);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select * from users where userName='"+selectName+"'";
                    cmd.Connection = conn;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    //userlistBox.Items.Clear();
                    while (sdr.Read())
                    {
                        userName.Text = (String)sdr[1];
                        email.Text = (String)sdr[2];
                        phone.Text = (String)sdr[3];
                    }
                    sdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Encounter error when loading database" + ex.Message);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    //loadUsers();
                    userlistBox.SelectedItem = selectName;
                }
            }
            

            
        }

        private void userlistBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //delete a user
            String selectName = null;
            int index = userlistBox.IndexFromPoint(e.X, e.Y);
            userlistBox.SelectedIndex = index;
            if (userlistBox.SelectedIndex != -1)
            {
                selectName = userlistBox.SelectedItem.ToString();
                MessageBox.Show("Successfully delete user: "+selectName);

                
                SqlConnection conn = new SqlConnection(strConnection);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "delete from users where userName='" + selectName + "'";
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Encounter error when deleting database" + ex.Message);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    loadUsers();
                    clearinputUser();
                    generateCheckBox();
                } 
            }
        }

        private void fileListBox_MouseClick(object sender, MouseEventArgs e)
        {
            //stop timer, stop detect new files
            loadFileTimer.Enabled = false;

            //get the file name user clicked
            String selectName=null;
            int index=fileListBox.IndexFromPoint(e.X,e.Y);
            fileListBox.SelectedIndex = index;
            if (fileListBox.SelectedIndex != -1)
            {
                selectName = fileListBox.SelectedItem.ToString();
                //MessageBox.Show(selectName);
            }
            //MessageBox.Show(fileListBox.SelectedItem.ToString());

            
            //get the selected file name
            if (fileListBox.SelectedItem != null)
            {
                String selectedFileName = fileListBox.SelectedItem.ToString();
                SqlConnection conn = new SqlConnection(strConnection);
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    long fileId = -1;
                    //get selected fileId
                    cmd.CommandText = "select * from files where fileName='" + selectedFileName + "';";
                    SqlDataReader sdrr = cmd.ExecuteReader();
                    while (sdrr.Read())
                    {
                        fileId = (long)sdrr[0];
                    }
                    sdrr.Close();
                    //MessageBox.Show(fileId.ToString());


                    //get all the owner's userId based on the fileId
                    List<long> userIds = new List<long>();
                    cmd.CommandText = "select * from fileOwner where fileId="+fileId+";";
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        userIds.Add((long)sdr[1]);
                    }
                    sdr.Close();

                    //get all the owner's userNames based on the ids list
                    List<String> userNames = new List<string>();
                    foreach (long id in userIds)
                    {
                        cmd.CommandText = "select * from users where userId="+id+";";
                        SqlDataReader sdrrr = cmd.ExecuteReader();
                        while (sdrrr.Read())
                        {
                            userNames.Add((String)sdrrr[1]);
                        }
                        sdrrr.Close();
                    }


                    //go through all the userNames and set these corresponding checkLists to checked
                    foreach (Control control in this.Controls)
                    {
                        bool isOwner = false;
                        if (control is CheckBox)
                        {
                            CheckBox t = (CheckBox)control;
                            foreach (String user in userNames)
                            {
                                if (t.Text.Equals(user))
                                {
                                    isOwner = true;
                                }
                            }
                            if (isOwner == true)
                            {
                                t.Checked = true;
                            }
                            else
                            {
                                t.Checked = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Encounter error when get file owners" + ex.Message);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            loadFileTimer.Enabled = true;
        }
    }
}