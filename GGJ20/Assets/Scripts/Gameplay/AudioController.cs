using UnityEngine;

public class AudioController : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public AudioSource AudioSource;
    public AudioClip Music;
    public AudioClip HappyEndingMusic;
    public AudioClip SadEndingMusic;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void StartGame () {
        if(AudioSource.clip == Music) return;
        
        AudioSource.clip = Music;
        AudioSource.Play();
    }

    // ------------------------------------------------------------------------
    public void EndGame (bool happy) {
        AudioSource.clip = happy? HappyEndingMusic : SadEndingMusic;
        AudioSource.Play();
    }
}