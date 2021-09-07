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

            Get("/user", _ => activarUsuario());

            //Get("/user", _ => "Received GET request");

        }


        private object activarUsuario()
        {
            try
            {
                ActivacionUsuario p = this.Bind();
                var r = _DAUsuario.ActivarUsuario(p);
                return r.Data.MensajeBitacora;
            }
            catch (Exception ex)
            {
                return "Problemas al consultar la url solicitada";
            }
        }
    }
}