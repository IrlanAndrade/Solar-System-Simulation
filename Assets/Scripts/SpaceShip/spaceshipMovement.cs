using UnityEngine;

public class AcceleratedMovement : MonoBehaviour
{
    public float maxSpeed = 10f; // Velocidade máxima do objeto
    public float acceleration = 5f; // Taxa de aceleração
    public float deceleration = 8f; // Taxa de desaceleração
    private Vector3 velocity = Vector3.zero; // Velocidade atual do objeto
    public int player;

    void keyboardMovement()
    {
        float inputHorizontal = 0;
        float inputVertical = 0;

        if (player == 1){
            inputVertical = -Input.GetAxis("Vertical 1");
            inputHorizontal = Input.GetAxis("Horizontal 1");
        }
        if (player == 2){
            inputVertical = -Input.GetAxis("Vertical 2");
            inputHorizontal = Input.GetAxis("Horizontal 2");
        }

        transform.Rotate(0, inputHorizontal, 0, Space.Self);

        // Calcula a direção do movimento com base nas entradas
        Vector3 direction = transform.up * inputVertical; // Move na direção que a nave está apontando

        // Se há entrada, aumenta a velocidade na direção do movimento
        if (direction.magnitude > 0)
        {
            velocity += direction * acceleration * Time.deltaTime;

            // Limita a velocidade máxima
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        else
        {
            // Sem entrada: reduz gradualmente a velocidade até parar
            velocity = Vector3.Lerp(velocity, Vector3.zero, deceleration * Time.deltaTime);
        }

        // Move o objeto com base na velocidade calculada
        transform.Translate(velocity * Time.deltaTime, Space.World);

    }
    void mouseMovement()
    {
        // Captura o movimento do mouse
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(0, 0, mouseX, Space.Self);
        transform.Rotate(-mouseY, 0, 0, Space.Self);
    }
    bool IsMouseInsideScreen()
    {
        // Obtém a posição do mouse em pixels na tela
        Vector3 mousePosition = Input.mousePosition;

        // Verifica se a posição do mouse está dentro dos limites da tela
        return mousePosition.x >= 0 && mousePosition.x <= Screen.width &&
               mousePosition.y >= 0 && mousePosition.y <= Screen.height;
    }

    void Start()
    {
        
    }

    void Update()
    {   
        if (IsMouseInsideScreen() == true)
        {
            mouseMovement();   
        }
        keyboardMovement();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
