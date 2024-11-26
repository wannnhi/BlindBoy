using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    public List<EnityStatus> myRealHero; // ������ �� ���� ����Ʈ
    public List<EnityStatus> myHero; // ���� ���� ���� ����Ʈ
    public float currentMoney; // ���� ���� �� 
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
