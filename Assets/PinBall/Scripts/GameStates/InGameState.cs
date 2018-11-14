using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

public class InGameState : GameState
{
    [Inject]
    InGameView view;
    [Inject]
    GameStateMachine sm;
    [Inject]
    ScoreController scoreController;
    [Inject]
    BallSpawnController spawnController;
    [Inject]
    GameSettings settings;
    [Inject]
    SignalBus signalBus;
    [Inject]
    AIController AI;
    [Inject]
    SpringArea springArea;

    Rigidbody ball;

    bool aiEnabled;

    float maxDrag = 600f;

    float launchForce;

    public void LaunchTheBall()
    {
        var force = Mathf.Lerp(aiEnabled ? 1.3f : settings.MinBallLaunchForce, // ensuring that AI will throw ball with enough force
                        settings.MaxBallLaunchForce,
                        aiEnabled ? Random.Range(0, 1) : launchForce);
        Debug.Log($"Throwing Force {force}");
        ball.AddForce(force * Vector3.forward +
                        Random.Range(-0.5f, 0.5f) * Vector3.left, // some randomization of direction
                        ForceMode.Impulse);
    }

    public override void Initialize()
    {
        view.ToMenu.AddListener(() => sm.ChangeState<MenuGameState>());

        view.LeftDown.AddListener(() => { if (!aiEnabled) signalBus.Fire<EmptynessInside>("LeftFlipperDown"); });
        view.LeftUp.AddListener(() => { if (!aiEnabled) signalBus.Fire<EmptynessInside>("LeftFlipperUp"); });
        view.RightDown.AddListener(() => { if (!aiEnabled) signalBus.Fire<EmptynessInside>("RightFlipperDown"); });
        view.RightUp.AddListener(() => { if (!aiEnabled) signalBus.Fire<EmptynessInside>("RightFlipperUp"); });

        springArea.BallEntered.AddListener(() => { if (!aiEnabled) view.SetActiveAcceleratorPanel(true); });
        springArea.BallLeft.AddListener(() => { if (!aiEnabled) view.SetActiveAcceleratorPanel(false); });

        view.OnAcceleratorDrag.AddListener((x) =>
                {
                    view.SetAcceleratorFill(Mathf.Clamp01(-(x.position - x.pressPosition).y / maxDrag));
                });

        view.OnAcceleratorUp.AddListener((x) =>
        {
            launchForce = Mathf.Clamp01(-(x.position - x.pressPosition).y / maxDrag);
            Debug.Log(x.position - x.pressPosition);
            LaunchTheBall();
            // view.SetActiveAcceleratorPanel(false);
        });
    }

    public override void OnEnter()
    {
        aiEnabled = AI.enabled;
        Debug.Log($"AI is: {aiEnabled}");
        view.enabled = true;
        view.SetAcceleratorFill(0);
        view.SetActiveAcceleratorPanel(!aiEnabled);

        ball = spawnController.Spawn().GetComponent<Rigidbody>();

        if (aiEnabled)
        {
            LaunchTheBall();
        }
    }

    public override void Update()
    {
        view.SetScore(scoreController.CurrentScore);
    }

    public override void OnExit()
    {
        spawnController.DisableBall();
        view.enabled = false;
    }
}