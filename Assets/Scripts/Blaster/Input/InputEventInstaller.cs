using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InputEventInstaller : MonoInstaller
{
    [SerializeField] private Button _shotButton ;
    
    public override void InstallBindings()
    {
#if UNITY_EDITOR
        Container.Bind(typeof(IInputEventProvider), 
                typeof(IInitializable), typeof(IDisposable))
            .To<MouseInputProvider>().AsSingle().WithArguments(_shotButton);
#elif UNITY_ANDROID
        Container.Bind(typeof(IInputEventProvider), 
                typeof(IInitializable), typeof(IDisposable))
            .To<TouchInputProvider>().AsSingle().WithArguments(_shotButton);
#endif
    }
}