using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2 StartPosition;
    public float minY = -2f;
    public float maxY = 5f;
    public float moveSpeed = 2f;

    private bool movingUp = true;
    private bool isMoving;

    private void OnEnable()
    {
        transform.position = StartPosition;
        SetRandomState();
    }

    void Start()
    {
        StartPosition = new Vector2(12f, -2f);
    }

    void Update()
    {
        if (GameManager.instance.isPlay)
        {
            transform.Translate(Vector2.left * Time.deltaTime * GameManager.instance.gameSpeed);

            if (transform.position.x < -12f)
            {
                gameObject.SetActive(false);
            }

            if (isMoving)
            {
                // �����̴� y��ǥ ����
                float newY = transform.position.y;

                if (movingUp)
                {
                    newY += moveSpeed * Time.deltaTime;
                    if (newY >= maxY)
                    {
                        movingUp = false;
                        newY = maxY;
                    }
                }
                else
                {
                    newY -= moveSpeed * Time.deltaTime;
                    if (newY <= minY)
                    {
                        movingUp = true;
                        newY = minY;
                    }
                }

                transform.position = new Vector2(transform.position.x, newY);
            }
        }
    }

    private void SetRandomState()
    {
        isMoving = Random.value < 0.5f; // 50%�� Ȯ���� �����̴� ���·� ����

        if (isMoving)
        {
            // �����̴� ������ ��� ������ �ʱ� y��ǥ ����
            float randomY = Random.Range(minY, maxY);
            transform.position = new Vector2(transform.position.x, randomY);
        }
    }
}
