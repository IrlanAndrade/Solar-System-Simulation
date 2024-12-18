using UnityEngine;

public class AcceleratedMovement : MonoBehaviour
{
    #region variables

    [SerializeField]private float maxSpeed = 10f;
    [SerializeField]private float acceleration = 5f;
    [SerializeField]private float deceleration = 8f;
    [SerializeField]private float rotationSpeed = 5f; // Ajuste de sensibilidade da rotação
    [SerializeField]private float maxPitch = 45f; // Limite para rotação no eixo X (pitch)
    [SerializeField]private int _player;
    [SerializeField]private GameObject cameraController;
    private AudioSource audiosrc;
    private cameraSwitch cs;
    private Vector3 velocity = Vector3.zero; 
    private Rigidbody rb;

    #endregion

    #region gets e sets

    public int player
    {
        get { return _player; }
        set { _player = value; }
    }

    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audiosrc = GetComponent<AudioSource>();
    }

    void Update()
    {   
        
        cs = cameraController.GetComponent<cameraSwitch>();

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

    // void keyboardMovement()
    // {
    //     float inputHorizontal = 0;
    //     float inputVertical   = 0;

    //     if (_player == 1){
    //         inputVertical   = -Input.GetAxis("Vertical 1");
    //         inputHorizontal = Input.GetAxis("Horizontal 1");
    //     }

    //     if (_player == 2){
    //         inputVertical   = -Input.GetAxis("Vertical 2");
    //         inputHorizontal = Input.GetAxis("Horizontal 2");
    //     }

    //     transform.Rotate(0, inputHorizontal, 0, Space.Self);

    //     Vector3 direction = transform.up * inputVertical;

    //     if (direction.magnitude > 0)
    //     {
    //         velocity += direction * acceleration * Time.deltaTime;
    //         velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
    //     }
    //     else
    //     {
    //         velocity = Vector3.Lerp(velocity, Vector3.zero, deceleration * Time.deltaTime);
    //     }
    //     transform.Translate(velocity * Time.deltaTime, Space.World);

    // }

    // void mouseMovement()
    // {
    //     // Captura o movimento do mouse
    //     float mouseX = Input.GetAxis("Mouse X");
    //     float mouseY = Input.GetAxis("Mouse Y");

    //     if (player == cs.actualPlayer){
    //         transform.Rotate(0, 0, mouseX, Space.Self);
    //         transform.Rotate(-mouseY, 0, 0, Space.Self);
    //     }
    // }

    void keyboardMovement()
    {
        // Leitura do input
        float inputHorizontal = 0;
        float inputVertical = 0;

        if (_player == 1)
        {
            inputVertical = -Input.GetAxis("Vertical 1");
            inputHorizontal = Input.GetAxis("Horizontal 1");
        }
        else if (_player == 2)
        {
            inputVertical = -Input.GetAxis("Vertical 2");
            inputHorizontal = Input.GetAxis("Horizontal 2");
        }

        // Aplicar força para movimentação
        Vector3 direction = transform.up * inputVertical; // "up" é o eixo local Y da nave
        if (direction.magnitude > 0)
        {
            if (audiosrc.isPlaying == false)
            {
                audiosrc.Play();
            }
            rb.AddForce(direction * acceleration, ForceMode.Acceleration);
        }
        else
        {
            audiosrc.Stop();
            // Aplicar "freio" (desaceleração linear)
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, deceleration * Time.fixedDeltaTime);
        }

        // Limitar a velocidade máxima
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }

        // Aplicar torque para rotação
        float torqueAmount = inputHorizontal;

        Vector3 currentAngularVelocity = rb.angularVelocity;

        if (Mathf.Abs(torqueAmount) > 0.01f) // Se houver entrada no eixo horizontal
        {
            rb.AddTorque(transform.up * torqueAmount * rotationSpeed, ForceMode.Force);
        }else{
            // Anular o torque aplicado pela rotação anterior
            
            
            // Se houver rotação no eixo Y, aplique um torque oposto proporcional à aceleração angular
            if (Mathf.Abs(currentAngularVelocity.y) != 0)
            {
                // Aplicar torque proporcional à aceleração angular no eixo Y
                rb.AddTorque(-currentAngularVelocity * rotationSpeed, ForceMode.Force);
            }
        }
    }
    void mouseMovement()
    {
        // Captura o movimento do mouse
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (player == cs.actualPlayer)
        {
            // Rotação vertical (eixo X - "olhar para cima/baixo")
            // Calcula o ângulo atual no eixo X (pitch) com sinal
            float currentPitch = Vector3.SignedAngle(transform.forward, Vector3.ProjectOnPlane(transform.forward, Vector3.up), transform.right);

            // Aplica torque somente se estiver dentro dos limites
            if ((currentPitch < maxPitch && mouseY < 0) || (currentPitch > -maxPitch && mouseY > 0))
            {
                float torqueX = -mouseY * rotationSpeed;
                rb.AddTorque(transform.right * torqueX, ForceMode.Force);
            }

            // Rotação lateral (eixo Y - "olhar para os lados")
            // Calcula o ângulo atual no eixo Y (yaw) com sinal
            float currentYaw = Vector3.SignedAngle(transform.forward, Vector3.ProjectOnPlane(transform.forward, Vector3.right), Vector3.up);

            // Aplica torque lateral (yaw) somente se estiver dentro dos limites
            if ((currentYaw < maxPitch && mouseX < 0) || (currentYaw > -maxPitch && mouseX > 0))
            {
                float torqueY = mouseX * rotationSpeed;
                rb.AddTorque(transform.forward * torqueY, ForceMode.Force);
            }
        }

    }


    bool IsMouseInsideScreen()
    {
        // Obtém a posição do mouse em pixels na tela
        Vector3 mousePosition = Input.mousePosition;

        // Verifica se a posição do mouse está dentro dos limites da tela
        return mousePosition.x >= 0 && mousePosition.x <= Screen.width &&
               mousePosition.y >= 0 && mousePosition.y <= Screen.height;
    }

}
