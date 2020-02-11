using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class Recibo : System.Web.UI.Page
{
    private CNX conn = new CNX();
    string editar;

    protected void Page_Load(object sender, EventArgs e)
    {
        CargarReporte("Recibo " + Request.QueryString["folio"], Request.QueryString["folio"]);
    }

    public void CargarReporte(string fileName, string Folio)
    {

        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;

        rptPagos.ProcessingMode = ProcessingMode.Local;
        rptPagos.LocalReport.ReportPath = "Recibo.rdlc";

    

        rptPagos.LocalReport.DataSources.Add(new ReportDataSource("DataSetRecibo", conn.ObtenerDatoSicad("SELECT * FROM vw_ReporteRecibo WHERE folio ='" + Request.QueryString["folio"] + "'")));



        rptPagos.SizeToReportContent = true;




        byte[] bytes = rptPagos.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);


        Response.Buffer = true;
        Response.Clear();
        Response.ContentType = mimeType;
        Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
        Response.BinaryWrite(bytes);
        Response.Flush();

    }


}