using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    public Transform player; // Player ������Ʈ�� Transform ������Ʈ

    private void Update()
    {
        // Player�� Enemy Ŭ�е��� AABB�� ���
        Bounds playerBounds = CalculateAABB(player);
        Bounds[] enemyBoundsArray = CalculateEnemyAABBs();

        // Enemy Ŭ�е���� AABB �浹�� Ȯ��
        for (int i = 0; i < enemyBoundsArray.Length; i++)
        {
            if (AABBIntersect(playerBounds, enemyBoundsArray[i]))
            {
                // �浹 �߻�
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
            return new Bounds(); //�� Bounds ��ȯ
        }
    }

    private Bounds[] CalculateEnemyAABBs()
    {
        Enemy[] enemyClones = GameObject.FindObjectsOfType<Enemy>(); // Enemy ��ũ��Ʈ�� ���� ��� ������Ʈ�� ã��
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
                enemyBoundsArray[i] = new Bounds(); // �� Bounds ���
            }
        }

        return enemyBoundsArray;
    }

    private bool AABBIntersect(Bounds boundsA, Bounds boundsB)
    {
        if (boundsA.min.x > boundsB.max.x || boundsA.max.x < boundsB.min.x)
            return false; // x ������ ��ġ�� ����

        if (boundsA.min.y > boundsB.max.y || boundsA.max.y < boundsB.min.y)
            return false; // y ������ ��ġ�� ����

        return true; // ��ħ
    }
}
