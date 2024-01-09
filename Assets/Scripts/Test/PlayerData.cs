using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public string playerName;
    public float totalRaceTime;
    public List<float> checkpointTimes;
    public PlayerData(string name)
    {
        playerName = name;
        totalRaceTime = 0;
        checkpointTimes = new List<float>();
    }
}
