using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Dan.Main;
using Dan.Models;

public class LeaderBOard : MonoBehaviour
{
    public Button buttonSwitchSaveHighScore;
    public List<TextMeshProUGUI> name;
    public List<TextMeshProUGUI> scores;
    public TMP_Text username;
    public CheckPoints checkpoints;
    public Saveoad saveLoad;
    private string publicLeaderBoardKey = 
    "b4fa2ac64019ba32716a56b29e6dd19567c9754b76522bb15898f530e2f29bbf";

    public void Start()
    {
        GetLeaderBoard();
       
    }

    private void Update()
    {
        // tijdelijk heb geen VR
        if (Input.GetKey(KeyCode.B))
        {
           
        }
    }
    public void GetLeaderBoard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderBoardKey, ((msg) =>
        {
            int loopLengt = (msg.Length < name.Count) ? msg.Length : name.Count;
            for (int i = 0; i < loopLengt; i++)
            {
                name[i].text = msg[i].Username;
                scores[i].text = FloatToInt(msg[i].Score);

            }
        }));
    }

    public void SetLeaderBoardEntry(string username, float finishTime)
    {
        
        LeaderboardCreator.UploadNewEntry(publicLeaderBoardKey, username, finishTime, ((msg) =>
        {
            GetLeaderBoard();
        }));
    }

    public void ButtonPressed()
    {

        string playerName = username.text;
        float finishTime = checkpoints.fiishTime;
        if (finishTime < saveLoad.bestTime)
        {
            buttonSwitchSaveHighScore.enabled = true;
            SetLeaderBoardEntry(playerName, finishTime);
        }
        

    }
    public string FloatToInt(float time)
    {
        int minutes = Mathf.FloorToInt(checkpoints.fiishTime / 60);
        int seconds = Mathf.FloorToInt(checkpoints.fiishTime % 60);
        int miliSeconds = Mathf.FloorToInt(checkpoints.fiishTime * 1000);
        miliSeconds = checkpoints.miliSeconds % 1000;
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, miliSeconds);
    }
}
