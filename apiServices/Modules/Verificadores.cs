using apiServices.DA;
using apiServices.Models;
using apiServices.Models.Catalogos;
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
    public class Verificadores : NancyModule
    {
        private readonly DAVerificadores _DAVerificadores = null;

        public Verificadores() : base("/verificadores")
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
            _DAVerificadores = new DAVerificadores();


            Post("/consulta", _ => ConsultaVerificadores());
            Post("/consulta/cobranza", _ => CobranzaVerificadoresCon());
            Post("/consulta/cobranza/detalle", _ => CobranzaDetalleVerificadoresCon());

        }
        private object ConsultaVerificadores()
        {
            try
            {
                VerificadoresModel p = this.Bind();

                var r = _DAVerificadores.ConsultarVerificadores(p);

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
                    Message = "Problemas al obtener los verificadores",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                });
            }
        }
        private object CobranzaVerificadoresCon()
        {
            try
            {
                VerificadoresModel p = this.Bind();

                var r = _DAVerificadores.CobranzaVerificadoresCon(p);

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
                    Message = "Problemas al obtener el detalle de cobranza",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                });
            }
        }
        private object CobranzaDetalleVerificadoresCon()
        {
            try
            {
                VerificadoresModel p = this.Bind();

                var r = _DAVerificadores.CobranzaDetalleVerificadoresCon(p);

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
                    Message = "Problemas al obtener el detalle de cobranza",
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