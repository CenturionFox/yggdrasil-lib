using System.Runtime.Serialization;
using Attribute.Common.Data;
using Attribute.Interop.Yggdrasil.Components;

namespace Attribute.Interop.Yggdrasil
{
    /// <summary>
    /// Models a response from the Yggdrasil authentication server.
    /// </summary>
    [DataContract]
    public class YggdrasilResponse
    {
        #region [-- PROPERTIES --]

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>
        /// The hexadecimal access token.
        /// </value>
        public string AccessToken
        {
            get { return this._accessToken; }
            internal set { this._accessToken = value; }
        }


        /// <summary>
        /// Gets the available profiles.
        /// </summary>
        /// <value>
        /// The available profiles.  Only present if the access token was recieved.
        /// </value>
        public Profile[] AvailableProfiles
        {
            get { return this._availableProfiles; }
            internal set { this._availableProfiles = value; }
        }

        /// <summary>
        ///     Identical to recieved client token.
        /// </summary>
        public string ClientToken
        {
            get { return this._clientToken; }
            internal set { this._clientToken = value; }
        }

        /// <summary>
        ///     Only present if the agent field was recieved.  The current user profile.
        /// </summary>
        public Profile SelectedProfile
        {
            get { return this._selectedProfile; }
            internal set { this._selectedProfile = value; }
        }

        #endregion


        #region [-- FIELDS --]

        [DataMember(Name = "accessToken", IsRequired = true)]
        private string _accessToken;
        [DataMember(Name = "availableProfiles", IsRequired = false)]
        private Profile[] _availableProfiles;
        [DataMember(Name = "clientToken", IsRequired = true)]
        private string _clientToken;
        [DataMember(Name = "selectedProfile", IsRequired = false)]
        private Profile _selectedProfile;

        #endregion
    }
}
