using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChosseStatusBtn : BaseButton
{
    public StatusGame.STATUS chosseStatus;
    [SerializeField] private GameObject _highlight;
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    public override void Start()
    {
        base.Start();
    }
    protected override void OnClick()
    {
        FillPixel.Instance.status = chosseStatus;
        GameManager.Instance.getColorButtonNow.TurnOffHighLight();
    }
    /*  private void TurnOffHighLight()
      {
          _highlight.SetActive(false);
      }*/
}
