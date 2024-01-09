using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBOard : MonoBehaviour
{
    public Saveoad saveLoad;
    public List<Button> loadButtons;
    public List<TMP_Text> time;


    private void Start()
    {
        saveLoad = FindObjectOfType<Saveoad>();
        for (int i = 0; i < loadButtons.Count; i++)
        {
            int profileIndex = i;
            loadButtons[i].onClick.AddListener(() => LoadLeaderboardData(profileIndex));
        }

        // Load initial leaderboard data
        LoadLeaderboardData(0);
    }
    private void LoadLeaderboardData(int profileIndex)
    {
        saveLoad.LoadData();
        for(int i =0; i< saveLoad.loadTime.Length; i++)
        {
            time[i].text = $"Checkpoint {i + 1}: {saveLoad.loadTime[i]} seconds";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
