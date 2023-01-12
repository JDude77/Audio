using System;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    #region Attributes
    [SerializeField]
    private float MouseSensitivity = 500f;
    private Transform PlayerBody;
    private float XRotation = 0f;
    private float TargetCameraHeight = 0.65f;
    private PlayerMovement PlayerMovement;
    private float TimeToCrouch = 1.5f;
    private float CrouchCounter = 0.0f;
    private bool Crouching = false;
    private bool CanLook = true;

    [SerializeField, Range(0, 180)]
    private float MaxPitch;
    [SerializeField, Range(-180, 0)]
    private float MinPitch;

    [SerializeField]
    private bool InvertedY = false;
    [SerializeField]
    private bool InvertedX = false;
    #endregion

    #region Getters & Setters
    #region Mouse Sensitivity
    //Getter
    public float GetMouseSensitivity()
    {
        return MouseSensitivity;
    }//End mouse sensitivity getter

    //Setter
    public void SetMouseSensitivity(float MouseSensitivity)
    {
        MouseSensitivity = this.MouseSensitivity;
    }//End mouse sensitivity setter
    #endregion
    #region Can Look
    //Getter
    public bool GetCanLook()
    {
        return CanLook;
    }//End Can Look Getter

    //Setter
    public void SetCanLook(bool CanLook)
    {
        this.CanLook = CanLook;
        SetCursorLockState();
    }//End Can Look Setter
    #endregion
    #region Inverted Y
    //Setter
    public void SetInvertedY(bool InvertedY)
    {
        this.InvertedY = InvertedY;
    }//End Inverted Y Setter
    #endregion
    #region Inverted X
    //Setter
    public void SetInvertedX(bool InvertedX)
    {
        this.InvertedX = InvertedX;
    }//End Inverted X Setter
    #endregion
    #endregion

    private void Start()
    {
        PlayerBody = GetComponentInParent<CharacterController>().transform;
        PlayerMovement = PlayerBody.GetComponent<PlayerMovement>();
        SetCanLook(false);
    }//End Start

    private void Update()
    {
        if(CanLook)
        {
            SetCameraHeight();

            //Get movement of mouse according to mouse sensitivity and make sure it's the same across framerate
            float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
            float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

            RotatePlayerHorizontal(MouseX);
            RotateCameraVertical(MouseY);
        }//End if
    }//End Update

    #region Behaviours
    private void SetCursorLockState()
    {
        Cursor.lockState = CanLook ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !CanLook;
    }//End SetCursorLockState

    private void SetCameraHeight()
    {
        //Resets the counter if last frame's crouch state and this frame's don't match
        if(Crouching != PlayerMovement.GetIsCrouching())
        {
            CrouchCounter = 0.0f;
            Crouching = PlayerMovement.GetIsCrouching();
            TargetCameraHeight = Crouching ? 0f : 0.65f;
        }//End if
        float DistanceToTarget = transform.localPosition.y - TargetCameraHeight;
        if(transform.localPosition.y != TargetCameraHeight && CrouchCounter < TimeToCrouch)
        {
            CrouchCounter += Time.deltaTime;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, TargetCameraHeight, Mathf.Abs(DistanceToTarget) * CrouchCounter * 5), transform.localPosition.z);
        }//End if
        else
        {
            CrouchCounter = 0.0f;
            transform.localPosition = new Vector3(transform.localPosition.x, TargetCameraHeight, transform.localPosition.z);
        }//End else
    }//End SetCameraHeight

    //Handle player left and right rotation
    private void RotatePlayerHorizontal(float mouseX)
    {
        if(InvertedX) PlayerBody.Rotate(-Vector3.up * mouseX);
        else PlayerBody.Rotate(Vector3.up * mouseX);
    }//End RotatePlayerHorizontal

    //Handle camera up and down tilting
    private void RotateCameraVertical(float mouseY)
    {
        if(InvertedY)
        {
            XRotation += mouseY;
            XRotation = Mathf.Clamp(XRotation, MinPitch, MaxPitch);
            transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        }//End if
        else
        {
            XRotation -= mouseY;
            XRotation = Mathf.Clamp(XRotation, MinPitch, MaxPitch);
            transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        }//End else
    }//End RotateCameraVertical
    #endregion
}