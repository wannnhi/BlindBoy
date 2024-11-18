using UnityEngine;

[CreateAssetMenu(fileName = "EnityStatus", menuName = "SO/Entity/Status")]
public class EnityStatus : ScriptableObject
{
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
}
