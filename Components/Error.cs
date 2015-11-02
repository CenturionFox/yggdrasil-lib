using System.Diagnostics;
using System.Runtime.Serialization;

namespace Attribute.Interop.Yggdrasil.Components
{
    /// <summary>
    ///     Class representation of an Yggdrasil authentication error.
    /// </summary>
    [DataContract, DebuggerDisplay("Error[{ToString()},HasCause:{HasCause}]")]
    public struct Error
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return
                $"{this.Description}: {this.ErrorMessage} {(this.HasCause ? $"({this.Cause})" : "")}";
        }

        #endregion


        #region [-- PROPERTIES --]

        /// <summary>
        ///     Gets or sets the cause of the error.
        /// </summary>
        /// <value>
        ///     The cause of the error. Optional.
        /// </value>
        public string Cause
        {
            get { return this._cause; }
            set { this._cause = value; }
        }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     A short description of the error.
        /// </value>
        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        /// <summary>
        ///     Gets or sets the error message.
        /// </summary>
        /// <value>
        ///     Verbose description that is shown to the user.
        /// </value>
        public string ErrorMessage
        {
            get { return this._errorMessage; }
            set { this._errorMessage = value; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether a cause was specified for this error.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the error has a specified cause; otherwise, <c>false</c>.
        /// </value>
        public bool HasCause => !string.IsNullOrWhiteSpace(this.Cause);

        #endregion


        #region [-- FIELDS --]

        [DataMember(Name = "cause", IsRequired = false)]
        private string _cause;
        [DataMember(Name = "error")]
        private string _description;
        [DataMember(Name = "errorMessage")]
        private string _errorMessage;

        #endregion
    }
}
