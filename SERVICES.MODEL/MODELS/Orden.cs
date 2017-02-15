using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace SERVICES.MODEL
{
    [DataContract]
    public class Orden
    {
        [DataMember]
        public long OrdenId { get; set; }
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public DateTime? FechaAlta { get; set; }
        [DataMember]
        public int Prioridad { get; set; }
        [DataMember]
        public string Motivo { get; set; }
        [DataMember]
        public DateTime? FechaAcordada { get; set; } 
    }
}
