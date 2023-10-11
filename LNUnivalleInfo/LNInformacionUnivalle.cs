using ENTIDADES.EPostgrado;
using HERRAMIENTAS;
using SWDAUnivalleInfo.SWDAIPostgrado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNUnivalleInfo
{
    public class LNInformacionUnivalle
    {
        #region Atributos
        public SWDAIPostgrado SWDAIPostgrado;
        #endregion

        #region Constructor
        public LNInformacionUnivalle() 
        {
            SWDAIPostgrado = new SWDAIPostgrado();
        }
        #endregion

        #region Metodos Publicos
        public EResponse<int> Adicionar_Postgrado_EIPostgrado(EIPostgrado eIPostgrado)
        {           
            EResponse<int> response = SWDAIPostgrado.Adicionar_Postgrado_EIPostgrado(eIPostgrado);
            return response;           
        }

        public EResponse<List<EIPostgrado>> Obtener_Postgrados()
        {
            EResponse<List<EIPostgrado>> response = SWDAIPostgrado.Obtener_Postgrados();
            return response;
        }
        public EResponse<bool> Actualizar_Postgrado_EIPostgrado(EIPostgrado eIPostgrado)
        {
            EResponse<bool> response = SWDAIPostgrado.Actualizar_Postgrado_EIPostgrado(eIPostgrado);
            return response;
        }
        public EResponse<bool> Eliminar_Postgrado_PostgradoId(int postgradoId)
        {
            EResponse<bool> response = SWDAIPostgrado.Eliminar_Postgrado_PostgradoId(postgradoId);

            if (!response.Exitoso)
            {
                response.Mensaje = "Error al Eliminar el Postgrado";
            }

            return response;
        }
        #endregion
    }
}
