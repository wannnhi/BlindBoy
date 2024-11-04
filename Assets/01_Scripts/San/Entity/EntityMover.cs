using System;
using UnityEngine;

public class EntityMover : MonoBehaviour, IEntityComponent
{
    [Header("Move values")]
    [SerializeField] private AnimParamSO LastMoveX;
    [SerializeField] private AnimParamSO LastMoveY;
    [SerializeField] private float _moveSpeed = 5f;

    public Vector2 Velocity => _rbCompo.linearVelocity;

    public float SpeedMultiplier { get; set; } = 1f;
    public bool CanManualMove { get; set; } = true;

    private Entity _entity;
    private EntityRenderer _renderer;
    private Rigidbody2D _rbCompo;

    private Vector2 _movementInput;

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

    public void StopImmediately()
    {
        _rbCompo.linearVelocity = Vector2.zero;
        _movementInput = Vector2.zero;
    }

    public void SetMovementInput(Vector2 input)
    {
        _movementInput = input;
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        if (CanManualMove)
        {
            Vector2 movement = _movementInput * _moveSpeed * SpeedMultiplier;
            _rbCompo.linearVelocity = movement;

            if (_renderer != null)
            {
                if (Mathf.Abs(_movementInput.x) > 0.01f)
                {
                    _renderer.FlipController(_movementInput.x * -1);
                }
            }
        }

        if (_movementInput != Vector2.zero)
        {
            _renderer.SetParam(LastMoveX, _movementInput.x);
            _renderer.SetParam(LastMoveY, _movementInput.y);
        }
    }


}
