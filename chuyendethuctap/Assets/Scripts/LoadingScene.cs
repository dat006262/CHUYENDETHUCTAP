using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : SingletonMonoBehaviour<LoadingScene>
{
    public GameObject loadingSceneGameObject;
    public Image fill;
    public TextMeshProUGUI textLoading;
    public void Start()
    {

    }
    public void LoadScene(string name)
    {
        StartCoroutine(LoadSceneAsync(name));
    }
    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingSceneGameObject.SetActive(true);
        fill.fillAmount = 0.1f;
        while (!operation.isDone)
        {
            float x = Mathf.Clamp(operation.progress, 0, 1f);
            fill.fillAmount = x;
            yield return null;
        }
        loadingSceneGameObject.SetActive(false);

    }


}
