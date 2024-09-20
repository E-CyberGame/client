using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fusion;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [ScenePath] private static string _gameScene;
    [SerializeField] Slider progressBar;
    
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void SetGameScene(string nextGameScene)
    {
        _gameScene = nextGameScene;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(_gameScene);
        op.allowSceneActivation = false;
        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime;
            if (op.progress < 0.8f)
            {
                progressBar.value = Mathf.Lerp(progressBar.value, op.progress, timer);
                if (progressBar.value >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.value = Mathf.Lerp(progressBar.value, 1f, timer);
                if (progressBar.value >= 0.95f)
                {
                    yield return new WaitForSeconds(2.0f);
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
