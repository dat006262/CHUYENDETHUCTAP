﻿using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [Header("---UI---")]
    [SerializeField] TMP_Text loadingPercent;
    [SerializeField] GameObject logo;
    [SerializeField] TMP_Text versionBuild;
    [SerializeField] Slider _slider;
    [SerializeField] Image i_BG;
    [SerializeField] Sprite _bgMoonFestival;

    //[SerializeField] private DailyService _DailyService;

    private int percent;
    float loadTime = 1.5f;

    void Start()
    {
        InitInfor();
        LogoAnim();
        StartCoroutine(Load());

        //  DisPlayBG();
        //   Debug.LogError($"width: {Screen.width} height: {Screen.height}");
    }

    private void InitInfor()
    {
        versionBuild.text = /*GameLanguage.Get("txt_version") +*/ $" {Application.version} - " /*+ GameLanguage.Get("txt_build_number") + $" {GlobalSetting.Instance.GetBuildNumber()}"*/;
    }

    IEnumerator Load()
    {
        int ran = UnityEngine.Random.Range(75, 90);
        while (percent < 150)
        {
            percent++;
            _slider.value = (float)percent / 100;

            if (percent == ran)
            {
                //if (!DataManager.UserTutorialData.isShowTutSurvey)  // Hiển thị popup Survey
                //{
                //    PopupSurveyPlayer.Instance.Show();
                //    yield return new WaitUntil(() => DataManager.UserTutorialData.isShowTutSurvey);
                //}

                yield return new WaitForSecondsRealtime(0.5f);
            }
            loadingPercent.text = (percent >= 100) ? "100%" : $"{percent}%";
            yield return new WaitForSeconds(0.01f);
        }
        //if (!PlayerPrefs.HasKey(Const.USER_FIRST_TIME_OPEN))
        //{
        //    PlayerData.Instance.FirstTimeOpen = DateTime.Now;
        //    PlayerData.Instance.GameLoginDay = 0;
        //}
        //else
        //{
        //    TimeSpan _timeFromFirstOpen = DateTime.Now.StartOfDay() - DateTime.Parse(PlayerData.Instance.FirstTimeOpen.StartOfDay().ToString());
        //    int _dayFromFirstOpen = (int)_timeFromFirstOpen.Days;
        //    if (_dayFromFirstOpen > PlayerData.Instance.GameLoginDay) PlayerData.Instance.GameLoginDay = _dayFromFirstOpen;
        //}
        //_DailyService.HandleDailyServiceTime();
        //if (PlayerData.Instance.HighestLevel >= 5)
        //{
        //    AddressablesManager.Instance.LoadAddressableScene(Const.SCENE_HOME);
        //}
        //else
        //{
        //    AddressablesManager.Instance.LoadAddressableScene(Const.SCENE_GAME);
        //}
        SoundManager.Instance.PlayGameMusic();
    }

    private void LogoAnim()
    {
        logo.transform.DOLocalMoveY(logo.transform.localPosition.y + 32f, loadTime).SetEase(Ease.OutQuad).SetLoops(-1, LoopType.Yoyo).SetDelay(0.1f);
    }

    private void DisPlayBG()
    {
        //if (DHome.IsTimeChristMas())
        //{
        //    i_BG.sprite = _bgMoonFestival;
        //}
    }
}