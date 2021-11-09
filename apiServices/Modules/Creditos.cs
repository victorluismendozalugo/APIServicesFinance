using apiServices.DA;
using apiServices.Models;
using apiServices.Models.Creditos;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarmPack.Classes;

namespace apiServices.Modules
{
    public class Creditos : NancyModule
    {
        private readonly DACreditos _DACreditos = null;
        public Creditos(): base("/creditos") {
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
            _DACreditos = new DACreditos();

            Post("/abonos/guardar", _ => GuardaAbonos());
            Post("/abonos/consultar", _ => ConsultaAbonos());
        }

        private object ConsultaAbonos()
        {
            try
            {
                CreditosModel p = this.Bind();

                var r = _DACreditos.ConsultarAbonos(p);

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
                    Message = "Problemas al obtener el detalle de abonos",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                });
            }
        }

        private object GuardaAbonos()
        {
            try
            {
                //var t = this.BindToken();
                CreditosModel p = this.Bind();

                var r = _DACreditos.GuardarAbono(p);

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
                    Message = "Problemas al registrar el abono",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                });
            }
        }
    }
}