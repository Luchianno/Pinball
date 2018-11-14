using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public class DebugInputController : MonoBehaviour
{
    [Header("For testing in Editor")]
    [SerializeField]
    KeyCode leftKey;
    [SerializeField]
    KeyCode rightKey;

    [Inject]
    protected SignalBus signalBus;

    // using signal bus to communicate with flipper controller
    void Update()
    {
#if UNITY_EDITOR
        // left
        if (Input.GetKeyDown(leftKey))
        {
            signalBus.Fire<EmptynessInside>("LeftFlipperDown");
        }

        if (Input.GetKeyUp(leftKey))
        {
            signalBus.Fire<EmptynessInside>("LeftFlipperUp");
        }

        // right
        if (Input.GetKeyDown(rightKey))
        {
            signalBus.Fire<EmptynessInside>("RightFlipperDown");
        }

        if (Input.GetKeyUp(rightKey))
        {
            signalBus.Fire<EmptynessInside>("RightFlipperUp");
        }
#endif

    }
}
