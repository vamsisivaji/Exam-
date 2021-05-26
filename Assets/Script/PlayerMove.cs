using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sp;
    public Text TimeTXT;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-1, 0)* dogspeed());
            sp.flipX = true;
        }
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(1, 0)* dogspeed());
            sp.flipX = false;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, 1)*50);
        }
        time = time + Time.deltaTime;
        TimeTXT.text = time.ToString();
    }
    float dogspeed()
    {
        return 100 * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            SceneManager.LoadScene(2);
        }
    }
}
