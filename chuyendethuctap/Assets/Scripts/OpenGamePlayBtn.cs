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
    public int size = 50;
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
        GlobalSetting.Instance.SizeTextureLevel = size;
        SoundManager.Instance.PlaySfxRewind(Resources.Load<AudioClip>("Sounds/tap"));

        //  SceneManager.LoadScene("GamePlay");
        LoadingScene.Instance.LoadScene("GamePlay");
        GameConfig.Instance.spriteInGame = spriteSource;
    }
    public void LoadImageRenderer()
    {
        Texture2D textureTrue = TextureChange.Bilinear(spriteSource.texture, size, size); ;//tao anh 50*50dung format
        textureTrue.filterMode = FilterMode.Point;
        Sprite create = Sprite.Create(textureTrue, new Rect(0, 0, textureTrue.width, textureTrue.height), Vector2.one * 0.5f);
        create.name = spriteSource.name;


        if (imageStat.Equals(ImageStat.INPROGRESS))
        {
            Sprite blackwhite = TextureChange.CreatBlackAndWhiteSpriteDrawed(create);
            blackwhite.texture.wrapMode = UnityEngine.TextureWrapMode.Clamp;
            blackwhite.texture.filterMode = FilterMode.Point;
            Image.sprite = blackwhite;
        }
        else if (imageStat.Equals(ImageStat.COMPLETE))
        {
            Image.sprite = create;
            create.texture.filterMode = FilterMode.Point;
            create.texture.wrapMode = UnityEngine.TextureWrapMode.Clamp;
            create.texture.filterMode = FilterMode.Point;
            ImageComplete.SetActive(true);
        }
        else
        {
            Sprite blackwhite = TextureChange.CreatBlackAndWhiteSprite(create);
            blackwhite.texture.filterMode = FilterMode.Point;
            Image.sprite = blackwhite;
        }
    }
}
