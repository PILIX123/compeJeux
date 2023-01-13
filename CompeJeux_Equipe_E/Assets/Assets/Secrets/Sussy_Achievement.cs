using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sussy_Achievement : MonoBehaviour
{
    public int SussyCount
    {
        set
        {
            sussyCount= value;
            if(sussyCount >=5)
            {
                AchievementGet();
            }
        }
        get { return sussyCount; }
    }
    int sussyCount;
    void AchievementGet()
    {

    }
}
