using System.Runtime.Serialization;
using Attribute.Common.Data;
using Attribute.Interop.Yggdrasil.Components;

namespace Attribute.Interop.Yggdrasil
{
    /// <summary>
    ///     Authenticates a user using their password.
    /// </summary>
    [DataContract]
    public class YggdrasilPayload
    {
        #region [-- PROPERTIES --]

        /// <summary>
        ///     The client agent.
        /// </summary>
        public Agent Agent
        {
            get { return this._agent; }
            set { this._agent = value; }
        }

        /// <summary>
        ///     Optional client token.
        /// </summary>
        public string ClientToken
        {
            get { return this._clientToken; }
            set { this._clientToken = value; }
        }

        /// <summary>
        ///     Mojang account password.
        /// </summary>
        public string Password
        {
            get { return this._password; }
            set { this._password = value; }
        }

        /// <summary>
        ///     Email or player name.
        /// </summary>
        public string Username
        {
            get { return this._username; }
            set { this._username = value; }
        }

        #endregion


        #region [-- FIELDS --]

        [DataMember(Name = "agent")]
        private Agent _agent;
        [DataMember(Name = "clientToken")]
        private string _clientToken;
        [DataMember(Name = "password")]
        private string _password;
        [DataMember(Name = "username")]
        private string _username;

        #endregion
    }
}
