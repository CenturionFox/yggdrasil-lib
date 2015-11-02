using System;
using System.Globalization;
using System.IO;
using System.Net;
using Attribute.Common.Attributes.Enumeration;
using Attribute.Common.Data;
using Attribute.Common.Extensions;
using Attribute.Interop.Yggdrasil.Components;
using Attribute.Interop.Yggdrasil.Enumeration;
using Attribute.Interop.Yggdrasil.Properties;

namespace Attribute.Interop.Yggdrasil
{
    /// <summary>
    /// Utility used to send <see cref="YggdrasilPayload"/> request objects and process the incoming <see cref="YggdrasilResponse"/>.
    /// </summary>
    public static class YggdrasilTransactionUtility
    {
        /// <summary>
        /// The Yggdrasil exception data key used in any thrown WebException objects.
        /// </summary>
        public const string YggdrasilExceptionDataKey = "YggdrasilErrorCode";

        #region [-- PUBLIC & PROTECTED METHODS --]

        /// <summary>
        /// Sends the <see cref="YggdrasilPayload"/> request object to the specified <paramref name="endpoint"/> on the authentication server.
        /// </summary>
        /// <param name="payload">The payload to send to the server.</param>
        /// <param name="endpoint">The endpoint on the server to send the payload to.</param>
        /// <returns>An <see cref="YggdrasilResponse"/> object containing the user's profile data, if login was successful.</returns>
        /// <exception cref="IOException">Thrown when the request stream fails to open.</exception>
        /// <exception cref="WebException">Thrown if the Yggdrasil server returns an error object.</exception>
        public static YggdrasilResponse SendRequest(YggdrasilPayload payload, YggdrasilEndPoint endpoint)
        {
            var endpointName = Settings.Default[
                                                typeof(YggdrasilEndPoint).GetMemberAttribute
                                                    <DataValueAttribute>(endpoint.ToString()).DataValue];
            var request =
                WebRequest.CreateHttp(
                                      Settings.Default.YggdrasilAuthServer
                                      + endpointName);
            request.UserAgent = $"Attribute Yggdrasil Authentication ({Environment.OSVersion.Platform}; U; {Environment.OSVersion}; {CultureInfo.CurrentCulture.Name})";
            request.Method = Settings.Default.YggdrasilRequestMethod;
            request.ContentType = Settings.Default.YggdrasilRequestContentType;
            request.Credentials = null;

            var dataRequestStream = request.GetRequestStream();

            if (dataRequestStream != Stream.Null)
            {
                JsonUtility.SerializeObject(payload, ref dataRequestStream);
                dataRequestStream.Close();
            }
            else
            {
                throw new IOException("Unable to open request stream.");
            }

            Stream responseStream = null;

            try
            {
                var response = request.GetResponse() as HttpWebResponse;

                if (response != null)
                {
                    responseStream = response.GetResponseStream();

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var wex = new WebException("Yggdrasil login failed.", null, WebExceptionStatus.ServerProtocolViolation, response);

                        throw wex;
                    }
                }
            }
            catch (WebException wex)
            {
                if (wex.Response != null && wex.Response.ContentType == Settings.Default.YggdrasilRequestContentType)
                {
                    var error = JsonUtility.DeserializeObject<Error>(wex.Response.GetResponseStream());
                    wex.Data[YggdrasilExceptionDataKey] = error.ToString();
                }
                throw;
            }

            return responseStream == null ? null : JsonUtility.DeserializeObject<YggdrasilResponse>(responseStream);
        }

        #endregion
    }
}
