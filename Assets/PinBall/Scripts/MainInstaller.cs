using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    [Space]
    [Header("Settings and initial params")]
    [SerializeField]
    GameSettings gameSettings;
    [SerializeField]
    GameAudioSettings audioSettings;

    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        // signals for flipper controller
        // these can be called either by AI or player
        Container.DeclareSignal<EmptynessInside>().WithId("LeftFlipperDown");
        Container.DeclareSignal<EmptynessInside>().WithId("LeftFlipperUp");
        Container.DeclareSignal<EmptynessInside>().WithId("RightFlipperDown");
        Container.DeclareSignal<EmptynessInside>().WithId("RightFlipperUp");

        Container.Bind<AIController>().FromComponentInHierarchy(includeInactive: true).AsSingle();

        Container.Bind<FlipperController>().FromComponentInHierarchy(includeInactive: true).AsSingle();
        Container.Bind<BallSpawnController>().FromComponentInHierarchy(includeInactive: true).AsSingle();
        Container.Bind<SpringArea>().FromComponentInHierarchy(includeInactive: true).AsSingle();
        Container.Bind<ScoreController>().AsSingle();

        Container.BindInstance<GameSettings>(gameSettings);
        Container.BindInstance<GameAudioSettings>(audioSettings);

        // ui views
        // we bind them to any interfaces they might implement and to self too
        Container.BindInterfacesAndSelfTo<MenuView>().FromComponentInHierarchy(includeInactive: true).AsSingle();
        Container.BindInterfacesAndSelfTo<InGameView>().FromComponentInHierarchy(includeInactive: true).AsSingle();
        Container.BindInterfacesAndSelfTo<GameOverView>().FromComponentInHierarchy(includeInactive: true).AsSingle();

        // define game states here. simple.
        Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();

        Container.Bind(typeof(IInitializable), typeof(GameState)).To<MenuGameState>().AsSingle();
        Container.Bind(typeof(IInitializable), typeof(GameState)).To<InGameState>().AsSingle();
        Container.Bind(typeof(IInitializable), typeof(GameState)).To<GameOverState>().AsSingle();
    }
}

public class EmptynessInside { }