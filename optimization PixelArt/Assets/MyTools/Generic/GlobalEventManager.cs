//using Firebase.Analytics;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GlobalEventManager : MonoBehaviour
//{
//    public static Action<string, Parameter[]> EvtSendEvent;
//    public static Action EvtUpdateUserProperties;

//    #region GameActivity
//    public static void OnLevelPlay(int lv, int moved, int hinted, int backed, int bonus_branched)
//    {
//        Parameter[] parameter = new Parameter[]
//        {
//            new Parameter("level", lv.ToString()),
//            new Parameter("move", moved.ToString()),
//            new Parameter("hint", hinted.ToString()),
//            new Parameter("back", backed.ToString()),
//            new Parameter("branch", bonus_branched.ToString()),
//        };
//        EvtSendEvent?.Invoke("play_level", parameter);
//        if (lv < 50) EvtSendEvent?.Invoke($"play_level_{lv}", null);
//    }

//    public static void OnLevelComplete(int lv, int moved, int hinted, int backed, int bonus_branched)
//    {
//        Parameter[] parameter = new Parameter[]
//        {
//            new Parameter("level", lv.ToString()),
//            new Parameter("move", moved.ToString()),
//            new Parameter("hint", hinted.ToString()),
//            new Parameter("back", backed.ToString()),
//            new Parameter("branch", bonus_branched.ToString()),
//        };
//        EvtSendEvent?.Invoke("win_level", parameter);
//        if (lv <= 50) EvtSendEvent?.Invoke($"win_level_{lv - 1}", null);
//    }

//    public static void OnLevelRetry(int lv, int moved, int hinted, int backed, int bonus_branched)
//    {
//        Parameter[] parameter = new Parameter[]
//        {
//            new Parameter("level", lv.ToString()),
//            new Parameter("move", moved.ToString()),
//            new Parameter("hint", hinted.ToString()),
//            new Parameter("back", backed.ToString()),
//            new Parameter("branch", bonus_branched.ToString()),
//        };
//        EvtSendEvent?.Invoke("level_retry", parameter);
//        if (lv < 50) EvtSendEvent?.Invoke($"level_retry_{lv}", null);
//    }

//    public static void OnLevelShowLogoGame(int lv)
//    {
//        EvtSendEvent?.Invoke("show_logo_win", null);
//        if (lv < 50) EvtSendEvent?.Invoke($"show_logo_win_{lv}", null);
//    }

//    public static void OnLevelShowPopupWin(int lv)
//    {
//        EvtSendEvent?.Invoke("show_popup_win", null);
//        if (lv < 50) EvtSendEvent?.Invoke($"show_popup_win_{lv}", null);
//    }

//    public static void OnTutorialLevel1Step1Tap()
//    {
//        EvtSendEvent?.Invoke("tutorial_level1_step1_tap", null);
//    }

//    public static void OnTutorialLevel2Step1Tap()
//    {
//        EvtSendEvent?.Invoke("tutorial_level2_step1_tap", null);
//    }

//    public static void OnGameLoading()
//    {
//        EvtSendEvent?.Invoke("start_loading", null);
//    }
//    public static void OnUseHintComplete()
//    {
//        // EvtSendEvent?.Invoke("use_hint", null);
//    }

//    public static void OnUserBackComplete()
//    {
//        //  EvtSendEvent?.Invoke("use_back", null);
//    }

//    public static void OnUserBonusBranch()
//    {
//        //  EvtSendEvent?.Invoke("use_branch", null);
//    }

//    public static void OnTutorialComplete(string tut)
//    {
//        //Parameter[] parameters = new Parameter[]
//        //{
//        //    new Parameter("level", PlayerData.Instance.HighestLevel),
//        //    new Parameter("tutorial", tut),
//        //};
//        //EvtSendEvent?.Invoke("tutorial_complete", parameters);
//    }

//    private static string UserName
//    {
//        get
//        {
//            return PlayerPrefs.GetString("user_name");
//        }
//        set
//        {
//            PlayerPrefs.SetString("user_name", value);
//        }
//    }

