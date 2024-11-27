using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sr;
    private Vector2 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        sr       = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement   = movement.normalized;

        SpriteControl();
    }

    void SpriteControl()
    {
        if (movement.x != 0){
            animator.SetBool("isWalking", true);
        }else{
            animator.SetBool("isWalking", false);
        }

        if (movement.x > 0){
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        } else if (movement.x < 0){
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * -1;
            transform.localScale = scale;
        } 
    }
}
