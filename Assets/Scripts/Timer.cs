using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI Clock;
    public string bestTimeKey = "BestTimeKey"; // the player prefs key that will be implemented with highscore system
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Clock.text = new string(Mathf.FloorToInt(Time.timeSinceLevelLoad / 60)+":"+Mathf.FloorToInt(Time.timeSinceLevelLoad % 60));
    }
}
