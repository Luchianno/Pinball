using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class GameOverView : BasicView
{
    [SerializeField]
    Button restart;
    [SerializeField]
    Button toMenu;
    [SerializeField]
    TextMeshProUGUI label;

    public UnityEvent OnRestartClicked;
    public UnityEvent OnToMenuClicked;

    protected override void Awake()
    {
        restart.onClick.AddListener(OnRestartClicked.Invoke);
        toMenu.onClick.AddListener(OnToMenuClicked.Invoke);
    }

    public void SetScore(int value)
    {
        label.text = $"good job there!\nTime survived:\n03:14[PlaceHolder]\nYour Score:\n{value}";
    }
}
