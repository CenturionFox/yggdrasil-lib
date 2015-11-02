using System;
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
    public static class YggdrasilTransactionUtility
    {
        public const string YggdrasilExceptionDataKey = "YggdrasilErrorCode";

        #region [-- PUBLIC & PROTECTED METHODS --]

        public static YggdrasilResponse SendRequest(YggdrasilPayload payload, YggdrasilEndPoint endPoint)
        {
            var endpointName = Settings.Default[
                                                typeof(YggdrasilEndPoint).GetMemberAttribute
                                                    <DataValueAttribute>(endPoint.ToString()).DataValue];
            var request =
                WebRequest.CreateHttp(
                                      Settings.Default.YggdrasilAuthServer
                                      + endpointName);
            request.UserAgent = "Yggdrasil Authentication (Windows; U; Windows NT 5.1; en-US)";
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
                throw new Exception("Unable to open request stream.");
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
