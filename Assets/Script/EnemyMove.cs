using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rg;
    public GameObject Player;
    float x;
    SpriteRenderer sp;
    bool isgrounded=false;
    public EnemySpawn es;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
        es = EnemySpawn.Inst;
    }
    // Update is called once per frame
    void Update()
    {
        if(isgrounded)
        {
            if (Player.transform.position.x > transform.position.x)
            {
                rg.AddForce(new Vector2(1, 0) * 60 * Time.deltaTime);
                sp.flipX = false;
            }
            else
            {
                rg.AddForce(new Vector2(-1, 0) * 60 * Time.deltaTime);
                sp.flipX = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            isgrounded = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            gameObject.SetActive(false);
            es.enemyCount--;
            es.score++;
        }
    }
}