//    public static void OnEventPlayerProfile(string value)
//    {
//        if (UserName.Equals(value)) return;
//        Parameter[] parameters = new Parameter[]
//        {
//            new Parameter("playfab_id",value),
//        };
//        EvtSendEvent?.Invoke("playfab_profile", parameters);
//        UserName = value;
//        Debug.Log(value);
//    }

//    #endregion

//    #region AdActivity
//    public static int interAdCount
//    {
//        get { return PlayerPrefs.GetInt("INTER_AD_COUNT", 0); }
//        set
//        {
//            PlayerPrefs.SetInt("INTER_AD_COUNT", value);
//        }
//    }

//    public static void OnAds_Interstitial_times()
//    {
//        interAdCount += 1;
//        Parameter[] parameter = new Parameter[]
//        {
//            new Parameter("amount", interAdCount.ToString()),
//        };
//        EvtSendEvent?.Invoke("ads_interstitial_times", parameter);
//    }

//    public static int rewardedAdCount
//    {
//        get { return PlayerPrefs.GetInt("REWARDED_AD_COUNT", 0); }
//        set
//        {
//            PlayerPrefs.SetInt("REWARED_AD_COUNT", value);
//        }
//    }

//    public static void OnAds_Rewarded_times()
//    {
//        rewardedAdCount += 1;
//        Parameter[] parameter = new Parameter[]
//        {
//            new Parameter("amount", rewardedAdCount.ToString()),
//        };
//        EvtSendEvent?.Invoke("ads_rewarded_times", parameter);
//    }

//    public static int bannerAdCount
//    {
//        get { return PlayerPrefs.GetInt("BANNER_AD_COUNT", 0); }
//        set
//        {
//            PlayerPrefs.SetInt("BANNER_AD_COUNT", value);
//        }
//    }

//    public static void OnAds_Banner_times()
//    {
//        bannerAdCount += 1;
//        Parameter[] parameter = new Parameter[]
//        {
//            new Parameter("amount", bannerAdCount.ToString()),
//        };
//        EvtSendEvent?.Invoke("ads_banner_times", parameter);
//    }

//    public static void OnShowInter()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_ADS_INTER_SHOW, null);
//    }

//    public static void OnCloseInter()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_ADS_INTER_CLOSED, null);
//    }

//    public static void OnshowRewarded(string adsLocation)
//    {
//        Parameter[] parameters = new Parameter[]
//        {
//            new Parameter("level", PlayerData.Instance.HighestLevel),
//            new Parameter("position", adsLocation),
//        };
//        EvtSendEvent?.Invoke(Const.KEY_ADS_REWARDED_SHOW, parameters);
//    }

//    public static void OnRewardedComplete(string adsComplete)
//    {
//        Parameter[] parameters = new Parameter[]
//        {
//            new Parameter("level", PlayerData.Instance.HighestLevel),
//            new Parameter("position",adsComplete),
//        };
//        EvtSendEvent?.Invoke(Const.KEY_ADS_REWARDED_COMPLETE, parameters);
//    }
//    #endregion

//    #region UserEngagement
//    public static void OnSpendCoin(SpendCoinLocation location, int value)
//    {
//        string level = string.Format("{0:00000}", PlayerData.Instance.HighestLevel);
//        Parameter[] parameters = new Parameter[]
//        {
//            new Parameter("level", level),
//            new Parameter("coinLocation", location.ToString()),
//            new Parameter("coinAmount", value),
//        };
//        EvtSendEvent?.Invoke(Const.EVENT_SPEND_COIN, parameters);
//    }

//    public static void OnUseBooster(BoosterType booster, GameModeType gameMode)
//    {
//        string level = string.Format("{0:00000}", PlayerData.Instance.HighestLevel);
//        Parameter[] parameters = new Parameter[]
//        {
//            new Parameter("level", level),
//            new Parameter("boosterType", booster.ToString()),
//            new Parameter("boosterLocation", gameMode.ToString()),
//        };
//        EvtSendEvent?.Invoke(Const.EVENT_USE_BOOSTER, parameters);
//    }

