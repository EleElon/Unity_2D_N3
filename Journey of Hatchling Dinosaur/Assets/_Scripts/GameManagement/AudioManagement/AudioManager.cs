using UnityEngine;

class AudioManager : MonoBehaviour {

    internal static AudioManager Instance { get; private set; }

    [Header("---------- Audio Sources ----------")]
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioSource sfxAudioSource;

    [Header("---------- Audio Clips ----------")]

    [SerializeField] AudioClip music;
    [SerializeField] AudioClip eggCrackSound;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip tapSound;
    [SerializeField] AudioClip hurtSound;

    void Start() {
        Instance = this;

        PlayMusic();
    }

    void PlayMusic() {
        musicAudioSource.clip = music;
        musicAudioSource.Play();
    }

    internal void PlaySFX(AudioClip sfx) {
        sfxAudioSource.clip = sfx;
        sfxAudioSource.PlayOneShot(sfx);
    }

    internal AudioClip GetEggCrackSound() {
        return eggCrackSound;
    }

    internal AudioClip GetJumpSound() {
        return jumpSound;
    }

    internal AudioClip GetTapSound() {
        return tapSound;
    }

    internal AudioClip GetHurtSound() {
        return hurtSound;
    }
}
