using System;
using Zenject;

public class InputEventInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
#if UNITY_EDITOR
        Container.Bind(typeof(IInputEventProvider), 
                typeof(IInitializable), typeof(IDisposable))
            .To<MouseInputProvider>().AsSingle();
#elif UNITY_ANDROID
        Container.Bind(typeof(IInputEventProvider), 
                typeof(IInitializable), typeof(IDisposable))
            .To<TouchInputProvider>().AsSingle();
#endif
    }
}