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
        percentText.SetText($"{countryName}\n{value}%"); // 국가 이름과 값 출력
        subPercentText.SetText($"{value}% 정복됨");
        
    }
}
