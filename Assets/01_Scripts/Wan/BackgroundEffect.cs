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

        _background.DOMove(_target.position, 60f)
            .SetEase(Ease.InSine).SetDelay(2)
            .OnComplete(() =>
            {

                _background.DOMove(_originalPosition, 60f)
                    .SetEase(Ease.OutSine).SetDelay(2)
                    .OnComplete(AnimateBackground); 
            });
    }
}
