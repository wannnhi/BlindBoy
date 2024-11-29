using UnityEngine;
using TMPro;

public class HeroStats : MonoBehaviour
{
    public EntityStatusSO status;

    private TMP_Text _upgraded;
    private TMP_Text _stat;
    private TMP_Text _sellPrice;
    private TMP_Text _upgradePrice;

    private Transform _tab;

    private void Awake()
    {
        try
        {
            _upgraded = transform.Find("Upgrade").GetComponent<TMP_Text>();
            _stat = transform.Find("Stat").GetComponent<TMP_Text>();
            _tab = transform.Find("Tab").GetComponent<Transform>();
            _sellPrice = _tab.Find("Sell").Find("SellPrice").GetComponent<TMP_Text>();
            _upgradePrice = _tab.Find("Upgrade").Find("UpgradePrice").GetComponent<TMP_Text>();
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError($"Awake: 필요한 UI 컴포넌트를 찾을 수 없습니다. {e.Message}");
        }
    }

    private void Start()
    {
        try
        {
            Initialize();
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Start: 초기화 중 오류가 발생했습니다. {e.Message}");
        }
    }

    public void Initialize()
    {
        try
        {
            if (status == null)
            {
                throw new System.NullReferenceException("Status 객체가 설정되지 않았습니다.");
            }

            float upgradeMultiplier = 1f + (0.3f * status.Upgraded);
            float speedMultiplier = 1f + (0.1f * status.Upgraded);

            float upgradedAtkDamage = status.atkDamage * upgradeMultiplier;
            float upgradedSkillDamage = status.skillDamage * upgradeMultiplier;
            float upgradedHealth = status.maxHealth * upgradeMultiplier;
            float upgradedAttackSpeed = status.atkDamage * upgradeMultiplier;
            float upgradedMoveSpeed = status.moveSpeed * speedMultiplier;
            float upgradedSkillCooldown = status.skilCoolDown * speedMultiplier;

            if (_stat == null || _sellPrice == null || _upgradePrice == null)
            {
                throw new System.NullReferenceException("텍스트 컴포넌트가 올바르게 초기화되지 않았습니다.");
            }

            if (status.skilCoolDown == 0)
            {
                _stat.SetText($"공격 {upgradedAtkDamage:F1} 속도 {upgradedMoveSpeed:F1} \n체력 {upgradedHealth:F1} 공속 {upgradedAttackSpeed:F1}");
            }
            else
            {
                _stat.SetText($"공격 {upgradedAtkDamage:F1} 속도 {upgradedMoveSpeed:F1}\n체력 {upgradedHealth:F1} 공속 {upgradedAttackSpeed:F1}\n스킬 공격력 {upgradedSkillDamage:F1}\n스킬 쿨타임 {upgradedSkillCooldown:F1}");
            }

            _sellPrice.SetText($"${status.sellPrice * 0.8:F2}");
            _upgradePrice.SetText($"${status.sellPrice * 1.4:F2}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Initialize: 상태 초기화 중 오류가 발생했습니다. {e.Message}");
        }
    }
}
    