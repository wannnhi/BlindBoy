using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "EnityStatus", menuName = "SO/Entity/Status")]
public class EnityStatus : ScriptableObject
{
    [Header("Visual")]
    public string agentName;
    public Image characterImage;

    [Header("Health")]
    public float maxHealth = 50f;

    [Header("Move")]
    public float moveSpeed = 5f;
    [Header("Skill")]
    public float skilCoolDown = 0;
    public float skillDamage = 0;
    [Header("DefaultAttack")]
    public float atkDelay = 0;
    public float atkDamage = 0;
    [Header("Detact")]
    public float checkRadius = 3f;
    public float checkAngle = 60f;
    public LayerMask whatIsTarget, whatIsObstacle;

    [Header("Upgrade")]
    public int Upgraded = 0;
    public float percent = 1.2f;

    [Header("Price")]
    public float cost = 400f;
    public float sellPrice = 200f;

}
