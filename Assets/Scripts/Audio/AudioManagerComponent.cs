using Commons.Utility;
using CriWare;
using UnityEngine;

/// <summary>
/// CriAtomSourceを管理するクラス
/// </summary>
public class AudioManagerComponent : MonoBehaviour
{
    /// <summary>
    /// BGMのCriAtomSource
    /// </summary>
    [SerializeField] private CriAtomSource _bgmSource;

    /// <summary>
    /// SEのCriAtomSource
    /// </summary>
    [SerializeField] private CriAtomSource _seSource;

    public void Start()
    {
        _bgmSource = InitializeCriAtomSource(_bgmSource, true);
        _seSource = InitializeCriAtomSource(_seSource, false);
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private CriAtomSource InitializeCriAtomSource(CriAtomSource criAtomSource, bool isLoop = false)
    {
        criAtomSource.loop = isLoop;
        criAtomSource.playOnStart = false;
        
        return criAtomSource;
    }

    /// <summary>
    /// BGMを流す
    /// </summary>
    /// <param name="bgm">流したいBGM</param>
    /// <param name="loop">ループ再生するか</param>
    /// <param name="fadeTime">終了時のフェードアウト時間</param>
    public void PlayBGM(BGM bgm, bool loop, float fadeTime = 1000f)
    {
        if (_bgmSource.player.GetStatus() == CriAtomExPlayer.Status.Playing)
        {
            DebugUtility.Log("すにでBGMが再生中です");
            return;
        }
        
        _bgmSource.player.SetEnvelopeReleaseTime(fadeTime);
        _bgmSource.Play(bgm, loop);
    }
    
    /// <summary>
    /// BGMを停止する
    /// </summary>
    public void StopBGM()
    {
        _bgmSource.Stop();
    }

    /// <summary>
    /// SEを流す
    /// </summary>
    /// <param name="soundEffect">流したいSE</param>
    public void PlaySoundEffect(SoundEffect soundEffect)
    {
        _seSource.Play(soundEffect);
    }
}