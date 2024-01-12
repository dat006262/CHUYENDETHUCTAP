using Firebase.Analytics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventManager : MonoBehaviour
{
    #region Instance
    private static GlobalEventManager instance;
    public static GlobalEventManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<GlobalEventManager>();
            }
            return instance;
        }
    }
    public static bool Exist => instance;
    #endregion

    public static Action<string, Parameter[]> EvtSendEvent;
    public static Action EvtUpdateUserProperties;

    private void Awake()
    {
        //   PlayerData.Instance.EvtGameLoginDayChange += OnTrackGameLoginDay;

    }

    private void OnDestroy()
    {
        //  PlayerData.Instance.EvtGameLoginDayChange -= OnTrackGameLoginDay;

    }

    #region NEW2024
    private void OnTrackGameLoginDay()
    {
        // EvtSendEvent?.Invoke($"{FirebaseEvent.game_login_day_}{PlayerData.Instance.GameLoginDay}", null);
    }

    private int _coinAmount = 0;
    private CoinLocation _coinLocation = CoinLocation.None;

    public void UpdateCoinParams(int coinAmount, CoinLocation coinLocation = CoinLocation.None)
    {
        _coinAmount = coinAmount;
        _coinLocation = coinLocation;
    }

    private void OnTrackCoinEarned()
    {
        /* Parameter[] _params = new Parameter[]
         {
             new Parameter("on_login_day", PlayerData.Instance.GameLoginDay),
             new Parameter("level", PlayerData.Instance.HighestLevel),
             new Parameter("coin_amount", _coinAmount),
             new Parameter("coin_location", _coinLocation.ToString()),
             new Parameter("total_coin_balance", PlayerData.Instance.CountTotalCoinEarned - PlayerData.Instance.CountTotalCoinSpend),
         };
         Debug.LogError($"OnTrackCoinEarned = {_coinAmount}/{_coinLocation}");
         EvtSendEvent?.Invoke($"{FirebaseEvent.coin_earned}", _params);*/
    }

    private void OnTrackCoinSpend()
    {
        /*   Parameter[] _params = new Parameter[]
           {
               new Parameter("on_login_day", PlayerData.Instance.GameLoginDay),
               new Parameter("level", PlayerData.Instance.HighestLevel),
               new Parameter("coin_amount", _coinAmount),
               new Parameter("coin_location", _coinLocation.ToString()),
               new Parameter("total_coin_balance", PlayerData.Instance.CountTotalCoinEarned - PlayerData.Instance.CountTotalCoinSpend),
           };
           Debug.LogError($"OnTrackCoinSpend = {_coinAmount}/{_coinLocation}");
           EvtSendEvent?.Invoke($"{FirebaseEvent.coin_spend}", _params);*/
    }

    private int _boosterAmount = 0;
    private BoosterLocation _boosterLocation = BoosterLocation.None;

    public void UpdateBoosterParams(int boosterAmount, BoosterLocation boosterLocation = BoosterLocation.None)
    {
        _boosterAmount = boosterAmount;
        _boosterLocation = boosterLocation;
    }

    private void OnTrackBoosterEarned()
    {
        /* Parameter[] _params = new Parameter[]
         {
             new Parameter("on_login_day", PlayerData.Instance.GameLoginDay),
             new Parameter("level", PlayerData.Instance.HighestLevel),
             new Parameter("booster_amount", _boosterAmount),
             new Parameter("booster_location", _boosterLocation.ToString()),
             new Parameter("total_booster_balance", PlayerData.Instance.CountTotalBoosterEarned - PlayerData.Instance.CountTotalBoosterSpend),
         };
         Debug.LogError($"OnTrackBoosterEarned = {_boosterAmount}/{_boosterLocation}");
         EvtSendEvent?.Invoke($"{FirebaseEvent.booster_earned}", _params);*/
    }

    private void OnTrackBoosterSpend()
    {
        /* Parameter[] _params = new Parameter[]
         {
             new Parameter("on_login_day", PlayerData.Instance.GameLoginDay),
             new Parameter("level", PlayerData.Instance.HighestLevel),
             new Parameter("booster_amount", _boosterAmount),
             new Parameter("booster_location", _boosterLocation.ToString()),
             new Parameter("total_booster_balance", PlayerData.Instance.CountTotalBoosterEarned - PlayerData.Instance.CountTotalBoosterSpend),
         };
         Debug.LogError($"OnTrackBoosterSpend = {_boosterAmount}/{_boosterLocation}");
         EvtSendEvent?.Invoke($"{FirebaseEvent.booster_spend}", _params);*/
    }

    #region PLAY ACTIVITY
    private int _timePlay = 0;
    public int TimePlay
    {
        get { return _timePlay; }
        set { _timePlay = value; }
    }

    private int _boosterUsage = 0;
    public int BoosterUsage
    {
        get { return _boosterUsage; }
        set { _boosterUsage = value; }
    }



    private void OnTrackGamePlay()
    {

    }

    private void OnTrackGameWin()
    {

    }

    private void OnTrackGameLose()
    {

    }
    #endregion

    #region AD ACTIVITY
    private AdLocation _adLocation;
    public AdLocation AdLocation
    {
        get { return _adLocation; }
        set { _adLocation = value; }
    }

    private bool IsTrackedAmount(int amount)
    {
        return amount < 20 || (amount >= 20 && amount < 50 && amount % 5 == 0) || (amount >= 50 && amount % 10 == 0);
    }

    private void OnTrackAdInterShown()
    {

    }

    private void OnTrackAdInterClicked()
    {

    }

    private void OnTrackAdVideoShown()
    {

    }

    private void OnTrackAdVideoClicked()
    {

    }

    private void OnTrackAdVideoCompleted()
    {

    }
    #endregion
    #endregion
}

