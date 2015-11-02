using System.Runtime.Serialization;
using Attribute.Common.Data;

namespace Attribute.Interop.Yggdrasil.ServerRequest
{
    [DataContract]
    public class YggdrasilResponse : JsonObject
    {
        #region [-- PROPERTIES --]

        /// <summary>
        ///     Hexadecimal access token.
        /// </summary>
        public string AccessToken
        {
            get { return this._accessToken; }
            set { this._accessToken = value; }
        }

        /// <summary>
        ///     Only present if the agent field was recieved.
        /// </summary>
        public Profile[] AvailableProfiles
        {
            get { return this._availableProfiles; }
            set { this._availableProfiles = value; }
        }

        /// <summary>
        ///     Identical to recieved client token.
        /// </summary>
        public string ClientToken
        {
            get { return this._clientToken; }
            set { this._clientToken = value; }
        }

        /// <summary>
        ///     Only present if the agent field was recieved.  The current user profile.
        /// </summary>
        public Profile SelectedProfile
        {
            get { return this._selectedProfile; }
            set { this._selectedProfile = value; }
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
