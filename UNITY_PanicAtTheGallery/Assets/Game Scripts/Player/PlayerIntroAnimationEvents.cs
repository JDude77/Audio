using UnityEngine;

public class PlayerIntroAnimationEvents : MonoBehaviour
{
    [Header("Outdoor Environment")]
    [SerializeField]
    private AK.Wwise.Event StopOutdoorAudioEvent;
    [SerializeField]
    private GameObject ExteriorEnvironment;
    [Header("Intro Heartbeat")]
    [SerializeField]
    private AK.Wwise.Event StopMenuHeartbeatEvent;
    [Header("Live Music Starter")]
    [SerializeField]
    private AK.Wwise.Event StartLiveMusic;
    [SerializeField]
    private GameObject LiveStringsObject;
    [Header("Game HUD")]
    [SerializeField]
    private GameObject HUD;
    public void EndIntro()
    {
        GetComponentInChildren<PlayerCamera>().SetCanLook(true);
        GetComponentInChildren<PlayerMovement>().SetCanMove(true);
        StopOutdoorAudioEvent.Post(ExteriorEnvironment);
        HUD.SetActive(true);
        Destroy(GetComponentInChildren<Animator>());
        Destroy(this);
    }//End EndIntro

    public void StopHeartbeat()
    {
        StopMenuHeartbeatEvent.Post(ExteriorEnvironment);
    }//End StopHeartbeat

    public void StartMusic()
    {
        StartLiveMusic.Post(LiveStringsObject);
    }//End StartMusic
}