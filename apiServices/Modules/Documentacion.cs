using apiServices.DA;
using apiServices.Models;
using apiServices.Models.Catalogos;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;
using System;
using System.Linq;
using WarmPack.Classes;

namespace apiServices.Modules
{
    public class Documentacion : NancyModule
    {
        private readonly DADocumentacion _DADocumentacion = null;

        public Documentacion() : base("/doc")
        {
            Before += ctx =>
            {
                if (!ctx.Request.Headers.Keys.Contains("api-key"))
                {
                    return HttpStatusCode.Unauthorized;
                }
                else
                {
                    var apikey = ctx.Request.Headers["api-key"].FirstOrDefault() ?? string.Empty;
                    if (apikey != Globales.ApiKey)
                    {
                        return HttpStatusCode.Unauthorized;
                    }
                    else
                    {
                        return null;
                    }
                }
            };

            this.RequiresAuthentication();
            _DADocumentacion = new DADocumentacion();

            Post("/guardar", _ => GuardarDocumentacion());
            Post("/consulta", _ => ConsultaDocumentacion());
            Post("/clientes/documentacion", _ => ConsultaClientesDocumentacion());
            Post("/clientesXTipo/documentacion", _ => ConsultaClientesXTipoDocumentacion());
            Post("/clientesXTipo/comprobantes", _ => ObtieneComprobantesCliente());
            Post("/solicitudes/guardar", _ => SolicitudesGuardar());

        }

        private object GuardarDocumentacion()
        {
            try
            {
                //var t = this.BindToken();
                DocumentacionModel p = this.Bind();

                var r = _DADocumentacion.GuardarDocumentacion(p);

                return Response.AsJson(new Result<DataModel>()
                {
                    Value = r.Value,
                    Message = r.Message,
                    Data = new DataModel()
                    {
                        CodigoError = r.Data.CodigoError,
                        MensajeBitacora = r.Data.MensajeBitacora,
                        Data = r.Data.Data
                    }
                });
            }
            catch (Exception ex)
            {
                return Response.AsJson(new Result<DataModel>()
                {
                    Value = false,
                    Message = "Problemas al registrar su documentación",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                });
            }
        }

        private object ConsultaDocumentacion()
        {
            try
            {
                DocumentacionModel p = this.Bind();

                var r = _DADocumentacion.ConsultaDocumentacion(p.Usuario, p.SucursalID);

                return Response.AsJson(new Result<DataModel>()
                {
                    Value = r.Value,
                    Message = r.Message,
                    Data = new DataModel()
                    {
                        CodigoError = r.Data.CodigoError,
                        MensajeBitacora = r.Data.MensajeBitacora,
                        Data = r.Data.Data
                    }
                });
            }
            catch (Exception ex)
            {
                return Response.AsJson(new Result<DataModel>()
                {
                    Value = false,
                    Message = "Problemas al obtener la documentación",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                });
            }
        }

        private object ConsultaClientesDocumentacion()
        {
            try
            {
                DocumentacionModel p = this.Bind();

                var r = _DADocumentacion.ConsultaClientesDocumentacion(p.Usuario, p.SucursalID);

                return Response.AsJson(new Result<DataModel>()
                {
                    Value = r.Value,
                    Message = r.Message,
                    Data = new DataModel()
                    {
                        CodigoError = r.Data.CodigoError,
                        MensajeBitacora = r.Data.MensajeBitacora,
                        Data = r.Data.Data
                    }
                });
            }
            catch (Exception ex)
            {
                return Response.AsJson(new Result<DataModel>()
                {
                    Value = false,
                    Message = "Problemas al obtener la documentación",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                });
            }
        }

        private object ConsultaClientesXTipoDocumentacion()
        {
            try
            {
                DocumentacionModel p = this.Bind();

                var r = _DADocumentacion.ConsultaClientesXTipoDocumentacion(p.Usuario, p.SucursalID, p.TipoCliente);

                return Response.AsJson(new Result<DataModel>()
                {
                    Value = r.Value,
                    Message = r.Message,
                    Data = new DataModel()
                    {
                        CodigoError = r.Data.CodigoError,
                        MensajeBitacora = r.Data.MensajeBitacora,
                        Data = r.Data.Data
                    }
                });
            }
            catch (Exception ex)
            {
                return Response.AsJson(new Result<DataModel>()
                {
                    Value = false,
                    Message = "Problemas al obtener la documentación",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                });
            }
        }

