
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class ActionDraw
{

    public static void FillTrue(Vector2Int input, Tilemap tileMapRenColor, Tilemap tileMapLine, Tilemap tilemapNumber, Tilemap tilemapWhiteRenColor)
    {

        if (GameManager.Instance.allPixels[input].filledTrue) { return; }
        CammeraMove.intances.canMoveCam = false;
        int id = GameManager.Instance.allPixels[input].id;
        //Đổi màu phần màu trắng thành màu đúng
        CreatePixel(tilemapWhiteRenColor, input, GameManager.Instance.allPixels[input].color, GameManager.Instance._lineBigTile);
        //Loại bỏ phần viền, phần số, phần làm nổi bật và phần màu xám
        DeletePixel(tileMapLine, input);
        DeletePixel(tilemapNumber, input);
        DeletePixel(GameManager.Instance.tileMapHighLight, input);
        DeletePixel(tileMapRenColor, input);

        GameManager.Instance.allPixels[input].filledTrue = true;

        DataManager.Instance.dataInProgress.SetMatrix(GameConfig.Instance.spriteInGame.name, input.x, input.y);
        GameManager.Instance.allGetColorButton[id - 1].slide.fillAmount = CheckProgressId(id);
        if (CheckCompleteId(id)) { GameManager.Instance.allGetColorButton[id - 1].tickCompelete.enabled = true; }
        if (CheckCompleteAllColor())
        {
            DataManager.Instance.dataInProgress.SetImageStatComplete(GameConfig.Instance.spriteInGame.name);
            Debug.Log("WIM");
            InterstitialAdExample.intances.LoadAd();
            SceneManager.LoadScene("HomeUI");

        }

        //  Debug.Log("FillTrue");
    }
    public static void FillWrong(Vector2Int input, Tilemap tileMapRenColor)
    {
        if (GameManager.Instance.allPixels[input].filledTrue) { return; }
        if (GameManager.Instance.allPixels[input].colorWrongNow == GameManager.Instance.colorNow) return;

        Color _color = Color.Lerp(GameManager.Instance.colorNow, GameManager.Instance.allPixels[input].color, 0.5f);
        CreatePixel(GameManager.Instance.tileMapWhiteRenColor, input, _color, GameManager.Instance._smallTile);
        //  DeletePixel(GameManager.Instance.tileMapWhiteRenColor, input);
        GameManager.Instance.allPixels[input].colorWrongNow = GameManager.Instance.colorNow;
    }
    public static void CreatePixel(Tilemap tileMap, Vector2Int position, Color color, Tile tilePrefabs)
    {

        Vector3Int cell = new Vector3Int(position.x, position.y, 0);
        tileMap.SetTile(cell, tilePrefabs);
        tileMap.SetTileFlags(cell, TileFlags.None);
        tileMap.SetColor(cell, color);
    }
    public static void DeletePixel(Tilemap tileMap, Vector2Int position)
    {
        Vector3Int cell = new Vector3Int(position.x, position.y, 0);
        tileMap.SetTile(cell, null);
    }
    public static void FillBoomb(Vector2Int input, Tilemap tileMapRenColor, Tilemap tileMapLine,
        Tilemap tilemapNumber, Tilemap tilemapWhiteRenColor)
    {
        if (GameManager.Instance.allPixels[input].isDrawBomb) return;
        else GameManager.Instance.allPixels[input].isDrawBomb = true;

        for (int m = input.x - 5; m <= input.x + 5; m++)
        {
            for (int n = input.y - 5; n <= input.y + 5; n++)
            {
                //Kiểm tra viền 
                if (m < 0 || m >= GameManager.Instance.textureTrue.width) continue;
                if (n < 0 || n >= GameManager.Instance.textureTrue.height) continue;
                if (!GameManager.Instance.allPixels.ContainsKey(new Vector2Int(m, n)))
                {
                    continue;
                }
                //Đường kính bình phương <=26
                if (Math.Pow(input.x - m, 2) + Math.Pow(input.y - n, 2) <= 26)
                {
                    if (1 == 1)
                    {
                        if (!GameManager.Instance.allPixels[new Vector2Int(m, n)].filledTrue)
                        {
                            FillTrue(new Vector2Int(m, n), tileMapRenColor, tileMapLine, tilemapNumber,
                                tilemapWhiteRenColor);
                            //Fill
                        }
                    }
                }

            }
        }
    }

    public static void DrawAround(Vector2Int input, Tilemap tileMapRenColor, Tilemap tileMapLine,
        Tilemap tilemapNumber, Tilemap tilemapWhiteRenColor)
    {
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
                ///kiem tra xong
                /////Thực hiện đệ quy để liên tục tô các ô bên cạnh
                if (GameManager.Instance.allPixels[new Vector2Int(m, n)].id == id)
                {
                    //id giong
                    if (!GameManager.Instance.allPixels[new Vector2Int(m, n)].filledTrue)//chua to thi lay lan dc
                    {
                        FillTrue(new Vector2Int(m, n), tileMapRenColor, tileMapLine, tilemapNumber, tilemapWhiteRenColor);
                        DrawAround(new Vector2Int(m, n), tileMapRenColor, tileMapLine, tilemapNumber, tilemapWhiteRenColor);

                    }
                    else if (GameManager.Instance.allPixels[new Vector2Int(m, n)].filledTrue
                        && !GameManager.Instance.allPixels[new Vector2Int(m, n)].isCheckDrawStick)
                    {
                        GameManager.Instance.allPixels[new Vector2Int(m, n)].isCheckDrawStick = true;
                        DrawAround(new Vector2Int(m, n), tileMapRenColor, tileMapLine, tilemapNumber, tilemapWhiteRenColor);

                    }
                }

            }
        }
    }


    private static bool CheckCompleteAllColor()
    {
        foreach (GetColorButton btn in GameManager.Instance.allGetColorButton)
        {
            if (!btn.tickCompelete.enabled)
                return false;
        }
        return true;
    }
    public static float CheckProgressId(int id)
    {
        float a = 0;
        foreach (GameManager.Node px in GameManager.Instance._allPixelGroups[id])
        {
            if (px.filledTrue)
            {
                a++;
            }

        }
        return (a / GameManager.Instance._allPixelGroups[id].Count);
    }

    private static bool CheckCompleteId(int id)
    {
        foreach (GameManager.Node px in GameManager.Instance._allPixelGroups[id])
        {
            if (!px.filledTrue)
                return false;
        }
        return true;
    }

}

