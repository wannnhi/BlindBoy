using UnityEngine;
using DG.Tweening;

public class BackgroundEffect : MonoBehaviour
{
    [SerializeField] private Transform _background; 
    [SerializeField] private Transform _target;     
    private Vector3 _originalPosition;              

    private void Start()
    {
        _originalPosition = _background.position;

        AnimateBackground();
    }

    private void AnimateBackground()
    {

        _background.DOMove(new Vector3(_target.position.y,transform.position.y), 60f)
            .SetEase(Ease.InSine).SetDelay(2)
            .OnComplete(() =>
            {

                _background.DOMove(new Vector3(_originalPosition.x,transform.position.y), 60f)
                    .SetEase(Ease.OutSine).SetDelay(2)
                    .OnComplete(AnimateBackground); 
            });
    }
}
