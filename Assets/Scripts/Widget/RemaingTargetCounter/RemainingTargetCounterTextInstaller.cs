using UnityEngine;
using Zenject;

public class RemainingTargetCounterTextInstaller : MonoInstaller
{
    [SerializeField] private int _remainingTargetCount = 10;
    
    public override void InstallBindings()
    {
        Container.Bind(typeof(RemainingTargetCounterTextPresenter),typeof(IInitializable)).To<RemainingTargetCounterTextPresenter>().AsCached().NonLazy();
        Container.Bind<IRemainingTargetCounterTextModel>().To<RemainingTargetCounterTextModel>().AsCached().WithArguments(_remainingTargetCount);
    }
}