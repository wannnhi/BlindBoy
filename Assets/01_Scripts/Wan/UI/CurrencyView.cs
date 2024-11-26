using UnityEngine;
using TMPro;
public class CurrencyView : MonoBehaviour
{
    TMP_Text currencyText;

    private void Awake()
    {
        currencyText = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        currencyText.SetText($"${PlayerManager.instance.currentMoney.ToString("N2")}");
    }
}
