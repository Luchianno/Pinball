using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class MenuView : BasicView
{
    [SerializeField]
    Button start;
    [SerializeField]
    Button AIStart;
    [SerializeField]
    Button highScore;
    [SerializeField]
    Button egg;
    [SerializeField]
    BackKeyListener backKey;
    [SerializeField]
    TextMeshProUGUI highScoreLabel;

    public UnityEvent OnStartClicked;
    public UnityEvent OnStartAIClicked;
    public UnityEvent OnHighScoreClicked;
    public UnityEvent OnEggClicked;
    public UnityEvent OnBackKeyClicked;

    void Start()
    {
        start.onClick.AddListener(OnStartClicked.Invoke);
        AIStart.onClick.AddListener(OnStartAIClicked.Invoke);
        highScore.onClick.AddListener(OnHighScoreClicked.Invoke);
        egg.onClick.AddListener(OnEggClicked.Invoke);
        backKey.BackClicked.AddListener(OnBackKeyClicked.Invoke);
    }

    public void SetHighScore(int score)
    {
        highScoreLabel.text = $"High Score: {score}";
    }
}