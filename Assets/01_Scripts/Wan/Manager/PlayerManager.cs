using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    public List<EntityStatusSO> myRealHero; // ������ �� ���� ����Ʈ
    public List<EntityStatusSO> myHero; // ���� ���� ���� ����Ʈ
    public float currentMoney; // ���� ���� �� 
    [SerializeField] private GameObject overViewUI;


    public void SellHero(EntityStatusSO enityStatus)
    {
        enityStatus.Upgraded = 0;
        Destroy(overViewUI.transform.Find(enityStatus.name));

    }

    public void AddMoney(float money)
    {
        currentMoney += money;
    }


    public void AddHero(EntityStatusSO enityStatus)
    {

        if (myHero.Contains(enityStatus))
        {
            StartCoroutine(MiniCoroutine());

            enityStatus.Upgraded += 1;
        }
        else
        {
            myHero.Add(enityStatus);
            Debug.Log($"���ο� ���� �߰�: {enityStatus.name}");

        }
        GameManager.Instance.InitializeAllHeroStats();
    }

    IEnumerator MiniCoroutine()
    {
        yield return new WaitForSeconds(9);
        AlertManager.instance.SendAlert("�̹� �����ϰ� �ִ� ������ ��ȭ�˴ϴ�.");
    }
}