using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    public float moveSpeed = 5f;
    public float acceleration = 10f;
    public float deceleration = 8f;
    private Vector2 movement;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        // Define a velocidade desejada na direção horizontal com base no movimento
        float targetSpeed = movement.x * moveSpeed;

        // Aplica aceleração ou desaceleração dependendo da direção
        if (movement.x != 0)  // Se o jogador está movendo
        {
            rb.linearVelocity = new Vector2(Mathf.MoveTowards(rb.linearVelocity.x, targetSpeed, acceleration * Time.fixedDeltaTime), rb.linearVelocity.y);
        }
        else  // Se o jogador não está se movendo
        {
            rb.linearVelocity = new Vector2(Mathf.MoveTowards(rb.linearVelocity.x, 0, deceleration * Time.fixedDeltaTime), rb.linearVelocity.y);
        }
    }
}
