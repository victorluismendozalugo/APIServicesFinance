using apiServices.Models;
using apiServices.Models.Creditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarmPack.Classes;
using WarmPack.Database;

namespace apiServices.DA
{
    public class DACreditos
    {

        private readonly Conexion _conexion = null;
        public DACreditos()
        {
            _conexion = new Conexion(ConexionType.MSSQLServer, Globales.ConexionPrincipal);
        }
        public Result<DataModel> GuardarAbono(CreditosModel abono)
        {
            var parametros = new ConexionParameters();
            try
            {
                parametros.Add("@pCliente", ConexionDbType.Int, abono.Cliente);
                parametros.Add("@pMontoAbonado", ConexionDbType.VarChar, abono.MontoAbonado);                                                                                                                                                                                                                       .Usuario);
                parametros.Add("@pFechaAbono", ConexionDbType.Int, abono.FechaAbono);

                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, 300, System.Data.ParameterDirection.Output, 300);
                parametros.Add("@pCodError", ConexionDbType.Int, System.Data.ParameterDirection.Output);

                var r = _conexion.Execute("procClientesAbonoGuardar", parametros);

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
                    Message = "Problemas al registrar el saldo del cliente",
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
