using apiServices.DA;
using apiServices.Models;
using apiServices.Models.Usuario;
using Microsoft.Graph;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarmPack.Classes;

namespace apiServices.Modules
{
    public class UserActivation : NancyModule
    {
        private readonly DAUsuario _DAUsuario = null;

        public UserActivation() : base("/activation")
        {
            //Before += ctx =>
            //{
            //    if (!ctx.Request.Headers.Keys.Contains("api-key"))
            //    {
            //        return HttpStatusCode.Unauthorized;
            //    }
            //    else
            //    {
            //        var apikey = ctx.Request.Headers["api-key"].FirstOrDefault() ?? string.Empty;
            //        if (apikey != Globales.ApiKey)
            //        {
            //            return HttpStatusCode.Unauthorized;
            //        }
            //        else
            //        {
            //            return null;
            //        }
            //    }
            //};

            //this.RequiresAuthentication();
            _DAUsuario = new DAUsuario();

            Get("/user/{Usuario}", _ => activarUsuario());

            //Get("/user", _ => "Received GET request");

        }


        private object activarUsuario()
        {
            try
            {
                var r = this.Bind<UsuarioRegistroModel>();
                return r;

            }
            catch (Exception ex)
            {

                return ex.ToString();
            }

            //try
            //{
            //    UsuarioRegistroModel p = this.Bind();

            //    var r = _DAUsuario.ActivarUsuario(1, 1);

            //    return Response.AsJson(new Result<DataModel>()
            //    {
            //        Value = r.Value,
            //        Message = r.Message,
            //        Data = new DataModel()
            //        {
            //            CodigoError = r.Data.CodigoError,
            //            MensajeBitacora = r.Data.MensajeBitacora,
            //            Data = r.Data.Data
            //        }
            //    });
            //}
            //catch (Exception ex)
            //{
            //    return Response.AsJson(new Result<DataModel>()
            //    {
            //        Value = false,
            //        Message = "Problemas al consultar la url solicitada",
            //        Data = new DataModel()
            //        {
            //            CodigoError = 101,
            //            MensajeBitacora = ex.Message,
            //            Data = ""
            //        }
            //    });
            //}
        }

    }
}