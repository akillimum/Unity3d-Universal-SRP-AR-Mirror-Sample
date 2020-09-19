//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UB;
//using UnityEngine;
//using UnityEngine.UI;

//public class ManageReflection : MonoBehaviour
//{

//    public GameObject MirrorPlane;
//    public GameObject Plane;
//    public GameObject PlaneDark;
//    public GameObject ScreenShotCanvas;
//    public GameObject ScreenShotButton;
//    public Toggle Shadow;
//    public Light DirectLight;
//    public Toggle Reflect;
//    public Slider Reflection;
//    public Slider Transparency;
//    public Slider Refraction;
//    public Slider DarknessLevel;
//    public Toggle AntiAliasing;
//    public Toggle AO;
//    //public AmplifyOcclusionEffect AmplifOcclusionEffect;
//    //public AmplifyBloom.AmplifyBloomEffect AmplifyBloomEffect;
//    public Toggle Bloom;
//    public Toggle Darkness;
//    public VuforiaSceneTracker VuforiaSceneTracker;
//    //public FastMobileBloom BloomScript;
//    //public Camera CarCamera;

//    private MirrorWithShader _mirrorScript;
//    private Material[] _materials;
//    private bool _firstRun = true;
//    //private LightShadows _previousLight;


//    private void Awake()
//    {
//        Reflect.isOn = false;
//        MirrorPlane.SetActive(false);

//        AO.isOn = false;
//        Bloom.isOn = false;

//        //_previousLight = DirectLight.shadows;
//        if (DirectLight.shadows == LightShadows.None)
//        {
//            Shadow.isOn = false;
//        }
//        else
//        {
//            Shadow.isOn = true;
//        }

//        if (PlayerPrefsHelper.EnableAntiAliasing)
//        {
//            AntiAliasing.isOn = true;
//        }
//        else
//        {
//            AntiAliasing.isOn = false;
//        }

//        ChangeAntiAliasing(); //!!!!!!!!!AA DOES NOT WORK WITH BLOOM - HDR - METAL

//        Darkness.isOn = false;

//    }

//    private void OnEnable()
//    {
//        //UM_Camera.Instance.OnImageSaved += OnImageSaved;
//    }

//    private void OnDisable()
//    {
//        //UM_Camera.Instance.OnImageSaved -= OnImageSaved;
//    }

//    public void SwitchMirrorPlane()
//    {
//        Debug.Log("Value of toggle: " + Reflect.isOn);
//        if (Reflect.isOn)
//        {
//            MirrorPlane.SetActive(true);
//            if (VuforiaSceneTracker.IsNight)
//            {
//                MirrorPlane.transform.parent = PlaneDark.transform;
//            }
//            else
//            {
//                MirrorPlane.transform.parent = Plane.transform;
//            }
//            if (_firstRun)
//            {
//                _firstRun = false;

//                _mirrorScript = MirrorPlane.GetComponent<MirrorWithShader>();
//                _materials = MirrorPlane.GetComponent<Renderer>().sharedMaterials.Where(a => a != null).ToArray();

//            }
//        }
//        else
//        {
//            MirrorPlane.SetActive(false);
//        }
//    }

//    public void SwitchReflection()
//    {
//        if (_mirrorScript != null)
//        {
//            Debug.Log("Reflection.value: " + Reflection.value);
//            _mirrorScript.TextureSize = (int)Reflection.value + (((int)Reflection.value) % 2); //even
//        }
//    }

//    public void SwitchTransparency()
//    {
//        if (_materials != null && _materials.Length >= 0)
//        {
//            foreach (var material in _materials)
//            {
//                if (material.HasProperty("_Color"))
//                {
//                    Debug.Log("Transparency.value: " + Transparency.value);
//                    material.SetColor("_Color", new Color(1, 1, 1, Transparency.value));
//                }
//            }

//        }
//    }

//    public void SwitchRefraction()
//    {
//        if (_materials != null && _materials.Length >= 0)
//        {
//            foreach (var material in _materials)
//            {
//                if (material.HasProperty("_ReflDistort"))
//                {
//                    Debug.Log("Refraction.value: " + Refraction.value);
//                    material.SetFloat("_ReflDistort", Refraction.value);
//                }
//            }

//        }
//    }

