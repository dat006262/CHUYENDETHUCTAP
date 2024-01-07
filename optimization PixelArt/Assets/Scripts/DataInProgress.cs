using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ImageStat
{
    NEVER_DRAWED,
    INPROGRESS,
    COMPLETE
}
public class DataInProgress
{
    public Dictionary<string, ImageStat> imageStatData = new Dictionary<string, ImageStat>();
    public Dictionary<string, bool[,]> matrix = new Dictionary<string, bool[,]>();
    public Dictionary<string, bool> isdrawed = new Dictionary<string, bool>();
    public Dictionary<string, bool> isComplete = new Dictionary<string, bool>();
    public int WebCamPictureCount = 0;
}

