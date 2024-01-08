using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenGamePlayBtn : BaseButton
{
    [Header("DataToOpenGame")]
    public Sprite sprite;
    [Header("Referent")]
    public Image Image;

    public override void Start()
    {
        base.Start();
        Image.sprite = sprite;
    }
    protected override void OnClick()
    {
        SceneManager.LoadScene("GamePlay");
        GameConfig.Instance.spriteInGame = sprite;
        //if (DataManager.dataInProgress.CheckImageDrawed(sprite.name))
        //{
        //    Debug.Log("Drawed");
        //}
        //else
        //{
        //    Debug.Log("NotDrawed");
        //}
    }

}
