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
                Debug.LogWarning("가챠 대상이 없습니다.");
                return;
            }

            // 확률 합계 계산
            float totalPercent = 0f;
            foreach (var entity in entities)
            {
                totalPercent += entity.percent;
            }

            if (totalPercent <= 0)
            {
                Debug.LogWarning("가챠 대상의 확률 합이 0입니다.");
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
                    info.SetText($"{entity.agentName} 을(를) {entity.percent}% 확률로 모집했습니다!");
                    character.sprite = entity.characterImage;
                    timeline.Play();
                    PlayerManager.instance.AddHero(entity);
                    return;
                }
            }
        }
        else
        {
            AlertManager.instance.SendAlert("돈이 부족합니다.");
        }
    }

    public void Shake()
    {
        info.rectTransform.DOShakeAnchorPos(2, 50, 5, 45);
        character.gameObject.transform.DOShakePosition(2, 50, 5, 45);
        isClicked = false;
    }
}
이거 수정해줘 방금 바꾼거에 맞게