using UnityEngine;

public class slimeAnimation : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce;
    public float sideForce;
    public float jumptime = 1f;
    public float stoptime = 2f;
    private float stopped;
    private float jumping;
    private bool canJump = true;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumping = jumptime;
        stopped = stoptime;
        animator = GetComponent<Animator>();

        float direction = getPlayerDirection();
        Jump(direction);
    }

    void Update()
    {
        bool slimeisdead = animator.GetBool("isDead");

        if (slimeisdead == false){
            jumping -= Time.deltaTime;

            float direction = getPlayerDirection();

            if (jumping >= 0 && canJump == true){
                Jump(direction);
            }else{
                stopped -= Time.deltaTime;
                if (stopped <= 0){
                    canJump = true;
                    stopped = stoptime;
                    jumping = jumptime;
                }
            }
        }
    }

    void Jump(float direction){
        direction = (direction > 0) ? 1 : -1;
        rb.linearVelocity = new Vector2(sideForce * direction, jumpForce);
        canJump = false;
    }

    float getPlayerDirection(){
        GameObject player = GameObject.Find("player");
        Vector2 playerDirection = (player.transform.position - transform.position).normalized;

        return playerDirection.x;
    }
}
