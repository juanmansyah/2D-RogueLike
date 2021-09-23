using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class GameLogicScript : MonoBehaviour
{
    public event EventHandler LevelComplete;
    
    public GameObject EnemyPrefab;
    public GameObject KeyPrefab;
    public GameObject ExitPrefab;
    public Transform Locator;
    public int EnemiesPerRoom = 2;
    public RoomFirstDungeonGenerator DungeonGen;
    public TextMeshProUGUI KeyText;
    public GameObject Player;
    bool hasKey = false;
    public Storage storage;
    int EnemyHP;
    int PlayerHP;

    void Start()
    {
        DungeonGen.GenerateDungeon();
        EnemyHP = storage.returnHP(1);
        PlayerHP = storage.returnHP(2);
        Debug.Log(PlayerHP + EnemyHP);
        int j = 0;
        while (j < PlayerHP)
        {
            Player.GetComponent<PlayerHealth>().setHp();
            j++;
        }
    }


    public void SpawnEnemies(float x, float y)
    {
        int i = 0;
        while (i < EnemiesPerRoom)
        {
            GameObject enemy = Instantiate(EnemyPrefab, Locator.position, Locator.rotation);
            Vector2 circleRand = (Random.insideUnitCircle * 2.5f);
            enemy.transform.position = new Vector3(x + circleRand.x, y + circleRand.y, 0);

            if (EnemyHP > 0)
            {
                int t = 0;
                while (t < EnemyHP)
                {
                    enemy.gameObject.GetComponent<Enemy>().setHp();
                    t++;
                }
            }
            
            Debug.Log(enemy.GetComponent<Enemy>().maxHealth);
            i++;
        }
    }

    public void SpawnKey(float x, float y)
    {
        GameObject key = Instantiate(KeyPrefab, Locator.position, Locator.rotation);
        key.transform.position = new Vector3(x, y, 0);
    }

    public void SpawnExit(float x, float y)
    {
        GameObject Exit = Instantiate(ExitPrefab, Locator.position, Locator.rotation);
        Exit.transform.position = new Vector3(x, y, 0);
    }

    public void GetKey()
    {
        hasKey = true;
        KeyText.text = "Find the key : Complete";
    }

    public void ReachExit()
    {
        if(hasKey)
        {
            storage.IncreaseHP();
            SceneManager.LoadScene(1);

        }
    }
}
