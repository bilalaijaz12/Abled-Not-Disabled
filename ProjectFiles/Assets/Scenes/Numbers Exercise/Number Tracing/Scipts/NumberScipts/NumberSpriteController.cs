using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSpriteController : MonoBehaviour
{

    [SerializeField] public List<GameObject> Masks;
    [SerializeField] private int maxState;
    public bool isActive = false;
    private int state = 0; //




    // Start is called before the first frame update
    void Start()
    {
        InitializeAllMasks(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TouchController();
    }

    void TouchController()//called every frame
    {
        if(isActive == true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                BoxCollider2D currentMaskCollider = Masks[state].GetComponentInChildren<BoxCollider2D>();
                if (currentMaskCollider == touchedCollider)
                {
                    SetMaskActive();
                    IncrementState();
                }
            }
        }
    }

    void SetMaskActive()
    {
        Debug.Log("hello");
        Masks[state].GetComponent<SpriteMask>().enabled = true;
    }

    void IncrementState()
    {
        if(state +1 <= maxState)
        {
            state++;
        }
    }


    void InitializeAllMasks()
    {
        foreach(GameObject mask in Masks)
        {
            Debug.Log("hello");
            mask.GetComponent<SpriteMask>().enabled = false;
        }
    }

}
