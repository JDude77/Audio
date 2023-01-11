using UnityEngine;

public class DynamicPaintingEmissions : MonoBehaviour
{
    [SerializeField]
    private Material[] PaintingMaterials;

    private GameManager GM;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }//End Awake

    private void Update()
    {
        int Anxiety = GM.GetAnxiety();
        if(Anxiety >= 70)
        {
            foreach(Material Material in PaintingMaterials)
            {
                Material.SetFloat("_Emission_Intensity", (Anxiety - 70) / 15f);
                Material.EnableKeyword("_EMISSION");
            }//End foreach
        }//End if
        else if(PaintingMaterials[0].GetFloat("_Emission_Intensity") > 0.0f)
        {
            foreach(Material Material in PaintingMaterials)
            {
                Material.SetFloat("_Emission_Intensity", 0.0f);
                Material.DisableKeyword("_EMISSION");
            }//End foreach
        }//End else if
    }//End Update
}