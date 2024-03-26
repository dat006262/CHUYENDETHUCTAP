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
    public LibraryScroll libraryScrollPrefabs;
    private void Awake()
    {
        Instance = this;
    }
    public void SpawmLibrary_New(List<Sprite> sprites)
    {
        int i = 0;
        foreach (var sprite in sprites)
        {
            LibraryScroll libraryScroll;
            if (i % 6 == 0)
            {
                libraryScroll = Instantiate(libraryScrollPrefabs, contentLibrary);
            }
            else
            {
                libraryScroll = contentLibrary.GetChild(i / 6 + 1).GetComponent<LibraryScroll>();
                if (libraryScroll is null)
                {
                    Debug.LogError("libraryScroll is null");
                }
            };
            i++;
            OpenGamePlayBtn openGamePlayBtn = Instantiate(OpenGamePlayBtnPrefabs, libraryScroll.Content.transform);
            openGamePlayBtn.spriteSource = sprite;
            openGamePlayBtn.imageStat = DataManager.Instance.dataInProgress.AddImageStat(sprite.name);
            if (i == 10) break;
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
    public void SpawnCreated(List<Sprite> sprites)
    {
        foreach (var sprite in sprites)
        {

            OpenGamePlayBtn openGamePlayBtn = Instantiate(OpenGamePlayBtnPrefabs, contentCreate);
            openGamePlayBtn.spriteSource = sprite;
            openGamePlayBtn.imageStat = DataManager.Instance.dataInProgress.AddImageStat(sprite.name);
            openGamePlayBtn.size = Mathf.Min(sprite.texture.width, sprite.texture.height);
        }
    }
    public void SpawnOneBtnCreated(Sprite sprite)
    {
        OpenGamePlayBtn openGamePlayBtn = Instantiate(OpenGamePlayBtnPrefabs, contentCreate);
        openGamePlayBtn.spriteSource = sprite;
        openGamePlayBtn.imageStat = DataManager.Instance.dataInProgress.AddImageStat(sprite.name);
    }
    //=======================UI==============================================================================================================
    public void SetActiveMain(bool active)
    {
        main.gameObject.SetActive(active);
    }
    public void SetActiveCam(bool active)
    {
        camTakePicture.gameObject.SetActive(active);
    }
}
