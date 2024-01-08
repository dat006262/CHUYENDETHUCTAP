using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingletonMonoBehaviour<DataManager>
{
    public DataInProgress dataInProgress = new DataInProgress();
    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
        dataInProgress.Load();
    }
}
