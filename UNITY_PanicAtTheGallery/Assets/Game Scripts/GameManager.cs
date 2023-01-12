using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.RTPC RTPCAnxietyParamter;
    [SerializeField, Range(0, 100)]
    private int InitialAnxietyLevel;
    private int Anxiety = 0;

    [SerializeField]
    private Volume PostProcessingVolume;
    private VolumeProfile PostProcessingProfile;
    private Bloom Bloom;
    private Vignette Vignette;
    private FilmGrain FilmGrain;
    private ColorAdjustments ColorAdjustments;

    private Color FilterOff = new Color(1, 1, 1);
    private Color FilterOn = new Color(0.8f, 0.72f, 0.72f);

    [SerializeField]
    private Slider AnxietyHUD;
    private int TargetAnxietyValue;
    [SerializeField]
    private Image AnxietyAmountImage;
    private bool PostProcessingEnabledInOptions = true;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        TargetAnxietyValue = InitialAnxietyLevel;
        if(PostProcessingVolume != null) PostProcessingProfile = PostProcessingVolume.profile;
    }//End Awake

    public void TogglePostProcessing(bool Toggle)
    {
        PostProcessingEnabledInOptions = Toggle;
    }//End TogglePostProcessing

    private void Start()
    {
        SetAnxiety(InitialAnxietyLevel);
    }//End Start

    private void Update()
    {
        //Quick code to allow player to quit the game without ALT-F4-ing out
        if(Input.GetKey(KeyCode.Escape)) Application.Quit();

        //Update the anxiety HUD gradually
        if(TargetAnxietyValue != AnxietyHUD.value)
        {
            float Difference = Mathf.Abs(AnxietyHUD.value - TargetAnxietyValue);
            if(Difference > 0.25f)
            {
                AnxietyHUD.value = Mathf.Lerp(AnxietyHUD.value, TargetAnxietyValue, Difference * Time.deltaTime);
            }//End if
            else
            {
                AnxietyHUD.value = TargetAnxietyValue;
            }//End else
            AnxietyAmountImage.color = new Color(0.5f, 0.05f, 0.05f, (AnxietyHUD.value / 100) + 0.05f);
        }//End if
    }//End Update

    public void SetAnxiety(int Anxiety)
    {
        Anxiety = Mathf.Clamp(Anxiety, 0, 100);
        bool Higher = Anxiety < this.Anxiety;
        this.Anxiety = Anxiety;
        RTPCAnxietyParamter.SetGlobalValue(Anxiety);
        TargetAnxietyValue = Anxiety;
        if(PostProcessingEnabledInOptions) ApplyPostProcessing(Anxiety, Higher);
    }//End SetAnxiety

    private void ApplyPostProcessing(int Anxiety, bool Higher)
    {
        if (PostProcessingProfile != null)
        {
            PostProcessingProfile.TryGet(out Bloom);
            float Exp = Anxiety / 75 * Anxiety / 75;
            //Pay no attention to this atrocious line of code
            Bloom.intensity.value = Higher ? (Anxiety / 25 + 0.5f) * Exp : (Anxiety / 25 - 0.5f) * Exp;

            PostProcessingProfile.TryGet(out Vignette);
            Vignette.intensity.value = Anxiety / 500f;

            PostProcessingProfile.TryGet(out FilmGrain);
            FilmGrain.intensity.value = Mathf.Clamp((Anxiety - 70f) / 40f, 0, 1);

            PostProcessingProfile.TryGet(out ColorAdjustments);
            ColorAdjustments.contrast.value = Mathf.Clamp((Anxiety - 75f) / 2.5f, 0, 10);
            ColorAdjustments.colorFilter.value = Color.Lerp(FilterOff, FilterOn, (Anxiety - 75f) / 25f);
            ColorAdjustments.saturation.value = Mathf.Clamp(-((Anxiety - 60f) / 2.0f), -20, 0);

            PostProcessingProfile.Reset();
        }//End if
    }//End ApplyPostProcessing

    public int GetAnxiety()
    {
        return Anxiety;
    }//End GetAnxiety
}