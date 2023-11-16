using UnityEngine;

public class MainSound : MonoBehaviour
{
    [SerializeField] private AudioClip _bgSound;

    [Range(0f, 1f)]
    [SerializeField] private float _volume = 0.5f; 

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;
        _audioSource.volume = _volume;

        _audioSource.PlayOneShot(_bgSound);

        DontDestroyOnLoad(gameObject);
    }
}
