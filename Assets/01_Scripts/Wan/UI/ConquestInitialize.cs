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

    private void OnEnable()
    {
      
        CountryManager.instance.OnDataUpdated.AddListener(UpdateText);
        UpdateText();
    }

    private void OnDisable()
    {
        // ������ ���� �� ������ ����
        CountryManager.instance.OnDataUpdated.RemoveListener(UpdateText);
    }

    // �ؽ�Ʈ ����
    private void UpdateText()
    {
        int value = CountryManager.instance.GetCountryValue(countryName);
        percentText.SetText($"{countryName}\n{value}%"); // ���� �̸��� �� ���
        subPercentText.SetText($"{value}% ������");
        
    }
}
