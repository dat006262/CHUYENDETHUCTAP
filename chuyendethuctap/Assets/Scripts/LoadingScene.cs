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
    public bool isSoundOn = true;
    public Button soundBtn;
    public TextMeshProUGUI soundText;
    public void Start()
    {
        isSoundOn = true;
        soundBtn.onClick.AddListener(() =>
        {
            isSoundOn = !isSoundOn;
            if (isSoundOn)
            {
                SoundManager.Instance.PlayGameMusic();
                soundText.text = "Music:ON";
            }
            else
            {
                SoundManager.Instance.StopGameMusic();
                soundText.text = "Music:OFF";
            }
        });
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
    public IEnumerator LoadSceneAsync2()
    {

        int percent = 0;
        int ran = UnityEngine.Random.Range(75, 90);
        while (percent < 150)
        {
            percent++;
            fill.fillAmount = (float)percent / 100;

            if (percent == ran)
            {

                yield return new WaitForSecondsRealtime(0.5f);
            }
            yield return new WaitForSeconds(0.01f);
        }
        loadingSceneGameObject.SetActive(false);

    }


}
