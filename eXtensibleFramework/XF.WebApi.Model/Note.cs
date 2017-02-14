using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XF.WebApi.Core
{
    [DataContract(Namespace = "")]
    [Serializable]
    public class Note
    {
        [DataMember]
        public Guid NoteId { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string Text { get; set; }

        public Note()
        {

        }
    }
}
