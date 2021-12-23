using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SliderScript : MonoBehaviour
{
    protected float _defaultValue;
    protected Transform _photoObjTransform;
    protected Slider _slider;

    void Awake()
    {
        _slider = GetComponent<Slider>();
        _defaultValue = _slider.value;
    }

    private void Start()
    {
        EventsManager.instance.onNewPhotoObjectCreated += NewPhotoObjectCreated;
    }

    private void OnDestroy()
    {
        EventsManager.instance.onNewPhotoObjectCreated -= NewPhotoObjectCreated;
    }

    private void NewPhotoObjectCreated(GameObject obj)
    {
        _slider.value = _defaultValue;
        _photoObjTransform = obj.transform;
    }

    public abstract void SliderValueChange();
}
