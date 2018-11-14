using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class FlipperController : MonoBehaviour
{
    [SerializeField]
    HingeJoint left;

    [SerializeField]
    HingeJoint right;

    [SerializeField]
    AudioClip downSound, upSound;

    Rigidbody leftBody, rightBody;

    AudioSource audioSource;

    [Inject]
    GameSettings settings;

    [Inject]
    GameAudioSettings audioSettings;

    [Inject]
    SignalBus signalBus;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        leftBody = left.GetComponent<Rigidbody>();
        rightBody = right.GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        signalBus.Subscribe<EmptynessInside>(LeftDown, "LeftFlipperDown");
        signalBus.Subscribe<EmptynessInside>(LeftUp, "LeftFlipperUp");
        signalBus.Subscribe<EmptynessInside>(RightDown, "RightFlipperDown");
        signalBus.Subscribe<EmptynessInside>(RightUp, "RightFlipperUp");
    }


    void OnDisable()
    {
        signalBus.Unsubscribe<EmptynessInside>(LeftDown, "LeftFlipperDown");
        signalBus.Unsubscribe<EmptynessInside>(LeftUp, "LeftFlipperUp");
        signalBus.Unsubscribe<EmptynessInside>(RightDown, "RightFlipperDown");
        signalBus.Unsubscribe<EmptynessInside>(RightUp, "RightFlipperUp");
    }


    public void LeftDown()
    {
        ApplySettings();

        var motor = left.motor;
        motor.force = settings.FlipperForce;
        left.motor = motor;
        left.useMotor = true;

        audioSource.PlayOneShot(audioSettings.FlipperDownSound);
    }

    void RightDown()
    {
        ApplySettings();

        var motor = right.motor;
        motor.force = settings.FlipperForce;
        right.motor = motor;
        right.useMotor = true;

        audioSource.PlayOneShot(audioSettings.FlipperDownSound);
    }

    public void LeftUp()
    {
        left.useMotor = false;
        audioSource.PlayOneShot(audioSettings.FlipperUpSound);
    }

    void RightUp()
    {
        right.useMotor = false;
        audioSource.PlayOneShot(audioSettings.FlipperUpSound);
    }

    void ApplySettings()
    {
        // spring
        var spring = new JointSpring()
        {
            spring = settings.FlipperSpring,
            damper = settings.FlipperSpringDamper
        };

        left.spring = spring;
        right.spring = spring;

        var motor = left.motor;
        motor.targetVelocity = settings.FlipperTargetVelocity;

        left.motor = motor;
        right.motor = motor;

        // rigidbody
        leftBody.mass = settings.FlipperMass;
        rightBody.mass = settings.FlipperMass;
    }

}
