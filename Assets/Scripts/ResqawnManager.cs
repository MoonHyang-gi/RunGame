using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResqawnManager : MonoBehaviour
{
    public List<GameObject> enemyPool = new List<GameObject>();
    public GameObject enemies;
    public GameObject player;
    public int objCount = 5;

    private void Awake()
    {
        /*for(int i=0; i<enemies.Length; i++)
        {
            for(int j=0; j<objCount; j++)
            {
                enemyPool.Add(CreateObj(enemies[i], transform));
            }
        }*/
        CreateEnemyPool();
    }

    

    private void CreateEnemyPool()
    {
        for (int i = 0; i < objCount; i++)
        {
            GameObject enemy = Instantiate(enemies);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    void Start()
    {
        GameManager.instance.onPlay += PlayGame;
    }

    void PlayGame(bool isPlay)
    {
        if (isPlay)
        {
            for (int i = 0; i < enemyPool.Count; i++)
            {
                if (enemyPool[i].activeSelf)
                {
                    enemyPool[i].SetActive(false);
                }
            }
            StartCoroutine(CreateEnemy());
            /*GameManager.instance.timer += Time.deltaTime;
            if (GameManager.instance.timer > GameManager.instance.watingTime)
            {
                enemyPool[Random.Range(0, enemyPool.Count)].SetActive(true);
                GameManager.instance.timer = 0;
            }*/
        }
    }

    IEnumerator CreateEnemy()
    {
        while (GameManager.instance.isPlay)
        {
            yield return new WaitForSeconds(0.5f);

            GameObject enemy = GetInactiveEnemy();
            if (enemy != null)
            {
                enemy.SetActive(true);
            }
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    
    /*
        int DeactiveEnemy()
        {
            List<int> num = new List<int>();
            for (int i = 0; i < enemyPool.Count; i++)
            {
                if (!enemyPool[i].activeSelf)
                    num.Add(i);
            }
            int x = 0;
            if (num.Count > 0)
                x = num[Random.Range(0, num.Count)];
            return x;
        }

        GameObject CreateObj(GameObject obj, Transform parent)
        {
            GameObject copy = obj;
            copy.transform.SetParent(parent);
            copy.SetActive(false);
            return copy;
        }

        void Update()
        {

        }
    */
    private GameObject GetInactiveEnemy()
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].activeSelf)
            {
                return enemyPool[i];
            }
        }
        return null;
    }
}
