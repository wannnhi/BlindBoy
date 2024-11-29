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
            Debug.LogError($"Awake: �ʿ��� UI ������Ʈ�� ã�� �� �����ϴ�. {e.Message}");
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
            Debug.LogError($"Start: �ʱ�ȭ �� ������ �߻��߽��ϴ�. {e.Message}");
        }
    }

    public void Initialize()
    {
        try
        {
            if (status == null)
            {
                throw new System.NullReferenceException("Status ��ü�� �������� �ʾҽ��ϴ�.");
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
                throw new System.NullReferenceException("�ؽ�Ʈ ������Ʈ�� �ùٸ��� �ʱ�ȭ���� �ʾҽ��ϴ�.");
            }

            if (status.skilCoolDown == 0)
            {
                _stat.SetText($"���� {upgradedAtkDamage:F1} �ӵ� {upgradedMoveSpeed:F1} \nü�� {upgradedHealth:F1} ���� {upgradedAttackSpeed:F1}");
            }
            else
            {
                _stat.SetText($"���� {upgradedAtkDamage:F1} �ӵ� {upgradedMoveSpeed:F1}\nü�� {upgradedHealth:F1} ���� {upgradedAttackSpeed:F1}\n��ų ���ݷ� {upgradedSkillDamage:F1}\n��ų ��Ÿ�� {upgradedSkillCooldown:F1}");
            }

            _sellPrice.SetText($"${status.sellPrice * 0.8:F2}");
            _upgradePrice.SetText($"${status.sellPrice * 1.4:F2}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Initialize: ���� �ʱ�ȭ �� ������ �߻��߽��ϴ�. {e.Message}");
        }
    }
}
    