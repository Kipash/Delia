using UnityEngine;
using Zenject;
using PROJECT_HUSKY;
public class MainInstaller : MonoInstaller<MainInstaller>
{
    public override void InstallBindings()
    {
        InstallSignals();
        BindInterfacesTo();
    }
    void InstallSignals()
    {
        Container.DeclareSignal<OnChangeScene>().NonLazy();
        Container.DeclareSignal<ChangeScene>().NonLazy();

        Container.BindSignal<Scene, ChangeScene>()
            .To<SceneManager>(x => x.ChangeScene)
            .AsSingle()
            .NonLazy();

        //Container.BindSignal<Scene, OnChangeSceneSignal>()
        //    .To<Test>(x => x.Test_OnChangeScene).AsSingle();
    }
    void BindInterfacesTo()
    {
        Container.BindInterfacesTo<SceneManager>().AsSingle().NonLazy();
        Container.BindInterfacesTo<AppManager>().AsSingle().NonLazy();
    }
}