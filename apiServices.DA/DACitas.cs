using apiServices.Models;
using apiServices.Models.Citas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarmPack.Classes;
using WarmPack.Database;

namespace apiServices.DA
{
    public class DACitas
    {
        private readonly Conexion _conexion = null;

        public DACitas()
        {
            _conexion = new Conexion(ConexionType.MSSQLServer, Globales.ConexionPrincipal);
        }

        public Result<DataModel> TiposCitasCon(int tipoID, int sucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pTipoID", ConexionDbType.Int, tipoID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, sucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<TiposCitasModel>("CprocTiposCitasCon", parametros);

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
                    Message = "Problemas al obtener los tipos de citas",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> TiposCitasGuardar(TiposCitasModel tiposCitas)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursalID", ConexionDbType.Int, tiposCitas.SucursalID);
                parametros.Add("@pTipoID", ConexionDbType.Int, tiposCitas.TipoID);
                parametros.Add("@pTipoDescripcion", ConexionDbType.VarChar, tiposCitas.TipoDescripcion);
                parametros.Add("@pTipoEstatus", ConexionDbType.Bit, tiposCitas.TipoEstatus);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("CprocTiposCitasGuardar", parametros);

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
                    Message = "Problemas al registrar el tipo de cita",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> ConfiguracionCitasCon(int sucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursalID", ConexionDbType.Int, sucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<ConfiguracionCitasModel>("CprocConfigCitasCon", parametros);

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
                    Message = "Problemas al obtener la configuracion",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> ConfiguracionCitasGuardar(ConfiguracionCitasModel configcitas)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursalID", ConexionDbType.Int, configcitas.SucursalID);
                parametros.Add("@pCitaDiaID", ConexionDbType.Int, configcitas.CitaDiaID);
                parametros.Add("@pCitaHora", ConexionDbType.VarChar, configcitas.CitaHora);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("CprocConfigCitasGuardar", parametros);

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
                    Message = "Problemas al registrar la configuracion",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> CitasCon(int sucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursalID", ConexionDbType.Int, sucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<CitasModel>("CprocCitasCon", parametros);

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
                    Message = "Problemas al obtener las citas",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> CitasDiaCon(int sucursalID, string fechaCita)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursalID", ConexionDbType.Int, sucursalID);
                parametros.Add("@pFechaCita", ConexionDbType.VarChar, fechaCita);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<ConfiguracionCitasModel>("CprocCitasXFechaCon", parametros);

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
                    Message = "Problemas al obtener las citas",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> CitasGuardar(CitasModel citas)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pCitaID", ConexionDbType.Int, citas.CitaID);
                parametros.Add("@pCitaTipo", ConexionDbType.Int, citas.CitaTipo);
                parametros.Add("@pSucursalID", ConexionDbType.Int, citas.SucursalID);
                parametros.Add("@pCitaFecha", ConexionDbType.VarChar, citas.CitaFecha);
                parametros.Add("@pCitaDiaID", ConexionDbType.Int, citas.CitaDiaID);
                parametros.Add("@pClienteNombre", ConexionDbType.VarChar, citas.ClienteNombre);
                parametros.Add("@pClienteAp", ConexionDbType.VarChar, citas.ClienteAp);
                parametros.Add("@pClienteTelefono", ConexionDbType.VarChar, citas.ClienteTelefono);
                parametros.Add("@pClienteEmail", ConexionDbType.VarChar, citas.ClienteEmail);
                parametros.Add("@pCitaEstatus", ConexionDbType.Bit, citas.CitaEstatus);
                parametros.Add("@pCitaConfirmacion", ConexionDbType.Bit, citas.CitaConfirmacion);
                parametros.Add("@pCitaCantidadPersonas", ConexionDbType.Int, citas.CitaCantidadPersonas);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("CprocCitasGuardar", parametros);

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
                    Message = "Problemas al registrar la cita",
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

