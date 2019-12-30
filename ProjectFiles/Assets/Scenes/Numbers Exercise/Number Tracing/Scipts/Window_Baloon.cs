using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window_Baloon : MonoBehaviour
{

    [SerializeField] Transform pfBaloon;
    List<Baloon> baloonList;
    float spawnTimer;
    const float SPAWN_FLOAT_TIMER_MAX = 0.33F;
    [SerializeField] Color[] colorArray;

    private void Awake()
    {
        baloonList = new List<Baloon>();
        SpawnBaloon();
    }
    private void Update()
    {
        foreach (Baloon baloon in baloonList)
        {
            baloon.update();
        }

        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0f)
        {
            spawnTimer += SPAWN_FLOAT_TIMER_MAX;
            int spawnAmount = Random.Range(2, 7);
            for (int i = 0; i < spawnAmount; i++)
            {
                SpawnBaloon();
            }
        }

    }
    
    private void SpawnBaloon()
    {
        float width = transform.GetComponent<RectTransform>().rect.width;
        float height = transform.GetComponent<RectTransform>().rect.height;
        Vector2 anchoredPosition = new Vector2(Random.Range(-width/2f , width/2f), -height/2f - 100);
        Color color = colorArray[Random.Range(0, colorArray.Length)];
        Baloon baloon = new Baloon(pfBaloon, transform, anchoredPosition, color);
        baloonList.Add(baloon);
    }

    private class Baloon {
        Transform transform;
        RectTransform rectransform;
        Vector2 anchoredPosition;
        Vector2 moveAmount;

        public Baloon(Transform prefab, Transform container, Vector2 anchoredPosition, Color color)
        {
            this.anchoredPosition = anchoredPosition;
            
            transform = Instantiate(prefab,container);
            rectransform = transform.GetComponent<RectTransform>();
            rectransform.anchoredPosition = anchoredPosition;

            rectransform.sizeDelta *= Random.Range(0.8f, 1.2f);
            moveAmount = new Vector2(0, Random.Range(50f, 150f));
            transform.GetComponent<Image>().color = color;
        }

        public void update()
        {
            anchoredPosition += moveAmount * Time.deltaTime;
            rectransform.anchoredPosition = anchoredPosition;
        }




    }



}
