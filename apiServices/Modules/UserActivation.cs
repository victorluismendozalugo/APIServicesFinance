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
            Post("/guardar", _ => UsuarioRegistro());
            Post("/email", _ => UsuarioEnviarEmail());

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

        private object UsuarioRegistro()
        {
            try
            {
                //var t = this.BindToken();
                UsuarioRegistroModel p = this.Bind();

                var r = _DAUsuario.UsuarioRegistro(p);

                if (r.Data.CodigoError == 0)
                {
                    Emailer email = new Emailer();
                    email.EnviarEmail(p.Usuario, r.Message, p.SucursalID);
                }

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
                    Message = "Problemas al registrar el usuario",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                });
            }
        }

        private object UsuarioEnviarEmail()
        {
            try
            {
                //var t = this.BindToken();
                UsuarioRegistroModel p = this.Bind();

                var r = _DAUsuario.UsuarioEnviarEmail(p);

                if (r.Data.CodigoError == 0)
                {
                    Emailer email = new Emailer();
                    email.EnviarEmail(p.Usuario, r.Message, p.SucursalID);
                }

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
                    Message = "Problemas al registrar el usuario",
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