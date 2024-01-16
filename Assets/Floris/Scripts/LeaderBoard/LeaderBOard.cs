using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Dan.Main;

public class LeaderBOard : MonoBehaviour
{
   
    public List<TextMeshProUGUI> name;
    public List<TextMeshProUGUI> scores;
    public TMP_Text username;
    public CheckPoints checkpoints;
    private string publicLeaderBoardKey = 
    "b4fa2ac64019ba32716a56b29e6dd19567c9754b76522bb15898f530e2f29bbf";
    public void Start()
    {
        GetLeaderBoard();
    }
    public void GetLeaderBoard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderBoardKey, ((msg) =>
        {
            int loopLengt = (msg.Length < name.Count) ? msg.Length : name.Count;
            for (int i = 0; i < loopLengt; i++)
            {
                name[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderBoardEntry(string username, float finishTime)
    {
        int score = Mathf.FloorToInt(finishTime/60) * 100 + Mathf.FloorToInt(finishTime % 60);
        LeaderboardCreator.UploadNewEntry(publicLeaderBoardKey, username, score, ((msg) =>
        {
            GetLeaderBoard();
        }));
    }
    
    public void ButtonPressed()
    {
        string playerName = username.text;
        float finishTime = checkpoints.fiishTime;
        SetLeaderBoardEntry(playerName, finishTime);

    }
}
