using UnityEngine;

public class DodgeMovement : MonoBehaviour
{
    private DodgeController _controller;
    private CharacterStatHandler _statHandler;
    private Rigidbody2D _rigidbody;
    private CameraBounds _cameraBounds;

    private Vector2 _movementDirection = Vector2.zero;

    private void Awake()
    {
        _controller = GetComponent<DodgeController>();
        _statHandler = GetComponent<CharacterStatHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _cameraBounds = GetComponent<CameraBounds>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
        LimitMovement();
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction *= _statHandler.currentStat.speed;
        _rigidbody.velocity = direction;
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void LimitMovement()
    {
        if (!gameObject.CompareTag("Player"))
        {
            return;
        }

        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();

        Vector3 pos = _rigidbody.position;
        float halfWidth = renderer.bounds.size.x / 2;
        float halfHeight = renderer.bounds.size.y / 2;

        pos.x = Mathf.Clamp(pos.x, _cameraBounds.LeftPosition + halfWidth, _cameraBounds.RightPosition - halfWidth);
        pos.y = Mathf.Clamp(pos.y, _cameraBounds.BottomPosition + halfHeight, _cameraBounds.TopPosition - halfHeight);

        _rigidbody.position = pos;
    }
}
