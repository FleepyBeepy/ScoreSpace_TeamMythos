using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score = 0;
    public int MultiChoice = 0;
    public int Multiplier = 1;
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    [SerializeField]
    private TextMeshProUGUI MultiText;
    public int Round = 0;
    void Start()
    {
        score = 0;
    }

    public enum NoteHit
    {
        Miss,
        Good,
        Perfect,
      

    }
    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();
        MultiText.text = Multiplier.ToString();
       
        if (Input.GetKeyDown(KeyCode.M))
        {
            ProcessHit(NoteHit.Miss);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            ProcessHit(NoteHit.Good);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ProcessHit(NoteHit.Perfect);
        }
    }

    public void ProcessHit(NoteHit hit)
    {
        Multi();
        switch (hit)
        {
            case NoteHit.Miss:
                score -= 10 ;
                Multiplier = 1;
                Round = 0;
                MultiChoice = 0;
                break;
            case NoteHit.Good:
                score += 10 * Multiplier;
                MultiChoice++;
                break;
            case NoteHit.Perfect:
                score += 20 * Multiplier;
                MultiChoice++;
                break;
            default:
                break;
        }
        if (score <= 0)
        {
            score = 0;
        }
    }

    public void Multi()
    {
        if (MultiChoice == 10 && Round == 0)
        {
            Multiplier++;
            Round++;
        }
        if (MultiChoice == 20 && Round == 1)
        {
            Multiplier++;
            Round++;
        }
        if (MultiChoice == 30 && Round == 2)
        {
            Multiplier++;
            Round++;
        }
        if (MultiChoice == 40 && Round == 3)
        {
            Multiplier++;
            Round++;
        }
        if (Multiplier > 4)
        {
            Multiplier = 4;
        }
    }

  
}
