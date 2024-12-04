using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform player; // O objeto jogador
    public Vector3 offset;   // A posição inicial da câmera em relação ao jogador
    public float moveBackDistance = 2f;  // Distância de afastamento da câmera
    public float smoothSpeed = 0.125f;  // Velocidade de suavização do movimento da câmera

    private Vector3 currentOffset;

    void Start()
    {
        // A câmera começa com o offset padrão
        currentOffset = offset;
    }

    void Update()
    {
        // Verifica se o jogador está se movendo
        if (player.GetComponent<Rigidbody>().linearVelocity.magnitude > 0.1f)
        {
            // Se o jogador está se movendo, a câmera se afasta um pouco
            currentOffset = offset + Vector3.back * moveBackDistance;
        }
        else
        {
            // Se o jogador parou, a câmera volta à posição original
            currentOffset = offset;
        }

        // Atualiza a posição da câmera suavemente
        Vector3 desiredPosition = player.position + currentOffset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
