using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ManageHeroButton : MonoBehaviour
{
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private float y;
    
    public void OpenManageHero()
    {
        StartCoroutine(FadeEffect());

    }
    IEnumerator FadeEffect()
    {
        FadeManager.instance.FadeIn(1);

        yield return new WaitForSeconds(1);
        _mainCamera.position = new Vector3(_mainCamera.position.x, y,_mainCamera.position.z);
        FadeManager.instance.FadeOut(1);

       
    }

}
