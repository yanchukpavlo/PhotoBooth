using UnityEngine;

public class ZoomSlider : SliderScript
{
    [SerializeField] Cinemachine.CinemachineVirtualCamera _virtualCamera;

    public override void SliderValueChange()
    {
        _virtualCamera.m_Lens.FieldOfView = _slider.value;
    }
}
