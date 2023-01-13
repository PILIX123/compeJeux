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
        animState = 1;
        yield return new WaitForSeconds(4);
        animState = 2;
        yield return new WaitForSeconds(2);
        canvasTrophy.SetActive(false);
        Instantiate(Trophy, new Vector3(0, 1f, 0), transform.rotation);
    }

    private void Update()
    {
        if (animState == 1 && t != 1)
        {
            t += Time.deltaTime * 0.01f;
            canvasTrophy.GetComponent<RectTransform>().position.Set(0, Mathf.Lerp(-269f, -167.5f, t), 0);
            Debug.Log(canvasTrophy.GetComponent<RectTransform>().position);
        }
        if (animState == 2)
        {
            t -= Time.deltaTime * 0.01f;
            canvasTrophy.transform.GetComponent<RectTransform>().position.Set(0, Mathf.Lerp(-167.5f, -269f, t), 0);
            if (t == 0)
                animState = 0;
        }

    }
}
