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

        // 방향 계산
        Vector2 direction = (_agent.target.transform.position - transform.position).normalized; // 타겟 방향의 단위 벡터

        float velocityMagnitude = 10f; // 원하는 속도 크기 (조정 가능)
        Vector2 velocity = direction * velocityMagnitude; // 일직선 속도 벡터 생성

        // 폭탄 생성 및 발사
        Projectile projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
        projectile.Shoot(velocity.x, 4f);

        _animator.OnAttackTryEvent -= Attack;
    }
}
