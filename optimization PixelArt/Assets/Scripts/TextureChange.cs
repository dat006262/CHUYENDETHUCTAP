using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif 
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.U2D;
using UnityEngine.Windows;

public class TextureChange : MonoBehaviour
{

    public static Texture2D ChangeToTexture2D(Texture input)
    {
        Texture texture = input;
        RenderTexture renderTexture = new RenderTexture(texture.width, texture.height, 0, RenderTextureFormat.ARGB32);
        RenderTexture.active = renderTexture;
        Graphics.Blit(texture, renderTexture);
        Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.ARGB32, false);
        texture2D.filterMode = FilterMode.Point;
        texture2D.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
        texture2D.Apply();
        RenderTexture.active = null;
        GameObject.Destroy(renderTexture);
        return texture2D;
    }
    public static Sprite CreatBlackAndWhiteSprite(Sprite input)
    {
        Texture2D _texture = input.texture;
        Texture2D blackwhitteTexture = new Texture2D(_texture.width, _texture.height, TextureFormat.RGBA32, false);
        blackwhitteTexture.filterMode = FilterMode.Point;

        for (int x = 0; x < _texture.width; x++)
        {
            for (int y = 0; y < _texture.height; y++)
            {
                Color color = new Color();
                color = _texture.GetPixel(x, y);
                color = Color.Lerp(new Color(color.grayscale, color.grayscale, color.grayscale), Color.white, 0f);
                blackwhitteTexture.SetPixel(x, y, color);
                blackwhitteTexture.Apply();
            }
        }
        Sprite create = Sprite.Create(blackwhitteTexture, new Rect(0, 0, blackwhitteTexture.width, blackwhitteTexture.height), Vector2.one * 0.5f);
        create.name = input.name;

        return create;
    }
    /* public static void ChangeFormatTexture(Sprite input)
     {
         string path = AssetDatabase.GetAssetPath(input);
         bool checkchanged = false;

         UnityEditor.TextureImporter importer = (TextureImporter)TextureImporter.GetAtPath(path);
         if (input.texture.isReadable == false) { importer.isReadable = true; checkchanged = true; Debug.Log("a1"); }
         if (input.texture.filterMode != FilterMode.Point) { importer.filterMode = FilterMode.Point; checkchanged = true; Debug.Log("a2"); }
         // if (input.format != TextureFormat.RGBA32) { importer.textureFormat = TextureImporterFormat.RGBA32; checkchanged = true; Debug.Log("a3"); }
         //    if (importer.textureCompression != TextureImporterCompression.Uncompressed) { importer.textureCompression = TextureImporterCompression.Uncompressed; }
         //  if (importer.compressionQuality != (int)TextureCompressionQuality.Normal) { Debug.Log("a5"); }
         if (checkchanged)
         {
             importer.SaveAndReimport();
             Debug.Log("a");
         }
         // input.Apply();

     }*/
    public static Sprite ChangeScaleTexture2D(Texture2D input, float scale)
    {
        int sizewidth = Mathf.RoundToInt(input.width * scale);
        int sizeheight = Mathf.RoundToInt(input.height * scale);
        Texture2D texture = new Texture2D(input.width, input.height, TextureFormat.RGBA32, false);
        texture.filterMode = FilterMode.Point;
        //  Texture2D test = ChangeToTexture2D(grayScaleMaterial.mainTexture);

        texture.SetPixels(input.GetPixels());
        texture.Apply();
        TextureChange.Bilinear(texture, (int)sizewidth, (int)sizewidth);
        texture.Apply();
        Sprite create = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
        create.name = input.name;
        return create;
    }
    public static Texture2D Bilinear(Texture2D source, int targetWidth, int targetHeight)
    {
        Color[] pixels = new Color[targetWidth * targetHeight];
        float incX = (1.0f / targetWidth);
        float incY = (1.0f / targetHeight);
        float posX = (incX / 2.0f);
        float posY = (incY / 2.0f);

        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = source.GetPixelBilinear(posY, posX);
            posY += incY;
            if (posY >= 1.0f)
            {
                posY = (incY / 2.0f);
                posX += incX;
            }
        }
        Texture2D output = new Texture2D(targetWidth, targetHeight, TextureFormat.ARGB32, false);
        output.SetPixels(pixels);
        output.Apply();
        return output;
        /* source.Reinitialize(targetWidth, targetHeight);
         source.SetPixels(pixels);
         source.Apply();*/
    }
    public static Texture2D rotate90(Texture2D orig)
    {

        Color32[] origpix = orig.GetPixels32(0);
        Color32[] newpix = new Color32[orig.width * orig.height];
        for (int c = 0; c < orig.height; c++)
        {
            for (int r = 0; r < orig.width; r++)
            {
                newpix[orig.width * orig.height - (orig.height * r + orig.height) + c] =
                  origpix[orig.width * orig.height - (orig.width * c + orig.width) + r];
            }
        }
        Texture2D newtex = new Texture2D(orig.height, orig.width, orig.format, false);
        newtex.SetPixels32(newpix, 0);
        newtex.Apply();
        return newtex;
    }

    public static Texture2D rotate270(Texture2D orig)
    {

        Color32[] origpix = orig.GetPixels32(0);
        Color32[] newpix = new Color32[orig.width * orig.height];
        int i = 0;
        for (int c = 0; c < orig.height; c++)
        {
            for (int r = 0; r < orig.width; r++)
            {
                newpix[orig.width * orig.height - (orig.height * r + orig.height) + c] = origpix[i];
                i++;
            }
        }
        Texture2D newtex = new Texture2D(orig.height, orig.width, orig.format, false);
        newtex.SetPixels32(newpix, 0);
        newtex.Apply();
        return newtex;
    }
    public static Texture2D rotate180(Texture2D orig)
    {

        Color32[] origpix = orig.GetPixels32(0);
        Color32[] newpix = new Color32[orig.width * orig.height];
        for (int i = 0; i < origpix.Length; i++)
        {
            newpix[origpix.Length - i - 1] = origpix[i];
        }
        Texture2D newtex = new Texture2D(orig.width, orig.height, orig.format, false);
        newtex.SetPixels32(newpix, 0);
        newtex.Apply();
        return newtex;
    }


}
