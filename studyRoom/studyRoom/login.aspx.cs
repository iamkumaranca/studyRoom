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
    public partial class login : System.Web.UI.Page
    {
        SqlConnection studyRoomCN = new SqlConnection();
        DataTable userTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            var cstr = System.Configuration.ConfigurationManager.ConnectionStrings["studyRoomCN"];
            string strConn = cstr.ConnectionString;
            studyRoomCN = new SqlConnection(strConn);

            if (!IsPostBack)
            {
                LoadUsers();
            }

        }

        protected void LoadUsers()
        {
            studyRoomCN.Open();
            userTable.Clear();
            string sql = "SELECT userID, email, password FROM users";
            using (SqlCommand cmd = new SqlCommand(sql, studyRoomCN))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                userTable.Load(dr);
                dr.Close();
            }
            studyRoomCN.Close();
        }

        protected void checkUser()
        {
            string email, password;
            bool emailValid, passValid;

            LoadUsers();

            email = emailLogin.Value;
            password = passwordLogin.Value;
            emailValid = false;
            passValid = false;

            for (int i = 0; i < userTable.Rows.Count; i++ )
            {
                if(userTable.Rows[i][1].ToString() == email)
                {
                    emailValid = true;
                    if(userTable.Rows[i][2].ToString() == password)
                    {
                        passValid = true;
                        Session["userID"] = userTable.Rows[i][0].ToString();
                        Response.Redirect("index.aspx");
                    }
                }
            }

            if (!emailValid || !passValid)
            {
                loginError.InnerHtml = "<p class='alert alert-danger'>Invalid Email or Password. Please try again!</p>";
            }
        }

        protected void registerUser()
        {
            bool emailFound = false;
            bool isInvalid = false;
            bool passwordSame = false;
            
            if (fName.Value == "" || lName.Value == "" || emailReg.Value == "" || phone.Value == "" || passwordReg.Value == "" || passwordConfirm.Value == "")
            {
                isInvalid = true;
            }

            LoadUsers();

            for (int i = 0; i < userTable.Rows.Count; i++ )
            {
                if (userTable.Rows[i][1].ToString() == emailReg.Value)
                {
                    emailFound = true;
                }
            }

            if (passwordReg.Value == passwordConfirm.Value)
            {
                passwordSame = true;
            }

            if (isInvalid)
            {
                registerError.InnerHtml = "<p class='alert alert-danger'>Please fill in all fields!</p>";
            }
            else if (emailFound)
            {
                registerError.InnerHtml = "<p class='alert alert-danger'>You already have an account. Please <a href='login.aspx'>log in</a>!</p>";
            }
            else if (!passwordSame)
            {
                registerError.InnerHtml = "<p class='alert alert-danger'>Passwords do not match. Please enure the passwords match!</p>";

            }

            if (!isInvalid && !emailFound)
            {
                addUser();
            }
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

        protected void addUser()
        {
            String salt = createSalt(15);
            String hashedPassword = generateSHA512Hash(passwordConfirm.Value, salt);

            studyRoomCN.Open();
            string sql = "INSERT INTO users (fName, lName, email, phone, saltHash, password) VALUES (@fName, @lName, @email, @phone, @saltHast, @password)";
            using (SqlCommand cmd = new SqlCommand(sql, studyRoomCN))
            {
                // set up all parameters
                cmd.Parameters.Add("@fName", SqlDbType.VarChar);
                cmd.Parameters["@fName"].Value = fName.Value;
                cmd.Parameters.Add("@lName", SqlDbType.VarChar);
                cmd.Parameters["@lName"].Value = lName.Value;
                cmd.Parameters.Add("@email", SqlDbType.VarChar);
                cmd.Parameters["@email"].Value = emailReg.Value;
                cmd.Parameters.Add("@phone", SqlDbType.VarChar);
                cmd.Parameters["@phone"].Value = phone.Value;
                cmd.Parameters.Add("@saltHash", SqlDbType.VarChar);
                cmd.Parameters["@saltHash"].Value = salt;
                cmd.Parameters.Add("@password", SqlDbType.VarChar);
                cmd.Parameters["@password"].Value = hashedPassword;
                cmd.ExecuteNonQuery();
            }
            studyRoomCN.Close();
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            checkUser();
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            registerUser();
        }
    }
}