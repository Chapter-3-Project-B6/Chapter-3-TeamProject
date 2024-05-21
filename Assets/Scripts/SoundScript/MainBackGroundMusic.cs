using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBackGroundMusic : MonoBehaviour
{
    public AudioClip MainBGM;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayBGM(MainBGM);
    }
}
