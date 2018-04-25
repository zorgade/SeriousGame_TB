using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System;

public enum httpVerb
{
    GET,
    POST,
    PUT,
    DELETE
}
class FirebaseRestClient {

    public string endPoint { get; set; }
    public httpVerb httpMethod { get; set; }




    public FirebaseRestClient()
    {
        endPoint = string.Empty;
        httpMethod = httpVerb.GET;
    }
    
    public string makeRequest() { 

        string strResponseValue = string.Empty;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

        request.Method = httpMethod.ToString();
        HttpWebResponse response = null;
         ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
        try
        {
            response = (HttpWebResponse)request.GetResponse();

            //Process the respons stream ...(JSON, XML, HTML,etc)
            using (Stream responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        strResponseValue = reader.ReadToEnd();
                    }//End of StreamReader
                }
            }//End of using ResponseStream

        } catch (Exception ex)
        {
            strResponseValue = "{\"error\":[\"" + ex.Message.ToString() + "\"]";
        }
        finally
        {
            if (response != null)
            {
                ((IDisposable)response).Dispose();
            }
        }
        return strResponseValue;
    }
    public bool MyRemoteCertificateValidationCallback(System.Object sender,
    X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        bool isOk = true;
        // If there are errors in the certificate chain,
        // look at each error to determine the cause.
        if (sslPolicyErrors != SslPolicyErrors.None)
        {
            for (int i = 0; i < chain.ChainStatus.Length; i++)
            {
                if (chain.ChainStatus[i].Status == X509ChainStatusFlags.RevocationStatusUnknown)
                {
                    continue;
                }
                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                bool chainIsValid = chain.Build((X509Certificate2)certificate);
                if (!chainIsValid)
                {
                    isOk = false;
                    break;
                }
            }
        }
        return isOk;
    }
}
    


