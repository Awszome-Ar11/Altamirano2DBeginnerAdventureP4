using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Variables related to player character movement
    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public float speed = 3.0f;

    //Variables elated to the health system
    public int maxHealth = 5;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }



    // Update is called once per frame
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
        Debug.Log(move);
        float horizontal = 0.0f;
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            horizontal = -1.0f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = 1.0f;
        }
        Debug.Log(horizontal);

        float vertical = 0.0f;
        if (Keyboard.current.upArrowKey.isPressed)
        {
            vertical = 1.0f;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            vertical = -1.0f;
        }
        Debug.Log(vertical);

        Vector2 position = transform.position;
        position.x = position.x + 0.01f * horizontal;
        position.y = position.y + 0.01f * vertical;
        transform.position = position;

        void FixedUpdate()
        {
            Vector2 position = (Vector2)rigidbody2d.position + move * 3.0f * Time.deltaTime;
            rigidbody2d.MovePosition(position);
        }

        void ChangeHealth (int amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            Debug.Log(currentHealth + "/" + maxHealth);
        }
    }
}
