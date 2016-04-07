<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="book.aspx.cs" Inherits="studyRoom.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- ion_range -->
    <link rel="stylesheet" href="./__assets/__css/normalize.css" />
    <link rel="stylesheet" href="./__assets/__css/ion.rangeSlider.css" />
    <link rel="stylesheet" href="./__assets/__css/ion.rangeSlider.skinFlat.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="row">
           <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Book a room</h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <!-- Smart Wizard -->
                        <div id="wizard" class="form_wizard wizard_horizontal">
                            <ul class="wizard_steps">
                                <li>
                                    <a href="#step-1">
                                        <span class="step_no">1</span>
                                        <span class="step_descr">Date<br /><small>Select a date</small></span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#step-2">
                                        <span class="step_no">2</span>
                                        <span class="step_descr">Time<br /><small>Select a start time and the duration</small></span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#step-3">
                                        <span class="step_no">3</span>
                                        <span class="step_descr">Room<br /><small>Select the desired room</small></span>
                                    </a>
                                </li>
                            </ul>
                            <form id="bookingForm" class="form-horizontal form-label-left" novalidate runat="server">
                                <div id="step-1">
                                    <h2 class="StepTitle">Step 1 Select a date</h2>
                                    <div class="form-group">
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="bookDate" CssClass="form-control has-feedback-left col-md-7 col-xs-12" runat="server" OnTextChanged="startTime_SelectedIndexChanged" AutoPostBack="true"></asp:TextBox>
                                            <span class="fa fa-calendar-o form-control-feedback left" aria-hidden="true"></span>
                                        </div>
                                    </div>
                                </div>
                                <div id="step-2">
                                    <h2 class="StepTitle">Step 2 Select time and duration</h2>
                                    <div class="form-group">
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:DropDownList Width="90" runat="server" CssClass="form-control col-md-7 col-xs-12" id="startTime" AutoPostBack="true" Enabled ="true" OnSelectedIndexChanged="startTime_SelectedIndexChanged">
                                                <asp:ListItem value="07:00">07:00</asp:ListItem>
                                                <asp:ListItem value="07:30">07:30</asp:ListItem>
                                                <asp:ListItem value="08:00">08:00</asp:ListItem>
                                                <asp:ListItem value="08:30">08:30</asp:ListItem>
                                                <asp:ListItem value="09:00">09:00</asp:ListItem>
                                                <asp:ListItem value="09:30">09:30</asp:ListItem>
                                                <asp:ListItem value="10:00">10:00</asp:ListItem>
                                                <asp:ListItem value="10:30">10:30</asp:ListItem>
                                                <asp:ListItem value="11:00">11:00</asp:ListItem>
                                                <asp:ListItem value="11:30">11:30</asp:ListItem>
                                                <asp:ListItem value="12:00">12:00</asp:ListItem>
                                                <asp:ListItem value="12:30">12:30</asp:ListItem>
                                                <asp:ListItem value="13:00">13:00</asp:ListItem>
                                                <asp:ListItem value="13:30">13:30</asp:ListItem>
                                                <asp:ListItem value="14:00">14:00</asp:ListItem>
                                                <asp:ListItem value="14:30">14:30</asp:ListItem>
                                                <asp:ListItem value="15:00">15:00</asp:ListItem>
                                                <asp:ListItem value="15:30">15:30</asp:ListItem>
                                                <asp:ListItem value="16:00">16:00</asp:ListItem>
                                                <asp:ListItem value="16:30">16:30</asp:ListItem>
                                                <asp:ListItem value="17:00">17:00</asp:ListItem>
                                                <asp:ListItem value="17:30">17:30</asp:ListItem>
                                                <asp:ListItem value="18:00">18:00</asp:ListItem>
                                                <asp:ListItem value="18:30">18:30</asp:ListItem>
                                                <asp:ListItem value="19:00">19:00</asp:ListItem>
                                                <asp:ListItem value="19:30">19:30</asp:ListItem>
                                                <asp:ListItem value="20:00">20:00</asp:ListItem>
                                                <asp:ListItem value="20:30">20:30</asp:ListItem>
                                                <asp:ListItem value="21:00">21:00</asp:ListItem>
                                                <asp:ListItem value="21:30">21:30</asp:ListItem>
                                                <asp:ListItem value="22:00">22:00</asp:ListItem>
                                                <asp:ListItem value="22:30">22:30</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:DropDownList Width="90" runat="server" CssClass="form-control col-md-7 col-xs-12" id="bookingDuration" AutoPostBack="true" Enabled ="true" OnSelectedIndexChanged="startTime_SelectedIndexChanged">
                                                <asp:ListItem value="30">30 Minutes</asp:ListItem>
                                                <asp:ListItem value="60">60 Minutes</asp:ListItem>
                                                <asp:ListItem value="90">90 Minutes</asp:ListItem>
                                                <asp:ListItem value="120">120 Minutes</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>                             
                                </div>
                                <div id="step-3">
                                    <h2 class="StepTitle">Step 3 Select a room</h2>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:DropDownList ID="roomsAvailable" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                        <asp:Button ID="bookRoomBtn" runat="server" Text="Book Room" CssClass="btn btn-default" OnClick="bookRoomBtn_Click" />
                                    </div>
                                </div>
                            </form>
                            
                        </div> <!-- End SmartWizard Content -->
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="./__assets/__js/datepicker/daterangepicker.js"></script>
    <!-- form wizard -->
    <script src="./__assets/__js/wizard/jquery.smartWizard.js"></script>
    <!-- range slider -->
    <script src="./__assets/__js/ion_range/ion.rangeSlider.min.js"></script>
    
      <script type="text/javascript">
          $(document).ready(function () {
              // Smart Wizard
              $('#wizard').smartWizard();

              function onFinishCallback() {
                  $('#wizard').smartWizard('showMessage', 'Finish Clicked');
                  //alert('Finish Clicked');
              }
          });

          $(document).ready(function () {
              // Smart Wizard
              $('#wizard_verticle').smartWizard({
                  transitionEffect: 'slide'
              });
          });
    </script>

  <!-- /datepicker -->
  <script type="text/javascript">
      $(document).ready(function () {


          var newdate = new Date(new Date());
          newdate.setDate(newdate.getDate() + 6);
          var nd = new Date(newdate);

          $("#ContentPlaceHolder1_bookDate").attr("placeholder", moment(new Date()).format('YYYY/MM/DD'));
          //$("#ContentPlaceHolder1_bookDate").attr("value", moment(new Date()).format('YYYY/MM/DD'));

          $(".actionBar .btn-default").remove();

          $('#ContentPlaceHolder1_bookDate').daterangepicker({
              "singleDatePicker": true,
              calendar_style: "picker_4",
              "autoApply": true,
              "dateLimit": {
                  "days": 7
              },
              "startDate": new Date(),
              "endDate": nd,
              "minDate": new Date(),
              "maxDate": nd
          });
      });
  </script>
  <!-- /datepicker -->

    <!-- ion_range -->
  <script>
      $(function () {
          $(".bookingDuration").ionRangeSlider({
              min: "30",
              max: "120",
              from: "60",
              force_edges: true,
              step: "30"
          });
      });
  </script>
  <!-- /ion_range -->
</asp:Content>
