﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tramites.aspx.cs" Inherits="Tramites" %>


<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>AdminLTE 3 | General Form Elements</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta name="viewport" content="width=device-width, initial-scale=1">

  <!-- Font Awesome -->
  <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../../dist/css/adminlte.min.css">
  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
</head>
<body class="hold-transition sidebar-mini">
<div class="wrapper">
  <!-- Navbar -->
  <nav class="main-header navbar navbar-expand navbar-white navbar-light">
    <!-- Left navbar links -->
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link" data-widget="pushmenu" href="#"><i class="fas fa-bars"></i></a>
      </li>
<%--      <li class="nav-item d-none d-sm-inline-block">
        <a href="../../index3.html" class="nav-link">Home</a>
      </li>
      <li class="nav-item d-none d-sm-inline-block">
        <a href="#" class="nav-link">Contact</a>
      </li>--%>
    </ul>

    <!-- SEARCH FORM -->
    <form class="form-inline ml-3">
      <div class="input-group input-group-sm">
      <%--  <input class="form-control form-control-navbar" type="search" placeholder="Search" aria-label="Search">--%>
        <div class="input-group-append">
    <%--      <button class="btn btn-navbar" type="submit">
            <i class="fas fa-search"></i>
          </button>--%>
        </div>
      </div>
    </form>

    <!-- Right navbar links -->
    <ul class="navbar-nav ml-auto">
      <!-- Messages Dropdown Menu -->
      <li class="nav-item dropdown">
        <a class="nav-link" data-toggle="dropdown" href="#">
          <i class="far fa-comments"></i>
          <span class="badge badge-danger navbar-badge">3</span>
        </a>
        <div class="dropdown-menu dropdown-menu-lg dropdown-menu-right">
          <a href="#" class="dropdown-item">
            <!-- Message Start -->
            <div class="media">
              <img src="../../dist/img/user1-128x128.jpg" alt="User Avatar" class="img-size-50 mr-3 img-circle">
              <div class="media-body">
                <h3 class="dropdown-item-title">
                  Brad Diesel
                  <span class="float-right text-sm text-danger"><i class="fas fa-star"></i></span>
                </h3>
                <p class="text-sm">Call me whenever you can...</p>
                <p class="text-sm text-muted"><i class="far fa-clock mr-1"></i> 4 Hours Ago</p>
              </div>
            </div>
            <!-- Message End -->
          </a>
          <div class="dropdown-divider"></div>
          <a href="#" class="dropdown-item">
            <!-- Message Start -->
            <div class="media">
              <img src="../../dist/img/user8-128x128.jpg" alt="User Avatar" class="img-size-50 img-circle mr-3">
              <div class="media-body">
                <h3 class="dropdown-item-title">
                  John Pierce
                  <span class="float-right text-sm text-muted"><i class="fas fa-star"></i></span>
                </h3>
                <p class="text-sm">I got your message bro</p>
                <p class="text-sm text-muted"><i class="far fa-clock mr-1"></i> 4 Hours Ago</p>
              </div>
            </div>
            <!-- Message End -->
          </a>
          <div class="dropdown-divider"></div>
          <a href="#" class="dropdown-item">
            <!-- Message Start -->
            <div class="media">
              <img src="../../dist/img/user3-128x128.jpg" alt="User Avatar" class="img-size-50 img-circle mr-3">
              <div class="media-body">
                <h3 class="dropdown-item-title">
                  Nora Silvester
                  <span class="float-right text-sm text-warning"><i class="fas fa-star"></i></span>
                </h3>
                <p class="text-sm">The subject goes here</p>
                <p class="text-sm text-muted"><i class="far fa-clock mr-1"></i> 4 Hours Ago</p>
              </div>
            </div>
            <!-- Message End -->
          </a>
          <div class="dropdown-divider"></div>
          <a href="#" class="dropdown-item dropdown-footer">See All Messages</a>
        </div>
      </li>
      <!-- Notifications Dropdown Menu -->
      <li class="nav-item dropdown">
        <a class="nav-link" data-toggle="dropdown" href="#">
          <i class="far fa-bell"></i>
          <span class="badge badge-warning navbar-badge">15</span>
        </a>
        <div class="dropdown-menu dropdown-menu-lg dropdown-menu-right">
          <span class="dropdown-item dropdown-header">15 Notifications</span>
          <div class="dropdown-divider"></div>
          <a href="#" class="dropdown-item">
            <i class="fas fa-envelope mr-2"></i> 4 new messages
            <span class="float-right text-muted text-sm">3 mins</span>
          </a>
          <div class="dropdown-divider"></div>
          <a href="#" class="dropdown-item">
            <i class="fas fa-users mr-2"></i> 8 friend requests
            <span class="float-right text-muted text-sm">12 hours</span>
          </a>
          <div class="dropdown-divider"></div>
          <a href="#" class="dropdown-item">
            <i class="fas fa-file mr-2"></i> 3 new reports
            <span class="float-right text-muted text-sm">2 days</span>
          </a>
          <div class="dropdown-divider"></div>
          <a href="#" class="dropdown-item dropdown-footer">See All Notifications</a>
        </div>
      </li>
      <li class="nav-item">
        <a class="nav-link" data-widget="control-sidebar" data-slide="true" href="#">
          <i class="fas fa-th-large"></i>
        </a>
      </li>
    </ul>
  </nav>
  <!-- /.navbar -->

  <!-- Main Sidebar Container -->
  <aside class="main-sidebar sidebar-dark-primary elevation-4">
    <!-- Brand Logo -->
    <a href="../../index3.html" class="brand-link">
      <img src="../../dist/img/AdminLTELogo.png"
           alt="AdminLTE Logo"
           class="brand-image img-circle elevation-3"
           style="opacity: .8">
      <span class="brand-text font-weight-light">LawyerSystem1.0</span>
    </a>

    <div class="sidebar">
      <div class="user-panel mt-3 pb-3 mb-3 d-flex">
        <div class="image">
          <img src="../../dist/img/user2-160x160.jpg" class="img-circle elevation-2" alt="User Image">
        </div>
        <div class="info">
          <a href="#" class="d-block">Lic. Aarón Delgado</a>
        </div>
      </div>

      <nav class="mt-2">
        <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
          <li class="nav-item has-treeview">


            <a href="#" class="nav-link">
              <i class="nav-icon fas fa-tachometer-alt"></i>
              <p>
                Clientes
                <i class="right fas fa-angle-left"></i>
              </p>
            </a>
       

             <a href="#" class="nav-link">
              <i class="nav-icon fas fa-tachometer-alt"></i>
              <p>
                Juzgados
                <i class="right fas fa-angle-left"></i>
              </p>
            </a>


          </li>
        </ul>
      </nav>
    </div>
  </aside>

  <div class="content-wrapper">
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Generar un trámite</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Menu</a></li>
              <li class="breadcrumb-item active">AgregarAsuntos</li>
            </ol>
          </div>
        </div>
      </div>
    </section>

    <section class="content">
      <div class="container-fluid">
        <div class="row">
          <div class="col-md-12">

            <div class="card card-info">

              <div class="card-header">
                <h3 class="card-title"></h3>
              </div>



       <form class="form-horizontal" runat="server" id="form1">
        <div class="card-body">

                 <div class="form-group row">
            <label for="inputEmail3" class="col-sm-2 col-form-label">Cliente:</label>
            <div class="col-sm-10">
                        <asp:DropDownList ID="CmbCliente"  class="input-form-edit" CssClass="browser-default custom-select" Font-Names="area" runat="server"
                            AppendDataBoundItems="true">
                        </asp:DropDownList>
                               </div>
        </div>



        <div class="form-group row">
            <label for="inputEmail3" class="col-sm-2 col-form-label">Asunto:</label>
            <div class="col-sm-10">
                        <asp:DropDownList ID="CmbAsunto" class="input-form-edit" CssClass="browser-default custom-select" Font-Names="area" runat="server"
                            AppendDataBoundItems="true">
                        </asp:DropDownList>
                  </div>
        </div>


        <div class="form-group row">
            <label for="inputEmail3" class="col-sm-2 col-form-label">Fecha de Inicio:</label>
            <div class="col-sm-10">
                 <asp:TextBox runat="server" type="date" class="form-control" id="TxtFechaInicio" placeholder="Ingresar Fecha"/>
            </div>
        </div>


                  <div class="form-group row">
            <label for="inputEmail3" class="col-sm-2 col-form-label">Fecha de Termino:</label>
            <div class="col-sm-10">
                 <asp:TextBox runat="server" type="date" class="form-control" id="TxtFechaTermino" placeholder="Ingresar Fecha"/>
            </div>
        </div>


                         <div class="form-group row">
            <label for="inputEmail3" class="col-sm-2 col-form-label">Costo:</label>
            <div class="col-sm-10">
                 <asp:TextBox runat="server" type="numero" class="form-control" id="TxtCosto" placeholder="Ingresar Costo"/>
            </div>
        </div>


                             <div class="form-group row">
            <label for="inputEmail3" class="col-sm-2 col-form-label">Tipo de pago:</label>
            <div class="col-sm-10">
                        <asp:DropDownList ID="CmbTipoPago" class="input-form-edit" CssClass="browser-default custom-select" Font-Names="area" runat="server"
                            AppendDataBoundItems="true">
                                       <asp:ListItem Value="-1">-Selecciona-</asp:ListItem>
                            <asp:ListItem Value="Contado">Contado</asp:ListItem>
                            <asp:ListItem Value="Credito">Crédito</asp:ListItem>
                        </asp:DropDownList>
                               </div>
        </div>

                 <div class="form-group row">
            <label for="inputEmail3" class="col-sm-2 col-form-label">Estatus:</label>
            <div class="col-sm-10">
                        <asp:DropDownList ID="CmbEstatus" class="input-form-edit" CssClass="browser-default custom-select" Font-Names="area" runat="server"
                            AppendDataBoundItems="true">
                                <asp:ListItem Value="Pendiente">Pendiente</asp:ListItem>
                            <asp:ListItem Value="Terminado">Terminado</asp:ListItem>
                        </asp:DropDownList>
                   
                  </div>
        </div>

        <div class="form-group row">
            <div class="offset-sm-2 col-sm-10">
            </div>
        </div>
        </div>
       
        <div class="card-footer">
            
            <asp:Button runat="server" class="btn btn-info  float-right" Text="Agregar" OnClick="BtnAgregarCliente_Click" />

            <asp:Button runat="server" class="btn btn-default float-right" OnClick="BtnCancelarCliente_Click"  Text="Cancelar" />
           
            <asp:Button runat="server" class="btn btn-default float-left" OnClick="BtnRegresarlistaClientes_Click"  Text="Lista Asuntos" />

        </div>

        </form>
            </div>
          </div>
          <div class="col-md-6">
          </div>
        </div>
      </div>
    </section>
  </div>
  <footer class="main-footer">
    <div class="float-right d-none d-sm-block">
      <b>Version</b> 3.0.2-pre
    </div>
    <strong>Copyright &copy; 2014-2019 <a href="http://adminlte.io">AdminLTE.io</a>.</strong> All rights
    reserved.
  </footer>
  <aside class="control-sidebar control-sidebar-dark">
  </aside>
</div>
<script src="../../plugins/jquery/jquery.min.js"></script>
<script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<script src="../../plugins/bs-custom-file-input/bs-custom-file-input.min.js"></script>
<script src="../../dist/js/adminlte.min.js"></script>
<script src="../../dist/js/demo.js"></script>
<script type="text/javascript">
$(document).ready(function () {
  bsCustomFileInput.init();
});
</script>
</body>
</html>
