using UnityEngine;

public class RotateSlider : SliderScript
{
    [SerializeField] Axis axis;

    enum Axis
    {
        X,
        Y,
        Z
    }

    public override void SliderValueChange()
    {
        switch (axis)
        {
            case Axis.X:
                _photoObjTransform.rotation = Quaternion.Euler(_slider.value, _photoObjTransform.eulerAngles.y, _photoObjTransform.eulerAngles.z);
                break;

            case Axis.Y:
                _photoObjTransform.rotation = Quaternion.Euler(_photoObjTransform.eulerAngles.x, _slider.value, _photoObjTransform.eulerAngles.z);
                break;

            case Axis.Z:
                _photoObjTransform.rotation = Quaternion.Euler(_photoObjTransform.eulerAngles.x, _photoObjTransform.eulerAngles.y, _slider.value);
                break;
        }
    }
}
