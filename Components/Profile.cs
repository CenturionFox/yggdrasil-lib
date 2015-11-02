using System.Diagnostics;
using System.Runtime.Serialization;

namespace Attribute.Interop.Yggdrasil.Components
{
    /// <summary>
    ///     An yggdrasil auth component representing a requested profile.
    /// </summary>
    [DataContract, DebuggerDisplay("Profile[Name:{Name},IsLegacy:{IsLegacy}]")]
    public struct Profile
    {
        #region [-- PROPERTIES --]

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The hexadecimal identifier for the user profile.
        /// </value>
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the requested account is a legacy (non-migrated) account.
        /// </summary>
        /// <value>
        ///     Whether or not the account is a legacy (non-migrated) account.
        /// </value>
        public bool IsLegacy
        {
            get { return this._isLegacy; }
            set { this._isLegacy = value; }
        }

        /// <summary>
        ///     Gets or sets the profile's player name.
        /// </summary>
        /// <value>
        ///     The player name of the profile.
        /// </value>
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
