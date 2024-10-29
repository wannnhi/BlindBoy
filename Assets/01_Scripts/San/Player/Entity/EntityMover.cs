using System;
using UnityEngine;

public class EntityMover : MonoBehaviour, IEntityComponent
{
    [Header("Move values")]
    [SerializeField] private AnimParamSO _moveParam;
    [SerializeField] private float _moveSpeed = 5f;

    private Entity _entity;
    private EntityRenderer _renderer;
    private Rigidbody2D _rbCompo;

    private Vector2 _movementInput; // Stores movement input along both X and Y axes

    public void Initialize(Entity entity)
    {
        _entity = entity;
        _renderer = _entity.GetCompo<EntityRenderer>();
        _rbCompo = entity.GetComponent<Rigidbody2D>();
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

    public void SetMovement(Vector2 movementInput)
    {
        _movementInput = movementInput.normalized;
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        _rbCompo.linearVelocity = _movementInput * _moveSpeed;

        bool isMoving = _movementInput.magnitude > 0;
        _renderer.SetParam(_moveParam, isMoving);

        if (_movementInput.x != 0)
        {
            _renderer.FlipController(_movementInput.x);
        }
    }

}
