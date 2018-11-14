using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BallSpawnController : MonoBehaviour
{
    [Inject]
    GameSettings settings;

    GameObject ball;

    public GameObject Spawn()
    {
        if (ball == null)
            ball = Instantiate(settings.BallPrefab, this.transform.position, Quaternion.identity, transform);
        else
        {
            ball.transform.position = transform.position;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.SetActive(true);
        }
        return ball;
    }

    public void DisableBall()
    {
        ball.SetActive(false);
    }
}
