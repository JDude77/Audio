using UnityEngine;

public class Sink : MonoBehaviour, IInteractive
{
    #region Attributes
    [Header("Wwise Events")]
    [SerializeField]
    private AK.Wwise.Event PlaySinkAudioEvent;
    [SerializeField]
    private AK.Wwise.Event StopSinkAudioEvent;
    private bool SinkIsOn = false;
    private Animator SinkAnimator;
    #endregion

    #region IInteractive Properties
    public Collider[] InteractionColliders { get; set; }
    public bool IsInteractible { get; set; }
    public string HUDText { get; set; }
    #endregion
    
    private void Awake()
    {
        SinkAnimator = GetComponent<Animator>();
        InteractionColliders = GetComponentsInChildren<Collider>().Length > 0 ? GetComponentsInChildren<Collider>() : new Collider[1]{ gameObject.AddComponent<BoxCollider>() };
        IsInteractible = true;
        HUDText = "Turn On Faucet";
    }//End Awake

    #region Behaviours
    public void Interact()
    {
        StopSinkAudioEvent.Post(gameObject);
        SinkIsOn = !SinkIsOn;
        HUDText = SinkIsOn ? "Turn Off Faucet" : "Turn On Faucet";
        SinkAnimator.SetBool("FaucetOn", SinkIsOn);
        PlaySinkAudioEvent.Post(gameObject);
    }//End Interact
    #endregion
}