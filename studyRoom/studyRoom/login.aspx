<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="studyRoom.login" %>

<!DOCTYPE html>
<html lang = "en">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Login | TheForce.io</title>

    <!-- Bootstrap core CSS -->

    <link href="./__assets/__css/bootstrap.min.css" rel="stylesheet">

    <link href="./__assets/__fonts/css/font-awesome.min.css" rel="stylesheet">
    <link href="./__assets/__css/animate.min.css" rel="stylesheet">

    <!-- Custom styling plus plugins -->
    <link href="./__assets/__css/custom.css" rel="stylesheet">
    <link href="./__assets/__css/icheck/flat/green.css" rel="stylesheet">

    <script src="./__assets/__js/jquery.min.js"></script>

    <!--[if lt IE 9]>
        <script src="../assets/js/ie8-responsive-file-warning.js"></script>
    <![endif]-->

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body style="background:#F7F7F7;">
    <form id="form1" runat="server">
    <div>
        <a class="hiddenanchor" id="toregister"></a>
        <a class="hiddenanchor" id="tologin"></a>
        <a class="hiddenanchor" id="topassword"></a>

        <div id="wrapper">
            <div id="login" class="animate form">
                <section class="login_content">
                    <h1>Login Form</h1>
                    <div runat="server" id="loginError"></div>
                    <div>
                        <input type="email" id="emailLogin" class="form-control" placeholder="Email" runat="server" />
                    </div><br />
                    <div>
                        <input type="password" id="passwordLogin" class="form-control" placeholder="Password" runat="server" />
                    </div><br />
                    <div>
                        <asp:Button ID="loginBtn" runat="server" CssClass="btn btn-default submit" Text="Log in" OnClick="loginBtn_Click" />
                    </div>
                    <div class="clearfix"></div>
                    <div class="separator">
                        <p class="change_link">New to site?
                            <a href="#toregister" class="to_register"> Create Account </a>
                        </p>
                        <div class="clearfix"></div>
                        <br />
                        <div>
                            <h1><i class="fa fa-rocket" style="font-size: 26px;"></i> TheForce.io</h1>
                            <p>©2016 All Rights Reserved. TheForce.io!</p>
                        </div>
                    </div>
                </section> <!-- content -->
            </div>
            <div id="register" class="animate form">
                <section class="login_content">
                    <h1>Create Account</h1>
                    <div>
                        <input type="text" id="fName" class="form-control" placeholder="First Name" runat="server" />
                    </div>
                    <div>
                        <input type="text" id="lName" class="form-control" placeholder="Last Name" runat="server" />
                    </div>
                    <div>
                        <input type="email" id="emailReg" class="form-control" placeholder="Email" runat="server" />
                    </div>
                    <div>
                        <input type="text" id="phone" class="form-control" placeholder="Phone" runat="server" />
                    </div>
                    <div>
                        <input type="password" id="passwordReg" class="form-control" placeholder="Password" runat="server" />
                    </div>
                    <div>
                        <input type="password" id="passwordConfirm" class="form-control" placeholder="Confirm Password" runat="server" />
                    </div>
                    <div>
                        <button class="btn btn-default submit" id="registerBtn">Register</button>
                    </div>
                    <div class="clearfix"></div>
                    <div class="separator">
                        <p class="change_link">Already a member?
                            <a href="#tologin" class="to_register"> Log in </a>
                        </p>
                        <div class="clearfix"></div>
                        <br />
                        <div>
                            <h1><i class="fa fa-rocket" style="font-size: 26px;"></i> TheForce.io</h1>
                            <p>©2016 All Rights Reserved. TheForce.io!</p>
                        </div>
                    </div>
                </section> <!-- content -->
            </div>
        </div>
    </div>
    </form>
</body>
</html>
