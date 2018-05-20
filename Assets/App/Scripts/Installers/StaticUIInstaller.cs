using UnityEngine;
using Zenject;

public class StaticUIInstaller : MonoInstaller<StaticUIInstaller>
{
    [SerializeField] StaticUI staticUI;
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<StaticUI>().FromInstance(staticUI).AsSingle();
    }
}