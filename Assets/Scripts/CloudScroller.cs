using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScroller : MonoBehaviour
{
    public SpriteRenderer[] cloud;
    public Sprite[] cloudImg;

    public float speed = 0.1f;

    void Start()
    {
        temp = cloud[0];
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
        for (int i = 0; i < cloud.Length; i++)
        {
            if (-12 >= cloud[i].transform.position.x)
            {
                for (int j = 0; j < cloud.Length; j++)
                {
                    if (temp.transform.position.x < cloud[j].transform.position.x)
                        temp = cloud[j];
                }
                cloud[i].transform.position = new Vector3(temp.transform.position.x + 25f, 3f, 1f);
                cloud[i].sprite = cloudImg[Random.Range(0, cloudImg.Length)];
            }
        }
        for (int i = 0; i < cloud.Length; i++)
        {
            cloud[i].transform.Translate(new Vector2(-1f, 0) * Time.deltaTime * speed);
        }
    }
}
