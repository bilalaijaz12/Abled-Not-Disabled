using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyHolder : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> KeySprites;
    public List<Key> keys = new List<Key>();
    
    


    void Start()
    {
        InitializeKeysStructs();
        HideAllKeyPresses();    
    }

   

    private void InitializeKeysStructs()
    {
        foreach (GameObject keyGameObject in KeySprites)
        {
            keys.Add(new Key(keyGameObject,gameObject.GetComponent<PianoSoundEngine>(), false));

        }
    }

    public Key GetActiveKey()
    {
        foreach (Key key in keys)
        {
            if(key.isActive == true)
            {
                return key;
            }  

        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HideAllKeyPresses()
    {
        foreach(GameObject key in KeySprites)
        {
            key.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    public GameObject GetKeyGameObject(string name)
    {
        foreach (GameObject key in KeySprites)
        {
           if(key.name == name)
            {
                return key;
            }
        }
        return null;
    }

}
