using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class SlingshotController : MonoBehaviour
{
    public float Force = 1f;
    public int Points = 200;

    AudioSource audioSource;

    [Inject]
    GameAudioSettings audioSettings;
    [Inject]
    ScoreController scoreController;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    bool alreadyCalled;

    void OnCollisionEnter(Collision collision)
    {
        if (alreadyCalled)
        {
            return;
        }
        alreadyCalled = true;

        collision.rigidbody.AddForce(this.transform.forward * Force, ForceMode.Impulse);
        audioSource.PlayOneShot(audioSettings.SlingshotSound);

        scoreController.AddPoints(this.Points);
        Debug.Log("slingshot touched");
    }

    void OnCollisionExit(Collision collision)
    {
        alreadyCalled = false;
    }

  
}
