using UnityEngine;

public class EnemyManagerWave : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;
    private Wave wave;

    public int spawnPointLength;
    public int normalEnemyLength;

    private int enemyNormalCount = 0;
    private int enemyEliteCount = 0;
    private int enemyBossCount = 0;

    [SerializeField]
    MonoBehaviour factory;
    IFactoryWave Factory { get { return factory as IFactoryWave; } }

    void Start()
    {
        //Mengeksekusi fungs Spawn setiap beberapa detik sesuai dengan nilai spawnTime
        this.wave = new Wave();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        //Jika player telah mati maka tidak membuat enemy baru
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        // next wave kalau death mencukupi, memastikan enemy ga spawn terus menerus, wave selesai kalau enemy mati semua
        if (GameOverManager.enemyDeath == wave.GetTotalWaveDeath())
        {
            this.enemyNormalCount = 0;
            this.enemyEliteCount = 0;
            this.enemyBossCount = 0;
            wave.NextWave();
            WaveManager.nWave = wave.GetName();
        }

        // memastikan jumlah musuh yang spawn sesuai dengan batasan wave
        if (this.GetTotalEnemiesCount() < this.wave.GetTotalEnemiesCount())
        {
            // 0=normal, 1=elite, 2=boss
            int spawnIndex = Random.Range(0, 3);
            // Randomize spawn location
            int spawnLocation = Random.Range(0, this.spawnPointLength);
            // prioritasin random
            if (spawnIndex == 0 && this.enemyNormalCount < this.wave.GetNormal())
            {
                this.SpawnNormal(spawnLocation);
            }
            else if (spawnIndex == 1 && this.enemyEliteCount < this.wave.GetElite())
            {
                this.SpawnElite(spawnLocation);
            }
            else if (spawnIndex == 2 && this.enemyBossCount < this.wave.GetBoss())
            {
                this.SpawnBoss(spawnLocation);
            }
            else
            {
                // kalo random gagal, spawn normal -> spawn elite -> spawn boss
                if (this.enemyNormalCount < this.wave.GetNormal())
                {
                    this.SpawnNormal(spawnLocation);
                }
                else if (this.enemyEliteCount < this.wave.GetElite())
                {
                    this.SpawnElite(spawnLocation);
                }
                else
                {
                    this.SpawnBoss(spawnLocation);
                }
            }
        }
    }

    // Dapetin total musuh yang ada di map skrg
    private int GetTotalEnemiesCount()
    {
        return this.enemyNormalCount + this.enemyEliteCount + this.enemyBossCount;
    }

    // Manggil fungsi factory untuk spawn enemy
    // 0=normal, 1=elite, 2=boss
    private void SpawnEnemy(int enemyIndex, int spawnPointIndex, int mode)
    {
        Factory.FactoryMethod(enemyIndex, spawnPointIndex, mode);
    }

    // Method untuk spawn normal
    private void SpawnNormal(int spawnIndex)
    {
        int enemyIndex = Random.Range(0, this.wave.GetEnemyVariation());
        this.SpawnEnemy(enemyIndex, spawnIndex, 0);
        this.enemyNormalCount++;
    }

    // Method untuk spawn elite
    private void SpawnElite(int spawnIndex)
    {
        this.SpawnEnemy(0, spawnIndex, 1);
        this.enemyEliteCount++;
    }

    // Method untuk spawn boss
    private void SpawnBoss(int spawnIndex)
    {
        this.SpawnEnemy(0, spawnIndex, 2);
        this.enemyBossCount++;
    }
}