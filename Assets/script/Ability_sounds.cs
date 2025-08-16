using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_sounds : MonoBehaviour
{
    [SerializeField]
    AudioSource audoo_source;
    [SerializeField]
    public AudioClip Blink_SE;
    [SerializeField]
    public AudioClip Tackle_SE;
    public AudioClip Jump_SE;
    public AudioClip Double_Jump_SE;
    // Start is called before the first frame update
    void Start()
    {
        audoo_source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play_SE(AudioClip audioClip)
    {
        audoo_source.PlayOneShot(audioClip);
    }
}
