<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="studyRoom.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="row">
           <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Profile</h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <form class="form-horizontal form-label-left" novalidate runat="server">
                            <div runat="server" id="profileError"></div>
                            <span class="section">Personal Info</span>
                            <div class="item form-group">
                                <label class="control-label col-md-2 col-sm-2 col-xs-12" for="name">First Name <span class="required">*</span></label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="fName" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="1" name="fName" placeholder="First Name" required="required" type="text" runat="server" />
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-2 col-sm-2 col-xs-12" for="name">Last Name <span class="required">*</span></label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="lName" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" data-validate-words="1" name="lName" placeholder="Last Name" required="required" type="text" runat="server">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-2 col-sm-2 col-xs-12" for="email">Email <span class="required">*</span></label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="email" id="email" name="email" required="required" placeholder="Email" class="form-control col-md-7 col-xs-12" runat="server">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-2 col-sm-2 col-xs-12" for="telephone">Phone Number <span class="required">*</span></label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="tel" id="telephone" name="phone" required="required" data-validate-length-range="8,20" placeholder="Phone Number" class="form-control col-md-7 col-xs-12" runat="server">
                                </div>
                            </div>
                            <span class="section">Password</span>
                            <div class="item form-group">
                                <label for="currentPassword" class="control-label col-md-2 col-sm-2 col-xs-12">Current Password <span class="required">*</span></label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="currentPassword" type="password" name="currentPassword" class="form-control col-md-7 col-xs-12" required="required" placeholder="Current Password" runat="server">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label for="password1" class="control-label col-md-2 col-sm-2 col-xs-12">New Password</label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="password1" type="password" name="password1" class="form-control col-md-7 col-xs-12" placeholder="New Password" runat="server">
                                </div>
                            </div>
                            <div class="item form-group">
                                <label for="password2" class="control-label col-md-2 col-sm-2 col-xs-12">Repeat Password</label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="password2" type="password" name="password2" data-validate-linked="password1" class="form-control col-md-7 col-xs-12" placeholder="Confirm Password" runat="server">
                                </div>
                            </div>
                            <div class="ln_solid"></div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                   <asp:Button ID="updateProfile" runat="server" CssClass="btn btn-success" Text="Update Profile" OnClick="updateProfile_Click" />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="./__assets/__js/validator/validator.js"></script>
    <script>
        // initialize the validator function
        validator.message['date'] = 'not a real date';

        // validate a field on "blur" event, a 'select' on 'change' event & a '.reuired' classed multifield on 'keyup':
        $('form')
            .on('blur', 'input[required], input.optional, select.required', validator.checkField)
            .on('change', 'select.required', validator.checkField)
            .on('keypress', 'input[required][pattern]', validator.keypress);

      $('.multi.required')
        .on('keyup blur', 'input', function () {
            validator.checkField.apply($(this).siblings().last()[0]);
        });

      // bind the validation to the form submit event
      //$('#send').click('submit');//.prop('disabled', true);

      $('form').submit(function (e) {
          e.preventDefault();
          var submit = true;
          // evaluate the form using generic validaing
          if (!validator.checkAll($(this))) {
              submit = false;
          }

          if (submit)
              this.submit();
          return false;
      });

      /* FOR DEMO ONLY */
      $('#vfields').change(function () {
          $('form').toggleClass('mode2');
      }).prop('checked', false);

      $('#alerts').change(function () {
          validator.defaults.alerts = (this.checked) ? false : true;
          if (this.checked)
              $('form .alert').remove();
      }).prop('checked', false);
  </script>
</asp:Content>
