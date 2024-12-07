using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource audioSource;

    public SoundClips soundClips;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayCollectItemSound() => audioSource.PlayOneShot(soundClips.collectItemSound, 0.3f);
    public void PlayJumpSound() => audioSource.PlayOneShot(soundClips.jumpSound, 1f);
    public void PlayHitSound() => audioSource.PlayOneShot(soundClips.hitSound, 1f);
    public void PlayHealSound() => audioSource.PlayOneShot(soundClips.healSound, 0.3f);
}
