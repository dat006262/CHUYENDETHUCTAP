
using System.Collections.Generic;
//using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int TestSize = 50;
    //-------------------GamePlay----------//
    [HideInInspector] public int idNow;
    [HideInInspector] public Color colorNow;
    //----------------------------------//
    public class Node
    {
        public bool isDrawBomb;
        public bool isCheckDrawStick;
        public UnityEngine.Color colorWrongNow;
        public bool filledTrue;
        public Vector2Int position;
        public UnityEngine.Color color;
        public int id;
        public Color graycolor => Color.Lerp(new Color(1 * color.grayscale, 1 * color.grayscale, 1 * color.grayscale, 1), Color.white, 0.0f);
    }
    public static GameManager Instance { get; private set; }
    /*[HideInInspector]*/
    public Sprite sprite;
    [HideInInspector] public Texture2D textureTrue;
    //-------------------//
    //-------------------//
    public Tilemap tileMapLine;
    public Tilemap tileMapRenColor;
    public Tilemap tileMapHighLight;
    public Tilemap tilemapNumber;
    public Tilemap tileMapWhiteRenColor;
    //-----------RenMap-----//

    [SerializeField] public Tile _smallTile;
    [SerializeField] public Tile _lineBigTile;
    public List<Tile> number;
    //-------SavePixel-------//
    private int _countColor;
    Dictionary<Color, int> _color_ID = new Dictionary<Color, int>();
    public Dictionary<int, List<Node>> _allPixelGroups = new Dictionary<int, List<Node>>();
    [HideInInspector] public Dictionary<Vector2Int, Node> allPixels;
    //---------SaveGetColorButton-------------//
    [HideInInspector] public int totalPage;
    [SerializeField] private GameObject pageParent;
    [SerializeField] private GameObject pageprefabs;
    [SerializeField] private GetColorButton getColorButtonPrefabs;
    public List<GetColorButton> allGetColorButton = new List<GetColorButton>();
    public PageColorSwipe pageColorSwipe;
    private GameObject pageNotFull;
    public Canvas canvas;
    //---------------HighLight------------//
    [HideInInspector] public GetColorButton getColorButtonNow;
    [HideInInspector] public List<Node> PixelsNow => _allPixelGroups[getColorButtonNow.id];
    //----------------Zoom--------------------//
    [SerializeField] private Slider slider;

    void Awake()
    {
        slider.onValueChanged.AddListener(OnslideValueChange);
        Instance = this;
    }
    void OnslideValueChange(float value)
    {
        tileMapRenColor.color = new Color(1, 1, 1, Mathf.Clamp(1 - value, 0, 0.6f));
        tilemapNumber.color = new Color(1, 1, 1, value);
        tileMapHighLight.color = new Color(1, 1, 1, 1 - value * 0.5f);

    }
    private void Start()
    {
        NewGame(GameConfig.Instance.spriteInGame);

        /*        idNow = allGetColorButton[0].id;
                colorNow = allGetColorButton[0].color;*/
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void ClearAll()
    {

    }
    public void NewGame(Sprite input)
    {
        Debug.Log("NEWGAME WITH" + input.name);

        textureTrue = ChangeTexture(input, TestSize);//tao anh 50*50dung format
        if (!DataManager.Instance.dataInProgress.matrix.ContainsKey(input.name))
        {
            DataManager.Instance.dataInProgress.AddMatrix(input.name, new bool[textureTrue.width, textureTrue.height]);
        }
        CreatePixelMap(textureTrue);
        CreateGetColotButton();
        getColorButtonNow = allGetColorButton[0];
        getColorButtonNow.UpdateGamePlay();
        getColorButtonNow.TurnOnHighLight();
        FillPixel.Instance.LoadFilled();
    }

    Texture2D ChangeTexture(Sprite sprite, int size)
    {
        return TextureChange.Bilinear(sprite.texture, size, size);//thay doi kich thuoc anh
    }
    void CreatePixelMap(Texture2D texture)
    {
        #region Reset
        pageColorSwipe.totalPages = 1;
        allPixels = new Dictionary<Vector2Int, Node>();
        _color_ID = new Dictionary<Color, int>();
        _allPixelGroups = new Dictionary<int, List<Node>>();
        _allPixelGroups.Clear();

        _countColor = 1;
        allGetColorButton = new List<GetColorButton>();
        #endregion

        #region GetColor[] colors

        Color[] colors = texture.GetPixels();
        for (int i = 0; i < colors.Length; i++)
        {
            if (colors[i].a >= 0.5f)
            {
                colors[i] = new Color(ColorHelp.RoundColor(colors[i].r, 0.25f), ColorHelp.RoundColor(colors[i].g, 0.25f), ColorHelp.RoundColor(colors[i].b, 0.25f));
            }
        }
        #endregion

        #region RenTileMap

        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                if (colors[x + y * texture.width].a >= 0.5f)
                {
                    //tao node
                    Node pixel = new Node()
                    {
                        isDrawBomb = false,
                        isCheckDrawStick = false,

                        colorWrongNow = new Color(1, 1, 1, 0),
                        filledTrue = false,
                        position = new Vector2Int(x, y),
                        color = colors[x + y * texture.width],
                        id = 0
                    };
                    allPixels.Add(new Vector2Int(x, y), pixel);
                    CreatePixel(tileMapRenColor, pixel.position, pixel.graycolor, _smallTile);
                    CreatePixel(tileMapWhiteRenColor, pixel.position, Color.white, _smallTile);
                    CreatePixel(tileMapLine, pixel.position, Color.black, _lineBigTile);

                    //ID Color
                    if (!_color_ID.ContainsKey(colors[x + y * texture.width]))//mau moi
                    {
                        allPixels[new Vector2Int(x, y)].id = _countColor;
                        _color_ID.Add(colors[x + y * texture.width], _countColor);
                        _allPixelGroups.Add(_countColor, new List<Node>());
                        _allPixelGroups[_countColor].Add(pixel);
                        CreatePixel(tilemapNumber, pixel.position, Color.black, number[_countColor - 1]);
                        _countColor++;

                    }
                    else//mau cu
                    {
                        int foundId = _color_ID.GetValueOrDefault(colors[x + y * texture.width]);
                        allPixels[new Vector2Int(x, y)].id = foundId;
                        _allPixelGroups[foundId].Add(pixel);
                        CreatePixel(tilemapNumber, pixel.position, Color.black, number[foundId - 1]);

                    }

                }
            }
        }
        #endregion
    }
    void CreatePixel(Tilemap tileMap, Vector2Int position, Color color, Tile tilePrefabs)
    {

        Vector3Int cell = new Vector3Int(position.x, position.y, 0);
        tileMap.SetTile(cell, tilePrefabs);
        tileMap.SetTileFlags(cell, TileFlags.None);
        tileMap.SetColor(cell, color);
    }
    void CreateGetColotButton()
    {
        int countGetColorBtn = _color_ID.Count;
        totalPage = (_countColor - 1) / 10 + 1;
        if ((_countColor - 1) % 10 == 0)
        {
            totalPage = (_countColor - 1) / 10;
        }
        //-------------------------//
        pageColorSwipe.totalPages = totalPage + 1;
        pageColorSwipe.currentPage = 2;
        //-------------------------//
        int i = 1;
        foreach (KeyValuePair<Color, int> c in _color_ID)
        {


            if (i % 10 == 1)
            {
                GameObject x = Instantiate(pageprefabs, pageParent.transform);
                x.name = "page" + i / 10 + 1;
                x.transform.position = x.transform.position + new Vector3(Screen.width, 0, 0) * (i / 10);
                // x.GetComponent<GridLayoutGroup>().cellSize = new Vector2(Screen.width / 5, Screen.width / 5);
                pageNotFull = x;
            }
            GetColorButton getColorBtn = Instantiate(getColorButtonPrefabs, pageNotFull.transform);
            getColorBtn.name = "Button" + c.Value.ToString();
            getColorBtn.color = c.Key;
            getColorBtn.id = c.Value;
            allGetColorButton.Add(getColorBtn);
            i++;
        }

        /* for (int i = 1; i <= totalPage; i++)
         {
             GameObject x = Instantiate(pageprefabs, pageParent.transform);
             x.name = "page" + i;
             x.transform.position = x.transform.position + new Vector3(Screen.width, 0, 0) * (i - 1);
             for (int k = (i - 1) * 10; k < i * 10; k++)
             {
                 if (k >= allGetColorButton.Count) break;

                 allGetColorButton[k].transform.SetParent(x.transform);
             }
         }*/

    }
    public void CreateHighLighMap(bool turn)
    {

        for (int i = 0; i < PixelsNow.Count; i++)
        {
            if (!PixelsNow[i].filledTrue && turn)//bat highlight
            {
                CreatePixel(tileMapHighLight, PixelsNow[i].position, new Color(220 / 255, 220 / 255, 220 / 255, 0.5f), _lineBigTile);
            }
            else
                 if (!PixelsNow[i].filledTrue && !turn)//off highlight
            {
                ActionDraw.DeletePixel(tileMapHighLight, PixelsNow[i].position);
            }
        }
    }
}
public static class ColorHelp
{
    public static float RoundColor(float input, float step)

    {
        if (input % step >= step / 2)
            return step * ((int)(input / step) + 1);
        else return step * ((int)(input / step));

    }

}
