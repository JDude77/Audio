using UnityEngine;

public class BathroomDoor : MonoBehaviour, IInteractive
{
    public Collider[] InteractionColliders { get; set; }
    private bool DoorOpen = false;
    private float Counter = 0;
    [SerializeField]
    private Animator DoorAnimator;
    public bool IsInteractible { get; set; }
    public string HUDText { get; set; }

    public bool GetDoorOpen() { return DoorOpen; }

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
}
