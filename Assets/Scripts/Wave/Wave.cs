using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wave
{
    private int wave;
    private int waveDuration;
    private int normalEnemyCount;
    private int eliteEnemyCount;
    private int bossEnemyCount;
    private int waveCooldown;
    private int totalWaveDeath = 0;
    private int enemyVariation = 2;

    public Wave()
    {
        this.wave = 1;
        this.waveDuration = 30;
        this.waveCooldown = 5;
        this.normalEnemyCount = 5;
        this.eliteEnemyCount = 3;
        this.bossEnemyCount = 0;
        this.totalWaveDeath = this.GetTotalEnemiesCount();
    }

    public int GetName()
    {
        return this.wave;
    }

    public int GetDuration()
    {
        return this.waveDuration;
    }

    public int GetNormal()
    {
        return this.normalEnemyCount;
    }

    public int GetElite()
    {
        return this.eliteEnemyCount;
    }

    public int GetBoss()
    {
        return this.bossEnemyCount;
    }

    public int GetTotalEnemiesCount()
    {
        return this.normalEnemyCount + this.eliteEnemyCount + this.bossEnemyCount;
    }

    public int GetTotalWaveDeath()
    {
        return this.totalWaveDeath;
    }
    public int GetEnemyVariation()
    {
        return this.enemyVariation;
    }
    public void NextWave()
    {
        this.wave += 1;
        if (this.waveDuration < 90)
        {
            this.waveDuration += 10;
        }
        this.normalEnemyCount += 1;
        this.eliteEnemyCount += 0;
        if (this.wave % 3 == 0)
        {
            double temp = this.wave / 5;
            int additionalBoss = (int)Math.Floor(temp);
            this.bossEnemyCount = 1 + additionalBoss;
        }
        else
        {
            this.bossEnemyCount = 0;
        }
        if (this.wave > 3)
        {
            this.enemyVariation = 3;
        }
        if (this.wave > 5)
        {
            this.enemyVariation = 4;
        }
        this.totalWaveDeath += this.GetTotalEnemiesCount();
    }
}
