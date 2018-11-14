using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[ExecuteInEditMode]
[RequireComponent(typeof(AudioSource))]
public class BumperController : MonoBehaviour
{
    public float Force = 1f;
    public int Points = 100;

    AudioSource audioSource;

    [Inject]
    GameAudioSettings audioSettings;
    [Inject]
    ScoreController scoreController;

    bool alreadyCalled;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (alreadyCalled)
        {
            return;
        }
        alreadyCalled = true;

        collision.rigidbody.AddForce(-collision.contacts[0].normal * Force, ForceMode.Impulse);
        audioSource.PlayOneShot(audioSettings.BumperSound);

        scoreController.AddPoints(this.Points);
        Debug.Log("BUMP!");
    }

    void OnCollisionExit(Collision collision)
    {
        alreadyCalled = false;
    }
}
