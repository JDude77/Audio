using UnityEngine;

public class PulsatingSkin : MonoBehaviour
{
    #region Attributes
    //Shared
    private GameManager GM;
    private float ScaleCounter = 0.0f;
    private float Scale;
    //Scaling
    private Vector3 DefaultScale = new Vector3(.9f, .9f, .9f);
    [SerializeField]
    private Vector3 MaxScale;
    private Vector3 CurrentMaxScale;
    [SerializeField]
    private Vector3 MinScale;
    private Vector3 CurrentMinScale;
    private Material SkinMaterial;
    private float MinY = 1.5f;
    private float CurrentMinY;
    private float MaxY = 1.7f;
    private float CurrentMaxY;
    //Audio Synthesis
    private AudioSource AudioSource;
    private float Gain;
    [SerializeField]
    private float Volume = 0.1f;
    public void SetVolume(float Volume)
    {
        Volume /= 100f;
        this.Volume = Volume * 0.25f; 
    }//End Volume Setter
    private double Phase;
    private double Frequency = 440.0;
    private double SamplingFrequency;
    private double Increment;
    #endregion

    private void Awake()
    {
        SamplingFrequency = AkSoundEngine.GetSampleRate();
        GM = FindObjectOfType<GameManager>();
        AudioSource = GetComponent<AudioSource>() ? GetComponent<AudioSource>() : gameObject.AddComponent<AudioSource>();
        SkinMaterial = GetComponent<MeshRenderer>().material;
    }//End Awake

    private void Update()
    {
        float Anxiety = GM.GetAnxiety();
        if(Anxiety > 60)
        {
            //Calculate values for scaling
            float AnxietySinAndCounter = Anxiety / 40f;
            float AnxietyScaleLerp = (Anxiety - 40) / 60f;
            Scale = (Mathf.Sin(ScaleCounter * AnxietySinAndCounter) + 1) / 2f;
            ScaleCounter += Time.deltaTime * AnxietySinAndCounter;
            if(ScaleCounter > 360) ScaleCounter -= 360;

            //Audio synthesis
            if(!AudioSource.enabled)
            {
                AudioSource.enabled = true;
                if(!AudioSource.isPlaying) AudioSource.Play();
            }//End if
            Gain = Mathf.Lerp(0, Volume, AnxietyScaleLerp);
            Frequency = 196.0 * Scale + (AnxietyScaleLerp * 196.0);

            //Scaling of the sphere
            CurrentMaxScale = Vector3.Lerp(DefaultScale, MaxScale, AnxietyScaleLerp);
            CurrentMinScale = Vector3.Lerp(MinScale, DefaultScale, 1 - AnxietyScaleLerp);

            CurrentMaxY = Mathf.Lerp(1.55f, MaxY, AnxietyScaleLerp);
            CurrentMinY = Mathf.Lerp(MinY, 1.55f, 1 - AnxietyScaleLerp);

            transform.localScale = Vector3.Lerp(CurrentMinScale, CurrentMaxScale, Scale);
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(CurrentMinY, CurrentMaxY, Scale));

            //Material alteration
            Color Emission = new Color(0.15f, 0.9f, 0.05f) * Scale / 2.0f;
            SkinMaterial.SetColor("_EmissionColor", Emission);
            SkinMaterial.EnableKeyword("_EMISSION");
        }//End if
        else if(transform.localScale != DefaultScale)
        {
            Gain = 0;
            AudioSource.Stop();
            AudioSource.enabled = false;
            transform.localScale = DefaultScale;
            transform.localPosition = new Vector3(transform.localPosition.x, 1.55f, transform.localPosition.z);
            SkinMaterial.DisableKeyword("_EMISSION");
        }//End else
    }//End Update

    private void OnAudioFilterRead(float[] data, int channels)
    {
        Increment = Frequency * 2.0f * Mathf.PI / SamplingFrequency;
        for (int i = 0; i < data.Length; i += channels)
        {
            Phase += Increment;
            data[i] = Gain * Mathf.PingPong((float)(Phase), 1.0f);
            if(channels == 2) data[i+1] = data[i];
            if(Phase > Mathf.PI * 2.0) Phase -= Mathf.PI * 2.0;;
        }//End for
    }//End OnAudioFilterRead
}