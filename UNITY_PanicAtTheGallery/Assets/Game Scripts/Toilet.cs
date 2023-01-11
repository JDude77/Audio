
using UnityEngine;

public class Toilet : MonoBehaviour, IInteractive
{
    [SerializeField]
    private AK.Wwise.Event FlushToiletEvent;
    [SerializeField]
    private AK.Wwise.Event StopFlushToiletEvent;
    private readonly float FlushCooldownTime = 10.0f;
    private float CooldownTimer;
    private Animator FlushAnimator;

    public Collider[] InteractionColliders { get; set; }
    public bool IsInteractible { get; set; }
    public string HUDText { get; set; }

    public void Interact()
    {
        IsInteractible = false;
        FlushAnimator.Play("Flush");
        StopFlushToiletEvent.Post(gameObject);
        FlushToiletEvent.Post(gameObject);
    }//End Interact

    private void Awake()
    {
        HUDText = "Flush Toilet";
        FlushAnimator = GetComponent<Animator>();
        IsInteractible = true;
        InteractionColliders = GetComponentsInChildren<Collider>().Length != 0 ? GetComponentsInChildren<Collider>() : new Collider[1]{gameObject.AddComponent<BoxCollider>()};
    }//End Awake

    private void Update()
    {
        if(!IsInteractible)
        {
            CooldownTimer += Time.deltaTime;
            if(CooldownTimer >= FlushCooldownTime)
            {
                IsInteractible = true;
                CooldownTimer = 0.0f;
            }//End if
        }//End if
    }//End Update
}
