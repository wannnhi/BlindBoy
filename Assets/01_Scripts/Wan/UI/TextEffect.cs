using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


public class TextEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TMP_Text text;
    private string temp;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        temp = text.text;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.SetText($"- {temp}");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.SetText(temp);
    }

    
}
