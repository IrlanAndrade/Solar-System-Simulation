using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public float moveSpeed = 2f, refreshcd = 3.0f;
    private BoxCollider2D pc, tc;
    public GameObject trap;

    void Start()
    {
        pc = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        refreshcd -= Time.deltaTime;
        if (refreshcd <= 0.0f){
            attack();
        }
    }

    private void attack(){
        if (Input.GetMouseButtonDown(1))
        {
            GameObject newTrap = Instantiate(trap, transform.position, Quaternion.identity);

            tc = newTrap.GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(pc, tc, true);
            refreshcd = 3.0f;
        }
    }
}
