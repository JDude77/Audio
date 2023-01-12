using UnityEngine;

public class ElectrodudLights : MonoBehaviour
{
    #region Attributes
    [SerializeField]
    private Material ElectrodudMaterial;
    private Light[] ElectrodudSpotlights;
    private GameManager GM;
    private int Anxiety;
    #endregion

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
        ElectrodudSpotlights = GetComponentsInChildren<Light>();
        Anxiety = GM.GetAnxiety();
        ElectrodudMaterial.SetColor("_EmissionColor", new Color(0, 0, 0));
        ElectrodudMaterial.EnableKeyword("_EMISSION");
        foreach(Light Spotlight in ElectrodudSpotlights)
        {
            Spotlight.intensity = 0;
        }//End foreach
    }//End Awake

    private void Update()
    {
        //Prevent running update when no changes need to be made
        if(Anxiety == GM.GetAnxiety()) return;

        //Cache to avoid repeated calls to getter
        Anxiety = GM.GetAnxiety();
        if(Anxiety >= 75)
        {
            Color Emission = new Color(1, 1, 1) * (Anxiety - 75) / 10f;
            ElectrodudMaterial.SetColor("_EmissionColor", Emission);
            ElectrodudMaterial.EnableKeyword("_EMISSION");
            foreach(Light Spotlight in ElectrodudSpotlights)
            {
                Spotlight.intensity = Anxiety / 95f;
            }//End foreach
        }//End if
        else
        {
            ElectrodudMaterial.DisableKeyword("_EMISSION");
            foreach(Light Spotlight in ElectrodudSpotlights)
            {
                Spotlight.intensity = 0;
            }//End foreach
        }//End else
    }//End Update
}
