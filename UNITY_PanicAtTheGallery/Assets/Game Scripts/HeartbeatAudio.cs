using UnityEngine;

public class HeartbeatAudio : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.Event PlayHeartbeatEvent;
    [SerializeField]
    private AK.Wwise.Event StopHeartbeatEvent;
    private bool HeartbeatState = false;
    private bool HeartbeatEnabledInOptions = true;

    private GameManager GM;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }//End Awake

    private void Update()
    {
        if(!HeartbeatEnabledInOptions) return;

        //Turn on heartbeat if it isn't playing and anxiety above audible heartbeat volume
        if(GM.GetAnxiety() >= 25 && !HeartbeatState)
        {
            HeartbeatState = true;
            PlayHeartbeatEvent.Post(gameObject);
            return;
        }//End if

        //Turn off heartbeat if it is playing and anxiety below audible heartbeat volume
        else if(GM.GetAnxiety() < 25 && HeartbeatState)
        {
            HeartbeatState = false;
            StopHeartbeatEvent.Post(gameObject);
            return;
        }//End else if
    }//End Update

    public void ToggleHeartbeat(bool Toggle)
    {
        HeartbeatEnabledInOptions = Toggle;
    }//End ToggleHeartbeat
}