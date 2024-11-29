using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Playables;
using TMPro;
using DG.Tweening;

public class GachaButton : MonoBehaviour
{
    [SerializeField] private List<EntityStatusSO> entities;
    [SerializeField] private PlayableDirector timeline;
    [SerializeField] private SpriteRenderer character;
    [SerializeField] private TMP_Text info;
    [SerializeField] private float price;

    bool isClicked;

    public void GachaStart()
    {

        if (price < PlayerManager.instance.currentMoney)
        {
            isClicked = true;

            if (entities == null || entities.Count == 0)
            {
                Debug.LogWarning("��í ����� �����ϴ�.");
                return;
            }

            // Ȯ�� �հ� ���
            float totalPercent = 0f;
            foreach (var entity in entities)
            {
                totalPercent += entity.percent;
            }

            if (totalPercent <= 0)
            {
                Debug.LogWarning("��í ����� Ȯ�� ���� 0�Դϴ�.");
                return;
            }


            float randomValue = Random.Range(0, totalPercent);
            float cumulativePercent = 0f;

            PlayerManager.instance.AddMoney(-price);
            foreach (var entity in entities)
            {
                cumulativePercent += entity.percent;
                if (randomValue <= cumulativePercent)
                {
                    info.SetText($"{entity.agentName} ��(��) {entity.percent}% Ȯ���� �����߽��ϴ�!");
                    character.sprite = entity.characterImage;
                    timeline.Play();
                    PlayerManager.instance.AddHero(entity);
                    return;
                }
            }
        }
        else
        {
            AlertManager.instance.SendAlert("���� �����մϴ�.");
        }
    }

    public void Shake()
    {
        info.rectTransform.DOShakeAnchorPos(2, 50, 5, 45);
        character.gameObject.transform.DOShakePosition(2, 50, 5, 45);
        isClicked = false;
    }
}
�̰� �������� ��� �ٲ۰ſ� �°