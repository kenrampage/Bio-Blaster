using UnityEngine;
using FMODUnity;
using FMOD;


public class FMODPlayOneShot : MonoBehaviour
{
    public FMODUnity.EventReference fmodEventRef;
    // [EventRef] public string fmodEvent;
    [SerializeField] private bool soundEffectsOn = true;

    public void PlaySoundEvent()
    {
        if (!fmodEventRef.IsNull && soundEffectsOn)
        {
            bool is3D;
            RuntimeManager.GetEventDescription(fmodEventRef).is3D(out is3D);

            if (is3D)
            {
                PlaySoundEventAttached();
            }
            else
            {
                RuntimeManager.PlayOneShot(fmodEventRef);

            }
        }



    }

    private void PlaySoundEventAttached()
    {
        if (!fmodEventRef.IsNull && soundEffectsOn)
        {
            RuntimeManager.PlayOneShotAttached(fmodEventRef.Guid, gameObject);
            
        }

    }

    public void DisableSoundEffects()
    {
        soundEffectsOn = false;
    }

    public void EnableSoundEffects()
    {
        soundEffectsOn = true;
    }

}
