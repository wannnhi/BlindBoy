using System;
using UnityEngine;

public class EntityMover : MonoBehaviour, IEntityComponent
{
    [Header("Move values")]
    [SerializeField] private AnimParamSO _ySpeedParam;
    [SerializeField] private float _moveSpeed = 5f;

    [SerializeField] private Transform _groundTrm;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Vector2 _groundCheckSize;

    public bool IsGrounded { get; private set; }

    public Vector2 Velocity => _rbCompo.linearVelocity;

    public float SpeedMultiplier { get; set; } = 1f;
    public bool CanManualMove { get; set; } = true;

    private Entity _entity;
    private EntityRenderer _renderer;
    private Rigidbody2D _rbCompo;

    private float _xMovement;

    public void Initialize(Entity entity)
    {
        _entity = entity;
        _renderer = _entity.GetCompo<EntityRenderer>();
        _rbCompo = _entity.GetComponent<Rigidbody2D>();
    }

    public void AddForceToEntity(Vector2 force, ForceMode2D mode = ForceMode2D.Impulse)
    {
        _rbCompo.AddForce(force, mode);
    }

    public void StopImmediately(bool isYAxisToo = false)
    {
        if (isYAxisToo)
            _rbCompo.linearVelocity = Vector2.zero;
        else
            _rbCompo.linearVelocityX = 0;
        _xMovement = 0;
    }

    public void SetXMovement(float xMovement)
    {
        _xMovement = xMovement;
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        if (CanManualMove)
        {
            _rbCompo.linearVelocityX = _xMovement * _moveSpeed * SpeedMultiplier;
            _renderer.FlipController(_xMovement);
        }
        
        _renderer.SetParam(_ySpeedParam, _rbCompo.linearVelocityY);
    }

    private void OnDrawGizmos()
    {
        if (_groundTrm == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_groundTrm.position, _groundCheckSize);
    }

    
}
