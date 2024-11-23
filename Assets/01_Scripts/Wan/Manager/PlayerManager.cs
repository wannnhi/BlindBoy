using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    public List<EnityStatus> myHero; // ���� ���� ���� ����Ʈ
    public float currentMoney; // ���� ���� �� 

    public void SellHero(EnityStatus enityStatus)
    {
        enityStatus.Upgraded = 0;
        
    }

    public void AddHero(EnityStatus enityStatus)
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
