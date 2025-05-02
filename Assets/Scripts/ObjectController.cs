using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private PlayerManager playerManager; //PlayrerManagerを参照して関数取り込み
    private float currentPosition; //現在の位置を格納
    private float randomiser; //オブジェクト生成位置にランダム性を付与

    void Start()
    {
        playerManager = FindFirstObjectByType<PlayerManager>();

        if (playerManager == null)　//エラー処理
        {
            Debug.LogError("PlayerManagerが見つかりません。");
        }

    }

    void Update()
    {
        Transform myTransform = this.transform; // 現在位置を取得
        Vector3 pos = myTransform.position; // 座標を格納

        if (pos.x < -13.0f) //オブジェクトが画面外に出た場合、反対側へ移動
        {
            randomiser = Random.Range(0.0f, 1.50f);
            pos.x = 13.0f + randomiser;
            myTransform.position = pos;
        }

        if (playerManager != null) //PlayerManager.csから位置を取得して、オブジェクトの位置を動かす
        {
            currentPosition = playerManager.objectPosition;
            transform.Translate(Vector3.right * currentPosition, Space.World);
        }
    }
}