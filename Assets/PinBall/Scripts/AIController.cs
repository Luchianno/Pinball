using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AIController : MonoBehaviour
{
    [SerializeField]
    AiTentancle left;
    [SerializeField]
    AiTentancle right;

    [Inject]
    SignalBus signalBus;

    // no #DeepLearning needed here I guess
    // We're using signalBus to communicate with FlipperController
    void Start()
    {
        left.OnFeelingBall.AddListener(() =>
                                        {
                                            if (this.isActiveAndEnabled)
                                                signalBus.Fire<EmptynessInside>("LeftFlipperDown");
                                        }
        );

        left.OnBallExited.AddListener(() =>
                                        {
                                            if (this.isActiveAndEnabled)
                                                signalBus.Fire<EmptynessInside>("LeftFlipperUp");
                                        }
        );

        right.OnFeelingBall.AddListener(() =>
                                        {
                                            if (this.isActiveAndEnabled)
                                                signalBus.Fire<EmptynessInside>("RightFlipperDown");
                                        }
        );

        right.OnBallExited.AddListener(() =>
                                        {
                                            if (this.isActiveAndEnabled)
                                                signalBus.Fire<EmptynessInside>("RightFlipperUp");
                                        }
        );
    }
}
