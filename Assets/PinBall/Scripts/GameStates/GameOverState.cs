using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameOverState : GameState
{
    [Inject]
    GameOverView view;
    [Inject]
    GameStateMachine sm;
    [Inject]
    ScoreController scoreController;

    public override void Initialize()
    {
        view.OnToMenuClicked.AddListener(() => sm.ChangeState<MenuGameState>());
        view.OnRestartClicked.AddListener(() => sm.ChangeState<InGameState>());
    }

    public override void OnEnter()
    {
        view.enabled = true;
        scoreController.Save();
        view.SetScore(scoreController.CurrentScore);
    }

    public override void OnExit()
    {
        view.enabled = false;
        scoreController.ResetCurrent();
    }
}