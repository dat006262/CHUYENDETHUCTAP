using Firebase.Extensions;
using Firebase.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;
public class DataManager : MonoBehaviour
{

    public static DataManager Instance;
    public Firebase.FirebaseApp app = null;
    FirebaseStorage storage;
    public List<Sprite> allsprites = new List<Sprite>();
    public DataInProgress dataInProgress = new DataInProgress();
    public List<Sprite> folderNew = new List<Sprite>();
    public List<Sprite> folderCreate = new List<Sprite>();


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        app = Firebase.FirebaseApp.DefaultInstance;
        storage = FirebaseStorage.DefaultInstance;
        dataInProgress.Load();

    }
    private void Start()
    {
        StartCoroutine(
         LoadAllSprite(() =>
        {
            ShowDataManager.Instance.SpawmLibrary_New(allsprites);
            ShowDataManager.Instance.SpawnDrawed(allsprites);
            ShowDataManager.Instance.SpawnDrawed(folderCreate);
            ShowDataManager.Instance.SpawnCreated(folderCreate);
        })
        );

    }
    IEnumerable test()
    {
        yield return new WaitForSeconds(2f);

    }
    IEnumerator LoadAllSprite(Action completeLoad = null)
    {
        bool isLoadComplete = false;
        GetSpritesFromResource();
        GetAllSpriteCreated();
        GetSpriteFromStorage(() => { isLoadComplete = true; Debug.Log("LoadComplete"); });
        yield return new WaitUntil(() => isLoadComplete);
        completeLoad?.Invoke();
    }
    public void GetSpritesFromResource()
    {
        allsprites = Resources.LoadAll<Sprite>("New").ToList();


    }
    public void GetSpriteFromStorage(Action isComplete = null)
    {
        StorageReference storageReference = storage.GetReferenceFromUrl("gs://test19-1.appspot.com/18-1.png");
        GetASpriteFromStorage(storageReference, isComplete);
    }
    public void GetASpriteFromStorage(StorageReference reference, Action isComplete = null)
    {
        const long maxAllowedSize = 1 * 1024 * 1024;
        reference.GetBytesAsync(maxAllowedSize).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogException(task.Exception);
            }
            else
            {
                byte[] fileContents = task.Result;
                Texture2D imageTexture = new Texture2D(2, 2);
                imageTexture.filterMode = FilterMode.Point;
                imageTexture.LoadImage(fileContents);
                imageTexture.Apply();
                Color[] test = imageTexture.GetPixels();
                Sprite sprite = Sprite.Create(imageTexture, new Rect(0, 0, imageTexture.width, imageTexture.height), new Vector2(0.5f, 0.5f));
                sprite.name = "123";
                allsprites.Add(sprite);
                Debug.Log("Finished downloading!");
                isComplete?.Invoke();
            }
        });
    }
    public void GetAllSpriteCreated()
    {
        for (int i = 0; i < dataInProgress.WebCamPictureCount; i++)
        {
            Sprite create = GetCameraImage.intances.ReadFileToSprite("Create" + $"{i}", "/CamPicture");
            if (create != null)
            {
                Debug.Log("Add");
                folderCreate.Add(create);
            }

        }

    }


}
