using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
//using System.Drawing;
//using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
//using UnityEngine.Windows;

public class FillPixel : MonoBehaviour
{
    public bool isWorking = false;
    public static FillPixel Instance;
    //-------------------------//
    public Camera cam;
    //-------------------//

    public Tilemap tileMapLine;
    public Tilemap tileMapRenColor;
    public Tilemap tileMapHighLight;
    public Tilemap tilemapNumber;
    public Tilemap tilemapWhiteColorNumber;
    public static event System.Action<Vector2Int> onPoiterDown;
    public static event System.Action<Vector2Int> onPoiterHorver;
    //-------------------//
    public StatusGame.STATUS status = StatusGame.STATUS.NORMAL;
    private bool firstclicktrue = false;
    public List<Vector2Int> listTileDrawed;
    void Awake()
    {

        Instance = this;
        isWorking = false;
    }
    private void Update()
    {
        if (GlobalSetting.Instance.gameStat != GlobalSetting.GameStat.GAMEPLAY)
        {
            return;
        }
        if (isWorking) return;
        if (Input.GetMouseButtonDown(0))
        {
            InvokeWhenDown();
        }
        if (Input.GetMouseButton(0) && firstclicktrue)
        {
            InvokeWhenHorver();
        }
        if (Input.GetMouseButtonUp(0))
        {
            CammeraMove.intances.canMoveCam = true;
            firstclicktrue = false;
        }
    }
    void InvokeWhenDown()
    {
        //Đọc vị trí con trỏ chuột rồi làm tròn để đưa ra vị trí tileMap
        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        Vector3Int moucell = tileMapLine.WorldToCell(mouseWorldPos);
        Vector2Int coord = new Vector2Int { x = moucell.x, y = moucell.y };

        if (!GameManager.Instance.allPixels.ContainsKey(coord)) { return; }
        if (GlobalSetting.Instance.gameStat == GlobalSetting.GameStat.GAMEPLAY)
        {
            onPoiterDown?.Invoke(coord);
        }

    }
    void InvokeWhenHorver()
    {
        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        Vector3Int moucell = tileMapLine.WorldToCell(mouseWorldPos);
        Vector2Int coord = new Vector2Int { x = moucell.x, y = moucell.y }; //LUU TRI VI TRI CON TRO CHUOT

        if (!GameManager.Instance.allPixels.ContainsKey(coord)) { return; }
        if (GlobalSetting.Instance.gameStat == GlobalSetting.GameStat.GAMEPLAY)
        {
            onPoiterHorver?.Invoke(coord);
        }


    }

    //
    private void OnDisable()
    {
        onPoiterDown -= GetColorPixel;
        onPoiterHorver -= GetColorPixel;
    }

    private void OnEnable()
    {
        onPoiterDown += GetColorPixel;
        onPoiterHorver += GetColorPixel;
    }
    public void LoadInProgress()
    {
        Sprite input = GameConfig.Instance.spriteInGame;
        bool[,] matrix2 = DataManager.Instance.dataInProgress.GetMatrix(input.name);
        for (int x = 0; x < matrix2.GetLength(0); x++)
        {
            for (int y = 0; y < matrix2.GetLength(1); y++)
            {
                if (matrix2[x, y])
                {

                    ActionDraw.FillTrue(new Vector2Int(x, y), tileMapRenColor, tileMapLine, tilemapNumber, tilemapWhiteColorNumber);


                }
            }
        }

    }
    private void GetColorPixel(Vector2Int coord)
    {
        if (isWorking) return;

        isWorking = true;
        if (status == StatusGame.STATUS.NORMAL)
        {
            if (GameManager.Instance.allPixels.ContainsKey(coord))
            {
                //Kiểm tra xem màu của ô chứa màu và màu của ô cần tô có giống nhau không
                //Nếu giống tô màu đúng; Nếu sai tô màu sai
                if (CheckColor(GameManager.Instance.allPixels[coord].color))
                {

                    ActionDraw.FillTrue(coord, tileMapRenColor, tileMapLine, tilemapNumber, tilemapWhiteColorNumber);
                    if (!firstclicktrue) firstclicktrue = true;

                }
                else
                {
                    if (firstclicktrue)
                    {
                        ActionDraw.FillWrong(coord, tileMapRenColor);
                    }
                }
            }
            isWorking = false;
        }
        else if (status == StatusGame.STATUS.BOMB)
        {

            if (!firstclicktrue) firstclicktrue = true;
            ActionDraw.FillBoomb(coord, tileMapRenColor, tileMapLine, tilemapNumber, tilemapWhiteColorNumber);
            isWorking = false;
        }
        else if (status == StatusGame.STATUS.STICK)
        {
            if (!firstclicktrue) firstclicktrue = true;
            //StartCoroutine(IE_DrawAround(coord, tileMapRenColor, tileMapLine, tilemapNumber, tilemapWhiteColorNumber));
            ActionDraw.DrawAround(coord, tileMapRenColor, tileMapLine, tilemapNumber, tilemapWhiteColorNumber);
            isWorking = false;
        }

    }
    int start = 0;
    int end = 0;
    public IEnumerator IE_DrawAround(Vector2Int input, Tilemap tileMapRenColor, Tilemap tileMapLine, Tilemap tilemapNumber, Tilemap tilemapWhiteRenColor)
    {
        start++;
        int id = GameManager.Instance.allPixels[input].id;

        for (int m = input.x - 1; m <= input.x + 1; m++)
        {
            for (int n = input.y - 1; n <= input.y + 1; n++)
            {
                if (m < 0 || m >= GameManager.Instance.textureTrue.width) continue;
                if (n < 0 || n >= GameManager.Instance.textureTrue.height) continue;
                if (!GameManager.Instance.allPixels.ContainsKey(new Vector2Int(m, n)))
                {
                    continue;
                }
                if (GameManager.Instance.allPixels[new Vector2Int(m, n)].id == id)
                {
                    //id giong
                    if (!GameManager.Instance.allPixels[new Vector2Int(m, n)].filledTrue)//chua to thi lay lan dc
                    {
                        ActionDraw.FillTrue(new Vector2Int(m, n), tileMapRenColor, tileMapLine, tilemapNumber, tilemapWhiteRenColor);
                        yield return new WaitForEndOfFrame();

                        StartCoroutine(IE_DrawAround(new Vector2Int(m, n), tileMapRenColor, tileMapLine, tilemapNumber, tilemapWhiteRenColor));
                    }
                    else if (GameManager.Instance.allPixels[new Vector2Int(m, n)].filledTrue && !GameManager.Instance.allPixels[new Vector2Int(m, n)].isCheckDrawStick)
                    {
                        GameManager.Instance.allPixels[new Vector2Int(m, n)].isCheckDrawStick = true;
                        yield return new WaitForEndOfFrame();

                        StartCoroutine(IE_DrawAround(new Vector2Int(m, n), tileMapRenColor, tileMapLine, tilemapNumber, tilemapWhiteRenColor));

                    }
                }
            }
        }

        end++;
        if (end == start)
        {
            isWorking = false;
        }
    }

    private bool CheckColor(Color input)
    {
        if (input == GameManager.Instance.colorNow) return true;
        else return false;
    }

}

public class StatusGame
{
    public STATUS status = STATUS.NORMAL;
    public enum STATUS
    {
        NORMAL,
        STICK,
        BOMB
    }

}
