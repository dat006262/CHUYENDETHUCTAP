using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Const
{
    public static string KEY_DATAINPROGRESS = "DataInProgress";

    #region DAILY GIFT && WEEKLY GIFTS
    public static string KEY_DAY_NUMBER = "day_number";
    public static string KEY_TOTAL_DAY = "total_day";
    public const string KEY_VALUE_CURRENT_WG = "value_current_wg";
    public const string KEY_VALUE_MAX_WG = "value_max_wg";
    public static string KEY_COUNT_DAYS = "count_days";
    public static string KEY_RESET_DAY = "reset_day";
    public const string KEY_SAVE_PROCESS = "process_saved";
    public const string KEY_SAVE_GIFT_DAY = "gift_day";
    public const string KEY_SAVE_DAILY_GIFT = "daily_gift";

    //----------------------------
    public const string KEY_ADS_MORELIVE = "ads_more_live";
    public const string KEY_ADS_FREECOINS = "ads_free_coins";
    public const string KEY_INFINITY_LIVE = "infinity_live";
    public const string KEY_BIG_EFFORT = "big_effort_amount";
    #endregion

    #region CONFIGS
    public static string SHOW_AD = "show_ads";
    public const string KEY_WELCOM = "Relax your brain with 10 minutes of playing everyday";
    #endregion

    #region Keys
    public static string FIRST_TIME_OPEN = "FIRST_TIME_OPEN";
    public static string MUSIC_VALUE = "MUSIC_VALUE";
    public static string SOUND_VALUE = "SOUND_VALUE";
    public static string VOICE_OVER_VALUE = "VOICE_OVER_VALUE";
    #endregion

    #region SCENE
    public const string SCENE_LOADING = "Loading";
    public const string SCENE_HOME = "Home";
    public const string SCENE_GAME = "Game";
    public const string SCENE_ADVENTURE = "Adventure";
    public const string SCENE_TEST = "Test";
    public const string SCENE_STORY = "Story";
    #endregion

    #region Data keys
    public const string KEY_HIGHEST_LEVEL = "highest_level";
    public const string KEY_HIGLEST_LEVEL_WEEKLY = "higlest_level_weekly";
    public const string KEY_TOTAL_SCORE = "SumScore";
    public const string KEY_WEEKLY_SCORE = "WeekScore";
    public const string KEY_TOTAL_COIN = "TotalCoin";
    public const string REMOVE_ADS = "remove_ads";
    public const string KEY_NUMBER_CONSECUTIVE_WINS = "number_consecutive_wins";

    public const string KEY_TOTAL_WIN = "total_win";
    public const string KEY_TOTAL_PLAY = "total_play";
    public const string KEY_TOTAL_FIRST_WIN = "total_first_win";

    #region Data to PlayerFab
    //Tutorial
    public const string KEY_TUT_BACKED = "Tutorial_Backed";
    public const string KEY_TUT_ADD_BRANCH = "Tutorial_isMoreBranch";
    public const string KEY_TUT_HINT_FIRST = "Tutorial_isHintFirst";
    public const string KEY_TUT_HINT_SECOND = "Tutorial_isHintSecond";

    //item
    public const string KEY_LEVEL = "Level";
    public const string KEY_COIN = "Total_Coin";
    public const string KEY_TOTAL_SCORE_DATA = "Total_Score";
    public const string KEY_BRANCH_NUMBER = "Branch_Number";
    public const string KEY_HINT_NUMBER = "Hint_Number";
    public const string KEY_BACK_NUMBER = "Back_Number";

    public const string KEY_DATA_LOOT = "user_data_loot";
    public const string KEY_DATA_STREAK = "user_data_streak";
    //LeaderBoard
    public const string KEY_LEADER_BOARD_TOTAL = "Leader Board";
    public const string KEY_LEADER_BOARD_WEEKLY = "Leader Board Weekly";
    public const string KEY_LEADER_BOARD_HIGH_LEVEL = "Leaderboard High Level";
    public const string KEY_LEADER_BOARD_HIGH_LEVEL_WEEKLY = "Leaderboard High Level Weekly";
    #endregion

    #region Booster
    public const string REDO_NUMBER = "redo_number";
    public const string HINT_NUMBER = "hint_number";
    public const string BRANCH_NUMBER = "branch_number";
    public const string KEY_BIRD_SHARDS = "bird_shards";
    public const string KEY_STAR = "star";
    #endregion

    #region Process Gift
    public const string KEY_PROCESS_GIFT_CURRENT_VALUE = "Procees_gift_Current_Value";
    public const string KEY_PROCESS_GIFT_VALUE_MAX = "Process_gift_Value_max";
    public const string KEY_PROCESS_OPEN_GIFT = "process_open_gift";
    #endregion
    /// <summary>
    /// Tutorial
    /// </summary>
    public const string KEY_BACKED = "Backed";
    public const string KEY_MOREBRANCHED = "More_Branched";
    public const string KEY_HINT1 = "Hint1";
    public const string KEY_HINT2 = "Hint2";

    public const string KEY_BRANCH = "branch";

    public const string KEY_THE_1ST_LOSE = "the_1st_lose";

    public const string KEY_SAVE_TUTORIAL = "save_tutorial";


    #endregion

    #region Connect
    public const string KEY_NO_INTERNET = "txt_no_internet";
    public const string KEY_OVER_AD = "txt_over_ad";
    #endregion

    #region Login
    public const string KEY_LOGIN_FIRST_TIME = "loginFirstTime";
    #endregion

    #region Param FireBase
    //Show 
    public const string KEY_SHOW_POPUP_GET_FREE_COIN = "show_popup_get_free_coin";
    public const string KEY_SHOW_POPUP_CLAIM_COIN = "show_popup_claim_coin";
    public const string KEY_ADS_REWARDED_SHOW_COIN_25 = "rewarded_coin_25";
    public const string KEY_SHOW_SHOP = "show_shop";
    public const string KEY_SHOW_MY_BIRDS = "show_my_birds";
    public const string KEY_SHOW_HOME = "show_home";
    public const string KEY_SHOW_LEADER_BOARD = "show_leader_board";
    public const string KEY_SHOW_MY_QUEST = "show_my_quest ";
    public const string KEY_SHOW_BOOK_STORY = "show_book_story";
    public const string KEY_SHOW_WEEKLY_GIFTS = "show_weekly_gifts";
    public const string KEY_SHOW_DAILY_GIFTS = "show_daily_gifts";
    public const string KEY_SHOW_POPUP_UNDO = "show_popup_undo";
    public const string KEY_SHOW_POPUP_RULE_BREAKER = "show_popup_rule_breaker";
    public const string KEY_SHOW_POPUP_BRANCH = "show_popup_branch";
    public const string KEY_SHOW_POPUP_NON_STOP_PLAYING = "show_popup_non_stop_playing";
    public const string KEY_SHOW_POPUP_EXTRA_LIVES = "show_popup_extra_lives";
    public const string KEY_SHOW_POPUP_FASHIONISTA = "show_popup_fashionista";
    public const string KEY_SHOW_POPUP_BRANCH_WEEKEND_OFFER = "show_popup_branch_weekend_offer";
    public const string KEY_SHOW_POPUP_PREPARATION = "show_popup_preparation";
    public const string KEY_SHOW_POPUP_LIMITED_TIME_DEAL = "show_popup_limited_time_deal";
    //Click
    public const string KEY_CLICK_UNLOCK_SHARD = "click_unlock_shard";
    public const string KEY_CLICK_UNLOCK_COIN = "click_unlock_coin";

    //Bosster
    public const string KEY_REWARDED_BACK = "Rewarded_Back";
    public const string KEY_REWARDED_HINT = "Rewarded_Hint";
    public const string KEY_REWARDED_BRANCH = "rewarded_Branch";

    //Shop
    public const string KEY_UNLOCK_BIRD = "Unlock_Bird";
    public const string KEY_UNLOCK_THEME = "Unlock_Theme";
    public const string KEY_UNLOCK_COIN = "unlock_coin";
    public const string KEY_UNLOCK_SHARD = "unlock_shard";


    //Quest
    public const string KEY_RESTART_QUEST = "Restart_Quest";
    public const string KEY_QUEST_REWARDED = "Quest_Reward";

    #region Pack
    //COINS
    //On Click
    public const string KEY_START_PACK = "click_starter_pack";
    public const string KEY_CLICK_PACK_REMOVE_ADS = "click_remove_ads";
    public const string KEY_CLICK_PACK_COINS_25 = "click_coins_25";
    public const string KEY_CLICK_COINS_2900 = "click_coins_2900";
    public const string KEY_CLICK_COINS_240 = "click_coins_240";
    public const string KEY_CLICK_COINS_720 = "click_coins_720";
    public const string KEY_CLICK_COINS_1330 = "click_coins_1330";
    public const string KEY_CLICK_COINS_6300 = "click_coins_6300";
    public const string KEY_CLICK_COINS_17000 = "click_coins_17000";

    //ON Complete
    public const string KEY_STARTR_PACK_COMPLETE = "starter_pack_complete";
    public const string KEY_REMOVE_ADS_COMPLETE = "remove_ads_complete";
    public const string KEY_COINS_25_COMPLETE = "coins_25_complete";
    public const string KEY_COINS_2900_COMPLETE = "coins_2900_complete";
    public const string KEY_COINS_240_COMPLETE = "coins_240_complete";
    public const string KEY_COINS_720_COMPLETE = "coins_720_complete";
    public const string KEY_COINS_1330_COMPLETE = "coins_1330_complete";
    public const string KEY_COINS_6300_COMPLETE = "coins_6300_complete";
    public const string KEY_COINS_17000_COMPLETE = "coins_17000_complete";


    //BOOSTERS
    //On CLick
    //retail
    public const string KEY_CLICK_HINT = "click_hint";
    public const string KEY_CLICK_BRANCH = "click_branch";
    public const string KEY_CLICK_BACK = "click_back";
    //Combo
    public const string KEY_CLICK_COMBO_HINT = "click_combo_hint";
    public const string KEY_CLICK_COMBO_BRANCH = "click_combo_branch";
    public const string KEY_LICK_COMBO_BACK = "click_combo_back";
    //Buy succsess
    //retail
    public const string KEY_BUY_SUCCSES_HINT = "buy_succses_hint";
    public const string KEY_BUY_SUCCSES_BRANCH = "buy_succses_branch";
    public const string KEY_BUY_SUCCSES_BACK = "buy_succses_back";

    //Combo
    public const string KEY_BUY_SUCCSES_COMBO_HINT = "buy_succses_combo_hint";
    public const string KEY_BUY_SUCCSES_COMBO_BRANCH = "buy_succses_combo_branch";
    public const string KEY_BUY_SUCCSES_COMBO_BACK = "buy_succses_combo_back";
    #endregion

    #region BUTTON
    public const string KEY_CLICK_BUTTON_HOME = "click_button_home";
    public const string KEY_CLICK_BUTTON_ADD_COIN = "click_button_add_coin";

    public const string KEY_CLICK_BUTTON_SETTINGS = "click_button_settings";
    public const string KEY_CLICK_SAVE_PROGRESS = "click_save_progress";
    public const string KEY_CLICK_RATE = "click_rate";
    public const string KEY_CLICK_CLAIM_COIN = "claim_coin";
    public const string KEY_CLICK_BUTTON_SHOP = "click_button_shop";

    public const string KEY_LEVEL_NEXT = "level_next";
    public const string KEY_NO_THANKS_GET_FREE_COIN = "no_thanks_get_free_coin";
    #endregion

    public const string KEY_LOGIN_FB_COMPLETE = "login_FB_complete";


    //ADS
    public const string KEY_ADS_INTER_CLOSED = "ads_inter_closed";
    public const string KEY_ADS_INTER_SHOW = "ads_inter_show";
    public const string KEY_ADS_REWARDED_SHOW = "ads_rewarded_show";
    public const string KEY_ADS_REWARDED_COMPLETE = "ads_rewarded_complete";
    #endregion

    #region UserEngagement
    public const string EVENT_LEVEL_PLAY = "event_level_play";
    public const string EVENT_LEVEL_LOSE = "event_level_lose";
    public const string EVENT_LEVEL_WIN = "event_level_win";
    public const string EVENT_LEVEL_WIN_AT_FIRST_TRY = "event_level_win_at_first_try";
    public const string EVENT_LEVEL_WIN_WITHOUT_BOOSTER_USAGE = "event_level_win_without_booster_usage";
    public const string EVENT_SPEND_COIN = "event_spend_coin";
    public const string EVENT_USE_BOOSTER = "event_use_booster";
    public const string EVENT_IAP_SHOWN = "event_iap_shown";
    public const string EVENT_IAP_CLICKED = "event_iap_clicked";
    public const string EVENT_IAP_COMPLETED = "event_iap_completed";
    #endregion

    #region Toast
    public const string KEY_NOT_CONNECT_RANKING = "SOMETHING WRONG! TRY AGAIN LATER!";
    public const string KEY_NOT_HAVE_COIN = "YOU DON'T HAVE ENOUGH COIN";
    #endregion

    #region Daily Quest
    //Data key
    public const string KEY_SAVE_DAILY_QUEST = "daily quest";
    //Name Quest
    public const string QUEST_COMPLETE_LEVEL = "CompleteLevel";
    public const string QUEST_ONLINE_TIME = "OnLineTime";
    public const string QUEST_USE_UNDO = "UseUndo";
    public const string QUEST_USE_BRANCH = "UseBranch";
    public const string QUEST_USE_HINT = "UseHint";
    public const string QUEST_COMPLETE_SORT = "Complete Sort";
    public const string QUEST_WATCH_ADS = "WatchAds";
    public const string QUEST_RETRY_LEVEL = "RetryLevel";
    public const string QUEST_MOVE_BIRD = "MoveBird";
    public const string QUEST_COMPLETE_MISSION = "CompleteMission";
    #endregion

    #region Achiviement
    //Data key
    public const string KEY_SAVE_UNLOCKSKIN = "Save UnlockSkin";
    public const string KEY_SAVE_ACHIVIEMENT = "Save achiviement";
    public const string KEY_SAVE_CONSECUTIVE_DAY = "Save new day";
    public const string KEY_CAN_COUNT_DOWN = "Can_count_down";
    //Name Achiviement
    public const string Conqueror = "Conqueror";
    public const string Perfectionist = "Perfectionist";
    public const string Fast_and_Furious = "Fast and Furious";
    public const string Master_of_Calculation = "Master of Calculation";
    public const string Undefeated_Genius = "Undefeated Genius";
    public const string Self_Reliance = "Self-Reliance";
    public const string Try_Hard = "Try Hard";
    public const string Fashionista = "Fashionista";
    public const string Migratory_Birds = "Migratory Birds";
    public const string Homecoming_Birds = "Homecoming Birds";
    public const string New_Friends = "New Friends";
    public const string Victor_Passing_Branches = "Victor Passing Branches";
    public const string Victor_United = "Victor United";
    public const string Flick_Passing_Branches = "Flick Passing Branches";
    public const string Flick_United = "Flick United";
    public const string Billy_Passing_Branches = "Billy Passing Branches";
    public const string Billy_United = "Billy United";
    public const string Holla_Passing_Branches = "Holla Passing Branches";
    public const string Holla_United = "Holla United";
    public const string Charlie_Passing_Branches = "Charlie Passing Branches";
    public const string Charlie_United = "Charlie United";
    public const string Mark_Passing_Branches = "Mark Passing Branches";
    public const string Mark_United = "Mark United";
    public const string Fred_Passing_Branches = "Fred Passing Branches";
    public const string Fred_United = "Fred United";
    public const string Laura_Passing_Branches = "Laura Passing Branches";
    public const string Laura_United = "Laura United";
    public const string Lily_Passing_Branches = "Lily Passing Branches";
    public const string Lily_United = "Lily United";
    public const string Trevor_Passing_Branches = "Trevor Passing Branches";
    public const string Trevor_United = "Trevor United";
    public const string Lex_Passing_Branches = "Lex Passing Branches";
    public const string Lex_United = "Lex United";
    public const string Thomas_Passing_Branches = "Thomas Passing Branches";
    public const string Thomas_United = "Thomas United";
    public const string Un_Box = "Un Box";
    public const string Login = "Login";
    public const string Big_Earner = "Big Earner";
    public const string Consistency_is_Key = "Consistency is Key";
    public const string Addicted = "Addicted";
    public const string Finding_Help_Hints = "Finding Help: Hints";
    public const string Using_Help_Hints = "Using Help: Hints";
    public const string Finding_Help_More_Branch = "Finding Help: More Branch";
    public const string Using_Help_More_Branch = "Using Help: More Branch";
    public const string Finding_Help_Back = "Finding Help: Back";
    public const string Using_Help_Back = "Using Help: Back";
    #endregion

    #region Moon Festival Pack
    public const string KEY_MOON_FESTIVAL = "Moon Festival";
    public const string KEY_MOON_RABBIT = "Moon Rabbit";
    public const string KEY_MOON_GODDESS = "Moon Goddess";
    #endregion

    #region Noti Event
    public const string KEY_ID_EVENT_CURRENT = "id_event_current";
    public const string KEY_RECEIVED_EVENT = "received_event";
    #endregion
}
