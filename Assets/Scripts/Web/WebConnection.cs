using System;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Web
{
    public class WebConnection : MonoBehaviour
    {
        private const string _endpoint = "http://18.224.19.4:8080/api/";

        public void SentGet<T>(string request, Action<T> successAction, Action failAction)
        {
            StartCoroutine(SendGetRequest<T>(request, successAction, failAction));
        }
        
        public void SentGet(string request, Action<string> successAction, Action failAction)
        {
            StartCoroutine(SendGetRequest(request, successAction, failAction));
        }
        
        public void SendPost<T>(string request, DTO.DTO data, Action<T> successAction, Action failAction = null)
        {
            string body = JsonConvert.SerializeObject(data);
            StartCoroutine(SendPostRequest<T>(request, body, successAction, failAction));
        }

        public void SendPost(string request, DTO.DTO data, Action<string> successAction, Action failAction = null)
        {
            string body = JsonConvert.SerializeObject(data);
            StartCoroutine(SendPostRequest(request, body, successAction, failAction));
        }
        
        #region private
        private IEnumerator SendGetRequest<T>(string request, Action<string> successAction, Action failAction = null)
        {
            using (UnityWebRequest webRequest = new UnityWebRequest(_endpoint + request, "GET"))
            {
                // 요청 보내기
                yield return webRequest.SendWebRequest();

                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    failAction?.Invoke();
                    Debug.Log($"Error: {webRequest.error}");
                }
                else
                {
                    if (webRequest.downloadHandler.text.Contains("fail"))
                    {
                        failAction?.Invoke();
                    }
                    else
                    {
                        successAction?.Invoke(webRequest.downloadHandler.text);
                    }
                    Debug.Log("Response: " + webRequest.downloadHandler.text);
                }
            }
        }

        private IEnumerator SendGetRequest<T>(string request, Action<T> successAction, Action failAction = null)
        {
            using (UnityWebRequest webRequest = new UnityWebRequest(_endpoint + request, "GET"))
            {
                // 요청 보내기
                yield return webRequest.SendWebRequest();

                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    failAction?.Invoke();
                    Debug.Log($"Error: {webRequest.error}");
                }
                else
                {
                    if (webRequest.downloadHandler.text.Contains("fail"))
                    {
                        failAction?.Invoke();
                    }
                    else
                    {
                        try
                        {
                            T response = JsonConvert.DeserializeObject<T>(webRequest.downloadHandler.text);
                            successAction?.Invoke(response);
                        }
                        catch (JsonSerializationException ex)
                        {
                            Debug.Log("직렬화 과정에서 오류 발생");
                        }
                    }
                    Debug.Log("Response: " + webRequest.downloadHandler.text);
                }
            }
        }
        
        private IEnumerator SendPostRequest<T>(string request, string json, Action<T> successAction, Action failAction = null)
        {
            using (UnityWebRequest webRequest = new UnityWebRequest(_endpoint + request, "POST"))
            {
                byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
                webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
                webRequest.downloadHandler = new DownloadHandlerBuffer();
                webRequest.SetRequestHeader("Content-Type", "application/json");
                
                Debug.Log("data : " + json);
                Debug.Log("url : " + _endpoint + request);

                // 요청 보내기
                yield return webRequest.SendWebRequest();

                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    failAction?.Invoke();
                    Debug.Log($"Error: {webRequest.error}");
                }
                else
                {
                    if (webRequest.downloadHandler.text.Contains("fail"))
                    {
                        failAction?.Invoke();
                    }
                    else
                    {
                        try
                        {
                            T response = JsonConvert.DeserializeObject<T>(webRequest.downloadHandler.text);
                            successAction?.Invoke(response);
                        }
                        catch (JsonSerializationException ex)
                        {
                            Debug.Log("직렬화 과정에서 오류 발생");
                        }
                    }
                    Debug.Log("Response: " + webRequest.downloadHandler.text);
                }
            }
        }
        
        private IEnumerator SendPostRequest(string request, string json, Action<string> successAction, Action failAction = null)
        {
            using (UnityWebRequest webRequest = new UnityWebRequest(_endpoint + request, "POST"))
            {
                byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
                webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
                webRequest.downloadHandler = new DownloadHandlerBuffer();
                webRequest.SetRequestHeader("Content-Type", "application/json");

                Debug.Log("url : " + _endpoint + request);

                // 요청 보내기
                yield return webRequest.SendWebRequest();

                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    failAction?.Invoke();
                    Debug.Log($"Error: {webRequest.error}");
                }
                else
                {
                    if (webRequest.downloadHandler.text.Contains("fail"))
                    {
                        failAction?.Invoke();
                    }
                    else
                    {
                        successAction?.Invoke(webRequest.downloadHandler.text);
                    }
                    Debug.Log("Response: " + webRequest.downloadHandler.text);
                }
            }
        }
        
        #endregion
    }
}