using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rbCompo;
    private Animator _animator;
    [SerializeField] private AnimParamSO _triggerParam;
    [SerializeField] private string _targetTagName;

    private float _lifeTime;
    private bool _canImpact = true;

    private void Awake()
    {
        _rbCompo = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0 && _canImpact)
        {
            _canImpact = false;
            TriggerExplosion();
        }
    }

    public void Shoot(float xVelocity, float lifeTime)
    {
        _canImpact = true;
        _lifeTime = lifeTime;
        _rbCompo.gravityScale = 0f;
        _rbCompo.linearVelocityX = xVelocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == _targetTagName)
        {
            _canImpact = false;
            TriggerExplosion();
        }
    }

    private void TriggerExplosion()
    {
        _animator.SetTrigger(_triggerParam.hashValue);
    }

    public void Impacted()
    {
        Destroy(gameObject);
    }
}
