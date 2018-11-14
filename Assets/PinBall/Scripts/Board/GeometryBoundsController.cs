using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class GeometryBoundsController : MonoBehaviour
{
    public UnityEvent BallLeftGeometry;

    [Inject]
    GameStateMachine sm;

    void OnTriggerExit(Collider other)
    {
        BallLeftGeometry.Invoke();
        sm.ChangeState<GameOverState>();
    }
}
