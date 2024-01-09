using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDataManager : MonoBehaviour
{
    public static ShowDataManager Instance;
    [Header("Refferent")]
    public RectTransform contentLibrary;
    public RectTransform contentInProgress;
    public RectTransform contentComplete;
    public RectTransform contentCreate;
    public OpenGamePlayBtn OpenGamePlayBtnPrefabs;

    private void Awake()
    {
        Instance = this;
    }
    public void SpawmLibrary_New(List<Sprite> sprites)
    {
        foreach (var sprite in sprites)
        {
            OpenGamePlayBtn openGamePlayBtn = Instantiate(OpenGamePlayBtnPrefabs, contentLibrary);
            openGamePlayBtn.sprite = sprite;
        }
    }

}
