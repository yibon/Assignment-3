using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob
{
    private string currentEnemy;

    private string mobName;
    private float mobHP;
    private float mobAtt;
    private float mobSpeed;

    private bool isDirty;

    public Mob(string _currentEnemy)
    {
        this.currentEnemy = _currentEnemy;
        isDirty = true;
    }

    public string GetCurrentEnemy()
    {
        return currentEnemy;
    }

    public void SetCurrentEnemy(string _enemy)
    {
        currentEnemy = _enemy;
        isDirty = true;
    }

    public bool UpdateMobStats()
    {
        if (!isDirty)
            return false;

        Enemy mobEnemy = Game.GetEnemyByRefId(currentEnemy);

        mobName = mobEnemy.enemyName;
        mobHP = mobEnemy.enemyHeath;
        mobAtt = mobEnemy.enemyAttack;
        mobSpeed = mobEnemy.enemySpeed;

        isDirty = false;
        return true;
    }

    public string GetMobName()
    {
        UpdateMobStats();
        return mobName;
    }

    public float GetMobHP()
    {
        UpdateMobStats();
        return mobHP;
    }

    public float GetMobAtt()
    {
        UpdateMobStats();
        return mobAtt;
    }

    public float GetMobSpeed()
    {
        UpdateMobStats();
        return mobSpeed;
    }


}
