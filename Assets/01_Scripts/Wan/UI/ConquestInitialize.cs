using UnityEngine;
using TMPro;

public class ConquestInitialize : MonoBehaviour
{
    [SerializeField] private string countryName;
    [SerializeField] private TMP_Text subPercentText;
    [SerializeField] private GameObject unlockFrame;
    [SerializeField] private GameObject nextFrame;
    private TMP_Text percentText;

    private void Awake()
    {
        percentText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        int value = CountryManager.instance.GetCountryValue(countryName);
        percentText.SetText($"{countryName}\n{value}%");
        subPercentText.SetText($"{value}% ������");

        // ���ٽ��� Ȱ���� Ȱ��ȭ/��Ȱ��ȭ ó��
        System.Action<bool> toggleFrames = (isActive) =>
        {
            unlockFrame.SetActive(isActive);
            nextFrame.SetActive(isActive);
        };

        toggleFrames(value > 100);
    }
}
