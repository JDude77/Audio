using UnityEngine;

public class JaniceHeadRotation : MonoBehaviour
{
    private GameManager GM;
    [SerializeField]
    private GameObject[] Eyes;
    private GameObject Player;

    private void Awake()
    {
        Player = FindObjectOfType<Camera>().gameObject;
        GM = FindObjectOfType<GameManager>();
    }//End Awake

    private void Update()
    {
        //Cache anxiety to avoid repeated calls
        int Anxiety = GM.GetAnxiety();

        //Toggle visibility of the eyes depending on anxiety level
        ToggleEyes(Anxiety);

        //Rotates the head to follow the player if anxiety level is high enough
        RotateHead(Anxiety);
    }//End Update

    private void RotateHead(int Anxiety)
    {
        if (Anxiety >= 80)
        {
            Vector3 rotation = Quaternion.LookRotation(Player.transform.position - transform.position).eulerAngles;
            rotation.x = -90f;
            transform.rotation = Quaternion.Euler(rotation);
        }//End if
        else
        {
            transform.localRotation = Quaternion.Euler(270, 0, 0);
        }//End else
    }

    private void ToggleEyes(int Anxiety)
    {
        if(!Eyes[0].activeInHierarchy && Anxiety >= 90 )
        {
            foreach(GameObject eye in Eyes)
            {
                eye.SetActive(true);
            }//End foreach
        }//End if
        else if(Eyes[0].activeInHierarchy && Anxiety < 90)
        {
            foreach(GameObject eye in Eyes)
            {
                eye.SetActive(false);
            }//End foreach
        }//End else if
    }//End ToggleEyes
}
