using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDataManager : MonoBehaviour
{
    public static ShowDataManager Instance;
    [Header("Refferent")]
    public RectTransform contentLibrary;
    public RectTransform contentInProgress;
    public RectTransform contentComplete;
    public RectTransform contentCreate;
    public OpenGamePlayBtn OpenGamePlayBtnPrefabs;
    public GameObject main;
    public GameObject camTakePicture;
    private void Awake()
    {
        Instance = this;
    }
    public void SpawmLibrary_New(List<Sprite> sprites)
    {
        foreach (var sprite in sprites)
        {
            OpenGamePlayBtn openGamePlayBtn = Instantiate(OpenGamePlayBtnPrefabs, contentLibrary);
            openGamePlayBtn.spriteSource = sprite;
            openGamePlayBtn.imageStat = DataManager.Instance.dataInProgress.AddImageStat(sprite.name);
        }
    }
    public void SpawnDrawed(List<Sprite> sprites)
    {
        foreach (var sprite in sprites)
        {
            if (DataManager.Instance.dataInProgress.AddImageStat(sprite.name).Equals(ImageStat.INPROGRESS))
            {
                OpenGamePlayBtn openGamePlayBtn = Instantiate(OpenGamePlayBtnPrefabs, contentInProgress);
                openGamePlayBtn.spriteSource = sprite;
                openGamePlayBtn.imageStat = DataManager.Instance.dataInProgress.AddImageStat(sprite.name);
            }
            else if (DataManager.Instance.dataInProgress.AddImageStat(sprite.name).Equals(ImageStat.COMPLETE))
            {
                OpenGamePlayBtn openGamePlayBtn = Instantiate(OpenGamePlayBtnPrefabs, contentComplete);
                openGamePlayBtn.spriteSource = sprite;
                openGamePlayBtn.imageStat = DataManager.Instance.dataInProgress.AddImageStat(sprite.name);
            }

        }
    }
    public void SetActiveMain(bool active)
    {
        main.gameObject.SetActive(active);
    }
    public void SetActiveCam(bool active)
    {
        camTakePicture.gameObject.SetActive(active);
    }
}
