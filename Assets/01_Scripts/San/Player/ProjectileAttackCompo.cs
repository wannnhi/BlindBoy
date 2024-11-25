using System;
using UnityEngine;

public class ProjectileAttackCompo : AttackCompo
{
    [SerializeField] private Projectile _projectilePrefab;

    protected override void AttackEnter()
    {
        _animator.OnAttackTryEvent += Attack;
    }

    private void Attack()
    {
        _lastAtkTime = Time.time;

        // ���� ���
        Vector2 direction = (_agent.target.transform.position - transform.position).normalized; // Ÿ�� ������ ���� ����

        float velocityMagnitude = 10f; // ���ϴ� �ӵ� ũ�� (���� ����)
        Vector2 velocity = direction * velocityMagnitude; // ������ �ӵ� ���� ����

        // ��ź ���� �� �߻�
        Projectile projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
        projectile.Shoot(velocity.x, 4f);

        _animator.OnAttackTryEvent -= Attack;
    }
}
