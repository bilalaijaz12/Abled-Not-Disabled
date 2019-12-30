using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsDragAndDrop : MonoBehaviour
{
    // Start is called before the first frame update
    bool moveAllowed;
    Collider2D col;
    public GameObject selectionEffect;
    public GameObject deathEffect;
    private PlanetsGameMaster gm;
    

    void Start()
    {
       
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<PlanetsGameMaster>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if(col == touchedCollider)
                {
                    moveAllowed = true;
                    Instantiate(selectionEffect, transform.position, Quaternion.identity);
                    gm.PlaySound("PopSoundEffect");
                }
            }
            if(touch.phase == TouchPhase.Moved)
            {
                if(moveAllowed == true)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                    
                }
            }
            if(touch.phase == TouchPhase.Ended) {
                moveAllowed = false;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Planets")
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            gm.PlaySound("DeathSoundEffect");
            gm.GameOver();
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
