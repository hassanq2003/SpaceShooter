using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score=0;

    public int getScore()
    {
        return score;
    }

    public void modifyScore(int value)
    {
        score+=value;
        Mathf.Clamp(score,0,float.MaxValue);
        Debug.Log(score);
    }

    public void ResetScore()
    {
        score=0;
    }

}
