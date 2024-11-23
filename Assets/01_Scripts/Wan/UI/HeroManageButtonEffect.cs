using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class HeroManageButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] CanvasGroup _sellTab;

   
    public void OnPointerEnter(PointerEventData eventData)
    {
        _sellTab.DOFade(1, 0.3f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _sellTab.DOFade(0, 0.3f);
    }
}