//    public static void OnEventLevelPlay(int levelID)
//    {
//        string level = string.Format("{0:00000}", levelID);
//        Parameter[] parameters = new Parameter[]
//        {
//            new Parameter("level", level),
//        };
//        EvtSendEvent?.Invoke(Const.EVENT_LEVEL_PLAY, parameters);
//    }

//    public static void OnEventLevelLose(int levelID)
//    {
//        string level = string.Format("{0:00000}", levelID);
//        Parameter[] parameters = new Parameter[]
//        {
//            new Parameter("level", level),
//        };
//        EvtSendEvent?.Invoke(Const.EVENT_LEVEL_LOSE, parameters);
//    }

//    public static void OnEventLevelWin(int levelID)
//    {
//        string level = string.Format("{0:00000}", levelID);
//        Parameter[] parameters = new Parameter[]
//        {
//            new Parameter("level", level),
//        };
//        EvtSendEvent?.Invoke(Const.EVENT_LEVEL_WIN, parameters);
//    }

//    public static void OnEventLevelWinAtFirstTry(int levelID)
//    {
//        string level = string.Format("{0:00000}", levelID);
//        Parameter[] parameters = new Parameter[]
//        {
//            new Parameter("level", level),
//        };
//        EvtSendEvent?.Invoke(Const.EVENT_LEVEL_WIN_AT_FIRST_TRY, parameters);
//    }

//    public static void OnEventLevelWithoutBoosterUsage(int levelID)
//    {
//        string level = string.Format("{0:00000}", levelID);
//        Parameter[] parameters = new Parameter[]
//        {
//            new Parameter("level", level),
//        };
//        EvtSendEvent?.Invoke(Const.EVENT_LEVEL_WIN_WITHOUT_BOOSTER_USAGE, parameters);
//    }
//    #endregion

//    public static void OnShowPopupGetFreeCoin()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_POPUP_GET_FREE_COIN, null);
//    }

//    public static void OnShowPopupClaimCoin()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_POPUP_CLAIM_COIN, null);
//    }

//    public static void OnShowPopupOutMove()
//    {
//        EvtSendEvent?.Invoke("show_popup_out_move", null);
//    }

//    public static void OnShowPopupAdventureComingSoon()
//    {
//        EvtSendEvent?.Invoke("show_popup_adventure_coming_soon", null);
//    }

//    private static int SpendCoin
//    {
//        get => PlayerPrefs.GetInt("spend_coin", 0);
//        set
//        {
//            PlayerPrefs.SetInt("spend_coin", value);
//        }
//    }

//    private static int EarnCoin
//    {
//        get => PlayerPrefs.GetInt("earn_coin", 0);
//        set
//        {
//            PlayerPrefs.SetInt("earn_coin", value);
//        }
//    }

//    public static void OnEarnVirtualCurrency(string virtualCurrencyName, int value)
//    {
//        EarnCoin += value;
//        FirebaseAnalytics.LogEvent(
//        FirebaseAnalytics.EventEarnVirtualCurrency,
//        new Parameter[] {
//                new Parameter( FirebaseAnalytics.ParameterValue, EarnCoin),
//                new Parameter(FirebaseAnalytics.ParameterVirtualCurrencyName, virtualCurrencyName),
//        }
//        );
//    }

//    public static void OnSpendVirtualCurrency(string virtualCurrencyName, int value)
//    {
//        SpendCoin += value;
//        FirebaseAnalytics.LogEvent(
//        FirebaseAnalytics.EventSpendVirtualCurrency,
//        new Parameter[] {
//                new Parameter( FirebaseAnalytics.ParameterValue, SpendCoin),
//                new Parameter(FirebaseAnalytics.ParameterVirtualCurrencyName, virtualCurrencyName),
//                new Parameter($"spend_virtual_currency/{virtualCurrencyName}", null)

//        }
//        );
//    }

//    public static void OnShowShop()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_SHOP, null);
//    }

