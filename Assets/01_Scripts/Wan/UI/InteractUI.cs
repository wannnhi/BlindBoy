using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class InteractUI : MonoBehaviour
{
    private GameObject _outline;
    private Vector2 _temp;
    private Vector2 _scaledTemp;

    [SerializeField] private RectTransform _interactFrame; 

    private void Awake()
    {
        _outline = transform.Find("Outline").gameObject;
        print(_outline);

        _temp = transform.localScale;
        _scaledTemp = new Vector2(_temp.x - 0.4f, _temp.y - 0.4f);
    }

    private void OnMouseUp()
    {
        transform.DOScale(_temp,0.1f).SetEase(Ease.OutCubic);
        _interactFrame.DOScale(new Vector2(1,1), 0.1f).SetEase(Ease.InQuad);
        
    }

    private void OnMouseDown()
    {
        transform.DOScale(_scaledTemp, 0.1f).SetEase(Ease.InCubic);
    }

    private void OnMouseEnter()
    {
        _outline.SetActive(true);   
    }

    private void OnMouseExit()
    {
        _outline.SetActive(false);
    }

    public void CloseUI()
    {
        _interactFrame.DOScale(new Vector2(1, 0), 0.1f).SetEase(Ease.OutQuad);
    }
}
