using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public enum ImageStat
{
    NEVER_DRAWED,
    INPROGRESS,
    COMPLETE
}
[System.Serializable]
public class DataInProgress
{
    public Dictionary<string, ImageStat> imageStatData = new Dictionary<string, ImageStat>();
    public Dictionary<string, bool[,]> matrix = new Dictionary<string, bool[,]>();
    public int WebCamPictureCount = 0;
    public void Load()
    {
        if (!PlayerPrefs.HasKey(Const.KEY_DATAINPROGRESS))//neu chua tung tao PlayerPrefs cho jso
        {
            Save();//CreatePlayerPrefs
        }
        else
        {
            var data = PlayerPrefs.GetString(Const.KEY_DATAINPROGRESS);//if co roi thi lay ra
            var readData = JsonConvert.DeserializeObject<DataInProgress>(data);//
            DataManager.Instance.dataInProgress = readData;

        }
    }
    public void Save()
    {
        string data = JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });//ma hoa data thanh json//cho phepluu anh 2 chieu
        PlayerPrefs.SetString(Const.KEY_DATAINPROGRESS, data);  // tap PlayerPrefs cho json
    }
    public bool[,] GetMatrix(string key)
    {
        if (matrix.ContainsKey(key))
        {
            return matrix[key];
        }
        else return null;
    }
    public void AddMatrix(string key, bool[,] matrix)
    {

        if (!this.matrix.ContainsKey(key))
        {
            this.matrix.Add(key, matrix);
            Debug.Log("add keymatrix:" + key);
        }

        Save();
    }
    public void SetMatrix(string key, int i, int j)
    {
        if (imageStatData[key].Equals(ImageStat.NEVER_DRAWED))
        {
            imageStatData[key] = ImageStat.INPROGRESS;
        }
        if (matrix[key][i, j] == false)
        {
            matrix[key][i, j] = true;

        }
        Save();
    }

    public ImageStat AddImageStat(string key)
    {

        if (!this.imageStatData.ContainsKey(key))
        {
            this.imageStatData.Add(key, ImageStat.NEVER_DRAWED);
            Debug.Log("add keymImageStat:" + key);

            Save();
            return ImageStat.NEVER_DRAWED;
        }
        else
        {
            return this.imageStatData[key];
        }


    }
    public void SetImageStatComplete(string key)
    {
        if (this.imageStatData.ContainsKey(key))
        {
            this.imageStatData[key] = ImageStat.COMPLETE;
            Save();
        }
    }
    //private void AutoSetImageStat(string key)
    //{
    //    if (!imageStatData.ContainsKey(key))
    //    {
    //        imageStatData.Add(key, ImageStat.NEVER_DRAWED);
    //    }
    //    if (CheckImageDrawed(key))
    //    {
    //        foreach (var x in matrix[key])
    //        {
    //            if (!x)
    //            {
    //                imageStatData[key] = ImageStat.INPROGRESS;
    //            }
    //        }
    //        imageStatData[key] = ImageStat.COMPLETE;
    //    }
    //    else
    //    {
    //        imageStatData[key] = ImageStat.NEVER_DRAWED;
    //    }

    //}
    public bool CheckImageDrawed(string key)
    {
        foreach (var x in matrix[key])
        {
            if (x)
            {
                return true;
            }

        }
        return false;
    }

}

