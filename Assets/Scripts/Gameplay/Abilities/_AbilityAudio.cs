using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class _AbilityAudio : MonoBehaviour
{
    private const float Delay = 0.35f;

    [Space, SerializeField] private AudioClip onExecute;
    [SerializeField] private AudioClip onInterval;
    [SerializeField] private AudioClip onUnExecute;
    [SerializeField] private AudioClip onHit;

    private AudioSource _audioSource;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnExecute() => Play(onExecute);

    public void OnInterval() => Play(onInterval);

    public void OnUnExecute() => Play(onUnExecute);

    public void OnHit() => Play(onHit);


    private float _lastPlay;

    private void Play(AudioClip clip)
    {
        if (clip == null || _lastPlay + Delay > Time.time) return;

        _lastPlay = Time.time;

        _audioSource.clip = clip;
        _audioSource.Play();
    }
}