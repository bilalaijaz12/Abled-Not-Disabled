using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Touch touch;
    public KeyHolder kh;
    void Start()
    {
        kh = gameObject.GetComponent<KeyHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Key touchedKey = GetTouchedKey(touch);           
            if (touchedKey != null)
            {
                if (kh.GetActiveKey() != null)
                {
                    if (touchedKey != kh.GetActiveKey())
                    {
                        kh.GetActiveKey().Lifted();
                        touchedKey.Pressed();
                       
                    }
                }
                else
                {
                    touchedKey.Pressed();
                }
            }
            if(touch.phase == TouchPhase.Ended)
            {
                kh.GetActiveKey().Lifted();
            }
        }
    }

    public Key GetTouchedKey(Touch touch)
    {
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
        foreach(Key key in kh.keys)
       {
           PolygonCollider2D col = key.gameobject.GetComponent<PolygonCollider2D>();
           if (col == touchedCollider)
           {
            return key;
           }
        }
        return null;
    }

}
