using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float currentTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        UpdateTimer();
    }
    public void UpdateTimer()
    {
        int minutes =Mathf.FloorToInt(currentTime / 60);
        int seconds =Mathf.FloorToInt(currentTime % 60);
        text.text = string.Format("{00:00}:{1:00}", minutes, seconds);
    }
}
