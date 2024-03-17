using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    [SerializeField]CinemachineVirtualCamera virtual_cam;
    [SerializeField] public float ShakeIntensity = 1f;
    [SerializeField] public float ShakeTime = 0.2f;
    [SerializeField] GameObject Player;

    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;
    private void Awake()
    { 
        _cbmcp = virtual_cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    private void Start()
    {
        instance = this;
        StopShake();
    }
    public void ShakeCamera()
    {
        _cbmcp.m_AmplitudeGain= ShakeIntensity; 
        timer = ShakeTime;
    }

    public void StopShake()
    {
        _cbmcp.m_AmplitudeGain = 0f;
        timer = 0f;
    }
    private void Update()
    {
        if(Player!=null) {
            if (Player.GetComponent<CharacterController2D>().CameraShake_Fall)
            {
                ShakeCamera();
                Player.GetComponent<CharacterController2D>().ResetCamShake();
            }
            if (timer > 0f)
            {
                timer -= Time.deltaTime;
            }
        }
        if(Player==null) {
            if (timer > 0f)
            {
                timer -= Time.deltaTime;
            }
        }
        
        if (timer <= 0f) {
            StopShake();

        }
    }
}
