﻿using UnityEngine;

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
    public void PlayBGM(BGM bgm, bool loop)
    {
        _component.PlayBGM(bgm, loop);
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