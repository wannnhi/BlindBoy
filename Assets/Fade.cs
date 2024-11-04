using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        
        image.DOFade(0, 1).SetDelay(2);
    }

}
