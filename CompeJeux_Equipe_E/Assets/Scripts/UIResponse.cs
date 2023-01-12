using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIResponse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        Application.LoadLevel("");
    }

    public void Quit()
    {
#if DEBUG
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
