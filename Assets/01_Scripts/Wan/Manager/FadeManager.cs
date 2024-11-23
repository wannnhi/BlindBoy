using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeManager : MonoSingleton<FadeManager>
{
    private Image _fadeImage;

    private void Awake()
    {
        _fadeImage = GetComponent<Image>();

    }

    public void FadeIn(float duration) { _fadeImage.DOFade(1, duration); }

    public void FadeOut(float duration) { _fadeImage.DOFade(0, duration); }

    public void FadeAuto(float duration,float waitTime) { _fadeImage.DOFade(1, duration); _fadeImage.DOFade(1, duration).SetDelay(waitTime); }
}
