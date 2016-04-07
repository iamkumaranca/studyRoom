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
            studyRoomCN.Open();
            string userID = (string)Session["userID"];
            DataTable roomTable = new DataTable();
            roomTable.Clear();
            string sql = "SELECT bookingID, CONVERT(VARCHAR(12), bookingDate, 107), CONVERT(VARCHAR(5), startTime,108), CONVERT(VARCHAR(5), endTime,108), roomNum, roomLoc, roomCap FROM booking, rooms WHERE booking.roomID = rooms.roomID AND userID = @userID ORDER BY bookingDate, startTime, roomNum";
            using (SqlCommand cmd = new SqlCommand(sql, studyRoomCN))
            {
                cmd.Parameters.Add("@userID", SqlDbType.VarChar);
                cmd.Parameters["@userID"].Value = userID;

                SqlDataReader dr = cmd.ExecuteReader();
                roomTable.Load(dr);
                dr.Close();
            }
            studyRoomCN.Close();

            string bookingRow = "";

            for (int i = 0; i < roomTable.Rows.Count; i++)
            {
                bookingRow += "<tr class='even pointer'> " +
                                   "<td>" + roomTable.Rows[i][1].ToString() + "</td>" +
                                   "<td>" + roomTable.Rows[i][2].ToString() + "</td>" +
                                   "<td>" + roomTable.Rows[i][3].ToString() + "</td>" +
                                   "<td>" + roomTable.Rows[i][4].ToString() + "</td>" +
                                   "<td>" + roomTable.Rows[i][5].ToString() + "</td>" +
                                   "<td>" + roomTable.Rows[i][6].ToString() + "</td>" +
                                   "<td class='last'><a href='#'>Cancel</a></td>" +
                                   "</tr>";
            }
            bookingTable.InnerHtml = bookingRow;
        }

        protected void LoadBookings()
        {
            LoadBookingsTable();

            for (int i = 0; i < roomTable.Rows.Count; i++)
            {
                bookingTable.InnerHtml = "<tr class='even pointer'> " +
                                         "<td>" + roomTable.Rows[0][1].ToString() + "</td>" +
                                         "<td>" + roomTable.Rows[0][2].ToString() + "</td>" +
                                         "<td>" + roomTable.Rows[0][3].ToString() + "</td>" +
                                         "<td>" + roomTable.Rows[0][4].ToString() + "</td>" +
                                         "<td>" + roomTable.Rows[0][5].ToString() + "</td>" +
                                         "<td>" + roomTable.Rows[0][6].ToString() + "</td>" +
                                         "<td class='last'><a href='#'>Cancel</a></td>" +
                                         "</tr>";
            }
        }
    }
}