using UnityEditor.VersionControl;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{
    [SerializeField]private Camera cameraDefault1;
    [SerializeField]private Camera cameraFOV1;
    [SerializeField]private Camera cameraDefault2;
    [SerializeField]private Camera cameraFOV2;
    [SerializeField]private int _actualPlayer; 

    #region gets e sets
    public int actualPlayer
    {
        get { return _actualPlayer; }
        set { _actualPlayer = value; }
    }

    #endregion

    void Start()
    {
        cameraDefault1.enabled = true;
        cameraDefault2.enabled = true;
        cameraFOV1.enabled = false;
        cameraFOV2.enabled = false;
        actualPlayer = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            cameraDefault1.enabled = true;
            cameraFOV1.enabled = false;
            actualPlayer = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            cameraDefault1.enabled = false;
            cameraFOV1.enabled = true;
            
            actualPlayer = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0)){
            cameraDefault2.enabled = false;
            cameraFOV2.enabled = true;
            actualPlayer = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9)){
            cameraDefault2.enabled = true;
            cameraFOV2.enabled = false;
            actualPlayer = 2;
        }
    }
}
