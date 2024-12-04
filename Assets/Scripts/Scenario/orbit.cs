using UnityEngine;

public class orbit : MonoBehaviour
{

    public Transform parentObject; // Objeto pai ao redor do qual o filho irá girar
    public float orbitSpeed; // Velocidade de rotação
    public bool isMoon = false; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (parentObject != null)
        {
            if (isMoon == false)
            {
                // Faz o filho rotacionar em torno do pai
                transform.RotateAround(parentObject.position, Vector3.up, orbitSpeed * Time.deltaTime);
            }
            else
            {
                transform.RotateAround(parentObject.position, Vector3.forward, orbitSpeed * Time.deltaTime);
            }
        }
    }
}
