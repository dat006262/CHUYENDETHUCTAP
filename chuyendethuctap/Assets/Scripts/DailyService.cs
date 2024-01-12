using System;
using UnityEngine;

public class DailyService : MonoBehaviour
{
    public void HandleDailyServiceTime()
    {
        DateTime nextDay = DateTime.Now.EndOfDay();
        if (!PlayerPrefs.HasKey(Const.TODAY_TIME_RESET))
        {
            LogResetDailyServices();
            PlayerPrefs.SetString(Const.TODAY_TIME_RESET, nextDay.ToString());
        }
        TimeSpan remainTime = DateTime.Parse(PlayerPrefs.GetString(Const.TODAY_TIME_RESET)) - DateTime.Now;
        if (remainTime.TotalSeconds < 0)
        {
            LogResetDailyServices();
            PlayerPrefs.SetString(Const.TODAY_TIME_RESET, nextDay.ToString());
        }
    }

    private void LogResetDailyServices()
    {
        Debug.LogError($"ResetDailyServices");
    }
}
