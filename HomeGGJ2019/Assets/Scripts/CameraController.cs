using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera topDownCamera;

    public Transform target;
    public Vector3 offset;

    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float pitch = 2f;
    public float yawSpeed = 100f;

    private float currentZoom = 10f;
    private float currentYaw = 0f;

    public bool camSwitch = false;

    public float minX = -60.0f;
    public float maxX = 60.0f;
    public float minY = -360.0f;
    public float maxY = 360.0f;

    public float sensitivityX = 10f;
    public float sensitivityY = 10f;

    float rotationX = 0f;
    float rotationY = 0f;
    
    public CharacterMovement charMovement;

    // Start is called before the first frame update
    private void Start()
    {
        topDownCamera.gameObject.SetActive(false);
        firstPersonCamera.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (topDownCamera.gameObject.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

            currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
            CameraChanged();
        }

        if (firstPersonCamera.gameObject.activeSelf == true)
        {
            rotationX += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY += Input.GetAxis("Mouse X") * sensitivityX;

            rotationX = Mathf.Clamp(rotationX, minX, maxX);

            transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);
            target.localEulerAngles = new Vector3(0, rotationY, 0);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            camSwitch = !camSwitch;
            firstPersonCamera.gameObject.SetActive(!camSwitch);
            topDownCamera.gameObject.SetActive(camSwitch);
            CameraChanged();
            charMovement.GetComponent<CharacterMovement>().detectCam();
        }
    }


    void CameraChanged()
    {
        if (topDownCamera.gameObject.activeSelf == true)
        {
            topDownCamera.gameObject.transform.position = target.position - (offset * currentZoom);

            topDownCamera.gameObject.transform.LookAt(target.position + (Vector3.up * pitch));

            topDownCamera.gameObject.transform.RotateAround(target.position, Vector3.up, currentYaw);
        }
    }
}
