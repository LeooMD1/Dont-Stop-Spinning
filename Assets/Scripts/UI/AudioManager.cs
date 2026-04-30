using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSouce;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip Sponge;
    public AudioClip plateInWater;
    public AudioClip money;
    public AudioClip lever;
    public AudioClip bubbles;
    public AudioClip fiveInA_Row;
    public AudioClip ClickDown;
    public AudioClip ClickUp;
    //public AudioClip Sponge;
    //public AudioClip Sponge;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
