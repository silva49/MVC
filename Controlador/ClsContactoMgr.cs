using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Modelo;
namespace Controlador
{
    public class ClsContactoMgr
    {
        ClsDatos cnGeneral = null;
        ClsContacto objContacto = null;
        DataTable tblDatos = null;

        public ClsContactoMgr (ClsContacto parObjContacto)
        {
            objContacto = parObjContacto;
        }

        public DataTable Listar()
        {
            tblDatos = new DataTable();

            try {
                cnGeneral = new ClsDatos();
                SqlParameter[] parParameter = new SqlParameter[1];
                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@opc";
                parParameter[0].SqlDbType = SqlDbType.Int;
                parParameter[0].SqlValue = objContacto.opc;

                tblDatos = cnGeneral.RetornaTabla(parParameter,"SPContacto");
            }
           catch  (Exception e) {
                throw new Exception(e.Message);
            }
            return tblDatos;
        }


        public void GuardarDatos ()
        {
            try {
                cnGeneral = new ClsDatos();
                SqlParameter[] parParameter = new SqlParameter[4];

                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@opc";
                parParameter[0].SqlDbType = SqlDbType.Int;
                parParameter[0].SqlValue = objContacto.opc;

                parParameter[1] = new SqlParameter();
                parParameter[1].ParameterName = "@Id";
                parParameter[1].SqlDbType = SqlDbType.Int;
                parParameter[1].SqlValue = objContacto.Id;


                parParameter[2] = new SqlParameter();
                parParameter[2].ParameterName = "@Nombre";
                parParameter[2].SqlDbType = SqlDbType.VarChar;
                parParameter[2].Size = 50;
                parParameter[2].SqlValue = objContacto.Nombre;

                parParameter[3] = new SqlParameter();
                parParameter[3].ParameterName = "@Telefono";
                parParameter[3].SqlDbType = SqlDbType.VarChar;
                parParameter[3].Size = 50;
                parParameter[3].SqlValue = objContacto.Telefono;

                cnGeneral.EjecutarSP(parParameter, "SPContacto");

            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }


       public void EliminarDatos()
        {
            try
            {
                cnGeneral = new ClsDatos();
                SqlParameter[] parParameter = new SqlParameter[2];

                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@opc";
                parParameter[0].SqlDbType = SqlDbType.Int;
                parParameter[0].SqlValue = objContacto.opc;

                parParameter[1] = new SqlParameter();
                parParameter[1].ParameterName = "@Id";
                parParameter[1].SqlDbType = SqlDbType.Int;
                parParameter[1].SqlValue = objContacto.Id;

                cnGeneral.EjecutarSP(parParameter, "SPContacto");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }

}
