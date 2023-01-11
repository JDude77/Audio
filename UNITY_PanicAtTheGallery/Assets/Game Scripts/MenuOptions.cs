using UnityEngine;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{
    [SerializeField]
    private Slider[] VolumeSliders;
    [SerializeField, Tooltip("Need to be the name of the parameter in Wwise which controls the bus output volume of the same index as the volume slider.")]
    private string[] RTPCNames;
    [SerializeField]
    private Toggle HeartbeatToggle;
    [SerializeField]
    private Toggle PostProcessingToggle;
    [SerializeField]
    private Toggle InvertedMouseXToggle;
    [SerializeField]
    private Toggle InvertedMouseYToggle;
    [SerializeField]
    private Slider MouseSensitivitySlider;

    private HeartbeatAudio HeartbeatAudioScript;
    private bool MenuHeartbeatOn = true;
    private GameManager GM;
    private PlayerCamera PlayerCamera;

    [Header("Wwise Events")]
    [SerializeField]
    private AK.Wwise.Event StartMenuHeartbeat;
    [SerializeField]
    private AK.Wwise.Event StopMenuHeartbeat;
    [SerializeField]
    private GameObject ExteriorEnvironment;

    private void Awake()
    {
        HeartbeatAudioScript = FindObjectOfType<HeartbeatAudio>();
        GM = FindObjectOfType<GameManager>();
        PlayerCamera = FindObjectOfType<PlayerCamera>();
    }//End Awake

    public void SetVolume(int Index)
    {
        AkSoundEngine.SetRTPCValue(RTPCNames[Index], VolumeSliders[Index].value);
    }//End SetVolume

    public void SetInvertedMouseAxis(bool IsX)
    {
        if(IsX) PlayerCamera.SetInvertedX(InvertedMouseXToggle.isOn);
        else PlayerCamera.SetInvertedY(InvertedMouseYToggle.isOn);
    }//End SetInvertedMouseAxis

    public void SetMouseSensitivity()
    {
        PlayerCamera.SetMouseSensitivity(MouseSensitivitySlider.value * 100f);
    }//End SetMouseSensitivity

    public void ToggleHeartbeat()
    {
        MenuHeartbeatOn = !MenuHeartbeatOn;
        if(MenuHeartbeatOn) StartMenuHeartbeat.Post(ExteriorEnvironment);
        else StopMenuHeartbeat.Post(ExteriorEnvironment);
        HeartbeatAudioScript.ToggleHeartbeat(!HeartbeatToggle.isOn);
    }//End ToggleHeartbeat

    public void TogglePostProcessing()
    {
        GM.TogglePostProcessing(!PostProcessingToggle.isOn);
    }//End TogglePostProcessing
}
