<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="bookings.aspx.cs" Inherits="studyRoom.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="row">
           <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>My Bookings</h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <form class="form-horizontal form-label-left" novalidate runat="server">
                            <table class="table table-striped responsive-utilities jambo_table bulk_action">
                                <thead>
                                    <tr class="headings">
                                        <th class="column-title">Booking Date </th>
                                        <th class="column-title">Start Time </th>
                                        <th class="column-title">End Time </th>
                                        <th class="column-title">Room Number </th>
                                        <th class="column-title">Campus </th>
                                        <th class="column-title">Maximum Capacity </th>
                                        <th class="column-title no-link last"><span class="nobr">Cancel</span></th>
                                    </tr>
                                </thead>
                                <tbody id="bookingTable" runat="server">
                                </tbody>
                            </table>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
