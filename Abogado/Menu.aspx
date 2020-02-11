<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<title>Lawyer | System 1.0</title>
<link rel="stylesheet" href="../../plugins/datatables-bs4/css/dataTables.bootstrap4.css">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css">
<link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
<link rel="stylesheet" href="plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css">
<link rel="stylesheet" href="plugins/icheck-bootstrap/icheck-bootstrap.min.css">
<link rel="stylesheet" href="plugins/jqvmap/jqvmap.min.css">
<link rel="stylesheet" href="dist/css/adminlte.min.css">
<link rel="stylesheet" href="plugins/overlayScrollbars/css/OverlayScrollbars.min.css">
<link rel="stylesheet" href="plugins/daterangepicker/daterangepicker.css">
<link rel="stylesheet" href="plugins/summernote/summernote-bs4.css">
<link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
</head>
<body class="hold-transition sidebar-mini layout-fixed">
<div class="wrapper">
<nav class="main-header navbar navbar-expand navbar-white navbar-light">
<ul class="navbar-nav">
<li class="nav-item">
<a class="nav-link" data-widget="pushmenu" href="#"><i class="fas fa-bars"></i></a>
</li>
<li class="nav-item d-none d-sm-inline-block">
<a href="./Menu" class="nav-link">Inicio</a>
</li>
<li class="nav-item d-none d-sm-inline-block">
<a href="http://gruponovait.com/" class="nav-link" target="_blank">Contacto</a>
</li>
</ul>
<div class="input-group input-group-sm">
</div>
<form class="form-inline ml-3" runat="server">
<ul class="navbar-nav ml-auto">
<li class="nav-item dropdown">
<a class="nav-link" data-toggle="dropdown" href="#">
<i class="fas fa-share-square"></i>
<span class="badge badge-warning navbar-badge"></span>
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
<aside class="main-sidebar sidebar-dark-primary elevation-4">
<a href="./Menu" class="brand-link">
<img src="dist/img/AdminLTELogo.png" alt="AdminLTE Logo" class="brand-image img-circle elevation-3"
style="opacity: .8">
<span class="brand-text font-weight-light">lawyerSystem</span>
</a>
<div class="sidebar">
<div class="user-panel mt-3 pb-3 mb-3 d-flex">
<div class="image">
<img src="dist/img/user2-160x160.jpg" class="img-circle elevation-2" alt="User Image">
</div>
<div class="info">
<a href="#" class="d-block"><asp:Label runat="server" ID="TxtUsuario"/></a>
</div>
</div>
<nav class="mt-2">
<ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
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
</p>
</a>
</li>
         
<li class="nav-header"></li>
<li class="nav-item">
<a href="#" class="nav-link">
<i class="nav-icon far fa-calendar-alt"></i>
<p>
Calendario
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
</div>
</aside>
<div class="content-wrapper">
<div class="content-header">
<div class="container-fluid">
<div class="row mb-2">
<div class="col-sm-6">
<h1 class="m-0 text-dark">Dashboard</h1>
</div>
<div class="col-sm-6">
<ol class="breadcrumb float-sm-right">
</ol>
</div>
</div>
</div>
</div>
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
</div>
<div class="row">
    <section class="col-lg-12 connectedSortable">
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
        <!-- /.card -->
    </section>
<section class="col-lg-5 connectedSortable">
</section>
</div>
</div>
</section>
</div>
</form>
<footer class="main-footer">
<strong>Copyright &copy; 2014-2019 <a href="http://adminlte.io">AdminLTE.io</a>.</strong>
All rights reserved.
<div class="float-right d-none d-sm-inline-block">
<b>Version</b> 3.0.2-pre
</div>
</footer>
<aside class="control-sidebar control-sidebar-dark">
</aside>
</div>
<script src="plugins/jquery/jquery.min.js"></script>
<script src="plugins/jquery-ui/jquery-ui.min.js"></script>
<script>
$.widget.bridge('uibutton', $.ui.button)
</script>
<script src="plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<script src="plugins/chart.js/Chart.min.js"></script>
<script src="plugins/sparklines/sparkline.js"></script>
<script src="plugins/jqvmap/jquery.vmap.min.js"></script>
<script src="plugins/jqvmap/maps/jquery.vmap.usa.js"></script>
<script src="plugins/jquery-knob/jquery.knob.min.js"></script>
<script src="plugins/moment/moment.min.js"></script>
<script src="plugins/daterangepicker/daterangepicker.js"></script>
<script src="plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"></script>
<script src="plugins/summernote/summernote-bs4.min.js"></script>
<script src="plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>
<script src="dist/js/adminlte.js"></script>
<script src="dist/js/pages/dashboard.js"></script>
<script src="dist/js/demo.js"></script>
<script src="../../plugins/jquery/jquery.min.js"></script>
<script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<script src="../../plugins/datatables/jquery.dataTables.js"></script>
<script src="../../plugins/datatables-bs4/js/dataTables.bootstrap4.js"></script>
<script src="../../dist/js/adminlte.min.js"></script>
<script src="../../dist/js/demo.js"></script>
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
bindDataTable();
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