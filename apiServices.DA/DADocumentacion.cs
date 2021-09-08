using apiServices.Models;
using apiServices.Models.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarmPack.Classes;
using WarmPack.Database;

namespace apiServices.DA
{
    public class DADocumentacion
    {
        private readonly Conexion _conexion = null;
        public DADocumentacion()
        {
            _conexion = new Conexion(ConexionType.MSSQLServer, Globales.ConexionPrincipal);
        }
        public Result<DataModel> GuardarDocumentacion(DocumentacionModel usuario)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pUsuario", ConexionDbType.VarChar, usuario.Usuario);
                parametros.Add("@pSucursal", ConexionDbType.Int, usuario.SucursalID);
                parametros.Add("@pIdentificacion", ConexionDbType.VarChar, usuario.Identificacion);
                parametros.Add("@pCompDomicilio", ConexionDbType.VarChar, usuario.CompDomicilio);
                parametros.Add("@pCompIngresos", ConexionDbType.VarChar, usuario.CompIngresos);
                parametros.Add("@pReferenciaNombre1", ConexionDbType.VarChar, usuario.ReferenciaNombre1);
                parametros.Add("@pReferenciaTelefono1", ConexionDbType.VarChar, usuario.ReferenciaTelefono1);
                parametros.Add("@pReferenciaNombre2", ConexionDbType.VarChar, usuario.ReferenciaNombre2);
                parametros.Add("@pReferenciaTelefono2", ConexionDbType.VarChar, usuario.ReferenciaTelefono2);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procDocumentacionGuardar", parametros);

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
                    Message = "Problemas al registrar la documentación",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> ConsultaDocumentacion(string usuario, int sucursal)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pUsuario", ConexionDbType.VarChar, usuario);
                parametros.Add("@pSucursal", ConexionDbType.Int, sucursal);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<DocumentacionModel>("procDocumentacionCon", parametros);

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
                    Message = "Problemas al obtener su documentación",
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
