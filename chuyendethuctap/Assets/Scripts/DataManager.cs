using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;
public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public List<Sprite> allsprites = new List<Sprite>();
    public DataInProgress dataInProgress = new DataInProgress();
    public List<Sprite> folderNew = new List<Sprite>();
    public List<Sprite> folderCreate = new List<Sprite>();


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        dataInProgress.Load();
        GetAllSprite();

    }
    private void Start()
    {
        LoadAllSpriteCreated();
        ShowDataManager.Instance.SpawmLibrary_New(allsprites);
        ShowDataManager.Instance.SpawnDrawed(allsprites);
        ShowDataManager.Instance.SpawnDrawed(folderCreate);
        ShowDataManager.Instance.SpawnCreated(folderCreate);
    }
    IEnumerable test()
    {
        yield return new WaitForSeconds(2f);

    }
    public void GetAllSprite()
    {
        allsprites = Resources.LoadAll<Sprite>("New").ToList();
    }
    public void LoadAllSpriteCreated()
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
