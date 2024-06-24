using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Sources ----------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("---------- Audio Mixer ----------")]
    public AudioClip UI;
    public AudioClip Level1;
    public AudioClip Level2;
    public AudioClip Level3;
    public AudioClip Level4;
    public AudioClip Level5;
    public AudioClip Win;
    public AudioClip Loose;


    [Header("---------- Sound Effects ----------")]
    public AudioClip Jump;
    public AudioClip Shoot;
    public AudioClip Steps;
    public AudioClip Menu;
    public AudioClip Matching;
    public AudioClip NoAmmo;


    private void Start()
    {
        MusicSource.clip = UI;
        MusicSource.Play();

    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
