using System.Runtime.Serialization;
using Attribute.Common.Data;

namespace Attribute.Interop.Yggdrasil.Components
{
    /// <summary>
    ///     Class representation of an Yggdrasil authentication error.
    /// </summary>
    [DataContract]
    public struct Error
    {
        #region [-- PROPERTIES --]

        /// <summary>
        ///     Cause of the error. Optional.
        /// </summary>
        public string Cause
        {
            get { return this._cause; }
            set { this._cause = value; }
        }

        /// <summary>
        ///     A short description of the error.
        /// </summary>
        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        /// <summary>
        ///     Longer description which can be shown to the user
        /// </summary>
        public string ErrorMessage
        {
            get { return this._errorMessage; }
            set { this._errorMessage = value; }
        }

        #endregion


        #region [-- FIELDS --]

        [DataMember(Name = "cause", IsRequired = false)]
        private string _cause;
        [DataMember(Name = "error")]
        private string _description;
        [DataMember(Name = "errorMessage")]
        private string _errorMessage;

        #endregion


        public override string ToString()
        {
            return $"{this.Description}: {this.ErrorMessage} {(!string.IsNullOrWhiteSpace(this.Cause) ? $"({this.Cause})" : "")}";
        }
    }
}
