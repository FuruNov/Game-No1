using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoEnemy : MonoBehaviour
{

    // 目的地に着いたかどうか
    private bool isReachTargetPosition;
    // 目的地
    private Vector3 targetPosition;

    // x軸 下限
    public const float X_MIN_MOVE_RANGE = 5.947f;
    // x軸 上限
    public const float X_MAX_MOVE_RANGE = 5.95f;
    // y軸 下限
    public const float Y_MIN_MOVE_RANGE = 30f;
    // y軸 上限
    public const float Y_MAX_MOVE_RANGE = 35f;
    // 移動スピード
    public const float SPEED = 1f;

    void Start()
    {
        this.isReachTargetPosition = false;
        decideTargetPotision();
    }

    void Update()
    {
        decideTargetPotision();

        // 現在地から目的地までSPEEDの速度で移動する
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, SPEED);
        // 目的地についたらisReachTargetPositionをtrueにする
        if (transform.position == targetPosition)
        {
            isReachTargetPosition = true;
        }
    }

    // 目的地を設定する
    private void decideTargetPotision()
    {
        // まだ目的地についてなかったら（移動中なら）目的地を変えない
        if (!isReachTargetPosition)
        {
            return;
        }

        // 目的地に着いていたら目的地を再設定する
        targetPosition = new Vector3(Random.Range(X_MIN_MOVE_RANGE, X_MAX_MOVE_RANGE), Random.Range(Y_MIN_MOVE_RANGE, Y_MAX_MOVE_RANGE), 0);
        isReachTargetPosition = false;
    }
}