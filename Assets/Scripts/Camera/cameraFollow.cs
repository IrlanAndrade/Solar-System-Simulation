using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // O objeto que a câmera deve seguir
    public float smoothSpeed = 1.0f; // A suavização da câmera
    public Vector3 offset; // A distância entre a câmera e o objeto

    void LateUpdate()
    {
        // Verifica se o target foi atribuído
        if (target != null)
        {
            // Calcula a posição desejada da câmera (posição do objeto + offset)
            Vector3 desiredPosition = target.position + offset;

            // Faz a transição suave para a posição desejada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Atualiza a posição da câmera para a nova posição suavizada
            transform.position = smoothedPosition;

            // Faz a câmera olhar para o alvo
            transform.LookAt(target);
        }
    }
}
