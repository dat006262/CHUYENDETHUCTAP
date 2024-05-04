using System;
using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
#if UNITY_EDITOR
[CustomEditor(typeof(GetCameraImage))]
public class GetCameraImageEditor : Editor
{

    public override void OnInspectorGUI()
    {
        GetCameraImage tool = (GetCameraImage)target;
        if (GUILayout.Button("TurnOffCam"))
        {
            tool.TurnOffCam();
            AssetDatabase.SaveAssets();
        }
        if (GUILayout.Button("TurnOnCam"))
        {
            tool.TurnOnCam(0);
            AssetDatabase.SaveAssets();
        }
        base.OnInspectorGUI();
    }
}
#endif
public class GetCameraImage : MonoBehaviour
{
    public static GetCameraImage intances;
    public List<Sprite> saveSprite;
    private float size = 40;
    // Tạo mới một bitmap với kích thước 100x100
    public Slider slider;
    WebCamTexture webcamTexture;
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
    private void Awake()
    {
        intances = this;
        size = 50;
    }
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
        size = Mathf.Lerp(50, 100, value);
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
            permissions[2] = Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite);
            if (!permissions[2] && !permissionsAsked[2])
            {
                Permission.RequestUserPermission(Permission.ExternalStorageWrite);
                permissionsAsked[2] = true;
                return;
            }
        }),
           new Action(() => {
           permissions[1] = Permission.HasUserAuthorizedPermission(Permission.Camera);
           if (!permissions[1] && !permissionsAsked[1])
           {
                //TEST
                PermissionCallbacks permissionCallbacks = new PermissionCallbacks();
                permissionCallbacks.PermissionGranted += (a)=>{ TurnOnCam(0);};
                //TEST
                Permission.RequestUserPermission(Permission.Camera, permissionCallbacks);
                permissionsAsked[1] = true;
                return;
           }
        })
    };
        for (int i = 0; i < permissionsAsked.Count;)
        {
            actions[i].Invoke();
            if (permissions[i])
            {
                ++i;
            }
            yield return new WaitForEndOfFrame();
        }
        TurnOnCam(0);


    }

    public void Reqquest()
    {
#if UNITY_ANDROID
        if (Application.platform != RuntimePlatform.Android) return;
        StartCoroutine(AskForPermissions());
#endif
    }
    public void OpenCameraDevice()
    {
        isCamOn = true;
        devices = WebCamTexture.devices;
    }
    public void TurnOnCam(int input)
    {
#if !UNITY_EDITOR
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
                    imgDisplay.uvRect = new Rect(0, 1, 1, 1);
                    break;
                }
            case 1:
                {
                    CamScreenBack.rotation = Quaternion.Euler(0, 0, 90);
                    imgDisplay.uvRect = new Rect(0, 1, 1, -1);
                    break;
                }

        }

        webcamTexture = new WebCamTexture(devices[nowCAm].name, 480, 480);
        grayScaleMaterial.mainTexture = webcamTexture;
        webcamTexture.Play();
        webcamTexture.filterMode = FilterMode.Trilinear;

        imgDisplay.material = grayScaleMaterial;
        imgDisplay.texture = webcamTexture;

#else

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

        CamScreenBack.rotation = Quaternion.Euler(0, 0, -0);
        imgDisplay.uvRect = new Rect(0, 1, -1, 1);

        webcamTexture = new WebCamTexture(devices[0].name, 480, 480);
        grayScaleMaterial.mainTexture = webcamTexture;
        webcamTexture.Play();
        webcamTexture.filterMode = FilterMode.Point;

        imgDisplay.material = grayScaleMaterial;
        imgDisplay.texture = webcamTexture;
#endif
        grayScaleMaterial.SetFloat("_GridWidth", (int)size);
        grayScaleMaterial.SetFloat("_GridHeight", (int)size);
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
#if UNITY_EDITOR
        return;
#endif
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
        Debug.Log("persistenppath" + Application.persistentDataPath);
        string destination = Application.persistentDataPath + "/" + name + ".png";
        File.WriteAllBytes(destination, bytes);
    }
    public Sprite ReadFileToSprite(string imageFileName, string foldername)
    {
        Texture2D imageTexture;
        byte[] imageBytes = File.ReadAllBytes(Application.persistentDataPath + "/" + imageFileName + ".png");
        Debug.Log("Read:" + Application.persistentDataPath + "/" + imageFileName + ".png");
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
        texture = TextureChange.Bilinear(texture, (int)size, (int)size);

        texture.Apply();
#if !UNITY_EDITOR
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
#else
        texture = TextureChange.FlipY(texture);
#endif
        Sprite create = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
        create.name = "Create" + $"{DataManager.Instance.dataInProgress.WebCamPictureCount}";
        return create;
    }
    public void CreateAPictureToDraw()
    {
        Sprite sprite = TakePicture();
        int sizeImage = (int)size;
        // blacksprite = PictureControll.Instance_picture.CreatBlackAndWhiteSprite(sprite);//tao anh den trang
        // PictureControll.Instance_picture.CreateBtnLoad(sprite, blacksprite, gridCreate);
        ShowDataManager.Instance.SpawnOneBtnCreated(sprite);
        SaveImageToFile(sprite.texture, "Create" + $"{DataManager.Instance.dataInProgress.WebCamPictureCount}", "/CamPicture");//luu anh thuong vao folder
        DataManager.Instance.dataInProgress.SetCamImageCount(DataManager.Instance.dataInProgress.WebCamPictureCount + 1);
        ;


        GameControll.Instance.OpenCreateWindow();
    }
}
