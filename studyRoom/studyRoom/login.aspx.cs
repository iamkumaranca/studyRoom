using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

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
                //Response.Write("<script>$('#loginError').text('Welcome');</script>");
                //Response.Write("<script>var loginError = document.getElementById('loginError'); loginError.innerHTML = loginError.innerHTML + 'Extra stuff';</script>");
                loginError.InnerHtml = "<p class='alert alert-danger'>Invalid Email or Password. Please try again!</p>";
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            checkUser();
        }
    }
}