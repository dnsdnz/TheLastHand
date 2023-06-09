using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float CameraMoveSpeed = 120.0f;
    public GameObject CameraFollowObj;
    public float minimumPivotAngle = -45;
    public float maximumPivotAngle = 60;
    public float inputSensitivity = 150.0f;
    public float mouseX;
    public float mouseY;
    private float rotY = 0.0f;
    private float rotX = 0.0f;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update()
    {
        if (LevelStateManager.Instance)
        {
            if (LevelStateManager.Instance.currentState != LevelState.OnMenu)
            {
                if (!LevelStateManager.Instance.isCraneActive)
                {
                    if (!LevelStateManager.Instance.isMinimapPuzzleActive)
                    {
                        RotateCamera();
                    } 
                }
            }
        }
    }

    void LateUpdate()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        Transform target = CameraFollowObj.transform;

        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    private void RotateCamera()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        rotY += mouseX * inputSensitivity * Time.deltaTime;
        rotX -= mouseY * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, minimumPivotAngle, maximumPivotAngle);
        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }
}
