using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePuzzleDragAndDrop : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform placeAnimal;
    [SerializeField]
    private Vector2 initialPosition;
    private float deltaX, deltaY;
    public bool locked;

    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touch.position))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);

                    }
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - placeAnimal.position.x) <= 1f &&
                       Mathf.Abs(transform.position.y - placeAnimal.position.y) <= 1f)
                    {
                        transform.position = new Vector2(placeAnimal.position.x, placeAnimal.position.y);           
                    }
                    else
                    {
                        transform.position = initialPosition;
                    }
                    break;

            }
                
        } 
    }
}
