using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    int coinScore = 0;
    int starScore = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCoinScore(int amount)
    {
        coinScore += amount;
    }
    public int GetCoinScore()
    {
        return coinScore;
    }

    public void ChangeStarScore(int amount)
    {
        starScore += amount;
    }
    public int GetStarScore()
    {
        return starScore;
    }
}
