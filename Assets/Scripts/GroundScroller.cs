using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public SpriteRenderer[] ground;
    public Sprite[] groundImg;
    
    void Start()
    {
        temp = ground[0];
    }

    SpriteRenderer temp;

    void Update()
    {
        for (int i = 0; i < ground.Length; i++)
        {
            if (-12 >= ground[i].transform.position.x)
            {
                for(int j = 0; j<ground.Length; j++)
                {
                    if(temp.transform.position.x < ground[j].transform.position.x)
                        temp = ground[j];
                }
                ground[i].transform.position = new Vector2(temp.transform.position.x + 5.5f, -3.7f);
                ground[i].sprite = groundImg[Random.Range(0,groundImg.Length)];
            }
        }
        for (int i = 0; i < ground.Length; i++)
        {
            ground[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime*GameManager.instance.gameSpeed);
        }
    }
}
