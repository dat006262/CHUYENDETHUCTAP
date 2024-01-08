using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetColorButton : BaseButton
{
    [HideInInspector] public int id;
    [HideInInspector] public Color color;
    [SerializeField] public TextMeshProUGUI textMeshPro;
    private StatusGame.STATUS chosseStatus = StatusGame.STATUS.NORMAL;
    public Image backGroundSlide;
    public Image slide;
    public Image tickCompelete;
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    public override void Start()
    {
        base.Start();
        this.GetComponent<Image>().color = color;
        slide.color = color;

        textMeshPro.text = id.ToString();
        if (color.grayscale <= 0.5f)//color la black
        {
            //this.BackgroundSlide.color = Color.white;
            textMeshPro.color = Color.white;
            backGroundSlide.color = Color.white;
        }
        else
        {
            // this.BackgroundSlide.color = Color.black;
            textMeshPro.color = Color.black;
            backGroundSlide.color = Color.black;
        }
    }
    protected override void OnClick()
    {
        UpdateGamePlay();
        HighLight();
    }
    public void UpdateGamePlay()
    {
        FillPixel.Instance.status = chosseStatus;
        GameManager.Instance.colorNow = color;
        GameManager.Instance.idNow = id;
    }
    void HighLight()
    {
        GameManager.Instance.getColorButtonNow.TurnOffHighLight();
        GameManager.Instance.getColorButtonNow = this;
        TurnOnHighLight();
    }
    public void TurnOffHighLight()
    {
        textMeshPro.fontSizeMax = 72;
        backGroundSlide.enabled = false;
        slide.enabled = false;
        GameManager.Instance.CreateHighLighMap(false);
    }
    public void TurnOnHighLight()
    {
        textMeshPro.fontSizeMax = 90;
        backGroundSlide.enabled = true;
        slide.enabled = true;
        GameManager.Instance.CreateHighLighMap(true);
    }

}
