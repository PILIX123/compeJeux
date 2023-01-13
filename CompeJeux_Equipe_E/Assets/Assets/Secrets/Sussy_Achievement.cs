using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sussy_Achievement : MonoBehaviour
{
    public GameObject Trophy;
    public GameObject canvasTrophy;
    private int animState = 0;
    private float t = 0;
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
        StartCoroutine("Coroutine");
    }

    IEnumerator Coroutine()
    {
        canvasTrophy.SetActive(true);
        yield return new WaitForSeconds(4);
        canvasTrophy.SetActive(false);
        Instantiate(Trophy, new Vector3(0, 1f, 0), transform.rotation);
    }
}
