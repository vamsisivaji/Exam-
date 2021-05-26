using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    GameObject enemy;
    public ObjectPooler EnemyPool;
    public int enemyCount = 0;
    float time=2;
    public int score = 0;
    public static EnemySpawn Inst;
    public Text Score;
    private void Awake()
    {
        Inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        EnemyPool= ObjectPooler.Instance;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(Random.Range(-2, 14), transform.position.y, 0);
        if(enemyCount<=3)
        {
            if(time>=2)
            {
                enemy = EnemyPool.SpawnFromPool("Enemy", transform.position, Quaternion.identity);
                enemyCount++;
                time = 0;
            }
            time = time+Time.deltaTime;
        }
        Score.text = score.ToString();

    }
}
