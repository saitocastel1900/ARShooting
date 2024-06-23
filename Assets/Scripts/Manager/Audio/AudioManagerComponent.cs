using Commons.Utility;
using CriWare;
using UnityEngine;


    public class AudioManagerComponent : MonoBehaviour
    {
        /// <summary>
        /// BGMのAudioSource
        /// </summary>
        [SerializeField] private CriAtomSource _bgmSource;

        /// <summary>
        /// SEのAudioSource
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
        public void PlayBGM(BGM bgm,bool loop)
        {
            if (_bgmSource.player.GetStatus() == CriAtomExPlayer.Status.Playing)
            {
                DebugUtility.Log(bgm + "は見つかりません");
                return;
            }
            
            _bgmSource.Play(bgm,loop);
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
