using System.Runtime.Serialization;

namespace JessieProvider.Models
{
    [DataContract()]
    public class MovieDataModel
    {
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string source { get; set; }
    }
}
