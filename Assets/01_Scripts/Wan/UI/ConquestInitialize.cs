using UnityEngine;
using TMPro;

public class ConquestInitialize : MonoBehaviour
{
    [SerializeField] private string countryName;
    [SerializeField] private TMP_Text subPercentText;
    private TMP_Text percentText;

    private void Awake()
    {
        percentText = GetComponent<TMP_Text>();
    }

    public void UpdateText()
    {   
        int value = CountryManager.instance.GetCountryValue(countryName);
        percentText.SetText($"{countryName}\n{value}%"); // ���� �̸��� �� ���
        subPercentText.SetText($"{value}% ������");
        
    }
}
