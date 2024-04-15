using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CinemaChineCamara : MonoBehaviour
{
    public static CinemaChineCamara Instance { get; private set; }
    private CinemachineVirtualCamera CinemachineVirtualCamera;
    private float timer;
    private void Awake()
    {
        Instance = this;
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    public void Movicamara(float intencidad, float tiempo)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intencidad;
        timer = tiempo;
    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }
}
