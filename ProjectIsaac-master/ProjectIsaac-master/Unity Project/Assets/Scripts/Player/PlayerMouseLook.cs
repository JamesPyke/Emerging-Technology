using UnityEngine;
 
public class PlayerMouseLook : MonoBehaviour {

    Vector2 MouseAbsolute;
    Vector2 SmoothMouse;
 
    public Vector2 ClampDegrees = new Vector2(360, 180);
    public Vector2 Sensitivity = new Vector2(2, 2);
    public Vector2 Smoothing = new Vector2(3, 3);
    public Vector2 TargetDirection;
    public Vector2 TargetCharacterDirection;
 
    public GameObject CharacterBody;
 
    void Start() {

    	Hide_Cursor(Cursor.visible);
    	
        // Set target direction to the camera's initial orientation.
        TargetDirection = transform.localRotation.eulerAngles;
 
        // Set target direction for the character body to its inital state.
        TargetCharacterDirection = CharacterBody.transform.localRotation.eulerAngles;
    }
 
    void Update() {

        if(Input.GetKeyDown(KeyCode.Escape)) {
            Hide_Cursor(Cursor.visible);
        }

        // Allow the script to clamp based on a desired target value.
        var TargetOrientation = Quaternion.Euler(TargetDirection);
        var TargetCharacterOrientation = Quaternion.Euler(TargetCharacterDirection);
 
        // Get raw mouse input for a cleaner reading on more sensitive mice.
        var MouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
 
        // Scale input against the Sensitivity setting and multiply that against the Smoothing value.
        MouseDelta = Vector2.Scale(MouseDelta, new Vector2(Sensitivity.x * Smoothing.x, Sensitivity.y * Smoothing.y));
 
        // Interpolate mouse movement over time to apply Smoothing delta.
        SmoothMouse.x = Mathf.Lerp(SmoothMouse.x, MouseDelta.x, 1f / Smoothing.x);
        SmoothMouse.y = Mathf.Lerp(SmoothMouse.y, MouseDelta.y, 1f / Smoothing.y);
 
        // Find the absolute mouse movement value from point zero.
        MouseAbsolute += SmoothMouse;
 
        // Clamp and apply the local x value first, so as not to be affected by world transforms.
        if (ClampDegrees.x < 360) {
            MouseAbsolute.x = Mathf.Clamp(MouseAbsolute.x, -ClampDegrees.x * 0.5f, ClampDegrees.x * 0.5f);
        }
 
        var RotationX = Quaternion.AngleAxis(-MouseAbsolute.y, TargetOrientation * Vector3.right);

        transform.localRotation = RotationX;
 
        // Then clamp and apply the global y value.
        if (ClampDegrees.y < 360) {
            MouseAbsolute.y = Mathf.Clamp(MouseAbsolute.y, -ClampDegrees.y * 0.5f, ClampDegrees.y * 0.5f);
        }
 
        transform.localRotation *= TargetOrientation;
 
        var RotationY = Quaternion.AngleAxis(MouseAbsolute.x, CharacterBody.transform.up);

        CharacterBody.transform.localRotation = RotationY;
        CharacterBody.transform.localRotation *= TargetCharacterOrientation;

    }
    
    void Hide_Cursor(bool _Hidden) {
        if(_Hidden) {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;     
        }
        else {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;      
        }
    }

}