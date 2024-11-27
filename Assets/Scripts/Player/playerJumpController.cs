using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    // Jump
    public float jumpForce = 10f;               // Força do pulo
    public float fallMultiplier = 2.5f;         // Multiplicador para quando estiver caindo
    public float lowJumpMultiplier = 2f;        // Multiplicador para quando o botão de pulo é solto
    public bool isGrounded = false;             // Flag para verificar se o personagem está no chão

    private Rigidbody2D rb;
    private Collider2D col;
    private Collider2D platformCollider;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Detecta o pulo e aplica a força se estiver no chão
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // Ajusta a aceleração durante a queda ou pulo baixo
        FallController();
    }

    // Aplica o pulo
    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Aplica a força de pulo no eixo y
        animator.SetBool("isJumping", true);  // Inicia a animação de pulo
    }

    // Ajusta a aceleração da queda ou do pulo baixo
    void FallController()
    {
        if (rb.linearVelocity.y < 0) // Jogador está caindo
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetButton("Jump")) // Soltou o botão de pulo
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    // Detecta quando o personagem colide com o chão
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se colidiu com o chão
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  // Marca o personagem como no chão
            animator.SetBool("isJumping", false);  // Para a animação de pulo
        }
    }

    // Detecta quando o personagem sai de uma colisão com o chão
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Saiu do chão
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;  // Marca o personagem como no ar
        }
    }
}
