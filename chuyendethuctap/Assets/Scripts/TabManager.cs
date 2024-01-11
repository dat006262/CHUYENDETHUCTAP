using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tab
{
    LIBRARY,
    DRAWED,
    CREATE
}
public enum DRAWEDTAB
{
    INPROGRESS,
    ONCOMPLETE
}
public class TabManager : MonoBehaviour
{
    public Tab tab = Tab.LIBRARY;
    public List<GameObject> listTab = new List<GameObject>();
    public DRAWEDTAB dRAWEDTAB = DRAWEDTAB.INPROGRESS;
    public List<GameObject> listDrawedTab = new List<GameObject>();
    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }
    //public void OpenTab(Tab tab)
    //{
    //    switch (tab)
    //    {
    //        case Tab.LIBRARY: break;
    //        case Tab.DRAWED: break;
    //        case Tab.CREATE: break;
    //        default: break;
    //    }
    //}
    public void CloseTab()
    {
        foreach (var tab in listTab)
        {
            tab.SetActive(false);
        }
    }
    public void CloseDrawedTab()
    {
        foreach (var tab in listDrawedTab)
        {
            tab.SetActive(false);
        }
    }

}
