using UnityEngine;
using Zenject;

/// <summary>
/// 的の残存数の注入する
/// </summary>
public class RemainingTargetCounterTextInstaller : MonoInstaller
{
    /// <summary>
    /// 的の残存数
    /// </summary>
    [SerializeField] private int _remainingTargetCount = 10;

    /// <summary>
    /// RemainingTargetCounterTextView
    /// </summary>
    [SerializeField] private RemainingTargetCounterTextView _remainingTargetCounterTextView;

    public override void InstallBindings()
    {
        Container.Bind(typeof(RemainingTargetCounterTextPresenter), typeof(IInitializable))
            .To<RemainingTargetCounterTextPresenter>().AsCached().NonLazy();
        Container.Bind<IRemainingTargetCounterTextModel>().To<RemainingTargetCounterTextModel>()
            .AsCached().WithArguments(_remainingTargetCount);
        Container.Bind<RemainingTargetCounterTextView>().FromInstance(_remainingTargetCounterTextView);
    }
}