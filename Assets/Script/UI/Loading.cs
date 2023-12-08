using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    private float timer;

    void Start()
    {
        StartCoroutine(LoadYourAsyncScene(GameManager.nextScenes));
    }

    IEnumerator LoadYourAsyncScene(string SceneName)
    {
        yield return new WaitForSeconds(1f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);

        GameManager.SetNowScene(SceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
