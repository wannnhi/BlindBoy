using UnityEngine;
using DG.Tweening;

public class GachaJoin : MonoBehaviour
{
    [SerializeField] private CanvasGroup CountryGacha;
    
    public void GachaOpen()
    {
        CountryGacha.DOFade(1, 0.3f);
        CountryGacha.blocksRaycasts = true;
    }
    public void GachaClose()
    {
        CountryGacha.DOFade(0, 0.3f);
        CountryGacha.blocksRaycasts = false;
    }
}
