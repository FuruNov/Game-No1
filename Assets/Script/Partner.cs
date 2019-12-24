using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partner : MonoBehaviour
{
    // Start is called before the first frame update

    //変数の定義と初期化
    public float scroll = 10f;
    public float size_scale = 1;
    public float mass_scale = 1;
    public float speed_limit = 30;
    Rigidbody2D rb2d;
    public GameObject collide_Enter_effect;

    void Start()
    {
        //Rigidbody2Dをキャッシュする
        rb2d = GetComponent<Rigidbody2D>();

        //サイズ,質量の倍率を変える
        transform.localScale *= size_scale;
        rb2d.mass *= mass_scale;

        //初速度を定義
        rb2d.velocity = new Vector2(-3*scroll, -2.5f*scroll);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
//      StartCoroutine(collide_effect());
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        impose_speed_limit();
    }

    public IEnumerator collide_effect()
    {
//      Instantiate(collide_Enter_effect, transform.position, Quaternion.identity);
        yield return null;
    }

    public void impose_speed_limit()
    {
        if (rb2d.velocity.x >= speed_limit)
        {
            rb2d.velocity = new Vector2(speed_limit, rb2d.velocity.y);
            Debug.Log("速度を制限しました。");
        }

        if (rb2d.velocity.x <= -speed_limit)
        {
            rb2d.velocity = new Vector2(-speed_limit, rb2d.velocity.y);
            Debug.Log("速度を制限しました。");
        }

        if (rb2d.velocity.y >= speed_limit)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, speed_limit);
            Debug.Log("速度を制限しました。");
        }

        if (rb2d.velocity.y <= -50)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -speed_limit);
            Debug.Log("速度を制限しました。");
        }
    }

}