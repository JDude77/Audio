using UnityEngine;

public class PulsatingSkin : MonoBehaviour
{
    private GameManager GM;
    private float ScaleCounter = 0.0f;

    private Vector3 DefaultScale = new Vector3(.9f, .9f, .9f);
    [SerializeField]
    private Vector3 MaxScale;
    [SerializeField]
    private Vector3 MinScale;

    private Material SkinMaterial;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
        SkinMaterial = GetComponent<MeshRenderer>().material;
    }//End Awake

    private void Update()
    {
        float Anxiety = GM.GetAnxiety();
        if(Anxiety > 60)
        {
            ScaleCounter += Time.deltaTime;
            if(ScaleCounter > 360) ScaleCounter -= 360;
            float Scale = (Mathf.Sin(ScaleCounter * Anxiety / 40f) + 1) / 2f;
            transform.localScale = Vector3.Lerp(MinScale, MaxScale, Scale);
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(1.5f, 1.7f, Scale));
            Color Emission = new Color(0.15f, 0.9f, 0.05f) * Scale / 2.0f;
            SkinMaterial.SetColor("_EmissionColor", Emission);
            SkinMaterial.EnableKeyword("_EMISSION");
        }//End if
        else if(transform.localScale != DefaultScale)
        {
            transform.localScale = DefaultScale;
            transform.localPosition = new Vector3(transform.localPosition.x, 1.55f, transform.localPosition.z);
            SkinMaterial.DisableKeyword("_EMISSION");
        }//End else
    }//End Update
}