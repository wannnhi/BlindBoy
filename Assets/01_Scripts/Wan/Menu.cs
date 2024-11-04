using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour, IPointerClickHandler
{
    public Image image;

    public void OnPointerClick(PointerEventData eventData)
    {
        image.DOFade(1, 0.2f).OnComplete(() => { SceneManager.LoadScene("Wan");  });
        }

   
}
