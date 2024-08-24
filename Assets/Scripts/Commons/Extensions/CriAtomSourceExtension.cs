using CriWare;

/// <summary>
/// AudioSourceの拡張メソッド
/// </summary>
public static class CriAtomSourceExtension
{
    /// <summary>
    /// 再生
    /// </summary>
    /// <param name="source">CriAtomSource</param>
    /// <param name="bgm">BGM</param>
    /// <param name="loop">ループ再生するか</param>
    public static void Play(this CriAtomSource source, BGM bgm,bool loop)
    {
        source.loop = loop;
        source.Play(bgm.ToString());
    }

    /// <summary>
    /// 再生
    /// </summary>
    /// <param name="source">CriAtomSource</param>
    /// <param name="se">SoundEffect</param>
    public static void Play(this CriAtomSource source, SoundEffect se)
    {
        source.Play(se.ToString());
    }
}