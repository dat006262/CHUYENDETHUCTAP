using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public DataInProgress dataInProgress = new DataInProgress();
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        dataInProgress.Load();
    }

}
