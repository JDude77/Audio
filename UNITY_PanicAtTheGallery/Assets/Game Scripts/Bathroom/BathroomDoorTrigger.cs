using UnityEngine;

public class BathroomDoorTrigger : MonoBehaviour, IInteractive
{
    [SerializeField]
    private BathroomDoor BathroomDoor;

    public Collider[] InteractionColliders { get; set; }
    public bool IsInteractible { get; set; }
    public string HUDText { get; set; }
    private float Counter = 0;

    public void Interact()
    {
        BathroomDoor.Interact();
        IsInteractible = false;
    }
    private void Start()
    {
        //Ensure at least one collider is active on an interactive object
        InteractionColliders = GetComponentsInChildren<Collider>().Length != 0 ? GetComponentsInChildren<Collider>() : new Collider[1]{gameObject.AddComponent<BoxCollider>()};
        IsInteractible = true;
    }//End Start

    private void Update()
    {
        HUDText = BathroomDoor.HUDText;
        if(!IsInteractible)
        {
            Counter += Time.deltaTime;
            if(Counter >=1)
            {
                IsInteractible = true;
                Counter = 0;
            }//End if
        }//End if
    }
}
