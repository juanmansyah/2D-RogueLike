using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{

    int EnemyHP = 0;
    int PlayerHP = 0;

    private static bool created = false;

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {       
            Destroy(this.gameObject);
        }

    }

    public int returnHP(int i)
    {
        if(i == 1)
        {
            return EnemyHP;
        }else if(i == 2)
        {
            return PlayerHP;
        }
        return 0;
    }

    public void IncreaseHP()
    {
        EnemyHP++;
        PlayerHP++;
    }

}
