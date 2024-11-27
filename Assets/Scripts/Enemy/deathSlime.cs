using UnityEngine;
using System.Collections;

public class deathSlime : MonoBehaviour
{
    private Animator animator;
    public float animationTime = 3;
    private bool startanimation = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startanimation == true){
            animationTime -= Time.deltaTime;
            if (animationTime <= 0){
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se colidiu com o chão
        if (collision.gameObject.CompareTag("Trap"))
        {
            animator.SetBool("isDead", true);  // Para a animação de pulo
            startanimation = true;
        }
    }
}
