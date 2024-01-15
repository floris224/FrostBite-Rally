using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBOard : MonoBehaviour
{
    public Saveoad saveLoad;
    
    public List<TMP_Text> time;


    private void Start()
    {
        saveLoad = FindObjectOfType<Saveoad>();
        
    }
    private void LoadLeaderboardData(int profileIndex)
    {
        saveLoad.LoadData();
        for(int i =0; i< saveLoad.loadTime.Length; i++)
        {
            time[i].text = $"Checkpoint {i + 1}: {saveLoad.loadTime[i]} seconds";
        }
    }

    void Update()
    {
        
    }
}
