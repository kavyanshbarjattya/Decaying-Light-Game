using UnityEngine;
public class MusicLerp : MonoBehaviour
{
    public static MusicLerp instance;

    [SerializeField] AudioSource mainMusic;
    [SerializeField] AudioSource tenseMusic;

    [SerializeField] AnimationCurve main, tense;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        mainMusic.Play();
        tenseMusic.Play();
        tenseMusic.volume = 0;
    }


    public void Progress(float pro)
    {
        mainMusic.volume = main.Evaluate(pro);
        tenseMusic.volume = tense.Evaluate(pro);
    }
}