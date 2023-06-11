using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScroller : MonoBehaviour
{
    public SpriteRenderer[] sky;
    public Sprite[] skyImg;

    public float speed = 0.5f;

    void Start()
    {
        temp = sky[0];
    }

    SpriteRenderer temp;

    void Update()
    {
        if (GameManager.instance.isPlay)
        {
            GameManager.instance.timer += Time.deltaTime;
            if (GameManager.instance.timer > GameManager.instance.watingTime)
            {
                speed = speed + 0.01f;
            }
        }
        for (int i = 0; i < sky.Length; i++)
        {
            if (-20f >= sky[i].transform.position.x)
            {
                for (int j = 0; j < sky.Length; j++)
                {
                    if (temp.transform.position.x < sky[j].transform.position.x)
                        temp = sky[j];
                }
                sky[i].transform.position = new Vector3(temp.transform.position.x + 20f, 0, 2f);
                sky[i].sprite = skyImg[Random.Range(0, skyImg.Length)];
            }
        }
        for (int i = 0; i < sky.Length; i++)
        {
            sky[i].transform.Translate(new Vector2(-1f, 0) * Time.deltaTime * speed);
        }
    }
}
