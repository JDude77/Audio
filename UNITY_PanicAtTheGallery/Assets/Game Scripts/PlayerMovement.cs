using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Attributes
    [SerializeField]
    private Transform GroundCheck;
    private bool IsGrounded = true;
    private bool CanMove = true;
    private bool IsCrouching = false;
    public bool GetIsCrouching() { return IsCrouching; }
    private float GroundDistance = 0.2f;
    private LayerMask GroundMask;
    private float Gravity = -9.81f;
    private CharacterController PlayerController;
    private FootstepsAudio FootstepsAudioScript;
    [SerializeField]
    private float MovementSpeed;
    private Vector3 Movement;
    #endregion

    #region Getters/Setters
    #region Can Move
    //Getter
    public bool GetCanMove()
    {
        return CanMove;
    }//End Can Move Getter
    //Setter
    public void SetCanMove(bool CanMove)
    {
        this.CanMove = CanMove;
        FootstepsAudioScript.SetCanMove(CanMove);
    }//End Can Move Setter
    #endregion
    #endregion

    private void Awake()
    {
        PlayerController = GetComponent<CharacterController>();
        FootstepsAudioScript = GetComponentInChildren<FootstepsAudio>();
        GroundMask = LayerMask.GetMask("Ground");
        SetCanMove(false);
    }//End Awake

    private void Update()
    {
        HandleGravity();
        DoCrouch();
        DoMovement();
    }//End Update

    #region Behaviours
    private void DoCrouch()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            IsCrouching = !IsCrouching;
            CanMove = !CanMove;
        }//End if
    }//End DoCrouch

    private void DoMovement()
    {
        //If the player character is allowed to move
        if (CanMove)
        {
            //Get player movement input
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            //Calculate the direction of horizontal movement that the player should be doing
            Vector3 directionOfMovement = transform.right * x + transform.forward * z;

            //Adjust velocity according to gravity and framerate
            Movement.y += Gravity * Time.deltaTime;

            //Apply movement according to framerate
            PlayerController.Move(directionOfMovement * MovementSpeed * Time.deltaTime + Movement);
            
            //Play footstep sounds
            PlayFootstepSound();
        }//End if
    }//End DoMovement

    private void PlayFootstepSound()
    {
        //Make sure the audio script is set up to not throw errors
        if (FootstepsAudioScript != null)
        {
            //Don't play if already playing footstep sound or if player is hardly moving
            if (!FootstepsAudioScript.GetFootstepIsPlaying() && PlayerController.velocity.magnitude > 1.0f)
            {
                //Post footstep audio sound event
                FootstepsAudioScript.PlayFootstepSound();
            }//End if
        }//End if
    }//End PlayFootStepSound

    private void HandleGravity()
    {
        //Check that the player is on the ground
        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        //If the player is grounded and the gravity is still increasing
        if (IsGrounded && Movement.y < 0)
        {
            //Stop the player falling so quickly
            Movement.y = -1f;
        }//End if
    }//End HandleGravity
    #endregion
}