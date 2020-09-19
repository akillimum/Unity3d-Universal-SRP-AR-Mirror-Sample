using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class EntryGuiM : MonoBehaviour
{
    public bool EnableAA = false;
    public GameObject CanvasGamePlay;
    public GameObject CanvasLoading;


    void Start(){
        //Debug.Log("Initialize ad");
        //Advertisement.Initialize("1268432", false);
        if(EnableAA){
            QualitySettings.antiAliasing = 8;
        }
    }

    public void StartAd()
    {
        StartCoroutine(ShowAdWhenReady());
    }

    IEnumerator ShowAdWhenReady()
    {
        //Debug.Log("Called ad");
        //while (!Advertisement.IsReady())
        //    yield return null;

        //Debug.Log("Running ad");
        //Advertisement.Show();
        yield return null;
    }

    public void StartGameMarkerless()
    {
        Loading();
        SceneManager.LoadScene("VuforiaScene");
    }

    public void StartGamePrinted()
    {
        Loading();
        SceneManager.LoadScene("VuforiaSceneImage");
    }

    public void StartGameHome()
    {
        SceneManager.LoadScene("Entry");
    }

    public void OpenShaderWeb()
    {
        Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/81728");
    }

    public void OpenImageWeb()
    {
        Application.OpenURL("https://drive.google.com/open?id=1_L6iJAxdL7bG4OH4UHmOvupkZuFaQcLq");
    }

    public void Loading()
    {
        CanvasGamePlay.SetActive(false);
        CanvasLoading.SetActive(true);
        var sounds = FindObjectsOfType<AudioSource>(); //disable all sounds so user do not hear engine voice etc.
        if (sounds!=null){
            foreach (var sound in sounds)
            {
                sound.enabled = false;
            }
        }
    }
}