//    public void SwitchShadows()
//    {
//        Debug.Log("Value of toggle: " + Shadow.isOn);
//        if (Shadow.isOn)
//        {
//            DirectLight.shadows = LightShadows.Soft;
//        }
//        else
//        {
//            DirectLight.shadows = LightShadows.None;
//        }
//    }

//    public void SwitchAO()
//    {
//        //if (AO.isOn)
//        //{
//        //    AmplifOcclusionEffect.enabled = true;
//        //}
//        //else
//        //{
//        //    AmplifOcclusionEffect.enabled = false;
//        //}
//    }

//    public void SwitchBloom()
//    {
//        //if (Bloom.isOn)
//        //{
//        //    BloomScript.enabled = true;
//        //}
//        //else
//        //{
//        //    BloomScript.enabled = false;
//        //}
//    }

//    public void SwitchDarkness()
//    {
//        if (Darkness.isOn)
//        {
//            VuforiaSceneTracker.ChangePlane(true);
//            SetDarknessLevel(0.2f);
//        }
//        else
//        {
//            VuforiaSceneTracker.ChangePlane(false);
//            SetDarknessLevel(1f);
//        }
//    }

//    public void SwitchDarknessLevel()
//    {
//        SetDarknessLevel(DarknessLevel.value);
//    }

//    void SetDarknessLevel(float value)
//    {
//        DirectLight.intensity = value;
//        RenderSettings.ambientIntensity = value;
//        RenderSettings.reflectionIntensity = value;
//    }

//    public void SwitchAntiAliasing()
//    {
//        PlayerPrefsHelper.EnableAntiAliasing = AntiAliasing.isOn;
//        Debug.Log("Value of toggle: " + AntiAliasing.isOn + "Value of antialiasing: " + PlayerPrefsHelper.EnableAntiAliasing);
//        ChangeAntiAliasing();
//    }

//    private void ChangeAntiAliasing()
//    {
//        if (PlayerPrefsHelper.EnableAntiAliasing)
//        {
//            QualitySettings.antiAliasing = 8;
//        }
//        else
//        {
//            QualitySettings.antiAliasing = 0;
//        }
//    }

//    public void CaptureScreen()
//    {
//        if (ScreenShotCanvas.activeSelf)
//        {
//            ScreenShotCanvas.SetActive(false);
//        }
//        else
//        {
//            ScreenShotButton.SetActive(false);
//            try
//            {
//                //UM_Camera.Instance.SaveScreenshotToGallery();
//            }
//            catch (System.Exception ex)
//            {
//                ShowPopup("Error", ex.Message);
//                ScreenShotCanvas.SetActive(true); //always activate parent first
//                ScreenShotButton.SetActive(true);

//            }

//        }

//    }

//    public static void ShowPopup(string title, string message)
//    {
//        try
//        {
//            //    MNPopup popup = new MNPopup(title, message);
//            //    popup.AddAction("OK", () => { });
//            //    //popup.AddAction("action2", () => { Debug.Log("action 2 action callback"); });
//            //    //popup.AddDismissListener(() => { Debug.Log("dismiss listener"); });
//            //    popup.Show();
//        }
//        catch (System.Exception ex)
//        {

//        }
//    }

//    //void OnImageSaved(UM_ImageSaveResult result)
//    //{
//    //    if (result.IsSucceeded)
//    //    {
//    //        //no image path for IOS
//    //        //new Native
//    //        //new MobileNativeMessage("Image Saved", result.imagePath);
//    //        ShowPopup("Success", "Image saved to gallery.");
//    //        //popup.AddAction("OK", () => { });
//    //        ////popup.AddAction("action2", () => { Debug.Log("action 2 action callback"); });
//    //        ////popup.AddDismissListener(() => { Debug.Log("dismiss listener"); });
//    //        //popup.Show();
//    //    }
//    //    else
//    //    {
//    //        ShowPopup("Error", "Image save failed!");
//    //        //popup.AddAction("OK", () => { });
//    //        ////popup.AddAction("action2", () => { Debug.Log("action 2 action callback"); });
//    //        ////popup.AddDismissListener(() => { Debug.Log("dismiss listener"); });
//    //        //popup.Show();
//    //    }
//    //    ScreenShotCanvas.SetActive(true);
//    //    ScreenShotButton.SetActive(true);
//    //}
//}
