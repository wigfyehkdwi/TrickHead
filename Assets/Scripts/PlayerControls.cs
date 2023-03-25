using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    // Rigidbody2D object that is stored
    [Header("Rigidbody")]
    private Rigidbody2D rb;
    // Downward speed of the object
    [Header("Default Down Speed")]
    public float downSpeed = 20f;
    // Movement speed of the object
    [Header("Default Directional Movement Speed")]
    public float movementSpeed = 10f;
    // Movement direction of the object
    // [Header("Default Directional Movement Speed")]
    private float movement = 0f;
    [Header("Score Text")]
    public Text scoreText;
    private float score;

    // Start is called before the first frame update
    void Start()
    {
        // variable equals to component Rigidbody2D
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement equals Horizontal movement
        // multiplied by the movement speed
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        // If direction on x axis is less than 0
        if (movement < 0)
        {
            // Object faces to the left
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            // Object faces to the right
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (rb.velocity.y > 0 && transform.position.y > score) score = transform.position.y;
        scoreText.text = "Score: " + Mathf.Round(score).ToString();
    }

    void FixedUpdate()
    {
        // Vector2 which is the velocity in (x, y)
        // equals to the velocity of the rigidbody2D
        Vector2 velocity = rb.velocity;
        // Velocity of the x axis equals to
        // the direction movement on the x axis
        // of the character,
        velocity.x = movement;
        // Rigidbody2D velocity equals to
        // velocity of the object
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // velocity with the downspeed
        if (rb.velocity.y > 0) return;
        rb.velocity = new Vector3(rb.velocity.x, downSpeed, 0);
        // score++;
    }
}
