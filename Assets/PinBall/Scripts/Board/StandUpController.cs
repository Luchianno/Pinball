using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class StandUpController : MonoBehaviour
{
    public float Force = 1f;
    public int Points = 200;
    public float FlickerTime = 2f;
    public Color LightColor;
    public Color DisabledColor;

    [SerializeField]
    SpriteRenderer lightRenderer;

    AudioSource audioSource;

    [Inject]
    GameAudioSettings audioSettings;
    [Inject]
    ScoreController scoreController;

    WaitForSeconds wait;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        wait = new WaitForSeconds(FlickerTime);
		lightRenderer.color = DisabledColor;
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
        audioSource.PlayOneShot(audioSettings.StandUpSound);

        scoreController.AddPoints(this.Points);
        Debug.Log("Standup touched");
        StopAllCoroutines();
        StartCoroutine(ChangeLights());
    }

    void OnCollisionExit(Collision collision)
    {
        alreadyCalled = false;
    }

    IEnumerator ChangeLights()
    {
        lightRenderer.color = this.LightColor;
        yield return wait;
        lightRenderer.color = this.DisabledColor;
    }
}
