using UnityEngine;
using DG.Tweening;

public class InteractUI : MonoBehaviour
{
    private GameObject _outline;
    private Vector2 _temp;
    private Vector2 _scaledTemp;
    private bool isOpened;

    [SerializeField] private RectTransform _interactFrame;
    [SerializeField] private Camera mainCamera;

    private void Awake()
    {
        _outline = transform.Find("Outline").gameObject;

        _temp = transform.localScale;
        _scaledTemp = new Vector2(_temp.x - 0.4f, _temp.y - 0.4f);
    }

    private void OnMouseUp()
    {
        if (!isOpened)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = mainCamera.WorldToScreenPoint(_interactFrame.position).z;

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            _interactFrame.position = worldPosition;

            transform.DOScale(_temp, 0.1f).SetEase(Ease.OutCubic);
            _interactFrame.DOScale(new Vector2(1, 1), 0.1f).SetEase(Ease.InQuad);
            isOpened = true;
        }
    }

    private void OnMouseDown()
    {
        if (!isOpened)
        {
            transform.DOScale(_scaledTemp, 0.1f).SetEase(Ease.InCubic);
        }
    }

    private void OnMouseEnter()
    {
        if (!isOpened)
        {
            _outline.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        _outline.SetActive(false);
    }

    public void CloseUI()
    {
        _interactFrame.DOScale(new Vector2(1, 0), 0.1f).SetEase(Ease.OutQuad);
        isOpened = false;
    }
}
