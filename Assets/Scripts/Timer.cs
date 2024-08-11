using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timerTxt;

    private void Update()
    {
        _timerTxt.text = "Timer: " + ((int)(GameManager.instance.timer()) / 60).ToString("00") + " : " + ((int)(GameManager.instance.timer()) % 60).ToString("00");
    }
}
