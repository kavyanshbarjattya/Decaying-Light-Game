using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
public class PostProcessCntroller : MonoBehaviour
{

    public static PostProcessCntroller instance;

    [SerializeField] Volume pp;

    CinemachineVirtualCamera cam;

    private CinemachineBasicMultiChannelPerlin noise;

    private void Awake()
    {
        instance = this;

        cam = FindObjectOfType<CinemachineVirtualCamera>();

        noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    public void UpdatePostProcessVolume(float progress)
    {
        pp.weight = 1 - progress;
        noise.m_FrequencyGain = Mathf.Lerp(0.05f, 1f, 1 - progress);
    }

}