using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.BattleNet
{
    [DataContract]
    public class BattleTag
    {
        #region >> Properties

        /// <summary>
        /// Name part of battle tag (before #).
        /// </summary>
        [IgnoreDataMember]
        public String Name { get; private set; }

        /// <summary>
        /// Code part of battle tag (after #).
        /// </summary>
        [IgnoreDataMember]
        public String Code { get; private set; }

        /// <summary>
        /// Formatted battle tag (Name#eCode).
        /// </summary>
        [DataMember]
        public String Id
        {
            get { return Name + "#" + Code; }
            private set
            {
                var splitted = value.Split('#');
                if (splitted.Length == 2 && !String.IsNullOrWhiteSpace(splitted[0]) && !String.IsNullOrWhiteSpace(splitted[1]))
                {
                    Name = splitted[0];
                    Code = splitted[1];
                }
                else
                    throw new ArgumentException("Battle tag format error: " + value);
            }
        }

        #endregion

        #region >> Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public BattleTag()
        {
            Name = "Undefined";
            Code = "0000";
        }

        /// <summary>
        /// Creates a new <see cref="BattleTag"/> instance.
        /// </summary>
        /// <param name="battleTag">Battle tag (Name#Code).</param>
        public BattleTag(String battleTag)
        {
            Id = battleTag;
        }

        #endregion

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return Id;
        }

        #endregion
    }
}
