using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ZTn.BNet.D3
{
    [DataContract]
    public class FailureObject
    {
        #region >> Fields

        [DataMember]
        public String code;
        [DataMember]
        public String reason;

        #endregion

        public Boolean isFailureObject()
        {
            return (code != null || reason != null);
        }
    }
}
