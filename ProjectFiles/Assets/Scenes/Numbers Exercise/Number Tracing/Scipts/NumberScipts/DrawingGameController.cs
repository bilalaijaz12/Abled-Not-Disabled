using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingGameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spriteHolder;
    public SpriteRenderer spriteRenderer;
    [SerializeField] public List<Sprite> sprites;
    [SerializeField] int startingIndex;



    void Start()
    {
        spriteRenderer = spriteHolder.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[startingIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetSprite(string name)
    {

    }





}
