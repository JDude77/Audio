using UnityEngine;

public class BathroomAnxietyReduction : MonoBehaviour
{
    #region Attributes
    private GameManager GM;
    private BathroomDoor BathroomDoor;
    private float TempAnxiety;
    #endregion

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
        BathroomDoor = FindObjectOfType<BathroomDoor>();
    }//End Awake

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            TempAnxiety = GM.GetAnxiety();
        }//End if
    }//End OnTriggerEnter

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Reduce anxiety faster if the door is closed
            TempAnxiety = BathroomDoor.GetDoorOpen() ? TempAnxiety - Time.deltaTime / 2.0f : TempAnxiety - Time.deltaTime;

            GM.SetAnxiety(Mathf.RoundToInt(TempAnxiety));
        }//End if
    }//End OnTriggerStay
}