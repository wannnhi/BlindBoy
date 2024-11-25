using UnityEngine;
using UnityEngine.Events;

public class CountryManager : MonoSingleton<CountryManager>
{
    public int player;
    public int forest;
    public int desert;
    public int deep;
    public int winter;
    public int magma;

    // 데이터 변경 시 호출되는 이벤트
    public UnityEvent OnDataUpdated = new UnityEvent();

    // 특정 국가의 값을 가져오기
    public int GetCountryValue(string countryName)
    {
        switch (countryName)
        {
            case "플레이어":
                return player;
            case "포레스트":
                return forest;
            case "데저트":
                return desert;
            case "딥":
                return deep;
            case "윈터":
                return winter;
            case "마그마":
                return magma;
            default:
                Debug.LogWarning($"국가 {countryName}를 찾을 수 없습니다!");
                return 0;
        }
    }

    // 특정 국가의 값에 추가
    public void AddToCountryValue(string countryName, int valueToAdd)
    {
        switch (countryName)
        {
            case "플레이어":
                player += valueToAdd;
                break;
            case "포레스트":
                forest += valueToAdd;
                break;
            case "데저트":
                desert += valueToAdd;
                break;
            case "딥":
                deep += valueToAdd;
                break;
            case "윈터":
                winter += valueToAdd;
                break;
            case "마그마":
                magma += valueToAdd;
                break;
            default:
                Debug.LogWarning($"국가 {countryName}를 찾을 수 없습니다!");
                return;
        }

        OnDataUpdated.Invoke(); // 변경 알림
    }
}
