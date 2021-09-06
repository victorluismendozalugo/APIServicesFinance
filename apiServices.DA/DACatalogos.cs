using apiServices.Models;
using apiServices.Models.Catalogos;
using System;
using WarmPack.Classes;
using WarmPack.Database;
using WarmPack.Extensions;

namespace apiServices.DA
{
    public class DACatalogos
    {
        private readonly Conexion _conexion = null;

        public DACatalogos()
        {
            _conexion = new Conexion(ConexionType.MSSQLServer, Globales.ConexionPrincipal);
        }

        public Result<DataModel> Colores(int colorID, int sucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pColorID", ConexionDbType.Int, colorID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, sucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<ColoresModel>("procColoresCon", parametros);

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
                    Message = "Problemas en catalogo de colores",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> Colores(ColoresModel colores)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursalID", ConexionDbType.Int, colores.SucursalID);
                parametros.Add("@pColorID", ConexionDbType.Int, colores.ColorID);
                parametros.Add("@pColorNombre", ConexionDbType.VarChar, colores.ColorNombre);
                parametros.Add("@pColorResponsable", ConexionDbType.Int, colores.ColorResponsable);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procColoresGuardar", parametros);

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
                    Message = "Problemas al registrar el color",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> Estilos(int estiloID, int sucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pEstiloID", ConexionDbType.Int, estiloID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, sucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<EstilosModel>("procEstilosCon", parametros);

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
                    Message = "Problemas en catalogo de estilos",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> Estilos(EstilosModel estilos)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursalID", ConexionDbType.Int, estilos.SucursalID);
                parametros.Add("@pEstiloID", ConexionDbType.Int, estilos.EstiloID);
                parametros.Add("@pEstiloNombre", ConexionDbType.VarChar, estilos.EstiloNombre);
                parametros.Add("@pEstiloResponsable", ConexionDbType.Int, estilos.EstiloResponsable);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procEstilosGuardar", parametros);

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
                    Message = "Problemas en catalogo de estilos",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> Generos(int generoID, int sucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pGeneroID", ConexionDbType.Int, generoID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, sucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<GenerosModel>("procGenerosCon", parametros);

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
                    Message = "Problemas en catalogo de generos",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> Generos(GenerosModel generos)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursalID", ConexionDbType.Int, generos.SucursalID);
                parametros.Add("@pGeneroID", ConexionDbType.Int, generos.GeneroID);
                parametros.Add("@pGeneroDescripcion", ConexionDbType.VarChar, generos.GeneroDescripcion);
                parametros.Add("@pGeneroResponsable", ConexionDbType.Int, generos.GeneroResponsable);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procGenerosGuardar", parametros);

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
                    Message = "Problemas al registrar el genero",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> Marcas(int marcaID, int sucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pMarcaID", ConexionDbType.Int, marcaID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, sucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<MarcasModel>("procMarcasCon", parametros);

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
                    Message = "Problemas en catalogo de Marcas",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> Marcas(MarcasModel marcas)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursalID", ConexionDbType.Int, marcas.SucursalID);
                parametros.Add("@pMarcaID", ConexionDbType.Int, marcas.MarcaID);
                parametros.Add("@pMarcaNombre", ConexionDbType.VarChar, marcas.MarcaNombre);
                parametros.Add("@pMarcaResponsable", ConexionDbType.Int, marcas.MarcaResponsable);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procMarcasGuardar", parametros);

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
                    Message = "Problemas al registrar el Marcas",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> Productos(int ProductoID, int ProductoSucID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pProductoID", ConexionDbType.Int, ProductoID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, ProductoSucID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<ProductosModel>("procProductosCon", parametros);

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
                    Message = "Problemas en catalogo de productos",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> Productos(string ProductoDescripcion, int ProductoSucID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pProductoDesc", ConexionDbType.VarChar, ProductoDescripcion);
                parametros.Add("@pSucursalID", ConexionDbType.Int, ProductoSucID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<ProductosModel>("procProductosDescripcionCon", parametros);

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
                    Message = "Problemas en catalogo de productos",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> Productos(ProductosModel productos)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pProductoSucID", ConexionDbType.Int, productos.ProductoSucID);
                parametros.Add("@pProductoID", ConexionDbType.Int, productos.ProductoID);
                parametros.Add("@pProductoCod", ConexionDbType.VarChar, productos.ProductoCod);
                parametros.Add("@pProductoDescCorta", ConexionDbType.VarChar, productos.ProductoDescCorta);
                parametros.Add("@pProductoDescLarga", ConexionDbType.VarChar, productos.ProductoDescLarga);
                parametros.Add("@pProdColorID", ConexionDbType.Int, productos.ProdColorID);
                parametros.Add("@pProdGeneroID", ConexionDbType.Int, productos.ProdGeneroID);
                parametros.Add("@pProdTallaID", ConexionDbType.Int, productos.ProdTallaID);
                parametros.Add("@pProdTemporadaID", ConexionDbType.Int, productos.ProdTemporadaID);
                parametros.Add("@pProdEstiloID", ConexionDbType.Int, productos.ProdEstiloID);
                parametros.Add("@pProdTerminadoID", ConexionDbType.Int, productos.ProdTerminadoID);
                parametros.Add("@pProdMarcaID", ConexionDbType.Int, productos.ProdMarcaID);
                parametros.Add("@pProdEstatus", ConexionDbType.VarChar, productos.ProdEstatus);
                parametros.Add("@pProdOcasion", ConexionDbType.VarChar, productos.ProdOcasion);
                parametros.Add("@pProdFormalidad", ConexionDbType.VarChar, productos.ProdFormalidad);
                parametros.Add("@pProdUsuarioResponsable", ConexionDbType.Int, productos.ProdUsuarioResponsable);
                parametros.Add("@pProdImagen1", ConexionDbType.VarChar, productos.ProdImagen1);
                parametros.Add("@pProdImagen2", ConexionDbType.VarChar, productos.ProdImagen2);
                parametros.Add("@pProdImagen3", ConexionDbType.VarChar, productos.ProdImagen3);
                parametros.Add("@pProdImagen4", ConexionDbType.VarChar, productos.ProdImagen4);
                parametros.Add("@pProdPrecioRenta", ConexionDbType.Decimal, productos.ProdPrecioRenta);
                parametros.Add("@pProdPrecioVenta", ConexionDbType.Decimal, productos.ProdPrecioVenta);
                parametros.Add("@pProdPrecioGarantia", ConexionDbType.Decimal, productos.ProdPrecioGarantia);
                parametros.Add("@pEsServicio", ConexionDbType.VarChar, productos.EsServicio);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procProductosGuardar", parametros);

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
                    Message = "Problemas al registrar el producto",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> ProductosWeb(int ProductoID, int ProductoSucID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pProductoID", ConexionDbType.Int, ProductoID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, ProductoSucID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<ProductosModel>("procProductosWebCon", parametros);

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
                    Message = "Problemas en catalogo de productos",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> ProductosWebFiltros(ProductosModel p)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pProdColorID", ConexionDbType.Int, p.ProdColorID);
                parametros.Add("@pEstiloID", ConexionDbType.Int, p.ProdEstiloID);
                parametros.Add("@pTallaID", ConexionDbType.Int, p.ProdTallaID);
                parametros.Add("@pTemporalidadID", ConexionDbType.Int, p.ProdTemporadaID);
                parametros.Add("@pTermindadoID", ConexionDbType.Int, p.ProdTerminadoID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, p.ProductoSucID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<ProductosModel>("procProductosWebCon2", parametros);

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
                    Message = "Problemas en catalogo de productos",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> Pagos(int pagoID, int sucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pPagoID", ConexionDbType.Int, pagoID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, sucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<PagosModel>("procPagosCon", parametros);

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
                    Message = "Problemas en catalogo de Pagos",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> Pagos(PagosModel Pagos)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursalID", ConexionDbType.Int, Pagos.SucursalID);
                parametros.Add("@pPagoID", ConexionDbType.Int, Pagos.PagoID);
                parametros.Add("@pPagoNombre", ConexionDbType.VarChar, Pagos.PagoNombre);
                parametros.Add("@pPagoResponsable", ConexionDbType.Int, Pagos.PagoResponsable);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procPagosGuardar", parametros);

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
                    Message = "Problemas al registrar el tipo de pago",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> Sucursales(int sucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursalID", ConexionDbType.Int, sucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<SucursalesModel>("procSucursalesCon", parametros);

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
                    Message = "Problemas en catalogo de coordinaciones",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> Tallas(int tallaID, int sucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pTallaID", ConexionDbType.Int, tallaID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, sucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<TallasModel>("procTallasCon", parametros);

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
                    Message = "Problemas en catalogo de tallas",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> Tallas(TallasModel tallas)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursalID", ConexionDbType.Int, tallas.SucursalID);
                parametros.Add("@pTallaID", ConexionDbType.Int, tallas.TallaID);
                parametros.Add("@pTallaNumero", ConexionDbType.VarChar, tallas.TallaNumero);
                parametros.Add("@pTallaResponsable", ConexionDbType.Int, tallas.TallaResponsable);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procTallasGuardar", parametros);

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
                    Message = "Problemas al registrar la Talla",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> Temporalidades(int temporalidadID, int sucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pTemporalidadID", ConexionDbType.Int, temporalidadID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, sucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<TemporalidadesModel>("procTemporalidadesCon", parametros);

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
                    Message = "Problemas en catalogo de temporalidades",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> Temporalidades(TemporalidadesModel temporalidades)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursalID", ConexionDbType.Int, temporalidades.SucursalID);
                parametros.Add("@pTemporalidadID", ConexionDbType.Int, temporalidades.TemporalidadID);
                parametros.Add("@pTemporalidadNombre", ConexionDbType.VarChar, temporalidades.TempNombre);
                parametros.Add("@pTemporalidadResponsable", ConexionDbType.Int, temporalidades.TempResponsable);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procTemporalidadesGuardar", parametros);

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
                    Message = "Problemas al registrar la temporalidad",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> Terminados(int terminadoID, int sucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pTerminadoID", ConexionDbType.Int, terminadoID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, sucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<TerminadosModel>("procTerminadosCon", parametros);

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
                    Message = "Problemas en catalogo de terminados",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> Terminados(TerminadosModel terminados)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursalID", ConexionDbType.Int, terminados.SucursalID);
                parametros.Add("@pTerminadoID", ConexionDbType.Int, terminados.TerminadoID);
                parametros.Add("@pTerminadoNombre", ConexionDbType.VarChar, terminados.TerminadoNombre);
                parametros.Add("@pTerminadoResponsable", ConexionDbType.Int, terminados.TerminadoResponsable);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procTerminadosGuardar", parametros);

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
                    Message = "Problemas al registrar el terminado",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> Clientes(int clienteID, int sucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pClienteID", ConexionDbType.Int, clienteID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, sucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<ClientesModel>("procClientesCon", parametros);

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
                    Message = "Problemas en catalogo de clientes",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> Clientes(ClientesModel clientes)
        {
            var parametros = new ConexionParameters();
            var xml = clientes.ToXml("root");
            try
            {
                parametros.Add("@pDatosXML", ConexionDbType.Xml, xml);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procClientesGuardar", parametros);

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
                    Message = "Problemas al registrar el cliente",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> ConceptosCobros(int conceptoID, int sucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pConceptoID", ConexionDbType.Int, conceptoID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, sucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<ConcCobrosModel>("procConceptosCobroCon", parametros);

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
                    Message = "Problemas en catalogo de conceptos",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> ConceptosCobros(ConcCobrosModel conceptos)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursalID", ConexionDbType.Int, conceptos.SucursalID);
                parametros.Add("@pConceptoID", ConexionDbType.Int, conceptos.ConceptoID);
                parametros.Add("@pConceptoDesc", ConexionDbType.VarChar, conceptos.ConceptoDesc);
                parametros.Add("@pConceptoCosto", ConexionDbType.Decimal, conceptos.ConceptoCosto);
                parametros.Add("@pConceptoResponsable", ConexionDbType.Int, conceptos.ConceptoResponsable);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procConceptosCorbroGuardar", parametros);

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
                    Message = "Problemas al registrar el concepto de cobro",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }

        public Result<DataModel> Descuentos(int descuentoID, int sucursalID)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pDescuentoID", ConexionDbType.Int, descuentoID);
                parametros.Add("@pSucursalID", ConexionDbType.Int, sucursalID);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.ExecuteWithResults<DescuentosModel>("procDescuentosCon", parametros);

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
                    Message = "Problemas en catalogo de descuentos",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }
        public Result<DataModel> Descuentos(DescuentosModel descuentos)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pSucursalID", ConexionDbType.Int, descuentos.SucursalID);
                parametros.Add("@pDescuentoID", ConexionDbType.Int, descuentos.DescuentoID);
                parametros.Add("@pDescuentoPorcentaje", ConexionDbType.Int, descuentos.DescuentoPorcentaje);
                parametros.Add("@pDescuentoResponsable", ConexionDbType.Int, descuentos.DescuentoResponsable);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procDescuentosGuardar", parametros);

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
                    Message = "Problemas al registrar el descuento",
                    Data = new DataModel()
                    {
                        CodigoError = 101,
                        MensajeBitacora = ex.Message,
                        Data = ""
                    }
                };
            }
        }


        ////SCROLL INFINITO
        //public Result<DataModel> ProductosScrolling(int ProductoGrupoNumero)
        //{
        //    var parametros = new ConexionParameters();
        //    try
        //    {
        //        parametros.Add("@pGrupoNumero", ConexionDbType.Int, ProductoGrupoNumero);
        //        parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
        //        parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
        //        parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

        //        var r = _conexion.ExecuteWithResults<ProductosModel>("QW_procCantidadProductosCon", parametros);

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
        //            Message = "Problemas en catalogo de productos",
        //            Data = new DataModel()
        //            {
        //                CodigoError = 101,
        //                MensajeBitacora = ex.Message,
        //                Data = ""
        //            }
        //        };
        //    }
        //}

        //public Result<DataModel> ProductosCodigoBarras(int idProducto, string productoCodigoBarras)
        //{
        //    var parametros = new ConexionParameters();
        //    try
        //    {
        //        parametros.Add("@pIDProducto", ConexionDbType.Int, idProducto);
        //        parametros.Add("@pProductoCodigoBarras", ConexionDbType.VarChar, productoCodigoBarras);
        //        parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
        //        parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
        //        parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

        //        var r = _conexion.ExecuteWithResults<ProductosModel>("QW_procProductosCodigoBarrasCon", parametros);

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
        //            Message = "Problemas en catalogo de productos",
        //            Data = new DataModel()
        //            {
        //                CodigoError = 101,
        //                MensajeBitacora = ex.Message,
        //                Data = ""
        //            }
        //        };
        //    }
        //}
        //public Result<DataModel> ProductosCodigosdeBarraGuardar(ProductosModel productos)
        //{
        //    var parametros = new ConexionParameters();
        //    var xml = productos.ToXml("root");
        //    try
        //    {
        //        parametros.Add("@pDatosXML", ConexionDbType.Xml, xml);
        //        parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
        //        parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
        //        parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

        //        var r = _conexion.Execute("QW_procProductosCodigoBarrasGuardar", parametros);

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
        //            Message = "Problemas al guardar el codigo de barras",
        //            Data = new DataModel()
        //            {
        //                CodigoError = 101,
        //                MensajeBitacora = ex.Message,
        //                Data = ""
        //            }
        //        };
        //    }
        //}
        //public Result<DataModel> ProductosCodigosdeBarraBorrar(ProductosModel productos)
        //{
        //    var parametros = new ConexionParameters();
        //    var xml = productos.ToXml("root");
        //    try
        //    {
        //        parametros.Add("@pDatosXML", ConexionDbType.Xml, xml);
        //        parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
        //        parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
        //        parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

        //        var r = _conexion.Execute("QW_procProductosCodigoBarrasBorrar", parametros);

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
        //            Message = "Problemas al borrar el codigo de barras",
        //            Data = new DataModel()
        //            {
        //                CodigoError = 101,
        //                MensajeBitacora = ex.Message,
        //                Data = ""
        //            }
        //        };
        //    }
        //}

        //public Result<DataModel> EmpleadosGuardar(EmpleadosModel empleado)
        //{
        //    var parametros = new ConexionParameters();
        //    var xml = empleado.ToXml("root");
        //    try
        //    {
        //        parametros.Add("@pDatosXML", ConexionDbType.Xml, xml);
        //        parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
        //        parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
        //        parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

        //        var r = _conexion.Execute("QW_procEmpleadosGuardar", parametros);

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
        //            Message = "Problemas al guardar empleado de mostrador",
        //            Data = new DataModel()
        //            {
        //                CodigoError = 101,
        //                MensajeBitacora = ex.Message,
        //                Data = ""
        //            }
        //        };
        //    }
        //}


        //public Result<DataModel> ServiciosGuardar(ServiciosModel servicios)
        //{
        //    var parametros = new ConexionParameters();
        //    var xml = servicios.ToXml("root");
        //    try
        //    {
        //        parametros.Add("@pDatosXML", ConexionDbType.Xml, xml);
        //        parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
        //        parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
        //        parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

        //        var r = _conexion.Execute("procServiciosGuardar", parametros);

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
        //            Message = "Problemas al guardar el servicio",
        //            Data = new DataModel()
        //            {
        //                CodigoError = 101,
        //                MensajeBitacora = ex.Message,
        //                Data = ""
        //            }
        //        };
        //    }
        //}



    }
}