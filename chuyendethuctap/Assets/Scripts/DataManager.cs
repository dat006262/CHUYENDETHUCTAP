using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public List<Sprite> sprites = new List<Sprite>();
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
        ShowDataManager.Instance.SpawmLibrary_New(sprites);
    }
    public void GetAllSprite()
    {
        sprites = Resources.LoadAll<Sprite>("New").ToList();
    }

}
