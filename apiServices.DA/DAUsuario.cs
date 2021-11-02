
using apiServices.Models;
using apiServices.Models.Usuario;
using System;
using WarmPack.Classes;
using WarmPack.Database;

namespace apiServices.DA
{
    public class DAUsuario
    {
        private readonly Conexion _conexion = null;

        public DAUsuario()
        {
            _conexion = new Conexion(ConexionType.MSSQLServer, Globales.ConexionPrincipal);
        }

        public Result<DataModel> Login(UsuarioCredencialesModel credenciales)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pUsuario", ConexionDbType.VarChar, credenciales.Usuario);
                parametros.Add("@pPassword", ConexionDbType.VarChar, credenciales.Password);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = new UsuarioModel();
                _conexion.ExecuteWithResults("procUsuariosIdentificar", parametros, row =>
                {
                    r.IdUsuario = row["IdUsuario"].ToInt32();
                    r.Usuario = row["Usuario"].ToString();
                    r.RolID = row["RolID"].ToInt32();
                });

                return new Result<DataModel>()
                {
                    Value = parametros.Value("@pResultado").ToBoolean(),
                    Message = parametros.Value("@pMsg").ToString(),
                    Data = new DataModel()
                    {
                        CodigoError = parametros.Value("@pCodError").ToInt32(),
                        MensajeBitacora = parametros.Value("@pMsg").ToString(),
                        Data = r
                    }
                };
            }
            catch (Exception ex)
            {
                return new Result<DataModel>()
                {
                    Value = false,
                    Message = "Problemas en acceso del usuario",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> ConsultaSucursalUsuario(string usuario)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pUsuario", ConexionDbType.VarChar, usuario);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<UsuarioModel>("procSucursalUsuarioCon", parametros);

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
                    Message = "Problemas al obtener la sucursal del usuario",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> UsuarioRegistro(UsuarioRegistroModel usuario)
        {
            var parametros = new ConexionParameters();
            //var xml = usaurio.ToXml("root");
            try
            {
                parametros.Add("@pUsuarioID", ConexionDbType.Int, usuario.IDUsuario);
                parametros.Add("@pUsuario", ConexionDbType.VarChar, usuario.Usuario);
                parametros.Add("@pPrimerApellido", ConexionDbType.VarChar, usuario.PrimerApellido);
                parametros.Add("@pSegundoApellido", ConexionDbType.VarChar, usuario.SegundoApellido);
                parametros.Add("@pNombre", ConexionDbType.VarChar, usuario.Nombre);
                parametros.Add("@pPassword", ConexionDbType.VarChar, usuario.Contrasena);
                parametros.Add("@pFechaTermino", ConexionDbType.VarChar, usuario.FechaTermino);
                parametros.Add("@pQuienAutoriza", ConexionDbType.Int, usuario.QuienAutoriza);
                parametros.Add("@pCorreo", ConexionDbType.VarChar, usuario.Correo);
                parametros.Add("@pCelular", ConexionDbType.VarChar, usuario.Celular);
                parametros.Add("@pRequiereToken", ConexionDbType.Bit, usuario.RequiereToken);
                parametros.Add("@pSucursal", ConexionDbType.Int, usuario.SucursalID);
                parametros.Add("@pRolID", ConexionDbType.Int, usuario.RolID);
                parametros.Add("@pCurp", ConexionDbType.VarChar, usuario.Curp);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procUsuariosAdd", parametros);

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
                    Message = "Problemas al registrar el usuario",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> UsuarioRegistroSCorreo(UsuarioRegistroModel usuario)
        {
            var parametros = new ConexionParameters();
            //var xml = usaurio.ToXml("root");
            try
            {
                parametros.Add("@pUsuarioID", ConexionDbType.Int, usuario.IDUsuario);
                parametros.Add("@pUsuario", ConexionDbType.VarChar, usuario.Usuario);
                parametros.Add("@pPrimerApellido", ConexionDbType.VarChar, usuario.PrimerApellido);
                parametros.Add("@pSegundoApellido", ConexionDbType.VarChar, usuario.SegundoApellido);
                parametros.Add("@pNombre", ConexionDbType.VarChar, usuario.Nombre);
                parametros.Add("@pPassword", ConexionDbType.VarChar, usuario.Contrasena);
                parametros.Add("@pFechaTermino", ConexionDbType.VarChar, usuario.FechaTermino);
                parametros.Add("@pQuienAutoriza", ConexionDbType.Int, usuario.QuienAutoriza);
                parametros.Add("@pCorreo", ConexionDbType.VarChar, usuario.Correo);
                parametros.Add("@pCelular", ConexionDbType.VarChar, usuario.Celular);
                parametros.Add("@pRequiereToken", ConexionDbType.Bit, usuario.RequiereToken);
                parametros.Add("@pSucursal", ConexionDbType.Int, usuario.SucursalID);
                parametros.Add("@pRolID", ConexionDbType.Int, usuario.RolID);
                parametros.Add("@pCurp", ConexionDbType.VarChar, usuario.Curp);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procUsuariosAddSinCorreo", parametros);

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
                    Message = "Problemas al registrar el usuario",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> ConsultaMenu(string usuario)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pUsuario", ConexionDbType.VarChar, usuario);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<UsuarioModel>("procMenuCon", parametros);

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
                    Message = "Problemas al obtener el menú",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> ConsultaUsuario(int IDUsuario)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pIDUsuario", ConexionDbType.Int, IDUsuario);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<UsuarioRegistroModel>("procUsuariosCon", parametros);

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
                    Message = "Problemas al obtener el listado de usuarios",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> ActivarUsuario(ActivacionUsuario activacion)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pGUID", ConexionDbType.VarChar, activacion.guid);
                parametros.Add("@pSucursalID", ConexionDbType.Int, activacion.sucursal);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procUsuariosActivar", parametros);

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
                    Message = "Problemas al activar el usuario",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> UsuarioEnviarEmail(UsuarioRegistroModel usuario)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pUsuario", ConexionDbType.VarChar, usuario.Usuario);
                parametros.Add("@pSucursalID", ConexionDbType.Int, usuario.SucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procUsuariosNuevoCorreo", parametros);

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
                    Message = "Problemas al enviar el correo elctrónico",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> TipoUsuario(string usuario, int sucursal)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pUsuario", ConexionDbType.VarChar, usuario);
                parametros.Add("@pSucursalID", ConexionDbType.Int, sucursal);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<UsuarioTipoModel>("procTipoClienteCon", parametros);

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
                    Message = "Problemas al obtener el tipo de usuario",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> UsuarioBaja(string usuario, int sucursal, string motivo)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursal", ConexionDbType.Int, sucursal);
                parametros.Add("@pUsuario", ConexionDbType.VarChar, usuario);
                parametros.Add("@pMotivoBaja", ConexionDbType.VarChar, motivo);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<UsuarioTipoModel>("procClientesBaja", parametros);

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
                    Message = "Problemas al dar de baja el cliente",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> UsuarioAlta(string usuario, int sucursal)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursal", ConexionDbType.Int, sucursal);
                parametros.Add("@pUsuario", ConexionDbType.VarChar, usuario);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<UsuarioTipoModel>("procClientesReactivar", parametros);

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
                    Message = "Problemas al reactivar al cliente",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> MotivosBajaCon(string usuario, int sucursal)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursal", ConexionDbType.Int, sucursal);
                parametros.Add("@pUsuario", ConexionDbType.VarChar, usuario);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<UsuarioTipoModel>("procMotivosBajaCon", parametros);

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
                    Message = "Problemas al obtener el motivo de baja del cliente",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> CreditoAutorizar(string usuario, int sucursal, int monto, string responsable)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursal", ConexionDbType.Int, sucursal);
                parametros.Add("@pUsuario", ConexionDbType.VarChar, usuario);
                parametros.Add("@pMontoAutorizado", ConexionDbType.Int, monto);
                parametros.Add("@pResponsable", ConexionDbType.VarChar, responsable);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<UsuarioTipoModel>("procClientesAutorizar", parametros);

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
                    Message = "Problemas al autorizar",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> UsuarioDispersar(string usuario, int sucursal, string fechaDeposito, string responsable)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursal", ConexionDbType.Int, sucursal);
                parametros.Add("@pUsuario", ConexionDbType.VarChar, usuario);
                parametros.Add("@pResponsable", ConexionDbType.VarChar, responsable);
                parametros.Add("@pFechaDeposito", ConexionDbType.VarChar, fechaDeposito);

                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<UsuarioTipoModel>("procClientesDispersar", parametros);

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
                    Message = "Problemas al dispersar",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> UsuarioCreditoAutorizadoCon(string usuario, int sucursal)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursal", ConexionDbType.Int, sucursal);
                parametros.Add("@pUsuario", ConexionDbType.VarChar, usuario);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<UsuarioTipoModel>("procClientesCreditoCon", parametros);

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
                    Message = "Problemas al obtener el detalle del crédito",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> AutorizarOpSupervizada(string Autorizador, int sucursal, string responsable, string operacion, string password, string cliente)
        {
            var parametros = new ConexionParameters();
            try
            {

                parametros.Add("@pUsuario", ConexionDbType.VarChar, Autorizador);
                parametros.Add("@pPassword", ConexionDbType.VarChar, password);
                parametros.Add("@pOperacion", ConexionDbType.VarChar, operacion);
                parametros.Add("@pResponsable", ConexionDbType.VarChar, responsable);
                parametros.Add("@pSucursal", ConexionDbType.Int, sucursal);
                parametros.Add("@pCliente", ConexionDbType.VarChar, cliente);

                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<UsuarioOperacionSupervizadaModel>("procUsuariosOpSupervizada", parametros);

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
                    Message = "Problemas al autorizar",
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