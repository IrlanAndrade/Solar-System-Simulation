using UnityEngine;

public class trapSpawn : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce;
    public float rightForce;
    public float jumptime = 1;
    private int position = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GameObject player = GameObject.Find("player");

        if (player.transform.localScale.x > 0){position = 1;}
        if (player.transform.localScale.x < 0){position = -1;}

        jumptime -= Time.deltaTime;
        if (jumptime >= 0){
            jump(position);
        }
    }

    void jump(int position){
        if (position == 1){
            rb.linearVelocity = new Vector2(rightForce, jumpForce);
        }else{
            rb.linearVelocity = new Vector2(-rightForce, jumpForce);
        }
    }
}
