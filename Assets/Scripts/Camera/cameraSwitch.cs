using UnityEditor.VersionControl;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{
    public Camera cameraDefault1;
    public Camera cameraFOV1;
    public Camera cameraDefault2;
    public Camera cameraFOV2;

    void Start()
    {
        cameraDefault1.enabled = true;
        cameraDefault2.enabled = true;
        cameraFOV1.enabled = false;
        cameraFOV2.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            cameraDefault1.enabled = true;
            cameraFOV1.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            cameraDefault1.enabled = false;
            cameraFOV1.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0)){
            cameraDefault2.enabled = false;
            cameraFOV2.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9)){
            cameraDefault2.enabled = true;
            cameraFOV2.enabled = false;
        }
    }
}
