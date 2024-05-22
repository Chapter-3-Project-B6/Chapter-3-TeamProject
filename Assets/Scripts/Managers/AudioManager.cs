using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Background Music")]
    public AudioSource bgmSource;

    [Header("Sound Effects")]
    public AudioSource sfxSource;
    public List<AudioClip> sfxClips;

    private Dictionary<string, AudioClip> sfxDictionary;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        if(sfxClips != null)
        {
            sfxDictionary = new Dictionary<string, AudioClip>();
            foreach (var clip in sfxClips)
            {
                sfxDictionary[clip.name] = clip;
            }
        }

        else
        {
            Debug.Log("list is null");
        }
    }

    public void PlayBGM(AudioClip clip)
    {
        if (bgmSource.clip == clip)
        {
            return;
        }
        
        bgmSource.clip = clip;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void PlaySFX(string name)
    {
        if (sfxDictionary.ContainsKey(name))
        {
            sfxSource.PlayOneShot(sfxDictionary[name]);
        }

        else
        {
            Debug.Log("sfx null");
        }
    }
}
