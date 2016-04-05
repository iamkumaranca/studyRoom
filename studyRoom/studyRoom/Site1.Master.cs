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
    public partial class Site1 : System.Web.UI.MasterPage
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
                isUserLoggedIn();
            }
        }

        protected void isUserLoggedIn()
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                loadUserInfo();
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

        protected void loadUserInfo()
        {
            LoadUser();

            string fName = userTable.Rows[0][1].ToString();
            string lName = userTable.Rows[0][2].ToString();

            userName.InnerHtml = fName + " " + lName;
            // registerError.InnerHtml = "<p class='alert alert-danger'>Passwords do not match. Please enure the passwords match!</p>";
        }
    }
}