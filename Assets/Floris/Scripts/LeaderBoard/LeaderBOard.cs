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

    private string publicLeaderBoardKey = 
    "b4fa2ac64019ba32716a56b29e6dd19567c9754b76522bb15898f530e2f29bbf";

    public void GetLeaderBoard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderBoardKey, ((msg) =>
        {
            for (int i = 0; i < name.Count; i++)
            {
                name[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderBoardEntry(string username, int scores)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderBoardKey, username, scores, ((msg) =>
        {
            GetLeaderBoard();
        }));
    }
}
