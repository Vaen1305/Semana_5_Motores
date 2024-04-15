using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MagerControl : MonoBehaviour
{
    public float timeCounter = 0;
    public TextMeshProUGUI timeText;
    void Update()
    {
        timeCounter += Time.deltaTime;
        timeText.text = "Time: " + timeCounter.ToString("0.00");
    }
    
}
