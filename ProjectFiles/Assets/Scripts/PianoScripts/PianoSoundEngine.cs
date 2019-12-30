using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoSoundEngine : MonoBehaviour
{
    [SerializeField]
    public Text log;
    public AudioSource w1Sound;
    public AudioSource w2Sound;
    public AudioSource w3Sound;
    public AudioSource w4Sound;
    public AudioSource w5Sound;
    public AudioSource w6Sound;
    public AudioSource w7Sound;
    public AudioSource w8Sound;
    public AudioSource w9Sound;
    public AudioSource w10Sound;
    public AudioSource w11Sound;
    public AudioSource w12Sound;
    public AudioSource w13Sound;
    public AudioSource w14Sound;
    public AudioSource b1Sound;
    public AudioSource b2Sound;
    public AudioSource b3Sound;
    public AudioSource b4Sound;
    public AudioSource b5Sound;
    public AudioSource b6Sound;
    public AudioSource b7Sound;
    public AudioSource b8Sound;
    public AudioSource b9Sound;
    public AudioSource b10Sound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        
    }

    public void FadeOutNote(string name)
    {
        StartCoroutine(PianoSoundEngine.FadeOut(GetAudioSource(name), 1f));
    }




    public void PlayNote(string name)
    {
        GetAudioSource(name).volume = 1;
        GetAudioSource(name).Play();
        
    }

    private AudioSource GetAudioSource(string name)
    {
        switch (name)
        {
            case "01W": { return (w1Sound); };
            case "02W": { return (w2Sound); } 
            case "03W": { return (w3Sound); } 
            case "04W": { return (w4Sound); } 
            case "05W": { return (w5Sound); } 
            case "06W": { return (w6Sound); } 
            case "07W": { return (w7Sound); } 
            case "08W": { return (w8Sound); } 
            case "09W": { return (w9Sound); } 
            case "10W": { return (w10Sound); }
            case "11W": { return (w11Sound); }
            case "12W": { return (w12Sound); }
            case "13W": { return (w13Sound); }
            case "14W": { return (w14Sound); }
            case "01B": { return (b1Sound); } 
            case "02B": { return (b2Sound); } 
            case "03B": { return (b3Sound); } 
            case "04B": { return (b4Sound); } 
            case "05B": { return (b5Sound); } 
            case "06B": { return (b6Sound); } 
            case "07B": { return (b7Sound); } 
            case "08B": { return (b8Sound); } 
            case "09B": { return (b9Sound); } 
            case "10B": { return (b10Sound); }
        }
        return null;
    }


}
