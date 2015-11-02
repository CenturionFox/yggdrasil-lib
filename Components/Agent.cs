using System.Runtime.Serialization;

namespace Attribute.Interop.Yggdrasil.Components
{
    [DataContract]
    public struct Agent
    {
        #region [-- PROPERTIES --]

        /// <summary>
        ///     Agent version.
        /// </summary>
        public double AgentVersion
        {
            get { return this._agentVersion; }
            set { this._agentVersion = value; }
        }

        /// <summary>
        ///     Agent name.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        #endregion


        #region [-- FIELDS --]

        [DataMember(Name = "version")]
        private double _agentVersion;
        [DataMember(Name = "name")]
        private string _name;

        #endregion
    }
}
