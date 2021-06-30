<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoRinku.Login" %>

<!DOCTYPE html>

<html lang="es">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <title>Nomina Rinku</title>
    <link rel="icon" href="img/favicon.png">

    <%--    <title>Login</title>--%>
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <!-- Bootstrap core CSS -->
    <link href="Content/css/bootstrap.min.css" rel="stylesheet">
    <!-- Material Design Bootstrap -->
    <link href="Content/css/mdb.min.css" rel="stylesheet">
    <%--    <link href="Content/login/bootstrap.min.css" rel="stylesheet">--%>
    <%--    <link href="Content/login/signin.css?v=1.0" rel="stylesheet">--%>
    <style>
        html,
        body,
        header,
        .view {
            height: 100vh;
        }

        @media (max-width: 740px) {
            html,
            body,
            header,
            .view {
                height: 815px;
            }
        }

        @media (min-width: 800px) and (max-width: 850px) {
            html,
            body,
            header,
            .view {
                height: 650px;
            }
        }

        .intro-2 {
            background: url("assets/login_background.jpg")no-repeat center center;
            background-size: cover;
        }


        .card {
            background-color: rgba(255, 255, 255, 0.30);
        }

        .md-form label {
            color: #ffffff;
        }

        h6 {
            line-height: 1.7;
        }


        .card {
            margin-top: 30px;
            /*margin-bottom: -45px;*/
        }

        .md-form input[type=text]:focus:not([readonly]),
        .md-form input[type=password]:focus:not([readonly]) {
            border-bottom: 1px solid #f1f1f1;
            box-shadow: 0 1px 0 0 #f1f1f1;
        }

            .md-form input[type=text]:focus:not([readonly]) + label,
            .md-form input[type=password]:focus:not([readonly]) + label {
                color: #f1f1f1;
            }

        .md-form .form-control {
            color: #fff;
        }

        .validation-error {
            border: solid 1px #ff0000;
        }

            .validation-error:focus {
                outline: none !important;
                border: 1px solid red;
                box-shadow: 0 0 10px #ff0000;
            }
    </style>

</head>

<body>


    <!--Main Navigation-->
    <header>

        <!--Intro Section-->
        <section class="view intro-2">
            <div class="mask rgba-black-strong h-100 d-flex justify-content-center align-items-center">
                <div class="container">
                    <div class="row">
                        <div id="content" class="col-sm-4" style="text-align: center; position: absolute; top: 8px; right: 30px;"></div>

                        <div class="col-xl-5 col-lg-6 col-md-10 col-sm-12 mx-auto mt-lg-5">



                            <!--Form with header-->
                            <div class="card wow fadeIn" data-wow-delay="0.3s">
                                <div class="card-body">
                                    <form role="form" class="form-signin">
                                        <!--Header-->
<%--                                        <div class="form-header white">
                                            <div class="col-6 offset-3">
                                                <h6 style="color:black">Nomina Rinku</h6>
                                            </div>

                                        </div>--%>

                                        <!--Body-->
                                        <div class="md-form">
                                            <i class="fa fa-user prefix white-text"></i>
                                            <input type="text" id="txtUsuario" name="txtUsuario" class="form-control" required>
                                            <label for="orangeForm-name">Usuario</label>
                                        </div>

                                        <div class="md-form">
                                            <i class="fa fa-lock prefix white-text"></i>
                                            <input type="password" id="txtContraseña" name="txtContraseña" class="form-control" required>
                                            <label for="orangeForm-pass">Contraseña</label>
                                        </div>

                                        <div class="text-center">
                                            <button type="submit" id="btnEntrar" class="btn btn-brown btn-lg">Entrar</button>
                                        </div>
                                    </form>
                                </div>
                            </div>
                            <!--/Form with header-->

                        </div>
                    </div>
                </div>
            </div>
        </section>

    </header>
    <!--Main Navigation-->


    <!--  SCRIPTS  -->
    <!-- JQuery -->
    <script type="text/javascript" src="Scripts/jquery-3.3.1.min.js"></script>
    <!-- Bootstrap tooltips -->
    <script type="text/javascript" src="Scripts/popper.min.js"></script>
    <!-- Bootstrap core JavaScript -->
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <!-- MDB core JavaScript -->
    <script type="text/javascript" src="Scripts/mdb.min.js"></script>
    <script>
        new WOW().init();
    </script>

    <%--    <script src="Scripts/jquery-2.1.1.js"></script>--%>
    <script src="Scripts/jquery.validate.min.js"></script>
    <script src="Scripts/messageProcessing.js"></script>
    <script src="Scripts/AjaxRequest.js"></script>
    <script src="Scripts/ScriptForm/Login.js?v=1.0"></script>
</body>


</html>
