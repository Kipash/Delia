using UnityEngine;
using Zenject;
using PROJECT_HUSKY;
using UnityEngine.UI;

public class GameInstaller : MonoInstaller<GameInstaller>
{
    [SerializeField] Transform mainLight;

    [Header("UI")]
    [SerializeField] Text timeLabel;
    [SerializeField] Text dateLabel;

    public override void InstallBindings()
    {
        InstallSignals();
        BindUI();

        //TimeManager
        Container.Bind<TimeManager>().AsSingle().NonLazy();
        Container.BindInterfacesTo<TimeManager>().AsSingle().NonLazy();

        //GameUI
        Container.Bind<GameUI>().AsSingle().NonLazy();
        Container.BindInterfacesTo<GameUI>().AsSingle().NonLazy();

        //GameManager
        Container.BindInterfacesTo<GameManager>().AsSingle().NonLazy();
        //LightController
        Container.Bind<LightController>().AsSingle().NonLazy();

        //BlockController
        foreach(var block in FindObjectsOfType<BlockController>())
        {
            Container.Bind<BlockController>().FromInstance(block).NonLazy();
            Container.BindInterfacesTo<BlockController>().FromInstance(block).NonLazy();
        }

        //SceneSwitch

        //Main light
        Container.Bind<Transform>()
                 .WithId("MainLight")
            .FromInstance(mainLight);
        
    }

    void BindUI()
    {
        //HUD
        Container.Bind<Text>()
             .WithId("timeUI")
            .FromInstance(timeLabel);

        Container.Bind<Text>()
             .WithId("dateUI")
            .FromInstance(dateLabel);

        /*
        Container.Bind<Text>()
             .WithId("moneyUI")
            .FromInstance(dateLabel);
        */
    }

    void InstallSignals()
    {
        Container.DeclareSignal<OnTimeChanged>().NonLazy();
        Container.DeclareSignal<OnDateChanged>().NonLazy();

        Container.BindSignal<int, int, int, OnTimeChanged>()
        .To<LightController>(x => x.OnTimeChanged)
            .AsSingle()
            .NonLazy();

        Container.DeclareSignal<OnNewHour>().NonLazy();
        
        Container.DeclareSignal<OnCashIn>().NonLazy();
    }
}