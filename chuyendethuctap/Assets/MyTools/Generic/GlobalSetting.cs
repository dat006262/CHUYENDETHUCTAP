//using PopupSystem;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSetting : SingletonMonoBehaviour<GlobalSetting>
{
    #region INIT, REF===============================
    public InterstitialAdExample interstitialAdExample;
    public AdsManager adsManager;
    public bool isHaveAds = false;
    public enum GameStat
    {
        HOMING,
        GAMEPLAY
    }
    public GameStat gameStat = GameStat.HOMING;
    //public static List<BasePopup> BasePopups = new List<BasePopup>();
    public override void Awake()
    {
#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = true;
#else
 Debug.unityLogger.logEnabled = false;
#endif
#if !UNITY_EDITOR
        Application.targetFrameRate = 60;
        Input.multiTouchEnabled = true  ;

#endif

        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.S))
        {

        }
#endif
    }

    #endregion



}


