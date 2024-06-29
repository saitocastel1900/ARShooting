using CriWare;

public static class CriAtomSourceExtension
{
    /// <summary>
    /// 再生
    /// </summary>
    public static void Play(this CriAtomSource source, BGM bgm,bool loop)
    {
        source.loop = loop;
        source.Play(bgm.ToString());
    }

    public static void Play(this CriAtomSource source, SoundEffect se)
    {
        source.Play(se.ToString());
    }
}