<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuControl.aspx.cs" Inherits="MenuControl" %>

<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Lawyer | System 1.0</title>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
  <!-- Tell the browser to be responsive to screen width -->
  <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.2/jquery-confirm.min.css"/>
    <link href="jquery/jquery-confirm.min" rel="stylesheet">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- DataTables -->
  <link rel="stylesheet" href="../../plugins/datatables-bs4/css/dataTables.bootstrap4.css">
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

        </div>
      </div>
    </form>

    <!-- Right navbar links -->
    <ul class="navbar-nav ml-auto">
      <!-- Messages Dropdown Menu -->

      <!-- Notifications Dropdown Menu -->
      <li class="nav-item dropdown">
        <a class="nav-link" data-toggle="dropdown" href="#">
        <i class="fas fa-share-square"></i>
         
        </a>
        <div class="dropdown-menu dropdown-menu-lg dropdown-menu-right">
   
 
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
            <h1>Dashboard</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Menu</a></li>
              <li class="breadcrumb-item active">Control de Actividades</li>
            </ol>
          </div>
        </div>
      </div>
    </section>

    <section class="content">
      <div class="container-fluid">
        <div class="row">

            <div class="col-lg-3 col-6">
<!-- small box -->
<div class="small-box bg-info">
<div class="inner">
<h3><asp:Label runat="server" ID="LblContAsuntos"/></h3>
<p>Asuntos</p>
</div>
<div class="icon">
<i class="ion ion-bag"></i>
</div>
<a href="./Tramitesver" class="small-box-footer">Mas información<i class="fas fa-arrow-circle-right"></i></a>
</div>
</div>
<div class="col-lg-3 col-6">
<div class="small-box bg-success">
<div class="inner">
<h3><asp:Label runat="server" ID="LblContarJuzgados"/></h3>
<p>Juzgados</p>
</div>
<div class="icon">
<i class="ion ion-stats-bars"></i>
</div>
<a href="./JuzgadosVer" class="small-box-footer">Mas información<i class="fas fa-arrow-circle-right"></i></a>
</div>
</div>
<div class="col-lg-3 col-6">
<div class="small-box bg-warning">
<div class="inner">
<h3><asp:Label runat="server" ID="LblContarClientes"/></h3>
<p>Clientes</p>
</div>
<div class="icon">
<i class="ion ion-person-add"></i>
</div>
<a href="./ClientesVer" class="small-box-footer">Mas información<i class="fas fa-arrow-circle-right"></i></a>
</div>
</div>
<div class="col-lg-3 col-6">
<div class="small-box bg-danger">
<div class="inner">
<h3><asp:Label runat="server" ID="LblContarTramites"/></h3>
<p>Trámites</p>
</div>
<div class="icon">
<i class="ion ion-pie-graph"></i>
</div>
<a href="#" class="small-box-footer">Mas información<i class="fas fa-arrow-circle-right"></i></a>
</div>
</div>

          <div class="col-md-12">

            <div class="card card-info">

              <div class="card-header">
                <h3 class="card-title">Control de Actividades</h3>
              </div>



       <form class="form-horizontal" runat="server" id="form1" autocomplete="off">

          


                <div class="card">
            <div class="card-header">
                <h3 class="card-title">Listado de Actividades</h3><br>
                <asp:Button runat="server" class="btn btn-block btn-info" Text="Agregar Actividad" ID="btnAgregarActividad" OnClick="btnAgregarActividad_Click" />
            </div>
            <div class="card-body">
                <div class="row">
                    <br />
                    <div class="col-12">
                          <div class="table-responsive dt-responsive">
                        <asp:Repeater runat="server" ID="DtgActividades">
                            <HeaderTemplate>
                                <table id="example1" class="table table-striped table-bordered nowrap">
                                    <thead>
                                        <tr>
                                            <th style="width: 1%">Cliente</th>
                                            <th style="width: 1%">Juzgado</th>
                                            <th style="width: 1%">Actividad</th>
                                            <th style="width: 1%">Fecha Inicio</th>
                                            <th style="width: 1%">Fecha Término</th>
                                            
                                            <th style="width: 1%"></th>
                                            <th style="width: 1%"></th>
                                        </tr>
                                    </thead>
                                    <tbody id="cuerpo">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr data-id="<%# Eval("event_id")%>">
                                     <td><%# Eval("cliente")%></td>
                                     <td><%# Eval("juzgado")%></td>
                                    <td><%# Eval("title")%></td>
                                    <td><%# Eval("event_start")%></td>
                                    <td><%# Eval("event_end")%></td>
                                       
                                    <td>
                                        <asp:LinkButton runat="server" ID="btnEditarEvento" OnClick="btnEditarEvento" CommandArgument='<%# Eval("event_id") %>'>Editar</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton runat="server" ID="btnEliminarevento" OnClick="btnEliminarevento" CommandArgument='<%# Eval("event_id") %>'>Eliminar</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                               </div>
                    </div>
                </div>
            </div>
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
      <b>Version</b> 
    </div>
  </footer>
  <aside class="control-sidebar control-sidebar-dark">
  </aside>
</div>
<!-- jQuery -->
<script src="../../plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- DataTables -->
<script src="../../plugins/datatables/jquery.dataTables.js"></script>
<script src="../../plugins/datatables-bs4/js/dataTables.bootstrap4.js"></script>
<!-- AdminLTE App -->
<script src="../../dist/js/adminlte.min.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="../../dist/js/demo.js"></script>
<!-- page script -->
<script>
    $(function () {
        $("#example1").DataTable();
        $('#example2').DataTable({
            "paging": true,
            "lengthChange": false,
            "searching": false,
            "ordering": true,
            "info": true,
            "autoWidth": false,
        });
    });
</script>


    <script>
        $(function () {
            bindDataTable(); // bind data table on first page load
            // bind data table on every UpdatePanel refresh   
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindDataTable);
        });

        function bindDataTable() {

            var table = $('#example1').DataTable({ retrieve: true, paging: false });

            table.destroy();

            $('#example1').DataTable({
                "language": {
                    "url": "https://cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json"
                }
            });
        }
</script>
</body>
</html>
