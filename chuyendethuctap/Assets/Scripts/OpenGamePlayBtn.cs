using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
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


    }
    IEnumerator IEOnClick()
    {
        LoadingScene.Instance.loadingSceneGameObject.SetActive(true);
        LoadingScene.Instance.fill.fillAmount = 0;
        yield return new WaitForSeconds(1);
        OnClickWork();
    }
    protected override void OnClick()
    {
        if (imageStat.Equals(ImageStat.COMPLETE)) { return; }
        StartCoroutine(IEOnClick());
    }

    private void OnClickWork()
    {
        SoundManager.Instance.PlaySfxRewind(Resources.Load<AudioClip>("Sounds/tap"));
        //  SceneManager.LoadScene("GamePlay");
        GameConfig.Instance.spriteInGame = spriteSource;
        GameConfig.Instance.spriteGameSize = size;
        GameConfig.Instance.nowGameButton = this;

        GameControll.Instance.OpenGamePlay();
        GameManager.Instance.NewGame(GameConfig.Instance.spriteInGame);
        GlobalSetting.Instance.gameStat = GlobalSetting.GameStat.GAMEPLAY;
    }
    public void UpdateImageRender()
    {
        size = Mathf.Clamp(Mathf.Min(spriteSource.texture.width, spriteSource.texture.height), 10, 50);
        imageStat = DataManager.Instance.dataInProgress.AddImageStat(spriteSource.name);
        Debug.Log("UpdateImageRender;");
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
