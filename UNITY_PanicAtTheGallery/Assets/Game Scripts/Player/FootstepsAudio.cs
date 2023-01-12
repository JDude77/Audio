using UnityEngine;

public class FootstepsAudio : MonoBehaviour
{
    #region Attributes
    [Header("Wwise Events")]
    [SerializeField]
    private AK.Wwise.Event FootstepsEvent;
    private float TimeBetweenFootsteps = 0.5f;
    private float Counter;
    private bool FootstepIsPlaying = true;
    private CharacterController PlayerController;
    private Vector3 PlayerMovementDirection;
    private bool CanMove = true;
    #endregion

    #region Getters & Setters
    public void SetCanMove(bool CanMove) { this.CanMove = CanMove; }

    public bool GetFootstepIsPlaying() { return FootstepIsPlaying; }
    #endregion

    private void Awake()
    {
       PlayerController = gameObject.GetComponent<CharacterController>();
    }//End Awake

    private void Update()
    {
        if(!CanMove) return;

        if(FootstepIsPlaying)
        {
            Counter += Time.deltaTime;
            if(Counter >= TimeBetweenFootsteps)
            {
                FootstepIsPlaying = false;
                Counter = 0;
            }//End if
        }//End if
    }//End Update

    private void OnTriggerStay(Collider other)
    {
        if(!other.CompareTag("Stairs")) return;

        PlayerMovementDirection = PlayerController.velocity.normalized;
        //This line of code is an abomination and I'm sorry
        float Angle = Mathf.Abs(Vector3.Angle(PlayerMovementDirection, Vector3.forward) - 90) / 90f;
        TimeBetweenFootsteps = Mathf.Lerp(0.25f, 0.5f, Angle);
    }//End OnTriggerStay

    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Stairs")) return;

        TimeBetweenFootsteps = 0.5f;
    }//End OnTriggerExit

    #region Behaviours
    public void PlayFootstepSound()
    {
        FootstepsEvent.Post(gameObject);
        FootstepIsPlaying = true;
    }//End PlayFootstepSound
    #endregion
}