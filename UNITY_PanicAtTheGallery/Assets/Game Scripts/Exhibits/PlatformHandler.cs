using UnityEngine;

public class PlatformHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject Bottom;

    [SerializeField]
    private GameObject Top;

    private Material[] PlatformMaterials;
    private Light[] PlatformLights;

    private GameManager GM;
    private float StretchCounter = 0.0f;

    private float ScaleFactor = 0.2f;

    private float Frequency = 0.044f;

    private Vector3 StartScaleMid;
    private Vector3 StartPositionMid;
    private Vector3 StartPositionTop;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
        StartScaleMid = transform.localScale;
        StartPositionMid = transform.localPosition;
        StartPositionTop = Top.transform.localPosition;
        PlatformMaterials = new Material[3];
        PlatformMaterials[0] = Top.GetComponent<MeshRenderer>().material;
        PlatformMaterials[1] = GetComponent<MeshRenderer>().material;
        PlatformMaterials[2] = Bottom.GetComponent<MeshRenderer>().material;
        PlatformLights = new Light[3];
        PlatformLights[0] = Top.GetComponent<Light>();
        PlatformLights[1] = GetComponent<Light>();
        PlatformLights[2] = Bottom.GetComponent<Light>();
    }//End Awake

    private void Update()
    {
        //Cache to avoid repeated calls
        int Anxiety = GM.GetAnxiety();
        Color Emission = new Color(0, 0, 0);
        if(Anxiety > 55)
        {
            ScalePlatform(Anxiety);
            Emission = new Color(1, 1, 1) * (Anxiety - 55) / 30.0f;
            SetPlatformLighting(Emission, Anxiety);
        }//End if
        else if (transform.localScale != StartScaleMid)
        {
            transform.localScale = StartScaleMid;
            transform.localPosition = StartPositionMid;
            Top.transform.localPosition = StartPositionTop;
            SetPlatformLighting(Emission, Anxiety);
        }//End else if
    }//End Update

    private void SetPlatformLighting(Color Emission, float Anxiety)
    {
        foreach (Material Material in PlatformMaterials)
        {
            Material.SetColor("_EmissionColor", Emission);
            Material.EnableKeyword("_EMISSION");
        }//End foreach
        foreach(Light PointLight in PlatformLights)
        {
            PointLight.intensity = Anxiety > 55 ? Anxiety / 95f : 0;
        }//End foreach
    }//End SetPlatformMaterialsEmission

    private void ScalePlatform(int Anxiety)
    {
        StretchCounter += Time.deltaTime * (Anxiety * Frequency);
        if(StretchCounter > 360) StretchCounter -= 360;
        ScaleFactor = ((Anxiety - 55) / 45f) / 3.0f;
        Frequency = 4.4f / Anxiety;
        transform.localScale = new Vector3(ScaleFactor * Mathf.Abs(Mathf.Sin(StretchCounter)), transform.localScale.y, transform.localScale.z);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.006f + (transform.localScale.x * 0.01f));
        Top.transform.localPosition = new Vector3(Top.transform.localPosition.x, Top.transform.localPosition.y, transform.localPosition.z + transform.localScale.x * 0.01f);
    }//End ScalePlatform
}
