//using PopupSystem;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSetting : SingletonMonoBehaviour<GlobalSetting>
{
    #region INIT, REF===============================

    [SerializeField] int _buildNumber;
    [SerializeField] GameObject _loadingTextObj, _loadingAnimObj;
    public SCENE Scene;
    public MODEGAME ModeGame;
    public StateGame StateGame;
    //public static List<BasePopup> BasePopups = new List<BasePopup>();
    public static bool isLevelTryHard = false;
    public static string LevelTagName;


    public override void Awake()
    {
#if !UNITY_EDITOR
        Application.targetFrameRate = 60;
        Input.multiTouchEnabled = false;
#endif

        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.S))
        {
            //   OfferAtStartGamePopup.Instance.Show();
        }
#endif
    }

    #endregion
    #region PUBLIC========================================================
    //public static void AddPopupBase(BasePopup basePopup)
    //{
    //    BasePopups.Add(basePopup);
    //}

    #endregion

    #region PRIVATE===================================================
    private void ChangeModeGame(MODEGAME mode)
    {
        this.ModeGame = mode;
    }
    private void ChangeScene(SCENE scene)
    {
        this.Scene = scene;
    }
    private void ChangeStateGame(StateGame state)
    {
        StateGame = state;
    }
    #endregion


}

public enum SCENE
{
    LOADING,
    HOME,
    GAME_PLAY
}

public enum MODEGAME
{
    NORMAL,
    CHALLENGE
}
public enum StateGame
{
    NONE,
    WIN,
    LOSE,
    PLAYING
}
