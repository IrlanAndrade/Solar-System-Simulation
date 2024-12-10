using UnityEngine;

public class AcceleratedMovement : MonoBehaviour
{
    #region variables

    [SerializeField]private float maxSpeed = 10f;
    [SerializeField]private float acceleration = 5f;
    [SerializeField]private float deceleration = 8f;
    [SerializeField]private int _player;
    [SerializeField]private GameObject cameraController;
    private cameraSwitch cs;
    private Vector3 velocity = Vector3.zero; 

    #endregion

    #region gets e sets

    public int player
    {
        get { return _player; }
        set { _player = value; }
    }

    #endregion

    void Start()
    {
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
    void keyboardMovement()
    {
        float inputHorizontal = 0;
        float inputVertical   = 0;

        if (_player == 1){
            inputVertical   = -Input.GetAxis("Vertical 1");
            inputHorizontal = Input.GetAxis("Horizontal 1");
        }

        if (_player == 2){
            inputVertical   = -Input.GetAxis("Vertical 2");
            inputHorizontal = Input.GetAxis("Horizontal 2");
        }

        transform.Rotate(0, inputHorizontal, 0, Space.Self);

        Vector3 direction = transform.up * inputVertical;

        if (direction.magnitude > 0)
        {
            velocity += direction * acceleration * Time.deltaTime;
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        else
        {
            velocity = Vector3.Lerp(velocity, Vector3.zero, deceleration * Time.deltaTime);
        }
        transform.Translate(velocity * Time.deltaTime, Space.World);

    }
    void mouseMovement()
    {
        // Captura o movimento do mouse
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (player == cs.actualPlayer){
            transform.Rotate(0, 0, mouseX, Space.Self);
            transform.Rotate(-mouseY, 0, 0, Space.Self);
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
