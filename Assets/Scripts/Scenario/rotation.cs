using UnityEngine;

public class rotation : MonoBehaviour
{
    public float rotationSpeed ;  // Velocidade de rotação em graus por segundo
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Loop sobre todos os filhos do objeto pai
        foreach (Transform child in transform)
        {
            // Faz cada filho girar em torno de seu próprio eixo (local)
            child.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
        }
    }
}
