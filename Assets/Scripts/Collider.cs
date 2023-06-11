using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    public Transform player; // Player 오브젝트의 Transform 컴포넌트

    private void Update()
    {
        // Player와 Enemy 클론들의 AABB를 계산
        Bounds playerBounds = CalculateAABB(player);
        Bounds[] enemyBoundsArray = CalculateEnemyAABBs();

        // Enemy 클론들과의 AABB 충돌을 확인
        for (int i = 0; i < enemyBoundsArray.Length; i++)
        {
            if (AABBIntersect(playerBounds, enemyBoundsArray[i]))
            {
                // 충돌 발생
                GameManager.instance.GameOver();
                break;
            }
        }
    }

    private Bounds CalculateAABB(Transform objTransform)
    {
        Renderer objRenderer = objTransform.GetComponent<Renderer>();
        if (objRenderer != null)
        {
            Bounds objBounds = objRenderer.bounds;
            return objBounds;
        }
        else
        {
            return new Bounds(); //빈 Bounds 반환
        }
    }

    private Bounds[] CalculateEnemyAABBs()
    {
        Enemy[] enemyClones = GameObject.FindObjectsOfType<Enemy>(); // Enemy 스크립트를 가진 모든 오브젝트를 찾음
        Bounds[] enemyBoundsArray = new Bounds[enemyClones.Length];

        for (int i = 0; i < enemyClones.Length; i++)
        {
            Renderer enemyRenderer = enemyClones[i].GetComponent<Renderer>();

            if (enemyRenderer != null)
            {
                Bounds enemyBounds = enemyRenderer.bounds;
                enemyBoundsArray[i] = enemyBounds;
            }
            else
            {
                enemyBoundsArray[i] = new Bounds(); // 빈 Bounds 사용
            }
        }

        return enemyBoundsArray;
    }

    private bool AABBIntersect(Bounds boundsA, Bounds boundsB)
    {
        if (boundsA.min.x > boundsB.max.x || boundsA.max.x < boundsB.min.x)
            return false; // x 축으로 겹치지 않음

        if (boundsA.min.y > boundsB.max.y || boundsA.max.y < boundsB.min.y)
            return false; // y 축으로 겹치지 않음

        return true; // 겹침
    }
}
