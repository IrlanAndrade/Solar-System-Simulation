using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy;
    public float timeToSpawn = 3;
    private float time, timeRandom;
    private bool chooseRandom = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        
        if (chooseRandom == true){
            timeRandom = setRandom();
            chooseRandom = false;
        }
        
        if (time <= timeRandom){
            spawnSlime();
        }
    }

    public void spawnSlime(){
        Instantiate(enemy, transform.position, Quaternion.identity);
        time = timeToSpawn;
        chooseRandom = true;
    }

    public float setRandom(){
        int timeRandom = Random.Range(1, -4);

        return timeRandom;
    }
}
