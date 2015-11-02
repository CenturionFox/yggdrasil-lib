using System.Diagnostics;
using System.Runtime.Serialization;

namespace Attribute.Interop.Yggdrasil.Components
{
    /// <summary>
    ///     The component of the Yggdrasil auth object representing the agent that constructed the request; i.e., the client.
    /// </summary>
    [DataContract, DebuggerDisplay("Agent[Name:{Name},Version:{Version}]")]
    public struct Agent
    {
        #region [-- PROPERTIES --]

        /// <summary>
        ///     Gets or sets the agent name.
        /// </summary>
        /// <value>
        ///     The agent name.
        /// </value>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        /// <summary>
        ///     Gets or sets the agent version.
        /// </summary>
        /// <value>
        ///     The agent version.
        /// </value>
        public double Version
        {
            get { return this._version; }
            set { this._version = value; }
        }

        #endregion


        #region [-- FIELDS --]

        [DataMember(Name = "name")]
        private string _name;
        [DataMember(Name = "version")]
        private double _version;

        #endregion
    }
}
