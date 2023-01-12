using UnityEngine;

public class ViewArt : MonoBehaviour, IInteractive
{
    #region Attributes
    static private GameManager GM;
    [Header("Player HUD Info")]
    [SerializeField]
    private string ArtName;
    [SerializeField]
    private string ArtComment;
    #endregion

    #region IInteractive Properties
    public Collider[] InteractionColliders { get; set; }
    public bool IsInteractible { get; set; }
    public string HUDText { get; set; }
    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        GM = FindObjectOfType<GameManager>();

        //Ensure at least one collider is active on an interactive object
        InteractionColliders = GetComponentsInChildren<Collider>().Length != 0 ? GetComponentsInChildren<Collider>() : new Collider[1]{gameObject.AddComponent<BoxCollider>()};
        IsInteractible = true;

        //Ignore the below auto-set line if the name's already been set in inspector
        if(ArtName.Length == 0) ArtName = !gameObject.name.Equals("Painting") && !gameObject.name.Equals("Pedestal") ? gameObject.name.Substring(0, gameObject.name.IndexOf(' ')) : "UNNAMED ART";
        HUDText = "View " + ArtName;
    }//End Start

    #region Behaviours
    public void Interact()
    {
        if(GM.GetAnxiety() < 100)
        {
            IsInteractible = false;
            GM.SetAnxiety(GM.GetAnxiety() + Random.Range(1, 15));
            Debug.Log("Anxiety: " + GM.GetAnxiety());
        }//End if
        else
        {
            Debug.Log("Max Anxiety: Interaction cancelled");
        }//End else
    }//End Interact
    #endregion
}
