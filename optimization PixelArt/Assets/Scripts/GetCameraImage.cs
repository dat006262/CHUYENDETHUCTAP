using System;
using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
using System.IO;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class GetCameraImage : MonoBehaviour
{
    public List<Sprite> saveSprite;
    private float size = 40;
    // Tạo mới một bitmap với kích thước 100x100
    public Slider slider;
    WebCamTexture webcamTexture;
    WebCamTexture webcamTexture2;
    public string path;
    public RawImage imgDisplay;
    private Material grayScaleMaterial = null;
    private Texture2D texture;
    public Shader shader;
    bool isCamOn = false;
    WebCamDevice[] devices;
    public int nowCAm = 0;
    public GameObject CamScreenFront;
    public RectTransform CamScreenBack;
    //Assets/Material2/GrayScale2.shader
    private void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        ChangeWhenSlideChange(value);
    }

    private void ChangeWhenSlideChange(float value)
    {
        size = Mathf.Lerp(40, 100, value);
        grayScaleMaterial.SetFloat("_GridWidth", (int)size);
        grayScaleMaterial.SetFloat("_GridHeight", (int)size);
    }

    private void Update()
    {

        if (isCamOn)
        {
            // grayScaleMaterial.SetTexture("_MainTex", webcamTexture);
            //  this.GetComponent<Image>().material = grayScaleMaterial;
        }
    }

    private IEnumerator AskForPermissions()
    {

#if UNITY_ANDROID
        List<bool> permissions = new List<bool>() { false, false, false };
        List<bool> permissionsAsked = new List<bool>() { false, false, false };
        List<Action> actions = new List<Action>()
    {
        new Action(() => {
            permissions[0] = Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead);
            if (!permissions[0] && !permissionsAsked[0])
            {
                Permission.RequestUserPermission(Permission.ExternalStorageRead);
                permissionsAsked[0] = true;
                return;
            }
        }),
        new Action(() => {
            permissions[1] = Permission.HasUserAuthorizedPermission(Permission.Camera);
            if (!permissions[1] && !permissionsAsked[1])
            {
                Permission.RequestUserPermission(Permission.Camera);
                permissionsAsked[1] = true;
                return;
            }
        }),
        new Action(() => {
            permissions[2] = Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite);
            if (!permissions[2] && !permissionsAsked[2])
            {
                Permission.RequestUserPermission(Permission.ExternalStorageWrite);
                permissionsAsked[2] = true;
                return;
            }
        }),
        //    new Action(() => {
        //    permissions[3] = Permission.HasUserAuthorizedPermission("android.permission.READ_PHONE_STATE");
        //    if (!permissions[3] && !permissionsAsked[3])
        //    {
        //        Permission.RequestUserPermission("android.permission.READ_PHONE_STATE");
        //        permissionsAsked[3] = true;
        //        return;
        //    }
        //})
    };
        for (int i = 0; i < permissionsAsked.Count;)
        {
            actions[i].Invoke();
            if (permissions[i])
            {
                Debug.Log("Reqquest" + $"{i}");
                ++i;
            }
            yield return new WaitForEndOfFrame();
        }
        TurnOnCam(0);
#endif

    }
    public void Reqquest()
    {
        if (Application.platform != RuntimePlatform.Android) return;
        StartCoroutine(AskForPermissions());
    }
    public void OpenCameraDevice()
    {

    }
    public void TurnOnCam(int input)
    {
        nowCAm = input;
        isCamOn = true;
        devices = WebCamTexture.devices;
        if (grayScaleMaterial != null)
        {
            DestroyImmediate(grayScaleMaterial);
        }
        //if (webcamTexture != null)
        //{
        //    DestroyImmediate(webcamTexture);
        //}
        grayScaleMaterial = new Material(shader);
        switch (input)
        {
            case 0:
                {
                    CamScreenBack.rotation = Quaternion.Euler(0, 0, -90);
                    this.GetComponent<RawImage>().uvRect = new Rect(0, 1, 1, 1);
                    break;
                }
            case 1:
                {
                    CamScreenBack.rotation = Quaternion.Euler(0, 0, 90);
                    this.GetComponent<RawImage>().uvRect = new Rect(0, 1, 1, -1);
                    break;
                }
        }

        webcamTexture = new WebCamTexture(devices[input].name, 480, 480);
        grayScaleMaterial.mainTexture = webcamTexture;
        webcamTexture.Play();
        webcamTexture.filterMode = FilterMode.Trilinear;

        this.GetComponent<RawImage>().material = grayScaleMaterial;
        this.GetComponent<RawImage>().texture = webcamTexture;

    }
    public void TurnOffCam()
    {
        isCamOn = false;
        webcamTexture.Pause();
        webcamTexture.Stop();
        if (webcamTexture != null)
        {
            DestroyImmediate(webcamTexture);
        }
    }
    public void ChangeCam()
    {
        if (devices.Length < 2) return;
        switch (nowCAm)
        {
            case 0:
                {
                    TurnOnCam(1);
                    break;
                }
            case 1:
                {
                    TurnOnCam(0);
                    break;
                }
        }
        ChangeWhenSlideChange(slider.value);
    }
    public void SaveImageToFile(Texture2D textureToSave, string name, string folder)
    {

        byte[] bytes = textureToSave.EncodeToPNG();
        string filename = name;
        Debug.LogError("persistenppath" + Application.persistentDataPath);
        string destination = Application.persistentDataPath + "/" + name + ".png";
        File.WriteAllBytes(destination, bytes);
    }
    public Sprite ReadFileToSprite(string imageFileName, string foldername)
    {
        Texture2D imageTexture;
        byte[] imageBytes = File.ReadAllBytes(Application.persistentDataPath + "/" + imageFileName + ".png");
        Debug.LogError("Read:" + Application.persistentDataPath + "/" + imageFileName + ".png");
        imageTexture = new Texture2D(2, 2);
        imageTexture.filterMode = FilterMode.Point;
        imageTexture.LoadImage(imageBytes);
        imageTexture.Apply();

        Sprite sprite = Sprite.Create(imageTexture, new Rect(0, 0, imageTexture.width, imageTexture.height), new Vector2(0.5f, 0.5f));
        sprite.name = imageFileName;
        return sprite;
    }
    public Sprite TakePicture()
    {
        Texture2D texture = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.RGBA32, false);
        texture.filterMode = FilterMode.Point;
        //  Texture2D test = ChangeToTexture2D(grayScaleMaterial.mainTexture);
        Texture2D test = TextureChange.ChangeToTexture2D(webcamTexture);

        texture.SetPixels(test.GetPixels());
        texture.Apply();
        TextureChange.Bilinear(texture, (int)size, (int)size);
        texture.Apply();

        switch (nowCAm)
        {
            case 0:
                {
                    texture = TextureChange.rotate270(texture);//cam sau OK
                    break;
                }
            case 1:
                {
                    texture = TextureChange.rotate90(texture);
                    texture = TextureChange.rotate180(texture);
                    break;
                }
        }
        Sprite create = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

        return create;
    }
}