        private object ObtieneComprobantesCliente()
        {
            try
            {
                DocumentacionModel p = this.Bind();

                var r = _DADocumentacion.ObtieneComprobantesCliente(p.Usuario, p.SucursalID);

                return Response.AsJson(new Result<DataModel>()
                {
                    Value = r.Value,
                    Message = r.Message,
                    Data = new DataModel()
                    {
                        CodigoError = r.Data.CodigoError,
                        MensajeBitacora = r.Data.MensajeBitacora,
                        Data = r.Data.Data
                    }
                });
            }
            catch (Exception ex)
            {
                return Response.AsJson(new Result<DataModel>()
                {
                    Value = false,
                    Message = "Problemas al obtener la documentación",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                });
            }
        }

        private object SolicitudesGuardar()
        {
            try
            {
                //var t = this.BindToken();
                SolicitudesModel p = this.Bind();

                var r = _DADocumentacion.SolicitudesGuardar(p);

                return Response.AsJson(new Result<DataModel>()
                {
                    Value = r.Value,
                    Message = r.Message,
                    Data = new DataModel()
                    {
                        CodigoError = r.Data.CodigoError,
                        MensajeBitacora = r.Data.MensajeBitacora,
                        Data = r.Data.Data
                    }
                });
            }
            catch (Exception ex)
            {
                return Response.AsJson(new Result<DataModel>()
                {
                    Value = false,
                    Message = "Problemas al registrar la solicitud",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                });
            }
        }

        //private object RptSolicitud()
        //{
        //    String b64Str;
        //    try
        //    {
        //        DocumentacionModel p = this.Bind();

        //        var r = _DADocumentacion.RptSolicitudDocumentacion(p.Usuario, p.SucursalID);

        //        if (r.Value == false)
        //        {
        //            return Response.AsJson(new Result<DataModel>()
        //            {
        //                Value = r.Value,
        //                Message = r.Message,
        //                Data = new DataModel()
        //                {
        //                    CodigoError = r.Data.CodigoError,
        //                    MensajeBitacora = r.Data.MensajeBitacora,
        //                    Data = ""
        //                }
        //            });
        //        }

        //        DataSet ds = (DataSet)r.Data.Data;


        //        ReportDataSource datasource = new ReportDataSource("Cabecero", ds.Tables[0]);


        //        ReportViewer rp = new ReportViewer();
        //        rp.ProcessingMode = ProcessingMode.Local;

        //        rp.LocalReport.ReportPath = Globales.RutaApp + "FormatoReporte.rdlc";

        //        rp.LocalReport.DataSources.Clear();
        //        rp.LocalReport.DataSources.Add(datasource);


        //        byte[] Bytes = rp.LocalReport.Render(format: "PDF", deviceInfo: "");

        //        System.IO.Stream stream = new System.IO.MemoryStream(Bytes);

        //        using (Stream stm = stream)
        //        {
        //            stm.Seek(0, SeekOrigin.Begin);
        //            byte[] buffer = new byte[stm.Length];
        //            stm.Read(buffer, 0, (int)stm.Length);
        //            b64Str = Convert.ToBase64String(buffer);
        //        }

        //        return Response.AsJson(new Result<DataModel>()
        //        {
        //            Value = true,
        //            Message = "Orden compra",
        //            Data = new DataModel()
        //            {
        //                CodigoError = 0,
        //                MensajeBitacora = "",
        //                Data = b64Str
        //            }
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Response.AsJson(new Result<DataModel>()
        //        {
        //            Value = false,
        //            Message = "Problemas al generar la solicitud",
        //            Data = new DataModel()
        //            {
        //                CodigoError = 101,
        //                MensajeBitacora = ex.Message,
        //                Data = ""
        //            }
        //        });
        //    }
        //}
    }
}

