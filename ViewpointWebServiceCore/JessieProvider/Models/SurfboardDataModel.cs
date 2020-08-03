using System.Runtime.Serialization;

namespace JessieProvider.Models
{
    [DataContract()]
    public class SurfboardDataModel
    {
        [DataMember]
        public string manufacturer { get; set; }
        [DataMember]
        public string model { get; set; }
        [DataMember]
        public double height{ get; set; }
        [DataMember]
        public double width { get; set; }
        [DataMember]
        public double volume { get; set; }
    }
}
