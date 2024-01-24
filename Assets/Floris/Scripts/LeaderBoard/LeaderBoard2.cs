using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Dan.Main;
using Dan.Models;

public class LeaderBoard2 : MonoBehaviour
{
    public GameObject buttonSwitchSaveHighScore;
    public List<TextMeshProUGUI> name;
    public List<TextMeshProUGUI> scores;

    public TMP_Text username;
    public CheckPointsMap2 checkpoints;
    public SaveLoadMAp2 saveLoad;
    public string publicLeaderBoardKey;
    // public key map 1
    // "b4fa2ac64019ba32716a56b29e6dd19567c9754b76522bb15898f530e2f29bbf";

    //public key map 2
    //a0c6bf68f52808add341859a3c2c0365363f98bd4cd86109c61da802b7a28c32
    public void Start()
    {
        GetLeaderBoard();

    }

    private void Update()
    {
        // tijdelijk heb geen VR
        if (Input.GetKey(KeyCode.B))
        {
            ButtonPressed();
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

                scores[i].text = msg[i].Extra;

            }
        }));
    }

    public void SetLeaderBoardEntry(string username, int score, string finishTime)
    {

        LeaderboardCreator.UploadNewEntry(publicLeaderBoardKey, username, score, finishTime, ((msg) =>
        {
            GetLeaderBoard();
        }));
    }

    public void ButtonPressed()
    {

        string playerName = username.text;
        string finishTime = FloatToString(checkpoints.fiishTime);
        int finishTimeScore = (int)checkpoints.fiishTime;

        Debug.Log("SAved");
        buttonSwitchSaveHighScore.SetActive(true);
        SetLeaderBoardEntry(playerName, finishTimeScore, finishTime);



    }
    public string FloatToString(float time)
    {
        int minutes = Mathf.FloorToInt(checkpoints.fiishTime / 60);
        int seconds = Mathf.FloorToInt(checkpoints.fiishTime % 60);
        int miliSeconds = Mathf.FloorToInt(checkpoints.fiishTime * 1000);
        miliSeconds = checkpoints.miliSeconds % 1000;
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, miliSeconds);
    }
}