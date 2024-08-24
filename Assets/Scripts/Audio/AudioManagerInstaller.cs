using UnityEngine;
using Zenject;

/// <summary>
/// AudioManagerを注入する
/// </summary>
public class AudioManagerInstaller : MonoInstaller
{
    [SerializeField] private AudioManager audioManager;

    public override void InstallBindings()
    {
        Container.Bind<AudioManager>().FromComponentInNewPrefab(audioManager).AsSingle();
    }
}