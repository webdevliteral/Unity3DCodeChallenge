using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public void LoadLevel(int sceneIndex)
    {
        //add int sceneIndex parameter to loadlevel if you want to load specific levels
        //StartCoroutine(LoadAsynchronously(sceneIndex));
        StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex + 1));
        
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
