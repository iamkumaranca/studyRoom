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
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection studyRoomCN = new SqlConnection();
        DataTable roomTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            var cstr = System.Configuration.ConfigurationManager.ConnectionStrings["studyRoomCN"];
            string strConn = cstr.ConnectionString;
            studyRoomCN = new SqlConnection(strConn);

            if (!IsPostBack)
            {
                LoadBookingsTable();
            }
        }

        protected void LoadBookingsTable()
        {
            //Clear Data
            bookingTableGV.DataSource = null;
            bookingTableGV.DataBind();

            studyRoomCN.Open();
            string userID = (string)Session["userID"];
            DataTable roomTable = new DataTable();
            roomTable.Clear();
            string sql = "SELECT CONVERT(VARCHAR(12), bookingDate, 107) AS 'Booking Date', CONVERT(VARCHAR(5), startTime,108) AS 'Start Time', CONVERT(VARCHAR(5), endTime,108) AS 'End Time', roomNum AS 'Room Number', roomLoc AS Campus, roomCap AS 'Room Capacity' FROM booking, rooms WHERE booking.roomID = rooms.roomID AND userID = @userID ORDER BY bookingDate, startTime, roomNum";
            using (SqlCommand cmd = new SqlCommand(sql, studyRoomCN))
            {
                cmd.Parameters.Add("@userID", SqlDbType.VarChar);
                cmd.Parameters["@userID"].Value = userID;

                SqlDataReader dr = cmd.ExecuteReader();
                roomTable.Load(dr);
                dr.Close();
            }
            studyRoomCN.Close();

            bookingTableGV.DataSource = roomTable;
            bookingTableGV.DataBind();
        }

        protected void BookingsGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            studyRoomCN.Open();
            try
            {
                //Source: https://social.msdn.microsoft.com/Forums/sqlserver/en-US/afcfb8bc-c0bb-45b1-b02b-2c19eef8aeff/how-to-write-sql-delete-script-with-rownumber?forum=transactsql
                string sql = "WITH cte AS ( SELECT *,row_number() over(order by bookingDate) AS row_number FROM booking WHERE userID = @userID ) DELETE FROM cte WHERE row_number = @row";
                using (SqlCommand cmd = new SqlCommand(sql, studyRoomCN))
                {
                    Response.Write("<script>alert('"+ e.RowIndex +"');</script>");
                    string userID = (string)Session["userID"];
                    cmd.Parameters.Add("@userID", SqlDbType.VarChar).Value = userID;
                    //Correction: e.RowIndex begins from 0.
                    cmd.Parameters.Add("@row", SqlDbType.VarChar).Value = e.RowIndex + 1;
                    cmd.ExecuteNonQuery();
                }
                studyRoomCN.Close();

                //Refresh the GridView after Deleting
                LoadBookingsTable();

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }


        }
    }
}