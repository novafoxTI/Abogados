<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Actividades.aspx.cs" Inherits="Actividades" %>



<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Lawyer | System 1.0</title>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
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
    <li class="nav-item d-none d-sm-inline-block">
        <a href="../MenuControl" class="nav-link">Inicio</a>
      </li>
      <li class="nav-item d-none d-sm-inline-block">
        <a href="http://gruponovait.com/" class="nav-link"  target="_blank">Contacto</a>
      </li>
    </ul>

    <!-- SEARCH FORM -->
    <form class="form-inline ml-3">
      <div class="input-group input-group-sm">
      <%--  --%>
        <div class="input-group-append">
    <%--      <button class="btn btn-navbar" type="submit">
            <i class="fas fa-search"></i>
          </button>--%>
        </div>
      </div>
    </form>

    <!-- Right navbar links -->
    <ul class="navbar-nav ml-auto">

      <!-- Notifications Dropdown Menu -->
      <li class="nav-item dropdown">
        <a class="nav-link" data-toggle="dropdown" href="#">
             <i class="fas fa-share-square"></i>
   
        </a>
        <div class="dropdown-menu dropdown-menu-lg dropdown-menu-right">
 
          <div class="dropdown-divider"></div>
       <a href="./login" class="dropdown-item dropdown-footer">Cerrar Sesión</a>
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
    <a href="./Menu" class="brand-link">
      <img src="dist/img/AdminLTELogo.png" alt="AdminLTE Logo" class="brand-image img-circle elevation-3"
           style="opacity: .8">
      <span class="brand-text font-weight-light">lawyerSystem</span>
    </a>

    <!-- Sidebar -->
    <div class="sidebar">
      <!-- Sidebar user panel (optional) -->
      <div class="user-panel mt-3 pb-3 mb-3 d-flex">
        <div class="image">
          <img src="dist/img/user2-160x160.jpg" class="img-circle elevation-2" alt="User Image">
        </div>
        <div class="info">
          <a href="#" class="d-block"><asp:Label runat="server" ID="TxtUsuario" Text="Lic. Aarón Delgado"/></a>
        </div>
      </div>

      <!-- Sidebar Menu -->
      <nav class="mt-2">
        <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
          <!-- Add icons to the links using the .nav-icon class
               with font-awesome or any other icon font library -->
          <li class="nav-item has-treeview menu-close">
            <a href="#" class="nav-link active">
              <i class="nav-icon fas fa-tachometer-alt"></i>
              <p>
                Catalogos
                <i class="right fas fa-angle-left"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item">
                <a href="./ClientesVer" class="nav-link active">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Clientes</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="./JuzgadosVer" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Juzgados</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="./AsuntosVer" class="nav-link">
                  <i class="far fa-circle nav-icon"></i>
                  <p>Asuntos</p>
                </a>
              </li>
            </ul>
          </li>
          <li class="nav-item">
            <a href="./Tramitesver" class="nav-link">
              <i class="nav-icon fas fa-th"></i>
              <p>
                Trámites
             <%--   <span class="right badge badge-danger">New</span>--%>
              </p>
            </a>
          </li>
         
          <li class="nav-header"></li>
          <li class="nav-item">
            <a href="#" class="nav-link">
              <i class="nav-icon far fa-calendar-alt"></i>
              <p>
                Calendario
        <%--        <span class="badge badge-info right">2</span>--%>
              </p>
            </a>
          </li>
          <li class="nav-item">
            <a href="#" class="nav-link">
              <i class="nav-icon far fa-image"></i>
              <p>
                Reportes
              </p>
            </a>
          </li>
        
         
          
        </ul>
      </nav>
      <!-- /.sidebar-menu -->
    </div>
    <!-- /.sidebar -->
  </aside>


  <div class="content-wrapper">
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Generar una Actividad</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Menu</a></li>
              <li class="breadcrumb-item active">AgregarActividad</li>
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
<h3 class="card-title">Agregar Actividad</h3>
              </div>



       <form class="form-horizontal" runat="server" id="form1" autocomplete="off">

           
                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel UpdateMode="Conditional"  ID="UpdatePanel1"  runat="server">
            <ContentTemplate>
        <div class="card-body">


            
            <div class="form-group row">
                <label for="inputEmail3" style="text-align: right" class="col-sm-2 col-form-label">Tipo de Actividad:</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="CmbTipoActividad" class="input-form-edit" CssClass="browser-default custom-select" AutoPostBack="true" OnSelectedIndexChanged="CmbTipoActividad_SelectedIndexChanged" Font-Names="area" runat="server"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">-Seleccionar-</asp:ListItem>
                        <asp:ListItem Value="Personal">Personal</asp:ListItem>
                        <asp:ListItem Value="Cliente">Cliente</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>



                 <div class="form-group row"  runat="server" id="Mostrarcliente" visible="false">
            <label for="inputEmail3" style="text-align:right" class="col-sm-2 col-form-label">Cliente:</label>
            <div class="col-sm-10">
                        <asp:DropDownList ID="CmbCliente"  class="input-form-edit" CssClass="browser-default custom-select" Font-Names="area" runat="server"
                            AppendDataBoundItems="true">
                            <asp:ListItem Value="-1">-Seleccionar-</asp:ListItem>
                        </asp:DropDownList>
                               </div>
        </div>

                                     <div class="form-group row">
            <label for="inputEmail3" style="text-align:right" class="col-sm-2 col-form-label">Asunto:</label>
            <div class="col-sm-10">
                 <asp:TextBox runat="server"   type="text" class="form-control" id="TxtAsunto" placeholder="Ingresar Asunto"/>
            </div>
        </div>

         <div class="form-group row">
            <label for="inputEmail3" style="text-align:right" class="col-sm-2 col-form-label">Notas:</label>
            <div class="col-sm-10">
                 <asp:TextBox runat="server"   type="text" class="form-control" id="TxtNotas" placeholder="Ingresar Notas"/>
            </div>
        </div>
                    <div class="form-group row"  runat="server" id="MostrarLugar" visible="false">
            <label for="inputEmail3" style="text-align:right" class="col-sm-2 col-form-label">Juzgado:</label>
            <div class="col-sm-10">
                        <asp:DropDownList ID="CmbJuzgados"  class="input-form-edit" CssClass="browser-default custom-select" Font-Names="area" runat="server"
                            AppendDataBoundItems="true">
                            <asp:ListItem Value="-1">-Seleccionar-</asp:ListItem>
                        </asp:DropDownList>
                               </div>
        </div>

        <div class="form-group row">
            <label for="inputEmail3" style="text-align:right" class="col-sm-2 col-form-label">Fecha de Inicio:</label>
            <div class="col-sm-10">
                 <asp:TextBox runat="server" type="datetime-local" class="form-control" id="TxtFechaInicio" placeholder="Ingresar Fecha"/>
            </div>
        </div>


                  <div class="form-group row">
            <label for="inputEmail3" style="text-align:right" class="col-sm-2 col-form-label">Fecha de Termino:</label>
            <div class="col-sm-10">
                 <asp:TextBox runat="server" type="datetime-local" class="form-control" id="TxtFechaTermino" placeholder="Ingresar Fecha"/>
            </div>
        </div>


    


                 <div class="form-group row">
            <label for="inputEmail3" style="text-align:right" class="col-sm-2 col-form-label">Estatus:</label>
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
            
            <asp:Button runat="server" class="btn btn-info  float-right" Text="Agregar" OnClick="BtnAgregarTramite_Click" />

            <%--<asp:Button runat="server" class="btn btn-default float-right" OnClick="BtnCancelarCliente_Click"  Text="Cancelar" />--%>
           
            <asp:Button runat="server" class="btn btn-default float-left" OnClick="BtnRegresarlistaActividades_Click"  Text="Lista de actividades" />

        </div>
                                </ContentTemplate>
            <Triggers>
                 <asp:AsyncPostBackTrigger ControlID="CmbTipoActividad" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
     
            </div>
              </form>
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
