using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraShakeController : MonoBehaviour
{
    [SerializeField, ReadOnly] private CinemachineVirtualCamera _virtualCamera;
    private CinemachineBasicMultiChannelPerlin _virtualCameraNoise;

    [SerializeField] private float _shakeAmplitude;
    [SerializeField] private float _shakeFrequency;

    [SerializeField] private float _shakeAmplitudeInShooting;
    [SerializeField] private float _shakeFrequencyInShooting;

    void Awake()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();

        if(_virtualCamera != null)
        {
            _virtualCameraNoise = _virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        }
    }

    void Start()
    {
        _virtualCameraNoise.m_AmplitudeGain = 0f;
        _virtualCameraNoise.m_FrequencyGain = 0f;
    }


    public void ShakedCamera()
    {
        if(_virtualCamera != null || _virtualCameraNoise != null)
        {
            StartCoroutine(HarlemShake());
        }
    }

    IEnumerator HarlemShake()
    {
        _virtualCameraNoise.m_AmplitudeGain = _shakeAmplitude;
        _virtualCameraNoise.m_FrequencyGain = _shakeFrequency;
        yield return new WaitForSeconds(0.5f);
        _virtualCameraNoise.m_AmplitudeGain = 0f;
        _virtualCameraNoise.m_FrequencyGain = 0f;
    }

    public void Shooting()
    {
        StartCoroutine(ShootShake());
    }

    IEnumerator ShootShake()
    {
        _virtualCameraNoise.m_AmplitudeGain = _shakeAmplitudeInShooting;
        _virtualCameraNoise.m_FrequencyGain = _shakeFrequencyInShooting;
        yield return new WaitForSeconds(0.2f);
        _virtualCameraNoise.m_AmplitudeGain = 0f;
        _virtualCameraNoise.m_FrequencyGain = 0f;
    }
}
