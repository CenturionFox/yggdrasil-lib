using Attribute.Common.Attributes.Enumeration;

namespace Attribute.Interop.Yggdrasil.Enumeration
{
    /// <summary>
    ///     Endpoints available to the Yggdrasil client.
    /// </summary>
    public enum YggdrasilEndPoint
    {
        /// <summary>
        ///     Authenticates a user using their password.  Maps to <c>https://authserver.mojang.com/authenticate</c>.
        /// </summary>
        [DisplayValue("Authenticate"), DataValue("AuthenticateEndpoint")]
        Authenticate,

        /// <summary>
        ///     Refreshes a valid access token.  This endpoint can be used to keep a user logged in over seperate sessions, and
        ///     should be used rather than manually storing the user's passcode.  Maps to
        ///     <c>https://authserver.mojang.com/refresh</c>.
        /// </summary>
        [DisplayValue("Refresh"), DataValue("RefreshEndpoint")]
        Refresh,

        /// <summary>
        ///     Checks the validity of an access token for use with a game server.  This endpoint can be called at startup to
        ///     determine whether or not a saved token is still usable.  You can create a call to the <see cref="Refresh" />
        ///     endpoint if an error is returned.  You may call this endpoint without specifying a client token, but if you do, it
        ///     should match the one used to obtain the access token in the first place.  Maps to
        ///     <c>https://authserver.mojang.com/validate</c>.
        /// </summary>
        [DisplayValue("Validate"), DataValue("ValidateEndpoint")]
        Validate,

        /// <summary>
        ///     Used to invalidate access tokens, using the account username and password.  Maps to
        ///     <c>https://authserver.mojang.com/signout</c>.
        /// </summary>
        [DisplayValue("Signout"), DataValue("SignoutEndpoint")]
        Signout,

        /// <summary>
        ///     Invalidates tokens with a client and access token pair.  Maps to <c>https://authserver.mojang.com/invalidate</c>.
        /// </summary>
        [DisplayValue("Invalidate"), DataValue("InvalidateEndpoint")]
        Invalidate
    }
}
