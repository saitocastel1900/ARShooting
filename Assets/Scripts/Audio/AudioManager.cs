using UnityEngine;

/// <summary>
/// 音Manager
/// </summary>
public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// AudioManagerComponent
    /// </summary>
    [SerializeField] private AudioManagerComponent _component;

    /// <summary>
    /// BGMを流す
    /// </summary>
    /// <param name="bgm">流したいBGM</param>
    /// <param name="loop">ループ再生するか</param>
    /// <param name="fadeTime">終了時のフェードアウト時間</param>
    public void PlayBGM(BGM bgm, bool loop, float fadeTime = 1000f)
    {
        _component.PlayBGM(bgm, loop,fadeTime);
    }
    
    /// <summary>
    /// BGMを停止する
    /// </summary>
    public void StopBGM()
    {
        _component.StopBGM();
    }

    /// <summary>
    /// SEを流す
    /// </summary>
    /// <param name="soundEffect">流したいSE</param>
    public void PlaySoundEffect(SoundEffect soundEffect)
    {
        _component.PlaySoundEffect(soundEffect);
    }
}