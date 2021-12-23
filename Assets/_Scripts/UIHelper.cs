using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHelper : MonoBehaviour
{
    public void NextPhotoObject()
    {
        EventsManager.instance.PhotoObjectChange(true);
    }
    
    public void PreviousPhotoObject()
    {
        EventsManager.instance.PhotoObjectChange(false);
    }

    public void GetPhoto()
    {
        Screenshot.instance.TakeScreenshot();
    }

    public void SetActiveNegate(bool active)
    {
        gameObject.SetActive(!active);
    }
}
