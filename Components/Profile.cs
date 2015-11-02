using System.Runtime.Serialization;

namespace Attribute.Interop.Yggdrasil.Components
{
    [DataContract]
    public struct Profile
    {
        #region [-- PROPERTIES --]

        /// <summary>
        ///     Hexadecimal profile identifier.
        /// </summary>
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        /// <summary>
        ///     Whether or not the account is a legacy (non-migrated) account.
        /// </summary>
        public bool IsLegacy
        {
            get { return this._isLegacy; }
            set { this._isLegacy = value; }
        }

        /// <summary>
        ///     The player name.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        #endregion


        #region [-- FIELDS --]

        [DataMember(Name = "id")]
        private string _id;
        [DataMember(Name = "legacy")]
        private bool _isLegacy;
        [DataMember(Name = "name")]
        private string _name;

        #endregion
    }
}
