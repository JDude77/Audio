/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_BATHROOMDOORCLICK = 3059754700U;
        static const AkUniqueID PLAY_BATHROOMDOORIMPACT = 2528637642U;
        static const AkUniqueID PLAY_BATHROOMDOORSQUEAKCLOSED = 836867030U;
        static const AkUniqueID PLAY_BATHROOMDOORSQUEAKOPEN = 2005310866U;
        static const AkUniqueID PLAY_BATHROOMDOORTHUD = 4104340779U;
        static const AkUniqueID PLAY_FOOTSTEPS = 3854155799U;
        static const AkUniqueID PLAY_HEARTBEAT = 3765695918U;
        static const AkUniqueID PLAY_MUSIC = 2932040671U;
        static const AkUniqueID PLAY_OUTDOORSBLENDCONTAINER = 2095862519U;
        static const AkUniqueID PLAY_OUTDOORSHEARTBEAT = 606952887U;
        static const AkUniqueID PLAY_STINGER = 754369548U;
        static const AkUniqueID PLAY_TAPRUNNING = 3748840666U;
        static const AkUniqueID PLAY_TOILETFLUSH = 1853832177U;
        static const AkUniqueID SET_BASS_PLAYING_OFF = 1968328302U;
        static const AkUniqueID SET_BASS_PLAYING_ON = 443506384U;
        static const AkUniqueID SET_CELLO_PLAYING_OFF = 4164588532U;
        static const AkUniqueID SET_CELLO_PLAYING_ON = 27402606U;
        static const AkUniqueID SET_MUSIC_KEY_SWITCH_B = 4015526953U;
        static const AkUniqueID SET_MUSIC_KEY_SWITCH_C = 4015526952U;
        static const AkUniqueID SET_VIOLA_PLAYING_OFF = 15315860U;
        static const AkUniqueID SET_VIOLA_PLAYING_ON = 1657027470U;
        static const AkUniqueID SET_VIOLIN_PLAYING_OFF = 2128560376U;
        static const AkUniqueID SET_VIOLIN_PLAYING_ON = 882775970U;
        static const AkUniqueID STOP_BATHROOMDOORSOUNDS = 253011666U;
        static const AkUniqueID STOP_HEARTBEAT = 3319673256U;
        static const AkUniqueID STOP_OUTDOORSBLENDCONTAINER = 82798741U;
        static const AkUniqueID STOP_OUTDOORSHEARTBEAT = 2243099949U;
        static const AkUniqueID STOP_STINGER = 3205063286U;
        static const AkUniqueID STOP_TAPRUNNING = 2944826444U;
        static const AkUniqueID STOP_TOILETFLUSH = 1875300071U;
    } // namespace EVENTS

    namespace SWITCHES
    {
        namespace BASS_PLAYING
        {
            static const AkUniqueID GROUP = 1707800063U;

            namespace SWITCH
            {
                static const AkUniqueID OFF = 930712164U;
                static const AkUniqueID ON = 1651971902U;
            } // namespace SWITCH
        } // namespace BASS_PLAYING

        namespace CELLO_PLAYING
        {
            static const AkUniqueID GROUP = 2097398747U;

            namespace SWITCH
            {
                static const AkUniqueID OFF = 930712164U;
                static const AkUniqueID ON = 1651971902U;
            } // namespace SWITCH
        } // namespace CELLO_PLAYING

        namespace FOOTSTEPS
        {
            static const AkUniqueID GROUP = 2385628198U;

            namespace SWITCH
            {
                static const AkUniqueID STONE = 1216965916U;
                static const AkUniqueID WOOD = 2058049674U;
            } // namespace SWITCH
        } // namespace FOOTSTEPS

        namespace MUSIC_KEY
        {
            static const AkUniqueID GROUP = 2078097994U;

            namespace SWITCH
            {
                static const AkUniqueID B_MINOR = 2279419299U;
                static const AkUniqueID C_MAJOR = 3947233186U;
            } // namespace SWITCH
        } // namespace MUSIC_KEY

        namespace VIOLA_PLAYING
        {
            static const AkUniqueID GROUP = 209381827U;

            namespace SWITCH
            {
                static const AkUniqueID OFF = 930712164U;
                static const AkUniqueID ON = 1651971902U;
            } // namespace SWITCH
        } // namespace VIOLA_PLAYING

        namespace VIOLIN_PLAYING
        {
            static const AkUniqueID GROUP = 466257165U;

            namespace SWITCH
            {
                static const AkUniqueID OFF = 930712164U;
                static const AkUniqueID ON = 1651971902U;
            } // namespace SWITCH
        } // namespace VIOLIN_PLAYING

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID ANXIETY = 4143496951U;
        static const AkUniqueID MASTERVOLUME = 2918011349U;
        static const AkUniqueID MUSICVOLUME = 2346531308U;
        static const AkUniqueID SFXVOLUME = 988953028U;
    } // namespace GAME_PARAMETERS

    namespace TRIGGERS
    {
        static const AkUniqueID DOWN_STINGER_B = 2176606481U;
        static const AkUniqueID DOWN_STINGER_C = 2176606480U;
    } // namespace TRIGGERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID BATHROOM = 1831461191U;
        static const AkUniqueID FOOTSTEPS = 2385628198U;
        static const AkUniqueID HEARTBEAT = 2179486487U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID OUTDOORS = 2730119150U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID MAIN_GALLERY = 1779701493U;
        static const AkUniqueID OUTSIDE = 438105790U;
        static const AkUniqueID SMALL_GALLERY = 3083919765U;
        static const AkUniqueID TOILET = 580245626U;
    } // namespace AUX_BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
