using apiServices.DA;
using apiServices.Models;
using apiServices.Models.Movimientos;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;
using System;
using System.Linq;
using WarmPack.Classes;

namespace apiServices.Modules
{
    public class Movimientos : NancyModule
    {
        private readonly DAMovimientos _DAMovimientos = null;


        public Movimientos() : base("/movimientos")
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
            //this.RequiresAuthentication();

            _DAMovimientos = new DAMovimientos();
            Post("/notas", _ => Notas());
            Post("/notasdetalle", _ => NotasDetalle());
            Post("/notasdetallepago", _ => NotasDetallePago());
            Post("/notas/guardar", _ => NotasGuardar());
            Post("/producto/disponibilidad", _ => ProductosDisponibilidad());

        }

        private object Notas()
        {
            try
            {
                NotasModel p = this.Bind();

                var r = _DAMovimientos.Notas(p.NotaID, p.SucursalID);

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
                    Message = "Problemas al obtener las notas",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                });
            }
        }

        private object NotasDetalle()
        {
            try
            {
                NotasModel p = this.Bind();

                var r = _DAMovimientos.NotasDetalleCon(p.NotaID, p.SucursalID);

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
                    Message = "Problemas al obtener las notas",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                });
            }
        }

        private object NotasDetallePago()
        {
            try
            {
                NotasModel p = this.Bind();

                var r = _DAMovimientos.NotasPagosCon(p.NotaID, p.SucursalID);

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
                    Message = "Problemas al obtener las notas",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                });
            }
        }

        private object NotasGuardar()
        {
            try
            {
                NotasModel p = this.Bind();

                var r = _DAMovimientos.Notas(p);

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
                    Message = "Problemas al registrar el movimiento",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                });
            }

        }

        //consulta la disponibilidad de renta de un producto
        private object ProductosDisponibilidad()
        {
            try
            {
                NotasModel p = this.Bind();

                var r = _DAMovimientos.ProductosDisponibilidad(p.ProductoCod, p.FechaEntrega, p.FechaDevolucion, p.SucursalID);

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
                    Message = "Problemas en catalogo de productos",
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