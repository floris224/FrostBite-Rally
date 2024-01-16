
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI inputScore;
    public TMP_InputField inputName;
    public UnityEvent<string, int> submitScoreEvent;
   
    private void Start()
    {
        
    }
    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));

    }
}
