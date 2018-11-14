using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingForceTest : MonoBehaviour
{
    public float Force;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Force * Vector3.forward + Random.Range(-3f, 3f) * Vector3.left, ForceMode.Impulse);
    }

}
