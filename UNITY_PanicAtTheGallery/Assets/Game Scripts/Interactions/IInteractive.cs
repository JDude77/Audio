using UnityEngine;

public interface IInteractive
{
    public Collider[] InteractionColliders { get; set; }
    public bool IsInteractible { get; set; }

    public string HUDText { get; set; }

    public void Interact();
}