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
    public class Snippet
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public ScopeOption Scope { get; set; }

        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string Mime { get; set; }

        [DataMember]
        public string Tags { get; set; }



    }
}
