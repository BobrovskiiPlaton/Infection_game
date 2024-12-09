using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] public GameObject cam;
    [SerializeField] public float sensitivity;
    
    public bool cameraTwisted;
    public bool cameraUpsideDown;
    
    private Quaternion StartingRotation;
    private float inputX;
    private float inputY;
    
    void Start()
    {
        StartingRotation = transform.rotation;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame

    private void Update()
    {
        inputX += Input.GetAxis("Mouse X") * sensitivity;
        inputY += Input.GetAxis("Mouse Y") * sensitivity;
        inputY = Mathf.Clamp(inputY, -90f, 90f);
        Quaternion RotX = Quaternion.AngleAxis(inputX, Vector3.up);
        Quaternion RotY = Quaternion.AngleAxis(-inputY, Vector3.right);
        Player.rotation = StartingRotation * RotX;
        cam.transform.rotation = StartingRotation * RotX * RotY;
        
        if(cameraTwisted)
        {
            // Поверните камеру на 90 градусов
            cam.transform.rotation *= Quaternion.Euler(0, 0, 90);
        }
        if(cameraUpsideDown)
        {
            // Поверните камеру на 180 градусов
            cam.transform.rotation *= Quaternion.Euler(0, 0, 180);
        }
            
    }
    
}
