using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AiTentancle : MonoBehaviour
{
    public UnityEvent OnFeelingBall;
    public UnityEvent OnBallExited;

    void OnTriggerEnter(Collider other)
    {
        OnFeelingBall.Invoke();
    }

    void OnTriggerExit(Collider other)
    {
        OnBallExited.Invoke();
    }
}
