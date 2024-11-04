using System;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Web
{
    public class WebConnection : MonoBehaviour
    {
        private const string _endpoint = "http://localhost:8080/api/";
        
        public void SendPost(string request, DTO.DTO data, Action<string> successAction, Action failAction = null)
        {
            string body = JsonConvert.SerializeObject(data);
            StartCoroutine(SendRequest(request, body, successAction, failAction));
        }
        
        private IEnumerator SendRequest(string request, string json, Action<string> successAction, Action failAction = null)
        {
            using (UnityWebRequest webRequest = new UnityWebRequest(_endpoint + request, "POST"))
            {
                byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
                webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
                webRequest.downloadHandler = new DownloadHandlerBuffer();
                webRequest.SetRequestHeader("Content-Type", "application/json");

                // 요청 보내기
                yield return webRequest.SendWebRequest();

                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    failAction?.Invoke();
                    Debug.Log($"Error: {webRequest.error}");
                }
                else
                {
                    if (webRequest.downloadHandler.text.Contains("[Fail]"))
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
    }
}