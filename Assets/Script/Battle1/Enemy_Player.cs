using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Player : Player
{
    public float speed_limit = 50;

    public override void Update()
    {
        impose_speed_limit();
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
