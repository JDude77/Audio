using UnityEngine;

public class BathroomDoorTrigger : MonoBehaviour, IInteractive
{
    #region Attributes
    [SerializeField]
    private BathroomDoor BathroomDoor;
    private float Counter = 0;
    #endregion

    #region IInteractive Properties
    public Collider[] InteractionColliders { get; set; }
    public bool IsInteractible { get; set; }
    public string HUDText { get; set; }
    #endregion

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
    }//End Update

    #region Behaviours
    public void Interact()
    {
        BathroomDoor.Interact();
        IsInteractible = false;
    }//End Interact
    #endregion
}
