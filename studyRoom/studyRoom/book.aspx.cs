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
    public partial class WebForm2 : System.Web.UI.Page
    {
        
        SqlConnection studyRoomCN = new SqlConnection();
        DataTable roomAvailableTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            var cstr = System.Configuration.ConfigurationManager.ConnectionStrings["studyRoomCN"];
            string strConn = cstr.ConnectionString;
            studyRoomCN = new SqlConnection(strConn);

            if (!IsPostBack)
            {
                LoadDates();
                LoadRoomsAvailable();

            }
        }

        protected void LoadDates()
        {
            var today = DateTime.Today;

            for(int i=0; i<7; i++)
            {
                bookingDate.Items.Add(new ListItem(today.ToString("yyyy-MM-dd")));
                today = today.AddDays(1);
            }
        }

        protected void LoadRoomsAvailable()
        {
            studyRoomCN.Open();
            DataTable roomAvailableTable = new DataTable();
            //Thought Buildup: http://dba.stackexchange.com/questions/111426/detect-if-two-time-periods-overlap
            string sql =    "SELECT roomID, roomNum FROM rooms WHERE roomNum NOT IN (" +
                                "SELECT RoomNum FROM filterBookings WHERE" +
                                    "([check IN] >= DATEADD(day, DATEDIFF(day,'19000101',@bookingDate), CAST(@startTime AS DATETIME2(7)))) AND ([check IN] <= DATEADD(minute, @timeRange, DATEADD(day, DATEDIFF(day,'19000101',@bookingDate), CAST(@startTime AS DATETIME2(7))))) " +
                                    "OR ([check OUT] >= DATEADD(day, DATEDIFF(day,'19000101',@bookingDate), CAST(@startTime AS DATETIME2(7)))) AND ([check OUT] <= DATEADD(minute, @timeRange, DATEADD(day, DATEDIFF(day,'19000101',@bookingDate), CAST(@startTime AS DATETIME2(7))))) " +
                                    "OR([check IN] <= DATEADD(day, DATEDIFF(day, '19000101', @bookingDate), CAST(@startTime AS DATETIME2(7)))) AND([check OUT] >= DATEADD(minute, @timeRange, DATEADD(day, DATEDIFF(day, '19000101', @bookingDate), CAST(@startTime AS DATETIME2(7))))) " +
                            ")";
            using (SqlCommand cmd = new SqlCommand(sql, studyRoomCN))
            {

                cmd.Parameters.Add("@bookingDate", SqlDbType.Date).Value = bookingDate.SelectedValue;
                cmd.Parameters.Add("@startTime", SqlDbType.Time).Value = startTime.SelectedValue;
                cmd.Parameters.Add("@timeRange", SqlDbType.Int).Value = bookingDuration.SelectedValue;

                SqlDataReader dr = cmd.ExecuteReader();
                roomAvailableTable.Load(dr);
                dr.Close();
            }

            studyRoomCN.Close();

            roomsAvailable.DataSource = roomAvailableTable;
            roomsAvailable.DataValueField = "roomID";
            roomsAvailable.DataTextField = "roomNum";
            roomsAvailable.DataBind();
        }

        protected void startTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoomsAvailable();            
        }

        protected void bookRoomBtn_Click(object sender, EventArgs e)
        {
            try
            {
                studyRoomCN.Open();
                //Source(DateAdd): https://msdn.microsoft.com/en-CA/library/ms186819.aspx?f=255&MSPPError=-2147217396
                string sql = "INSERT INTO booking (bookingDate, startTime, endTime, roomID, userID) VALUES (@date, @checkIn, DATEADD(minute, @timeRange, @checkIn), @roomID, @userID)";
                using (SqlCommand cmd = new SqlCommand(sql, studyRoomCN))
                {
                    string userID = (string)Session["userID"];
                    // set up all parameters
                    cmd.Parameters.Add("@date", SqlDbType.Date).Value = bookingDate.SelectedValue;
                    cmd.Parameters.Add("@checkIn", SqlDbType.Time).Value = startTime.SelectedValue;
                    //Reference to getCheckoutTime() Method which will add minutes to Time
                    cmd.Parameters.Add("@timeRange", SqlDbType.Int).Value = bookingDuration.SelectedValue;
                    cmd.Parameters.Add("@userID", SqlDbType.VarChar).Value = userID;
                    cmd.Parameters.Add("@roomID", SqlDbType.VarChar).Value = roomsAvailable.SelectedValue;

                    cmd.ExecuteNonQuery();
                }
                studyRoomCN.Close();
                Response.Redirect("bookings.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Booking Failed! " + ex + "');</script>");
            }
        }
    }
}