using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float _musicVolume;
    [SerializeField] float _soundClipVolume;

    [Header("References")]
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SetMusic(AudioClip clip)
    {
        _audioSource.volume = _musicVolume;
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void PlayClip(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip, _soundClipVolume);
    }
}
