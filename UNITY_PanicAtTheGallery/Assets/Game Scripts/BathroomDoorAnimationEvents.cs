using UnityEngine;

public class BathroomDoorAnimationEvents : MonoBehaviour
{
    [Header("Wwise Events")]
    [SerializeField]
    private AK.Wwise.Event PlayDoorSqueakOpen;
    [SerializeField]
    private AK.Wwise.Event PlayDoorSqueakClose;
    [SerializeField]
    private AK.Wwise.Event PlayDoorSlamWall;
    [SerializeField]
    private AK.Wwise.Event PlayDoorHitWall;
    [SerializeField]
    private AK.Wwise.Event PlayDoorClickShut;
    [SerializeField]
    private AK.Wwise.Event StopCurrentDoorSounds;
    [SerializeField]
    private GameObject ClickSoundOrigin;

    public void PlayDoorSqueakOpenSound()
    {
        //Stops any remaining noises from door being closed if applicable
        StopCurrentDoorSounds.Post(gameObject);
        PlayDoorSqueakOpen.Post(gameObject);
    }//End PlayDoorSqueakOpenSound

    public void PlayDoorSqueakCloseSound()
    {
        //Stops any remaining noises from door being opened if applicable
        StopCurrentDoorSounds.Post(gameObject);
        PlayDoorSqueakClose.Post(gameObject);
    }//End PlayDoorSqueakClose

    public void PlayDoorSlamWallSound()
    {
        //Stops the squeaking door opening in its tracks
        StopCurrentDoorSounds.Post(gameObject);
        PlayDoorSlamWall.Post(gameObject);
    }//End PlayDoorSlamWallSound

    public void PlayDoorHitWallSound()
    {
        PlayDoorHitWall.Post(gameObject);
    }//End PlayDoorHitWallSound

    public void PlayDoorClickShutSound()
    {
        PlayDoorClickShut.Post(ClickSoundOrigin);
    }//End PlayDoorClickShutSound
}
