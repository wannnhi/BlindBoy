using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    public List<EnityStatusSO> myHero; // ���� ���� ���� ����Ʈ
    public float currentMoney; // ���� ���� �� 

    public void SellHero(EnityStatusSO enityStatus)
    {
        enityStatus.Upgraded = 0;
        
    }

    public void AddHero(EnityStatusSO enityStatus)
    {   
       
        if (myHero.Contains(enityStatus))
        {
           
            Debug.Log($"�̹� ���� ���� ����: {enityStatus.name}");
            enityStatus.Upgraded += 1;
        }
        else
        {
            myHero.Add(enityStatus);
            Debug.Log($"���ο� ���� �߰�: {enityStatus.name}");
           
        }
        GameManager.Instance.InitializeAllHeroStats();
    }
}
