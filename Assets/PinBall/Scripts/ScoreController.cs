using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController
{
    const string scoreSettingName = "highScore";

    public int CurrentScore { get; protected set; }

    public int HighScore
    {
        get { return PlayerPrefs.GetInt(scoreSettingName, 0); }
    }

    public void AddPoints(int value)
    {
        CurrentScore += value;
    }

    public void ResetCurrent()
    {
        CurrentScore = 0;
    }

    public void Save()
    {
        if (CurrentScore > PlayerPrefs.GetInt(scoreSettingName, 0))
        {
            PlayerPrefs.SetInt(scoreSettingName, CurrentScore);
            PlayerPrefs.Save();
        }
    }
}
