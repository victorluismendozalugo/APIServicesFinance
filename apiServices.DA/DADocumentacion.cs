using apiServices.Models;
using apiServices.Models.Catalogos;
using System;
using System.Collections.Generic;
using System.Data;
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

                parametros.Add("@pDondeSeEntero", ConexionDbType.VarChar, usuario.DondeSeEntero);
                parametros.Add("@pGenero", ConexionDbType.VarChar, usuario.Genero);
                parametros.Add("@pFechaNacimiento", ConexionDbType.VarChar, usuario.FechaNacimiento);
                parametros.Add("@pEdad", ConexionDbType.Int, usuario.Edad);
                parametros.Add("@pPaisNacimiento", ConexionDbType.VarChar, usuario.PaisNacimiento);
                parametros.Add("@pNacionalidad", ConexionDbType.VarChar, usuario.Nacionalidad);
                parametros.Add("@pCURP", ConexionDbType.VarChar, usuario.curp);
                parametros.Add("@pRFC", ConexionDbType.VarChar, usuario.rfc);

                parametros.Add("@pNivelEstudios", ConexionDbType.VarChar, usuario.NivelEstudios);
                parametros.Add("@pEdoCivil", ConexionDbType.VarChar, usuario.EdoCivil);
                parametros.Add("@pOcupacion", ConexionDbType.VarChar, usuario.Ocupacion);
                parametros.Add("@pCalleNumero", ConexionDbType.VarChar, usuario.CalleNumero);
                parametros.Add("@pColonia", ConexionDbType.VarChar, usuario.Colonia);
                parametros.Add("@pCodigoPostal", ConexionDbType.VarChar, usuario.CodigoPostal);
                parametros.Add("@pMunicipio", ConexionDbType.VarChar, usuario.Municipio);
                parametros.Add("@pEstado", ConexionDbType.VarChar, usuario.Estado);

                parametros.Add("@pPais", ConexionDbType.VarChar, usuario.Pais);
                parametros.Add("@pTiempoVivir", ConexionDbType.Int, usuario.TiempoVivir);
                parametros.Add("@pTelefonoCasa", ConexionDbType.VarChar, usuario.TelefonoCasa);
                parametros.Add("@pEntidadFederativa", ConexionDbType.VarChar, usuario.EntidadFederativa);
                parametros.Add("@pNombreEmpresa", ConexionDbType.VarChar, usuario.NombreEmpresa);
                parametros.Add("@pCalleNumeroEmpresa", ConexionDbType.VarChar, usuario.CalleNumeroEmpresa);
                parametros.Add("@pColoniaEmpresa", ConexionDbType.VarChar, usuario.ColoniaEmpresa);
                parametros.Add("@pCodigoPostalEmpresa", ConexionDbType.VarChar, usuario.CodigoPostalEmpresa);

                parametros.Add("@pMunicipioEmpresa", ConexionDbType.VarChar, usuario.MunicipioEmpresa);
                parametros.Add("@pEstadoEmpresa", ConexionDbType.VarChar, usuario.EstadoEmpresa);
                parametros.Add("@pTelefonoEmpresa", ConexionDbType.VarChar, usuario.TelefonoEmpresa);
                parametros.Add("@pAntiguedad", ConexionDbType.Int, usuario.Antiguedad);
                parametros.Add("@pIngresoMensual", ConexionDbType.VarChar, usuario.IngresoMensual);
                parametros.Add("@pFrecuenciaPago", ConexionDbType.VarChar, usuario.FrecuenciaPago);
                parametros.Add("@pNombreConyugue", ConexionDbType.VarChar, usuario.NombreConyugue);
                parametros.Add("@pApellidoPConyugue", ConexionDbType.VarChar, usuario.ApellidoPConyugue);

                parametros.Add("@pApellidoMConyugue", ConexionDbType.VarChar, usuario.ApellidoMConyugue);
                parametros.Add("@pTelefonoConyugue", ConexionDbType.VarChar, usuario.TelefonoConyugue);
                parametros.Add("@pCelularConyugue", ConexionDbType.VarChar, usuario.CelularConyugue);
                parametros.Add("@pOcupacionConyugue", ConexionDbType.VarChar, usuario.OcupacionConyugue);
                parametros.Add("@pIngresoMensualConyugue", ConexionDbType.VarChar, usuario.IngresoMensualConyugue);
                parametros.Add("@pBancoCredito", ConexionDbType.VarChar, usuario.BancoCredito);
                parametros.Add("@pCtaClabeTarjeta", ConexionDbType.VarChar, usuario.CtaClabeTarjeta);

                parametros.Add("@pReferenciaNombre3", ConexionDbType.VarChar, usuario.ReferenciaNombre3);
                parametros.Add("@pReferenciaTelefono3", ConexionDbType.VarChar, usuario.ReferenciaTelefono3);
                parametros.Add("@pReferenciaNombre4", ConexionDbType.VarChar, usuario.ReferenciaNombre4);
                parametros.Add("@pReferenciaTelefono4", ConexionDbType.VarChar, usuario.ReferenciaTelefono4);

                parametros.Add("@pTipoVivienda", ConexionDbType.VarChar, usuario.TipoVivienda);

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

        public Result<DataModel> RptSolicitudDocumentacion(string usuario, int sucursal)
        {
            var parametros = new ConexionParameters();
            DataSet dsRep;
            try
            {
                parametros.Add("@pUsuario", ConexionDbType.VarChar, usuario);
                parametros.Add("@pSucursal", ConexionDbType.Int, sucursal);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults("procDocumentacionCon", parametros, out dsRep);

                return new Result<DataModel>()
                {
                    Value = parametros.Value("@pResultado").ToBoolean(),
                    Message = parametros.Value("@pMsg").ToString(),
                    Data = new DataModel()
                    {
                        CodigoError = parametros.Value("@pCodError").ToInt32(),
                        MensajeBitacora = parametros.Value("@pMsg").ToString(),
                        Data = dsRep
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

        public Result<DataModel> ConsultaClientesDocumentacion(string usuario, int sucursal)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pUsuario", ConexionDbType.VarChar, usuario);
                parametros.Add("@pSucursal", ConexionDbType.Int, sucursal);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<DocumentacionModel>("procClientesDocumentacionCon", parametros);

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
                    Message = "Problemas al obtener la documentación de los clientes",
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
