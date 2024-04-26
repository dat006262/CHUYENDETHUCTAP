using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : SingletonMonoBehaviour<GameControll>
{
    public GameObject Home;
    public GameObject PlayGame;
    public GameObject Loading;
    public void OpenHome()
    {
        LoadingScene.Instance.loadingSceneGameObject.SetActive(true);
        StartCoroutine(LoadingScene.Instance.LoadSceneAsync2());
        Home.SetActive(true);
        PlayGame.SetActive(false);
        GlobalSetting.Instance.gameStat = GlobalSetting.GameStat.HOMING;
    }

    public void OpenGamePlay()
    {
        //LoadingScene.Instance.loadingSceneGameObject.SetActive(true);
        StartCoroutine(LoadingScene.Instance.LoadSceneAsync2());
        PlayGame.SetActive(true);
        Home.SetActive(false);
        GlobalSetting.Instance.gameStat = GlobalSetting.GameStat.GAMEPLAY;
    }
    public void TurnOffLoading()
    {
        Loading.SetActive(false);
    }
}

