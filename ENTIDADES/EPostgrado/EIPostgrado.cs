using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES.EPostgrado
{
    [DataContract]
    public class EIPostgrado
    {
        #region Variables
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string TipoPostgrado { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string RequisitosPostgrado { get; set; }
        #endregion
    }
}
