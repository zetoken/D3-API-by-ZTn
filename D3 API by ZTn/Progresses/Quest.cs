using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ZTn.BNet.D3.Progresses
{
    [DataContract]
    public class Quest
    {
        #region >> Fields

        [DataMember]
        public String slug;
        [DataMember]
        public String name;

        #endregion
    }
}