//    public static void OnMyBirds()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_MY_BIRDS, null);
//    }

//    public static void OnShowHome()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_HOME, null);
//    }

//    public static void OnShowLeaderBoard()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_LEADER_BOARD, null);
//    }

//    public static void OnShowMyQuest()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_MY_QUEST, null);
//    }

//    public static void OnShowBookStory()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_BOOK_STORY, null);
//    }

//    public static void OnShowWeeklyGifts()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_WEEKLY_GIFTS, null);
//    }

//    public static void OnShowDailyGifts()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_DAILY_GIFTS, null);
//    }

//    /*  public static void OnAds_Banner_times()
//      {
//          bannerAdCount += 1;
//          Parameter[] parameter = new Parameter[]
//          {
//              new Parameter("amount", bannerAdCount.ToString()),
//          };
//          EvtSendEvent?.Invoke("ads_banner_times", parameter);
//      }*/

//    public static void OnIapComplete(string iapName)
//    {
//        Parameter[] parameter = new Parameter[]
//        {
//            new Parameter("IAP Complete", iapName),
//        };
//        EvtSendEvent?.Invoke("iap_complete", parameter);
//    }

//    public static void OnIAPCompleted(IAPPackName packName)
//    {
//        Parameter[] parameters = new Parameter[]
//        {
//            new Parameter("level", PlayerData.Instance.HighestLevel),
//            new Parameter("iap_pack_name", packName.ToString()),
//        };
//        EvtSendEvent?.Invoke(Const.EVENT_IAP_COMPLETED, parameters);
//    }

//    public static void OnBirdsClick(string birdName)
//    {
//        Parameter[] parameter = new Parameter[]
//        {
//            new Parameter("Profile", birdName),
//        };
//        EvtSendEvent?.Invoke("birds_click", parameter);
//    }

//    public static void OnIapClick(string iapNameClick)
//    {
//        Parameter[] parameter = new Parameter[]
//        {
//            new Parameter("IAP Click", iapNameClick),
//        };
//        EvtSendEvent?.Invoke("iap_click", parameter);
//    }

//    public static void OnIAPClicked(IAPPackName packName)
//    {
//        Parameter[] parameters = new Parameter[]
//        {
//            new Parameter("level", PlayerData.Instance.HighestLevel),
//            new Parameter("iap_pack_name", packName.ToString()),
//        };
//        EvtSendEvent?.Invoke(Const.EVENT_IAP_CLICKED, parameters);
//    }

//    public static void OnIAPShown(IAPPackName packName)
//    {
//        Parameter[] parameters = new Parameter[]
//        {
//            new Parameter("level", PlayerData.Instance.HighestLevel),
//            new Parameter("iap_pack_name", packName.ToString()),
//        };
//        EvtSendEvent?.Invoke(Const.EVENT_IAP_SHOWN, parameters);
//    }

//    public static void OnClaimDay(int level, int day)
//    {
//        Parameter[] parameter = new Parameter[]
//        {
//            new Parameter("Day" + day , level.ToString()),
//        };
//        EvtSendEvent?.Invoke("claim_day_" + day, parameter);
//    }

//    public static void OnClaimDay7(int level)
//    {
//        Parameter[] parameter = new Parameter[]
//        {
//            new Parameter("Day 7" ,level.ToString()),
//        };
//        EvtSendEvent?.Invoke("claim_day_7", parameter);
//    }

//    public static void OnClickUnlockShard()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_CLICK_UNLOCK_SHARD, null);
//    }

//    public static void OnClickUnlockCoin()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_CLICK_UNLOCK_COIN, null);
//    }

//    public static void OnUnlockCoin()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_UNLOCK_COIN, null);
//    }

//    public static void OnUnlockShard()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_UNLOCK_SHARD, null);
//    }

//    public static void OnShowPopupUndo()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_POPUP_UNDO, null);
//    }

//    public static void OnShowPopupRuleBreaker()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_POPUP_RULE_BREAKER, null);
//    }

