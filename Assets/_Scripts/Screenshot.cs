using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Screenshot : MonoBehaviour
{
    public static Screenshot instance;

    bool takeScreenshot;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    private void OnEnable()
    {
        RenderPipelineManager.endCameraRendering += RenderPipelineManager_endCameraRendering;
    }

    private void OnDisable()
    {
        RenderPipelineManager.endCameraRendering -= RenderPipelineManager_endCameraRendering;
    }

    private void RenderPipelineManager_endCameraRendering(ScriptableRenderContext arg1, Camera arg2)
    {
        if (takeScreenshot)
        {
            takeScreenshot = false;
            int width = Screen.width;
            int height = Screen.height;
            Texture2D screenshotTexture = new Texture2D(width, height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, width, height);
            screenshotTexture.ReadPixels(rect, 0, 0);
            screenshotTexture.Apply();

            byte[] byteArray = screenshotTexture.EncodeToPNG();
            var time = System.DateTime.UtcNow.ToString("-yyyy-MM-dd-HH-mm-ss-FF");
            System.IO.File.WriteAllBytes(Application.dataPath + $"/_Output/Screenshot{time}.png", byteArray);
        }
    }

    public void TakeScreenshot()
    {
        takeScreenshot = true;
    }
}
