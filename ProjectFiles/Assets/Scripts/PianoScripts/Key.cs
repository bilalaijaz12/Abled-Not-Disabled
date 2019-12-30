using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key{
    // Start is called before the first frame update
    public bool isActive;
    public GameObject gameobject;
    public PianoSoundEngine soundEngine;



    public Key(GameObject gameobject,PianoSoundEngine soundEngine, bool isActive )
    {
        this.gameobject = gameobject;
        this.isActive = isActive;
        this.soundEngine = soundEngine;
    }

    internal void Pressed()
    {
        



        isActive = true;    
        gameobject.GetComponent<SpriteRenderer>().enabled = true;
        string soundName = gameobject.name;
        string soundCode = soundName.Substring(0, 3);
        soundEngine.PlayNote(soundCode);
        
    }

    internal void Lifted()
    {
        isActive = false;
        string soundName = gameobject.name;
        string soundCode = soundName.Substring(0, 3);
        soundEngine.FadeOutNote(soundCode);
        gameobject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
