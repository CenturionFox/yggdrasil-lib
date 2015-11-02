using Attribute.Common.Attributes.Enumeration;

namespace Attribute.Interop.Yggdrasil.Enumeration
{
    /// <summary>
    /// Endpoint enums
    /// </summary>
    public enum YggdrasilEndPoint
    {
        [DisplayValue("Authenticate"), DataValue("AuthenticateEndpoint")]
        Authenticate,
        [DisplayValue("Refresh"), DataValue("RefreshEndpoint")]
        Refresh,
        [DisplayValue("Validate"), DataValue("ValidateEndpoint")]
        Validate,
        [DisplayValue("Signout"), DataValue("SignoutEndpoint")]
        Signout,
        [DisplayValue("Invalidate"), DataValue("InvalidateEndpoint")]
        Invalidate
    }
}
