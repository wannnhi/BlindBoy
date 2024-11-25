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
        // 데이터 변경 시 리스너 해제
        CountryManager.instance.OnDataUpdated.RemoveListener(UpdateText);
    }

    // 텍스트 갱신
    private void UpdateText()
    {
        int value = CountryManager.instance.GetCountryValue(countryName);
        percentText.SetText($"{countryName}\n{value}%"); // 국가 이름과 값 출력
        subPercentText.SetText($"{value}% 정복됨");
        
    }
}
