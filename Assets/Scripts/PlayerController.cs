using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isJump = false;
    bool isTop = false;
    public float jumpHeight = 0;
    public float jumpSpeed = 0;


    /*private static bool m_IsDeath;
    public static bool IsDeath
    {
        get { return m_IsDeath; }
    }
    // �÷��̾ ������ �Ѹ� ����� �����̴�
    private static Vector3 m_PlayerPos;
    public static Vector3 PlayerPos
    {
        get { return m_PlayerPos; } 
    }
*/
    Vector2 startPosition;

   
    /*void CheckCollision()
    {
        minX = enemy.transform.position.x - (enemy.transform.localScale.x / 2);
        maxX = enemy.transform.position.x + (enemy.transform.localScale.x / 2);

        minY = enemy.transform.position.y - (enemy.transform.localScale.y / 2);
        maxY = enemy.transform.position.y + (enemy.transform.localScale.y / 2);

        if (transform.position.x + (transform.localScale.x / 2) >= minX &&
            transform.position.x - (transform.localScale.x / 2) <= maxX)
            Debug.Log("XCrush");

        if (transform.position.y + (transform.localScale.y / 2) >= minY &&
            transform.position.y - (transform.localScale.y / 2) <= maxY)
            Debug.Log("YCrush");

        if (transform.position.x + (transform.localScale.x / 2) >= minX &&
            transform.position.x - (transform.localScale.x / 2) <= maxX &&
            transform.position.y + (transform.localScale.y / 2) >= maxY &&
            transform.position.y - (transform.localScale.y / 2) <= minY)
            Debug.Log("Crush");
    }*/

    void Start()
    {
        startPosition = transform.position;
        jumpHeight = 2f;
        jumpSpeed = 5f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.instance.isPlay)
        {
            isJump = true;
        }else if (transform.position.y <= startPosition.y)
        { //��ġ �ʱ�ȭ
            isJump = false;
            isTop = false;
            transform.position = startPosition;
        }

        if (isJump)
        {
            if (transform.position.y <= jumpHeight - 0.05f && !isTop)
            {
                transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, jumpHeight), jumpSpeed * Time.deltaTime);
            }
            else
            {
                isTop = true;
            }

            if(transform.position.y > startPosition.y && isTop)
            {
                transform.position = Vector2.MoveTowards(transform.position, startPosition, jumpSpeed * Time.deltaTime);
            }
        }
    }

    
}
