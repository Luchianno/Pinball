using System;
using UnityEngine;

[CreateAssetMenu(menuName = "PinBall/Audio Settings")]
public class GameAudioSettings : ScriptableObject
{
    public AudioClip FlipperDownSound;
    public AudioClip FlipperUpSound;
    public AudioClip BumperSound;
    public AudioClip StandUpSound;
    public AudioClip SlingshotSound;
}