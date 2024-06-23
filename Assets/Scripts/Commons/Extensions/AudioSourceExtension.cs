using CriWare;

public static class AudioSourceExtension
{
    /// <summary>
    /// 再生
    /// </summary>
    public static void Play(this CriAtomSource source, BGM bgm,bool loop)
    {
        source.loop= loop;
        source.Play((int)bgm);
    }

    public static void Play(this CriAtomSource source, SoundEffect se)
    {
        source.Play((int)se);
    }
}