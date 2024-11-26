using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    public List<EnityStatus> myRealHero; // 팀으로 들어간 영웅 리스트
    public List<EnityStatus> myHero; // 보유 중인 영웅 리스트
    public float currentMoney; // 보유 중인 돈 
    [SerializeField] private GameObject overViewUI;


    public void SellHero(EnityStatus enityStatus)
    {
        enityStatus.Upgraded = 0;
      //  overViewUI.    
        
    }




    public void AddHero(EnityStatus enityStatus)
    {   
       
        if (myHero.Contains(enityStatus))
        {
            StartCoroutine(MiniCoroutine());
            
            enityStatus.Upgraded += 1;
        }
        else
        {
            myHero.Add(enityStatus);
            Debug.Log($"새로운 영웅 추가: {enityStatus.name}");
           
        }
        GameManager.Instance.InitializeAllHeroStats();
    }

    IEnumerator MiniCoroutine()
    {
        yield return new WaitForSeconds(9);
        AlertManager.instance.SendAlert("이미 보유하고 있는 영웅은 강화됩니다.");
    }
}
