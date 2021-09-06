using apiServices.Models;
using apiServices.Models.Movimientos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using WarmPack.Classes;
using WarmPack.Database;
using WarmPack.Extensions;

namespace apiServices.DA
{
    public class DAMovimientos
    {
        private readonly Conexion _conexion = null;

        public DAMovimientos()
        {
            _conexion = new Conexion(ConexionType.MSSQLServer, Globales.ConexionPrincipal);
        }


        public Result<DataModel> Notas(int NotaID, int SucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pNotaID", ConexionDbType.Int, NotaID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, SucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<NotasModel>("procNotasCon", parametros);

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
                    Message = "Problemas al obtener los movimientos",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> NotasDetalleCon(int NotaID, int SucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pNotaID", ConexionDbType.Int, NotaID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, SucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<NotaDetalle>("procNotasDetalleCon", parametros);

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
                    Message = "Problemas al obtener los movimientos",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> NotasPagosCon(int NotaID, int SucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pNotaID", ConexionDbType.Int, NotaID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, SucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<NotaPagos>("procNotasPagosCon", parametros);

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
                    Message = "Problemas al obtener los movimientos",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> Notas(NotasModel notas)
        {
            var parametros = new ConexionParameters();
            var xml = notas.ToXml("root");
            try
            {
                parametros.Add("@pDatosXML", ConexionDbType.Xml, xml);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procNotasGuardar", parametros);

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
                    Message = "Problemas al registrar la nota",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> ProductosDisponibilidad(string ProductoCod, string FechaIni, string FechaFin, int SucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pProductoCod", ConexionDbType.VarChar, ProductoCod);
                parametros.Add("@pFechaIni", ConexionDbType.VarChar, FechaIni);
                parametros.Add("@pFechaFin", ConexionDbType.VarChar, FechaFin);
                parametros.Add("@pSucursalID", ConexionDbType.Int, SucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<NotasModel>("procVerificadisponibilidad", parametros);

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
                    Message = "Problemas al obtener la disponibilidad",
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




//public Result<DataModel> Usuarios(string usuarioLogin, int EmpresaID)
//{
//    var parametros = new ConexionParameters();
//    try
//    {
//        parametros.Add("@pUsuario", ConexionDbType.VarChar, usuarioLogin);
//        parametros.Add("@pEmpresa", ConexionDbType.Int, EmpresaID);
//        parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
//        parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
//        parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

//        var r = _conexion.ExecuteWithResults<UsuarioModel>("procUsuariosCon", parametros);

//        return new Result<DataModel>()
//        {
//            Value = parametros.Value("@pResultado").ToBoolean(),
//            Message = parametros.Value("@pMsg").ToString(),
//            Data = new DataModel()
//            {
//                CodigoError = parametros.Value("@pCodError").ToInt32(),
//                MensajeBitacora = parametros.Value("@pMsg").ToString(),
//                Data = r.Data
//            }
//        };
//    }
//    catch (Exception ex)
//    {
//        return new Result<DataModel>()
//        {
//            Value = false,
//            Message = "Problemas en catalogo de usuarios",
//            Data = new DataModel()
//            {
//                CodigoError = 101,
//                MensajeBitacora = ex.Message,
//                Data = ""
//            }
//        };
//    }
//}