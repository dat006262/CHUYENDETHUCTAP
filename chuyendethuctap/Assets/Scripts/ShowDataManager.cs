using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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

    Dictionary<string, OpenGamePlayBtn> SpriteName_BtnDrawed = new Dictionary<string, OpenGamePlayBtn>();
    Dictionary<string, OpenGamePlayBtn> SpriteName_Btnlibrary = new Dictionary<string, OpenGamePlayBtn>();
    Dictionary<string, OpenGamePlayBtn> SpriteName_BtnCreate = new Dictionary<string, OpenGamePlayBtn>();
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

            OpenGamePlayBtn openGamePlayBtn = Instantiate(OpenGamePlayBtnPrefabs, libraryScroll.Content.transform);
            openGamePlayBtn.spriteSource = sprite;
            openGamePlayBtn.imageStat = DataManager.Instance.dataInProgress.AddImageStat(sprite.name);
            openGamePlayBtn.size = Mathf.Clamp(Mathf.Min(sprite.texture.width, sprite.texture.height), 10, 100);

            openGamePlayBtn.LoadImageRenderer();
            SpriteName_Btnlibrary.Add(sprite.name, openGamePlayBtn);
            i++;
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
                openGamePlayBtn.size = Mathf.Clamp(Mathf.Min(sprite.texture.width, sprite.texture.height), 10, 100);

                openGamePlayBtn.LoadImageRenderer();
                SpriteName_BtnDrawed.Add(sprite.name, openGamePlayBtn);
            }
            else if (DataManager.Instance.dataInProgress.AddImageStat(sprite.name).Equals(ImageStat.COMPLETE))
            {
                OpenGamePlayBtn openGamePlayBtn = Instantiate(OpenGamePlayBtnPrefabs, contentComplete);
                openGamePlayBtn.spriteSource = sprite;
                openGamePlayBtn.imageStat = DataManager.Instance.dataInProgress.AddImageStat(sprite.name);
                openGamePlayBtn.size = Mathf.Clamp(Mathf.Min(sprite.texture.width, sprite.texture.height), 10, 100);

                openGamePlayBtn.LoadImageRenderer();
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
            openGamePlayBtn.size = Mathf.Clamp(Mathf.Min(sprite.texture.width, sprite.texture.height), 10, 100);

            openGamePlayBtn.LoadImageRenderer();
            SpriteName_BtnCreate.Add(sprite.name, openGamePlayBtn);

        }
    }
    public void SpawnOneBtnCreated(Sprite sprite)
    {
        OpenGamePlayBtn openGamePlayBtn = Instantiate(OpenGamePlayBtnPrefabs, contentCreate);
        openGamePlayBtn.spriteSource = sprite;
        openGamePlayBtn.imageStat = DataManager.Instance.dataInProgress.AddImageStat(sprite.name);
        openGamePlayBtn.size = Mathf.Clamp(Mathf.Min(sprite.texture.width, sprite.texture.height), 10, 100);

        openGamePlayBtn.LoadImageRenderer();
        SpriteName_BtnCreate.Add(sprite.name, openGamePlayBtn);
    }
    public void UpdateLibrary()
    {

        if (SpriteName_Btnlibrary.ContainsKey(GameConfig.Instance.spriteInGame.name))
        {
            OpenGamePlayBtn update = SpriteName_Btnlibrary[GameConfig.Instance.spriteInGame.name];

            update.UpdateImageRender();
        }

    }
    public void UpdateCreate()
    {

        if (SpriteName_BtnCreate.ContainsKey(GameConfig.Instance.spriteInGame.name))
        {
            OpenGamePlayBtn update = SpriteName_BtnCreate[GameConfig.Instance.spriteInGame.name];

            update.UpdateImageRender();
        }

    }
    public void UpdateDrawed()
    {
        if (DataManager.Instance.dataInProgress.AddImageStat(GameConfig.Instance.spriteInGame.name) == ImageStat.INPROGRESS)
        {
            if (SpriteName_BtnDrawed.ContainsKey(GameConfig.Instance.spriteInGame.name))
            {
                OpenGamePlayBtn update = SpriteName_BtnDrawed[GameConfig.Instance.spriteInGame.name];

                update.UpdateImageRender();
            }
            else
            {
                OpenGamePlayBtn openGamePlayBtn = Instantiate(OpenGamePlayBtnPrefabs, contentInProgress);
                openGamePlayBtn.spriteSource = GameConfig.Instance.spriteInGame;
                openGamePlayBtn.imageStat = DataManager.Instance.dataInProgress.AddImageStat(GameConfig.Instance.spriteInGame.name);
                SpriteName_BtnDrawed.Add(GameConfig.Instance.spriteInGame.name, openGamePlayBtn);
                openGamePlayBtn.imageStat = DataManager.Instance.dataInProgress.AddImageStat(GameConfig.Instance.spriteInGame.name);
                openGamePlayBtn.size = Mathf.Clamp(Mathf.Min(GameConfig.Instance.spriteInGame.texture.width, GameConfig.Instance.spriteInGame.texture.height), 10, 100);

                openGamePlayBtn.LoadImageRenderer();
            }
        }
        else if (DataManager.Instance.dataInProgress.AddImageStat(GameConfig.Instance.spriteInGame.name) == ImageStat.COMPLETE)
        {
            OpenGamePlayBtn openGamePlayBtn = Instantiate(OpenGamePlayBtnPrefabs, contentComplete);
            openGamePlayBtn.spriteSource = GameConfig.Instance.spriteInGame;
            openGamePlayBtn.imageStat = DataManager.Instance.dataInProgress.AddImageStat(GameConfig.Instance.spriteInGame.name);
            openGamePlayBtn.UpdateImageRender();
            if (SpriteName_BtnDrawed.ContainsKey(GameConfig.Instance.spriteInGame.name))//HaveDrawed
            {
                OpenGamePlayBtn update = SpriteName_BtnDrawed[GameConfig.Instance.spriteInGame.name];
                SpriteName_BtnDrawed.Remove(GameConfig.Instance.spriteInGame.name);
                Destroy(update.gameObject);
            }
            else
            {

            }
        }
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
