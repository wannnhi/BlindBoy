using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class SummonButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private CanvasGroup _effectFrame;
    private CanvasGroup _mainFrame;
    private Image _characterImage;
    private TMP_Text _name, _price;

    public EntityStatusSO status;
    public UnityEvent<EntityStatusSO> OnSummon;

    private void Awake()
    {
        _effectFrame = transform.Find("Effect").GetComponent<CanvasGroup>();
        _mainFrame = GetComponent<CanvasGroup>();
        _characterImage = transform.Find("CharacterImage").GetComponent<Image>();
        _name = transform.Find("Name").GetComponent<TMP_Text>();
        _price = transform.Find("Cost").GetComponent<TMP_Text>();
    }

    private void Start()
    {
        _characterImage.sprite = status.characterImage;
        _name.SetText(status.agentName);
        _price.SetText(status.cost.ToString());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _mainFrame.DOFade(0, 0.2f);
        _mainFrame.blocksRaycasts = false;
        StartCoroutine(RestoreMainFrame());
        OnSummon?.Invoke(status);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _effectFrame.DOFade(1, 0.1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _effectFrame.DOFade(0, 0.1f);
    }

    private IEnumerator RestoreMainFrame()
    {
        yield return new WaitForSeconds(status.atkDelay);
        _mainFrame.blocksRaycasts = true;
        _mainFrame.DOFade(1, 0.2f);
    }
}
