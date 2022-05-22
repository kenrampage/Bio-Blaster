using UnityEngine;
using FMODUnity;
using UnityEngine.UI;

public class FMODVolumeControl : MonoBehaviour
{
    [SerializeField] private FMOD.Studio.Bus musicBus;
    [SerializeField] private FMOD.Studio.Bus effectsBus;

    [SerializeField] private float musicVolume;
    [SerializeField] private float effectsVolume;

    [SerializeField] private Image musicBar;
    [SerializeField] private Image effectsBar;

    private void Awake()
    {
        GetBusReferences();
        GetVolumes();
        SetVolumeBars();

    }

    private void OnEnable()
    {
        GetBusReferences();
        GetVolumes();
        SetVolumeBars();
    }

    public void MusicVolumeUp()
    {
        GetVolumes();
        if (musicVolume < 1)
        {
            musicBus.setVolume(musicVolume + .1f);
            if (musicVolume > 1)
            {
                musicVolume = 1;
                musicBus.setVolume(1);
            }
        }
        GetVolumes();
        SetVolumeBars();
    }

    public void MusicVolumeDown()
    {
        GetVolumes();

        if (musicVolume > 0)
        {
            musicBus.setVolume(musicVolume - .1f);
            if (musicVolume < 0)
            {
                musicVolume = 0;
                musicBus.setVolume(0);
            }
        }

        GetVolumes();
        SetVolumeBars();
    }

    public void EffectsVolumeUp()
    {
        GetVolumes();
        if (effectsVolume < 1)
        {
            effectsBus.setVolume(effectsVolume + .1f);
            if (effectsVolume > 1)
            {
                effectsVolume = 1;
                effectsBus.setVolume(1);
            }
        }
        GetVolumes();
        SetVolumeBars();

    }

    public void EffectsVolumeDown()
    {
        GetVolumes();

        if (effectsVolume > 0)
        {
            effectsBus.setVolume(effectsVolume - .1f);
            if (effectsVolume < 0)
            {
                effectsVolume = 0;
                effectsBus.setVolume(0);
            }
        }

        GetVolumes();
        SetVolumeBars();

    }


    public void GetBusReferences()
    {
        if (effectsBus.isValid() == false)
        {
            effectsBus = RuntimeManager.GetBus("bus:/SFX");
        }

        if (musicBus.isValid() == false)
        {
            musicBus = RuntimeManager.GetBus("bus:/Music");
        }
    }

    public void GetVolumes()
    {
        musicBus.getVolume(out musicVolume);
        effectsBus.getVolume(out effectsVolume);
    }

    public void SetVolumeBars()
    {
        musicBar.fillAmount = musicVolume;
        effectsBar.fillAmount = effectsVolume;
    }
}
