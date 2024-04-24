using Firebase.Extensions;
using Firebase.Storage;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class DownloadImage : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    public Firebase.FirebaseApp app = null;
    FirebaseStorage storage;

    public void Awake()
    {
        int cach = 3;
        app = Firebase.FirebaseApp.DefaultInstance;
        storage = FirebaseStorage.DefaultInstance;
        StorageReference testImageRef;
        switch (cach)
        {
            case 1:
                testImageRef = storage.GetReferenceFromUrl("gs://test19-1.appspot.com/18-1.png");
                break;
            case 2:
                StorageReference storageRef = storage.GetReferenceFromUrl("gs://test19-1.appspot.com");
                testImageRef = storageRef.Child("18-1.png"); break;
            case 3:
                StorageReference storageRef3 = storage.RootReference;
                testImageRef = storageRef3.Child("18-1.png"); break;

            default: testImageRef = storage.GetReferenceFromUrl("gs://test19-1.appspot.com/18-1.png"); break;
        }

        //Cach1
        //

        //Cach2

        const long maxAllowedSize = 1 * 1024 * 1024;
        testImageRef.GetBytesAsync(maxAllowedSize).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogException(task.Exception);
            }
            else
            {
                byte[] fileContents = task.Result;
                Texture2D imageTexture = new Texture2D(2, 2);
                imageTexture.filterMode = FilterMode.Point;
                imageTexture.LoadImage(fileContents);
                imageTexture.Apply();
                Color[] test = imageTexture.GetPixels();
                Sprite sprite = Sprite.Create(imageTexture, new Rect(0, 0, imageTexture.width, imageTexture.height), new Vector2(0.5f, 0.5f));
                sprite.name = "123";
                sprites.Add(sprite);

                Debug.Log("Finished downloading!");
            }
        });
    }
}


