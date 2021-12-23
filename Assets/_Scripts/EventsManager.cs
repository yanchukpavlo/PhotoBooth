using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public event Action<bool> onPhotoObjectChange;
    public void PhotoObjectChange(bool isNext)
    {
        onPhotoObjectChange?.Invoke(isNext);
    }

    public event Action<GameObject> onNewPhotoObjectCreated;
    public void NewPhotoObjectCreated(GameObject newObj)
    {
        onNewPhotoObjectCreated?.Invoke(newObj);
    }
}
