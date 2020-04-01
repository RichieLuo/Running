using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Result<T>
{
    public bool comlpete;
    public bool succ;
    public T value;
}
public class HttpServer
{
    Result<string> result = new Result<string>();
    public bool isComplete => result.comlpete;
    public bool isSucc => result.succ;
    public string value => isSucc && isComplete ? result.value : "";
    public  IEnumerator SendPost(string url, Dictionary<string, string> formFields)
    {
        result.comlpete = false;
        if (string.IsNullOrEmpty(url))
        {
            result.comlpete = true;
            result.succ = false;
            yield break;

        }
        using (UnityWebRequest request = UnityWebRequest.Post(url, formFields))
        {
            yield return request.SendWebRequest();
            result.comlpete = true;
            if (request.isHttpError || request.isNetworkError)
            {
                result.succ = false;
            }
            else
            {
                result.value = request.downloadHandler.text;
                result.succ = true;
            }
        }

           
        

    }
    public IEnumerator SendGet(string url)
      {
        result.comlpete = false;
        if (string.IsNullOrEmpty(url))
        {
            result.comlpete = true;
            result.succ = false;
            yield break;

        }
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.isHttpError || request.isNetworkError)
            {
                result.succ = false;
            }
            else
            {
                result.value = request.downloadHandler.text;
                result.succ = true;
            }
        }

    }
}