//    public static void OnShowPopupBranch()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_POPUP_BRANCH, null);
//    }

//    public static void OnShowPopupNonStopPlaying()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_POPUP_NON_STOP_PLAYING, null);
//    }

//    public static void OnShowPopupExtraLives()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_POPUP_EXTRA_LIVES, null);
//    }

//    public static void OnShowPopupFashionista()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_POPUP_FASHIONISTA, null);
//    }

//    public static void OnShowPopupBranchWeekendOffer()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_POPUP_BRANCH_WEEKEND_OFFER, null);
//    }

//    public static void OnShowPopupPreparation()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_POPUP_PREPARATION, null);
//    }

//    public static void OnShowPopupLimitedTimeDeal()
//    {
//        EvtSendEvent?.Invoke(Const.KEY_SHOW_POPUP_LIMITED_TIME_DEAL, null);
//    }

//    #region Don't Use
//    public static void OnClickStarterPack()
//    {
//        // EvtSendEvent?.Invoke(Const.KEY_START_PACK, null);
//    }

//    public static void OnRemoveAdsClick()
//    {
//        // EvtSendEvent?.Invoke(Const.KEY_CLICK_PACK_REMOVE_ADS, null);
//    }

//    public static void OnClickPack25Coins()
//    {
//        //EvtSendEvent?.Invoke(Const.KEY_CLICK_PACK_COINS_25, null);
//    }

//    public static void OnCoin25Complete()
//    {
//        // EvtSendEvent?.Invoke(Const.KEY_COINS_25_COMPLETE, null);
//    }

//    public static void OnClickPack2900Coins()
//    {
//        // EvtSendEvent?.Invoke(Const.KEY_CLICK_COINS_2900, null);
//    }

//    public static void OnClickPack240Coins()
//    {
//        //  EvtSendEvent?.Invoke(Const.KEY_CLICK_COINS_240, null);
//    }

//    public static void OnClickPack720Coins()
//    {
//        //EvtSendEvent?.Invoke(Const.KEY_CLICK_COINS_720, null);
//    }

//    public static void OnCLickPack1330Coins()
//    {
//        //EvtSendEvent?.Invoke(Const.KEY_CLICK_COINS_1330, null);
//    }

//    public static void OnClickPack6300Coins()
//    {
//        // EvtSendEvent?.Invoke(Const.KEY_CLICK_COINS_6300, null);
//    }

//    public static void OnClickPack17000Coins()
//    {
//        //  EvtSendEvent?.Invoke(Const.KEY_CLICK_COINS_17000, null);
//    }


//    #region Buton
//    public static void OnClickButtonHome()
//    {
//        // EvtSendEvent?.Invoke(Const.KEY_CLICK_BUTTON_HOME, null);
//    }

//    public static void OnClickButtonAddCoin()
//    {
//        //  EvtSendEvent?.Invoke(Const.KEY_CLICK_BUTTON_ADD_COIN, null);
//    }

//    public static void OnClickButtonSetting()
//    {
//        //  EvtSendEvent?.Invoke(Const.KEY_CLICK_BUTTON_SETTINGS, null);
//    }

//    public static void OnClickSaveProgress()
//    {
//        // EvtSendEvent?.Invoke(Const.KEY_CLICK_SAVE_PROGRESS, null);
//    }

//    public static void OnClickRate()
//    {
//        // EvtSendEvent?.Invoke(Const.KEY_CLICK_RATE, null);
//    }

//    public static void OnClickClaimCoin()
//    {
//        //  EvtSendEvent?.Invoke(Const.KEY_CLICK_CLAIM_COIN, null);
//    }

//    public static void OnClickShop()
//    {
//        // EvtSendEvent?.Invoke(Const.KEY_CLICK_BUTTON_SHOP, null);
//    }

//    public static void OnClickNextLevel(int lv)
//    {
//        EvtSendEvent?.Invoke(Const.KEY_LEVEL_NEXT, null);
//        if (lv < 50) EvtSendEvent?.Invoke($"{Const.KEY_LEVEL_NEXT}_{lv}", null);
//    }

