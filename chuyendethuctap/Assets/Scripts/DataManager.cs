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
    public List<Sprite> folderCreate = new List<Sprite>();
    public DataInProgress dataInProgress = new DataInProgress();




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
        StartCoroutine(GetSpriteFromStorage(() => { isLoadComplete = true; }));

        yield return new WaitUntil(() => isLoadComplete);
        completeLoad?.Invoke();
    }
    public void GetSpritesFromResource()
    {
        allsprites = Resources.LoadAll<Sprite>("New").ToList();


    }
    IEnumerator GetSpriteFromStorage(Action isComplete = null)
    {
        bool isFallOrEmptFile = false;
        int countFuncRun = 0;
        int countFuncComplete = 0;
        for (int i = 0; i < 10; i++)
        {

            string path = $"gs://test19-1.appspot.com/18 ({i}).png";
            StorageReference storageReference = storage.GetReferenceFromUrl(path);
            countFuncRun++;
            GetASpriteFromStorage(storageReference, $"18 ({i})", () => { countFuncComplete++; }, () => { isFallOrEmptFile = true; countFuncComplete++; });

            if (isFallOrEmptFile)
            {
                break;
            }
        }
        yield return new WaitUntil(() => isFallOrEmptFile && countFuncComplete == countFuncRun);


        isComplete?.Invoke();
    }

    public void GetASpriteFromStorage(StorageReference reference, string name = "18 (0)", Action isComplete = null, Action isFall = null)
    {
        const long maxAllowedSize = 1 * 1024 * 1024;
        reference.GetBytesAsync(maxAllowedSize).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                isFall?.Invoke();
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
                sprite.name = name;
                allsprites.Add(sprite);

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
