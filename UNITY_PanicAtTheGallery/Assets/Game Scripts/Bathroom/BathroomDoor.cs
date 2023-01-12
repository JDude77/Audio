using UnityEngine;

public class BathroomDoor : MonoBehaviour, IInteractive
{
    #region Attributes
    private bool DoorOpen = false;
    private float Counter = 0;
    [SerializeField]
    private Animator DoorAnimator;
    #endregion

    #region IInteractive Properties
    public Collider[] InteractionColliders { get; set; }
    
    public bool IsInteractible { get; set; }
    public string HUDText { get; set; }
    #endregion

    #region Getters & Setters
    public bool GetDoorOpen() { return DoorOpen; }
    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        //Ensure at least one collider is active on an interactive object
        InteractionColliders = GetComponentsInChildren<Collider>().Length != 0 ? GetComponentsInChildren<Collider>() : new Collider[1]{gameObject.AddComponent<BoxCollider>()};
        DoorAnimator = GameObject.FindGameObjectWithTag("Bathroom Door").GetComponent<Animator>();
        IsInteractible = true;
        HUDText = "Open Door";
    }//End Start

    private void Update()
    {
        if(!IsInteractible)
        {
            Counter += Time.deltaTime;
            if(Counter >=1)
            {
                IsInteractible = true;
                Counter = 0;
            }//End if
        }//End if
    }//End Update

    #region Behaviours
    public void Interact()
    {
        if(DoorOpen)
        {
            DoorAnimator.SetBool("DoorOpen", false);
            HUDText = "Open Door";
        }//End if
        else
        {
            DoorAnimator.SetBool("DoorOpen", true);
            HUDText = "Close Door";
        }//End else
        IsInteractible = false;
        DoorOpen = !DoorOpen;
    }//End Interact
    #endregion
}
