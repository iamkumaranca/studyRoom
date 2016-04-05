using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace studyRoom
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection studyRoomCN = new SqlConnection();
        DataTable userTable = new DataTable();
        DataTable allUserTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            var cstr = System.Configuration.ConfigurationManager.ConnectionStrings["studyRoomCN"];
            string strConn = cstr.ConnectionString;
            studyRoomCN = new SqlConnection(strConn);

            if (!IsPostBack)
            {
                LoadUserInfo();
            }
        }

        protected void LoadUser()
        {
            studyRoomCN.Open();
            userTable.Clear();
            string userID = (string)Session["userID"];
            string sql = "SELECT * FROM users WHERE userID = @userID";
            using (SqlCommand cmd = new SqlCommand(sql, studyRoomCN))
            {
                cmd.Parameters.Add("@userID", SqlDbType.VarChar);
                cmd.Parameters["@userID"].Value = userID;

                SqlDataReader dr = cmd.ExecuteReader();
                userTable.Load(dr);
                dr.Close();
            }
            studyRoomCN.Close();
        }

        protected void LoadAllUsers()
        {
            studyRoomCN.Open();
            allUserTable.Clear();
            string sql = "SELECT * FROM users";
            using (SqlCommand cmd = new SqlCommand(sql, studyRoomCN))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                allUserTable.Load(dr);
                dr.Close();
            }
            studyRoomCN.Close();
        }

        protected void LoadUserInfo()
        {
            string strFName, strLName, strEmail, strPhone;

            LoadUser();

            strFName = userTable.Rows[0][1].ToString();
            strLName = userTable.Rows[0][2].ToString();
            strEmail = userTable.Rows[0][3].ToString();
            strPhone = userTable.Rows[0][4].ToString();

            fName.Value = strFName;
            lName.Value = strLName;
            email.Value = strEmail;
            telephone.Value = strPhone;
        }

        protected void updateUser()
        {
            bool currPassValid = false;
            bool emailFound = false;
            string passMatch = "na";

            LoadUser();
            LoadAllUsers();

            string curFName = userTable.Rows[0][1].ToString();
            string curLName = userTable.Rows[0][2].ToString();
            string curEmail = userTable.Rows[0][3].ToString();
            string curPhone = userTable.Rows[0][4].ToString();
            string currSalt = userTable.Rows[0][5].ToString();
            string currPassword = userTable.Rows[0][6].ToString();
            String hashedCurrEnteredPassword = generateSHA512Hash(currentPassword.Value, currSalt);

            string newFName = fName.Value;
            string newLName = lName.Value;
            string newEmail = email.Value;
            string newPhone = telephone.Value;
            string newPassword = password2.Value;

            for (int i = 0; i < allUserTable.Rows.Count; i++)
            {
                if (allUserTable.Rows[i][3].ToString() == email.Value)
                {
                    if (userTable.Rows[0][3].ToString() != allUserTable.Rows[i][3].ToString())
                    {
                        emailFound = true;
                    }
                }
            }

            if (hashedCurrEnteredPassword == currPassword)
            {
                currPassValid = true;
            }

            if (password1.Value != "" && password2.Value != "")
            {
                if (password1.Value == password2.Value)
                {
                    passMatch = "true";
                }
                else
                {
                    passMatch = "false";
                }
            }

            if (emailFound)
            {
                profileError.InnerHtml = "<p class='alert alert-danger'>The new email entered is already used for another account. Please enter a different email.</p>";
            }
            else if (!currPassValid)
            {
                profileError.InnerHtml = "<p class='alert alert-danger'>The current password entered is invalid. Please enter the correct password.</p>";
            }
            else if (passMatch == "false")
            {
                profileError.InnerHtml = "<p class='alert alert-danger'>The new passwords do not match. Please enure the passwords match!</p>";
            }

            if (!emailFound && currPassValid)
            {
                try
                {
                    dbUpdateUser(newFName, newLName, newEmail, newPhone, newPassword, passMatch);
                }
                catch
                {
                    dbUpdateUser(curFName, curLName, curEmail, curPhone, currPassword, passMatch);
                    profileError.InnerHtml = "<p class='alert alert-danger'>Update FAILED! Please try again!</p>";
                }
            }
        }

        protected void dbUpdateUser(string fname, string lname, string email, string phone, string password, string passMatch)
        {
            if (passMatch == "true")
            {
                String salt = createSalt(15);
                String hashednewPassword = generateSHA512Hash(password, salt);
                string userID = (string)Session["userID"];

                studyRoomCN.Open();
                string sql = "UPDATE users SET fName = @fName, lName = @lName, email = @email, phone = @phone, saltHash = @saltHash, password = @password WHERE userID = @userID";
                using (SqlCommand cmd = new SqlCommand(sql, studyRoomCN))
                {
                    // set up all parameters
                    cmd.Parameters.Add("@userID", SqlDbType.VarChar);
                    cmd.Parameters["@userID"].Value = userID;
                    cmd.Parameters.Add("@fName", SqlDbType.VarChar);
                    cmd.Parameters["@fName"].Value = fname;
                    cmd.Parameters.Add("@lName", SqlDbType.VarChar);
                    cmd.Parameters["@lName"].Value = lname;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar);
                    cmd.Parameters["@email"].Value = email;
                    cmd.Parameters.Add("@phone", SqlDbType.VarChar);
                    cmd.Parameters["@phone"].Value = phone;
                    cmd.Parameters.Add("@saltHash", SqlDbType.VarChar);
                    cmd.Parameters["@saltHash"].Value = salt;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar);
                    cmd.Parameters["@password"].Value = hashednewPassword;
                    cmd.ExecuteNonQuery();
                }
                studyRoomCN.Close();
            }
            else if (passMatch == "na")
            {
                string userID = (string)Session["userID"];
                //studyRoomCN.Close();
                studyRoomCN.Open();
                string sql = "UPDATE users SET fName = @fName, lName = @lName, email = @email, phone = @phone WHERE userID = @userID";
                using (SqlCommand cmd = new SqlCommand(sql, studyRoomCN))
                {
                    // set up all parameters
                    cmd.Parameters.Add("@userID", SqlDbType.VarChar);
                    cmd.Parameters["@userID"].Value = userID;
                    cmd.Parameters.Add("@fName", SqlDbType.VarChar);
                    cmd.Parameters["@fName"].Value = fname;
                    cmd.Parameters.Add("@lName", SqlDbType.VarChar);
                    cmd.Parameters["@lName"].Value = fname;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar);
                    cmd.Parameters["@email"].Value = email;
                    cmd.Parameters.Add("@phone", SqlDbType.VarChar);
                    cmd.Parameters["@phone"].Value = phone;
                    cmd.ExecuteNonQuery();
                }
                studyRoomCN.Close();
            }
            LoadUserInfo();
            profileError.InnerHtml = "<p class='alert alert-success'>Your profile has been successfuly updated!</p>";
        }

        protected void updateProfile_Click(object sender, EventArgs e)
        {
            updateUser();
        }

        private static String ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }

        private String createSalt(int size)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        private String generateSHA512Hash(String input, String salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA512Managed sha512HashString =
                new System.Security.Cryptography.SHA512Managed();
            byte[] hash = sha512HashString.ComputeHash(bytes);

            return ByteArrayToHexString(hash);
        }
    }
}