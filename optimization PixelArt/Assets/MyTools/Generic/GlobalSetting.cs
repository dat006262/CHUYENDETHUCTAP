//using PopupSystem;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//public class GlobalSetting : SingletonMonoBehaviour<GlobalSetting>
//{
//    public SCENE Scene;
//    public TAGLEVEL tagLevel = TAGLEVEL.NORMAL;
//    public StateGame StateGame;
//    [SerializeField] int _buildNumber;
//    [SerializeField] GameObject _loadingTextObj, _loadingAnimObj;
//    public static List<BasePopup> BasePopups = new List<BasePopup>();
//    public static bool isLevelTryHard = false;
//    public static string LevelTag;
//    public override void Awake()
//    {
//#if !UNITY_EDITOR
//        Application.targetFrameRate = 60;
//        Input.multiTouchEnabled = false;
//#endif
//        ActionEvent.OnChangeScene += ChangeScene;
//        DontDestroyOnLoad(gameObject);
//    }

//    public int GetBuildNumber()
//    {
//        return this._buildNumber;
//    }

//    public static void AddPopupBase(BasePopup basePopup)
//    {
//        BasePopups.Add(basePopup);
//    }

//    public static void ClearPopupBase()
//    {
//        foreach (var popup in BasePopups)
//        {
//            popup?.HidePopupisHome();
//        }
//        BasePopups.Clear();
//    }

//    private void ChangeScene(SCENE scene)
//    {
//        this.Scene = scene;

//        if (Scene.Equals(SCENE.GAME_PLAY))
//        {
//            ActionEvent.OnShowBanner?.Invoke();
//        }

//        else if (Scene.Equals(SCENE.HOME))
//        {
//            ActionEvent.OnHideBanner?.Invoke();
//        }
//    }

//    public void SetLoadingText(bool isValue)
//    {
//        _loadingTextObj.SetActive(isValue);
//    }

//    public void SetLoadingAnim(bool isValue)
//    {
//        _loadingAnimObj.SetActive(isValue);
//    }

//    public static AudioClip GetSFX(string audioName)
//    {
//        return Resources.Load<AudioClip>("SFX/" + audioName);
//    }

//    public void ChangeStateGame(StateGame state)
//    {
//        StateGame = state;
//    }

//    private void OnDestroy()
//    {
//        ActionEvent.OnChangeScene -= ChangeScene;
//    }
//}

//public enum SCENE
//{
//    LOADING,
//    HOME,
//    GAME_PLAY
//}

//public enum ModeGame
//{
//    NORMAL,
//    ADVENTURE,
//}

//public enum TAGLEVEL
//{
//    HARD,
//    SUPERHARD,
//    NORMAL
//}

//public enum StateGame
//{
//    NONE,
//    WIN,
//    LOSE
//}