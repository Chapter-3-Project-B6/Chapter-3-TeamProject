using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMusicController : MonoBehaviour
{
    public AudioClip introMenuBGM;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayBGM(introMenuBGM);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
