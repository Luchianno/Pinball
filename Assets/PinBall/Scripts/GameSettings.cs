using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PinBall/Starting Parameters")]
public class GameSettings : ScriptableObject
{
    [Header("Inclination of Board (degrees)")]
    [Range(0, 15)]
    public float Inclination = 6.5f;

    [Header("Flipper rigidbody settings")]
    // [Space(20)]
    public float FlipperMass = 100f;

    [Header("Flipper motor settings")]

    public float FlipperForce = 100f;

    public float FlipperTargetVelocity = 100f;

    [Header("Flipper string settings")]
    public float FlipperSpring;
    public float FlipperSpringDamper;

    [Header("Ball launcher range")]
    public float MinBallLaunchForce;
    public float MaxBallLaunchForce;
    
    [Space]
    public GameObject BallPrefab;
}
