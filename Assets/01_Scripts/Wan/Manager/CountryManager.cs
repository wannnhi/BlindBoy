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

    // ������ ���� �� ȣ��Ǵ� �̺�Ʈ
    public UnityEvent OnDataUpdated = new UnityEvent();

    // Ư�� ������ ���� ��������
    public int GetCountryValue(string countryName)
    {
        switch (countryName)
        {
            case "�÷��̾�":
                return player;
            case "������Ʈ":
                return forest;
            case "����Ʈ":
                return desert;
            case "��":
                return deep;
            case "����":
                return winter;
            case "���׸�":
                return magma;
            default:
                Debug.LogWarning($"���� {countryName}�� ã�� �� �����ϴ�!");
                return 0;
        }
    }

    // Ư�� ������ ���� �߰�
    public void AddToCountryValue(string countryName, int valueToAdd)
    {
        switch (countryName)
        {
            case "�÷��̾�":
                player += valueToAdd;
                break;
            case "������Ʈ":
                forest += valueToAdd;
                break;
            case "����Ʈ":
                desert += valueToAdd;
                break;
            case "��":
                deep += valueToAdd;
                break;
            case "����":
                winter += valueToAdd;
                break;
            case "���׸�":
                magma += valueToAdd;
                break;
            default:
                Debug.LogWarning($"���� {countryName}�� ã�� �� �����ϴ�!");
                return;
        }

        OnDataUpdated.Invoke(); // ���� �˸�
    }
}
