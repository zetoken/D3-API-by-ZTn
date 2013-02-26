using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using ZTn.BNet.D3.Helpers;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Gems
{
    [DataContract]
    public class KnownGems
    {
        #region >> Fields

        [DataMember]
        public List<Item> gems;

        #endregion

        #region >> Constructors

        public KnownGems(List<Item> gems)
        {
            this.gems = gems;
        }

        #endregion

        public static KnownGems getKnownGemsFromJsonFile(String fileName)
        {
            List<Item> gems = JsonHelpers.getDataFromJsonFile<Item>(fileName);
            return new KnownGems(gems);
        }
    }
}
