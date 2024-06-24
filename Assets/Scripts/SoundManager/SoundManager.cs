using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    // AudioSource-Komponenten f�r Musik und Soundeffekte
    public AudioSource musicSource;
    public AudioSource SFXSource;

    private void Awake()
    {
        // Singleton Pattern: sicherstellen, dass nur eine Instanz des SoundManagers existiert
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); // Macht den SoundManager persistent zwischen Szenen
    }

    // Musik abspielen
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    // Musik stoppen
    public void StopMusic()
    {
        musicSource.Stop();
    }

    // Soundeffekt abspielen
    public void PlaySoundEffect(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    // Lautst�rke der Musik �ndern
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    // Lautst�rke der Soundeffekte �ndern
    public void SetEffectsVolume(float volume)
    {
        SFXSource.volume = volume;
    }
}

// Erstelle jeweils separate Scripte f�r Musik und Soundeffekte, um sie zu verwalten.

// Musik und Soundeffekte abspielen:

// Um Musik abzuspielen, rufe die PlayMusic-Methode auf und �bergebe ein AudioClip
// SoundManager.instance.PlayMusic(deineMusikClip);


// Um Soundeffekte abzuspielen, rufe die PlaySoundEffect-Methode auf und �bergebe ein AudioClip:
// SoundManager.instance.PlaySoundEffect(deinSoundEffektClip);

// ----------------------------------------------------------------------------------------------------------------------------
// Musik und Soundeffekte stoppen oder �ndern:

// Um die Musik zu stoppen
// SoundManager.instance.StopMusic();

// Um die Lautst�rke der Musik zu �ndern:
// SoundManager.instance.SetMusicVolume(0.5f); // Lautst�rke auf 50% setzen

// Um die Lautst�rke der Soundeffekte zu �ndern:
// SoundManager.instance.SetEffectsVolume(0.5f); // Setzt die Lautst�rke auf 50%

// ----------------------------------------------------------------------------------------------------------------------------

// Nutzung des Sound-Managers
// Erstelle AudioClips in deinem Projekt und verweise auf sie in deinen Skripten, um Musik und Soundeffekte abzuspielen.
// Stelle sicher, dass der SoundManager-GameObject in deiner Szene ist, damit die Sound-Verwaltung funktioniert.