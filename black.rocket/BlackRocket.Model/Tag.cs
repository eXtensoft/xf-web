using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlackRocket
{
    [DataContract]
    [Serializable]
    public class Tag
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public object Value { get; set; }
    }
}
