using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.BattleNet
{
    [DataContract]
    public class BattleTag
    {
        #region >> Properties

        [IgnoreDataMember]
        public String name;
        [IgnoreDataMember]
        public String code;
        [DataMember]
        public String id
        {
            get { return name + "#" + code; }
            set
            {
                String[] splitted = value.Split('#');
                if (splitted.Length == 2)
                {
                    name = splitted[0];
                    code = splitted[1];
                }
                else
                    throw new Exception("Battle tag bad format: " + id);
            }
        }

        #endregion

        #region >> Constructors

        public BattleTag(String battleTag)
        {
            this.id = battleTag;
        }

        #endregion

        public override string ToString()
        {
            return id;
        }
    }
}
