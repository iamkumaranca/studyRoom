<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="studyRoom.login" %>

<!DOCTYPE html>
<html lang "en">
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
                    <form>
                        <h1>Login Form</h1>
                        <div>
                            <input type="email" class="form-control" placeholder="Email" required="" />
                        </div><br />
                        <div>
                            <input type="password" class="form-control" placeholder="Password" required="" />
                        </div><br />
                        <div>
                            <button class="btn btn-default submit">Log in</button>
                        </div>
                        <div>
                            <a class="reset_pass" href="#topassword">Lost your password?</a>
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
                    </form> <!-- form -->
                </section> <!-- content -->
            </div>
            <div id="register" class="animate form">
                <section class="login_content">
                    <form>
                        <h1>Create Account</h1>
                        <div>
                            <input type="text" class="form-control" placeholder="First Name" required="" />
                        </div>
                        <div>
                            <input type="text" class="form-control" placeholder="Last Name" required="" />
                        </div>
                        <div>
                            <input type="email" class="form-control" placeholder="Email" required="" />
                        </div>
                        <div>
                            <input type="text" class="form-control" placeholder="Phone" required="" />
                        </div>
                        <div>
                            <input type="password" class="form-control" placeholder="Password" required="" />
                        </div>
                        <div>
                            <input type="password" class="form-control" placeholder="Confirm Password" required="" />
                        </div>
                        <div>
                            <button class="btn btn-default submit">Register</button>
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
                    </form> <!-- form -->
                </section> <!-- content -->
            </div>
            <div id="password" class="animate form">
                <section class="login_content">
                    <form>
                        <h1>Reset Password</h1>
                        <div>
                            <input type="email" class="form-control" placeholder="Email" required="" />
                        </div>
                        <div>
                            <button class="btn btn-default submit">Reset Password</button>
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
                    </form> <!-- form -->
                </section> <!-- content -->
            </div>
        </div>
    </div>
    </form>
</body>
</html>