public enum GameModeType
{
    Classic,
    Adventure,
}

public enum FirebaseEvent
{
    game_login_day_,
    coin_earned,
    coin_spend,
    booster_earned,
    booster_spend,
    game_play_,
    game_win_,
    game_lose_,
    inter_show_,
    inter_click_,
    reward_show_,
    reward_click_,
    reward_complete_,
}

public enum SpendCoinLocation
{
    LiveRefill,
    PlayOn,
    PopupBuyRuleBreaker,
    PopupBuyBranch,
    PopupBuyUndo,
}

public enum BoosterType
{
    RuleBreaker,
    Branch,
    Undo,
    Replay,
}

public enum AdLocation
{
    None,
    BoosterRuleBreaker,
    BoosterBranch,
    BoosterUndo,
    GameWinWithBonus,
    InGameMoreLimit,
    MoreLive,
    InShopFreeCoin,
    InBirdFirstMeeting,
}

public enum CoinLocation
{
    None,
    GoldenPass,
    BirdRace,
    Skyward,
    MoreLive,
    GameWin,
    GameWinWithBonus,
    JoinCommunity,
    Achievement,
    DailyQuest,
    ShopFreeCoin,
    ShopStarterPack,
    ShopBillyPack,
    ShopVictorPack,
    ShopCoinPack1,
    ShopCoinPack2,
    ShopCoinPack3,
    ShopCoinPack4,
    ShopCoinPack5,
    ShopCoinPack6,
    ShopNonstopPlayingPack,
    ShopWeekendOfferPack,
    ShopLimitedTimeDealPack,
    EventMoonFestivalPack,
    EventMoonRabbitPack,
    EventMoonGoddessPack,
    EventHalloweenPartyPack,
    EventBewitchingPackPack,
    EventWickedPack,
    EventHauntingPack,
    EventChristmasPack,
    EventNewYearPack,
}

public enum BoosterLocation
{
    None,
    ChapterCompletedChest,
    GoldenPass,
    BirdRace,
    Skyward,
    WatchVideo,
    UseRuleBreaker,
    UseBranch,
    UseUndo,
    ShopStarterPack,
    ShopBillyPack,
    ShopVictorPack,
    ShopExtraLivesPack,
    ShopBranchStockpilePack,
    ShopWeekendOfferPack,
    ShopPreparationIsKeyPack,
    ShopLimitedTimeDealPack,
    EventMoonFestivalPack,
    EventMoonRabbitPack,
    EventMoonGoddessPack,
    EventHalloweenPartyPack,
    EventBewitchingPackPack,
    EventWickedPack,
    EventHauntingPack,
    EventChristmasPack,
    EventNewYearPack,
}

public enum IAPPackName
{
    RemoveAds,
    StarterPack,
    BillyPack,
    VictorPack,
    CoinPack1,
    CoinPack2,
    CoinPack3,
    CoinPack4,
    CoinPack5,
    CoinPack6,
    NonstopPlayingPack,
    ExtraLivesPack,
    FashionistaPack,
    BranchStockpilePack,
    WeekendOfferPack,
    PreparationIsKeyPack,
    LimitedTimeDealPack,
    GlamSkinPack,
    UniqueSkinPack1,
    EventMoonFestival,
    EventMoonRabbit,
    EventMoonGoddess,
    GoldenPass,
    PuzzlePack,
    PuzzlePackDeluxe,
    HalloweenParty,
    BewitchingPack,
    WickedPack,
    HauntingPack,
    ChristmasPack,
    NewYearPack,
    LastChristmasPack,
}
