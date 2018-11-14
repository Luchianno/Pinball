using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpringArea : MonoBehaviour
{
    public UnityEvent BallEntered, BallLeft;

    void OnTriggerEnter(Collider other)
    {
        BallEntered.Invoke();
    }

    void OnTriggerExit(Collider other)
    {
        BallLeft.Invoke();
    }
}