//    public static void OnClickNoThanks()
//    {
//        //EvtSendEvent?.Invoke(Const.KEY_NO_THANKS_GET_FREE_COIN, null);
//    }
//    #endregion

//    #region Booster
//    #region On Click
//    public static void OnClickPackHint(bool isCombo)
//    {
//        //if (isCombo)
//        //{
//        //    EvtSendEvent?.Invoke(Const.KEY_CLICK_COMBO_HINT, null);
//        //}
//        //else
//        //{
//        //    EvtSendEvent?.Invoke(Const.KEY_CLICK_HINT, null);
//        //}
//    }

//    public static void OnClickPackBranch(bool isCombo)
//    {
//        //if (isCombo)
//        //{
//        //    EvtSendEvent?.Invoke(Const.KEY_CLICK_COMBO_BRANCH, null);
//        //}
//        //else
//        //{
//        //    EvtSendEvent?.Invoke(Const.KEY_CLICK_BRANCH, null);
//        //}
//    }

//    public static void OnClickPackBack(bool isCombo)
//    {
//        //if (isCombo)
//        //{
//        //    EvtSendEvent?.Invoke(Const.KEY_LICK_COMBO_BACK, null);
//        //}
//        //else
//        //{
//        //    EvtSendEvent?.Invoke(Const.KEY_CLICK_BACK, null);
//        //}
//    }
//    #endregion

//    #region Buy succses
//    public static void OnBuySuccsesHint(bool isCombo)
//    {
//        //if (isCombo)
//        //{
//        //    EvtSendEvent?.Invoke(Const.KEY_BUY_SUCCSES_COMBO_HINT, null);
//        //}
//        //else
//        //{
//        //    EvtSendEvent?.Invoke(Const.KEY_BUY_SUCCSES_HINT, null);
//        //}
//    }

//    public static void OnBuySuccsesBranch(bool isCombo)
//    {
//        //if (isCombo)
//        //{
//        //    EvtSendEvent?.Invoke(Const.KEY_BUY_SUCCSES_COMBO_BRANCH, null);
//        //}
//        //else
//        //{
//        //    EvtSendEvent?.Invoke(Const.KEY_BUY_SUCCSES_BRANCH, null);
//        //}
//    }

//    public static void OnBuySuccsesBack(bool isCombo)
//    {
//        //if (isCombo)
//        //{
//        //    EvtSendEvent?.Invoke(Const.KEY_BUY_SUCCSES_COMBO_BACK, null);
//        //}
//        //else
//        //{
//        //    EvtSendEvent?.Invoke(Const.KEY_BUY_SUCCSES_BACK, null);
//        //}
//    }
//    #endregion


//    #endregion

//    #region Login
//    public static void OnLoginFBComplete()
//    {
//        // EvtSendEvent?.Invoke(Const.KEY_LOGIN_FB_COMPLETE, null);
//    }
//    #endregion
//    #endregion
//}

//public enum GameModeType
//{
//    Classic,
//    Adventure,
//}

//public enum SpendCoinLocation
//{
//    LiveRefill,
//    PlayOn,
//    PopupBuyRuleBreaker,
//    PopupBuyBranch,
//    PopupBuyUndo,
//}

//public enum BoosterType
//{
//    RuleBreaker,
//    Branch,
//    Undo,
//}

//public enum IAPPackName
//{
//    RemoveAds,
//    StarterPack,
//    BillyPack,
//    VictorPack,
//    CoinPack1,
//    CoinPack2,
//    CoinPack3,
//    CoinPack4,
//    CoinPack5,
//    CoinPack6,
//    NonstopPlayingPack,
//    ExtraLivesPack,
//    FashionistaPack,
//    BranchStockpilePack,
//    WeekendOfferPack,
//    PreparationIsKeyPack,
//    LimitedTimeDealPack,
//    GlamSkinPack,
//    UniqueSkinPack1,
//    EventMoonFestival,
//    EventMoonRabbit,
//    EventMoonGoddess,
//}
