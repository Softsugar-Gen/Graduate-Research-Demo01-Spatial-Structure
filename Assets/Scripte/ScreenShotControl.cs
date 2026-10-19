using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using TMPro;
using UnityEditor.Rendering;

public class ScreenShotControl : MonoBehaviour
{
    Camera screenShotCamera;

    public RawImage testRawImage;

    byte[] pngData;

    int Index = 001;

    GameObject text;

    static public Texture2D  GetTexture(RenderTexture rt)
    {
        RenderTexture currentActiveRT = RenderTexture.active;
        RenderTexture.active = rt;

        Texture2D tex = new Texture2D(rt.width, rt.height);
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        tex.Apply();

        RenderTexture.active = currentActiveRT;
        return tex;
    }

    private void Start()
    {
        screenShotCamera = GetComponent<Camera>();
        text = GameObject.Find("SaveMessage");
        text.SetActive(false);
    }

    public void TakeScreenShot()
    {
        while (File.Exists(Application.dataPath + "/RoomHistory/ScreenShot" + Index + ".png"))
        {
            Index++;
        }
        GetTexture(screenShotCamera.targetTexture);
        Texture2D picture = GetTexture(screenShotCamera.targetTexture);
        pngData = ImageConversion.EncodeToPNG(picture);
        File.WriteAllBytes(Application.dataPath + "/RoomHistory/ScreenShot" + Index + ".png", pngData);
        SetText();
        Invoke("HideText", 5f);

        //if(test != null)
        //{
        //    testRawImage.texture = test;
        //}
    }

    //private void Update()
    //{
        //if(File.Exists(Application.dataPath + "/RoomHistory/ScreenShot" + Index + ".png"))
        //{
        //    GameObject text = GameObject.Find("SaveMessage");
        //    text.GetComponent<TextMeshProUGUI>().text = "Screen shot saved: " + Index;
        //    text.SetActive(true);
        //    Invoke("HideText", 5f);
        //    Debug.Log("Screen shot saved: " + Index);
        //}
    //}
    
    void SetText()
    {
        text.SetActive(true);
    }

    void HideText()
    {
        text.SetActive(false);
    }


}
