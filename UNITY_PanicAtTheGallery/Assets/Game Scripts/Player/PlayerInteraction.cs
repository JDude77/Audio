using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField, Range(0.5f, 5)]
    private float InteractionRange;
    private IInteractive Interactive;
    [SerializeField]
    private TMPro.TextMeshProUGUI HUDText;

    private void Update()
    {
        //Ensure the extra calculation for debugging definitely isn't done in builds
        #if UNITY_EDITOR
        Debug.DrawRay(transform.position, transform.forward * InteractionRange, Color.blue);
        #endif

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, InteractionRange))
        {
            Interactive = hit.transform.GetComponentInChildren<IInteractive>();
            //If the object has an interactive component in it
            if(Interactive != null)
            {
                if(Interactive.IsInteractible)
                {
                    HUDText.text = Interactive.HUDText;
                    Debug.Log(Interactive.ToString());
                    if(Input.GetKeyDown(KeyCode.Space))
                    {
                        Interactive.Interact();
                    }//End if
                }//End if
                else
                {
                    HUDText.text = "";
                }//End else
            }//End if
            else
            {
                HUDText.text = "";
            }//End else
        }//End if
        else
        {
            Interactive = null;
            HUDText.text = "";
        }//End else
    }//End Update
}