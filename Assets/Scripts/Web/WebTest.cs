using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
using Web.DTO;

public class WebTest : MonoBehaviour
{
    private const string _endpoint = "http://localhost:8080/api/members/register";
    
    public void Start()
    {
        DTO loginData = new LoginDTO("TestID", "TestPW");
        string requestJson = JsonConvert.SerializeObject(loginData); // JSON으로 직렬화

        StartCoroutine(SendRequest(requestJson));
    }

    IEnumerator SendRequest(string json)
    {
        using (UnityWebRequest webRequest = new UnityWebRequest(_endpoint, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            // 요청 보내기
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Error: {webRequest.error}");
            }
            else
            {
                Debug.Log("Response: " + webRequest.downloadHandler.text);
            }
        }
    }

}
