using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraShakeController : MonoBehaviour
{
    [SerializeField, ReadOnly] private CinemachineVirtualCamera _virtualCamera;
    private CinemachineBasicMultiChannelPerlin _virtualCameraNoise;

    [SerializeField] private ShakeConfig _damageShakeConfig;
    [SerializeField] private ShakeConfig _shootShakeConfig;


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
        _virtualCameraNoise.m_AmplitudeGain = _damageShakeConfig.ShakeAmplitude;
        _virtualCameraNoise.m_FrequencyGain = _damageShakeConfig.ShakeFrequency;
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
        _virtualCameraNoise.m_AmplitudeGain = _shootShakeConfig.ShakeAmplitude;
        _virtualCameraNoise.m_FrequencyGain = _shootShakeConfig.ShakeFrequency;
        yield return new WaitForSeconds(0.2f);
        _virtualCameraNoise.m_AmplitudeGain = 0f;
        _virtualCameraNoise.m_FrequencyGain = 0f;
    }
}
