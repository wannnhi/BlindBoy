using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    public List<EnityStatusSO> myHero; // 보유 중인 영웅 리스트
    public float currentMoney; // 보유 중인 돈 

    public void SellHero(EnityStatusSO enityStatus)
    {
        enityStatus.Upgraded = 0;
        
    }

    public void AddHero(EnityStatusSO enityStatus)
    {   
       
        if (myHero.Contains(enityStatus))
        {
           
            Debug.Log($"이미 보유 중인 영웅: {enityStatus.name}");
            enityStatus.Upgraded += 1;
        }
        else
        {
            myHero.Add(enityStatus);
            Debug.Log($"새로운 영웅 추가: {enityStatus.name}");
           
        }
        GameManager.Instance.InitializeAllHeroStats();
    }
}
