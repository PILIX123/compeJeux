using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sussy_Achievement : MonoBehaviour
{
    public GameObject Trophy;
    public int SussyCount
    {
        set
        {
            sussyCount= value;
            if(sussyCount >=1)
            {
                AchievementGet();
            }
        }
        get { return sussyCount; }
    }
    int sussyCount;
    void AchievementGet()
    {
        Instantiate(Trophy);
    }
}
