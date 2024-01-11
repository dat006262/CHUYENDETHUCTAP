using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows;

public class OpenGamePlayBtn : BaseButton
{
    [Header("DataToOpenGame")]
    public Sprite spriteSource = null;
    [Header("Referent")]
    public Image Image;
    public ImageStat imageStat;
    public GameObject ImageComplete;
    public override void Start()
    {
        base.Start();
        LoadImageRenderer();

    }
    protected override void OnClick()
    {
        if (imageStat.Equals(ImageStat.COMPLETE)) { return; }

        SceneManager.LoadScene("GamePlay");
        GameConfig.Instance.spriteInGame = spriteSource;
    }
    public void LoadImageRenderer()
    {
        Texture2D textureTrue = TextureChange.Bilinear(spriteSource.texture, 50, 50); ;//tao anh 50*50dung format
        textureTrue.filterMode = FilterMode.Point;
        Sprite create = Sprite.Create(textureTrue, new Rect(0, 0, textureTrue.width, textureTrue.height), Vector2.one * 0.5f);
        create.name = spriteSource.name;


        if (imageStat.Equals(ImageStat.INPROGRESS))
        {
            Sprite blackwhite = TextureChange.CreatBlackAndWhiteSpriteDrawed(create);
            Image.sprite = blackwhite;
        }
        else if (imageStat.Equals(ImageStat.COMPLETE))
        {
            Image.sprite = create;
            ImageComplete.SetActive(true);
        }
        else
        {
            Sprite blackwhite = TextureChange.CreatBlackAndWhiteSprite(create);
            Image.sprite = blackwhite;
        }
    }
}
