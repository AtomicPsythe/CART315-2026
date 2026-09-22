using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Controller : MonoBehaviour
{
    private Vector2 _direction;

    public Paddle paddle;

    // Update is called once per frame
    private void Update()
    {
        _direction = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            _direction = Vector2.up;
        else if (Keyboard.current.sKey.isPressed)
            _direction = Vector2.down;
        paddle.direction = _direction;
    }
}