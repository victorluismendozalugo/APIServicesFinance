using apiServices.Models;
using apiServices.Models.Notificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarmPack.Classes;
using WarmPack.Database;

namespace apiServices.DA
{
    public class DANotificaciones
    {
        private readonly Conexion _conexion = null;
        public DANotificaciones()
        {
            _conexion = new Conexion(ConexionType.MSSQLServer, Globales.ConexionPrincipal);
        }

        public Result<DataModel> EnviarNotificacion(NotificacionesModel notificaciones)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursal", ConexionDbType.Int, notificaciones.Sucursal);
                parametros.Add("@pRemitente", ConexionDbType.VarChar, notificaciones.Remitente);
                parametros.Add("@pReceptor", ConexionDbType.VarChar, notificaciones.Receptor);
                parametros.Add("@pPrevia", ConexionDbType.VarChar, notificaciones.Previa);
                parametros.Add("@pTexto", ConexionDbType.VarChar, notificaciones.Texto);
                parametros.Add("@pImagen", ConexionDbType.VarChar, notificaciones.Imagen);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procNotificacionesGuardar", parametros);

                return new Result<DataModel>()
                {
                    Value = parametros.Value("@pResultado").ToBoolean(),
                    Message = parametros.Value("@pMsg").ToString(),
                    Data = new DataModel()
                    {
                        CodigoError = parametros.Value("@pCodError").ToInt32(),
                        MensajeBitacora = parametros.Value("@pMsg").ToString(),
                        Data = r.Data
                    }
                };
            }
            catch (Exception ex)
            {
                return new Result<DataModel>()
                {
                    Value = false,
                    Message = "Notificación enviada",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> ConsultaNotificaciones(NotificacionesModel notificaciones)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursal", ConexionDbType.Int, notificaciones.Sucursal);
                parametros.Add("@pReceptor", ConexionDbType.VarChar, notificaciones.Receptor);
                parametros.Add("@pEstatus", ConexionDbType.VarChar, notificaciones.Estatus);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<NotificacionesModel>("procNotificacionesCon", parametros);

                return new Result<DataModel>()
                {
                    Value = parametros.Value("@pResultado").ToBoolean(),
                    Message = parametros.Value("@pMsg").ToString(),
                    Data = new DataModel()
                    {
                        CodigoError = parametros.Value("@pCodError").ToInt32(),
                        MensajeBitacora = parametros.Value("@pMsg").ToString(),
                        Data = r.Data
                    }
                };
            }
            catch (Exception ex)
            {
                return new Result<DataModel>()
                {
                    Value = false,
                    Message = "Problemas al obtener sus notificaciones",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
    }
}
