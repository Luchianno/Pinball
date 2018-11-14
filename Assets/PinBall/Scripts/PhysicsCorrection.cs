using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

// We don't incline the slope of the board, we just modify the gravity when game starts
public class PhysicsCorrection : MonoBehaviour
{
    [Inject]
    GameSettings settings;

    void Awake() => ModifyGravity();

    public void ModifyGravity()
    {
        Physics.gravity = new Vector3(0, -9.81f * Mathf.Cos(settings.Inclination), -9.81f * Mathf.Sin(settings.Inclination));
    }
}
