using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAR()
    {
        SceneManager.LoadScene("SimpleAR");
    }

    public void GoToShaders()
    {
        Application.OpenURL("https://assetstore.unity.com/publishers/14806");
    }
}
