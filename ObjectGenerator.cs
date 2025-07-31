using UnityEngine;

public class ObjectGenarator : MonoBehaviour
{
    private PlayerManager playerManager;
    private float objectTimeForWall;
    private float objectTimeForRoof;

    public GameObject ground; // 地面
    public GameObject wall; // 壁
    public GameObject roof; // 屋根

    private float groundElapsedTime = 0.0f; // 地面経過時間
    private float wallElapsedTime = 0.0f; // 壁経過時間
    private float roofElapsedTime = 0.0f; // 屋根経過時間

    private float groundSpawnTime = 2.0f; // 地面待機時間
    private float wallSpawnTime = 0.50f; // 壁待機時間
    private float roofSpawnTime = 1.50f; // 屋根待機時間

    private float wallRundom;
    private float roofRundom;

    void Start()
    {
        playerManager = Object.FindFirstObjectByType<PlayerManager>();
        if (playerManager == null)
        {
            Debug.LogError("PlayerManagerが見つかりません。");
        }
    }

    // Update is called once per frame
    void Update()
    {
        groundElapsedTime += Time.deltaTime; // elapsedTimeの値を1秒に1のペースで増やす
        wallElapsedTime += Time.deltaTime; // elapsedTimeの値を1秒に1のペースで増やす
        roofElapsedTime += Time.deltaTime; // elapsedTimeの値を1秒に1のペースで増やす
        objectTimeForWall = playerManager.elapsedTime / 200;
        objectTimeForRoof = playerManager.elapsedTime / 60;

        if (groundElapsedTime >= groundSpawnTime) // groundを生成
        {
            GroundGenerate(); //GroundGenerate関数を呼び出す
            groundElapsedTime = 0; // elapsedTimeを初期化
            groundSpawnTime -= playerManager.elapsedTime/100 ; //groundの待機時間を減少
        }

        if (wallElapsedTime >= wallSpawnTime) // wallを生成
        {
            WallGenerate(); //WallGenerate関数を呼び出す
            wallElapsedTime -= wallSpawnTime; // elapsedTimeを初期化

            if (wallElapsedTime >= wallSpawnTime)
            {
                wallRundom = Random.Range(0, 0.10f);
                WallGenerate();
                wallElapsedTime = 0;
                wallSpawnTime -= objectTimeForWall; // 直接減算
                wallSpawnTime = Mathf.Max(1/objectTimeForWall　* 100, wallSpawnTime); // 最低間隔を設定
                wallSpawnTime += wallRundom;
            }
            else
            {
                wallSpawnTime += objectTimeForWall / playerManager.elapsedTime;
            }
        }

        if (roofElapsedTime >= roofSpawnTime) // roofを生成
        {
            RoofGenerate(); // RoofGenerate関数を呼び出す
            roofElapsedTime -= roofSpawnTime; // elapsedTimeを初期化

            if (roofElapsedTime >= roofSpawnTime)
            {
                roofRundom = Random.Range(0, 0.10f);
                RoofGenerate();
                roofElapsedTime = 0;
                roofSpawnTime -= objectTimeForRoof; // 直接減算
                roofSpawnTime = Mathf.Max(1/objectTimeForRoof * 100, roofSpawnTime); // 最低間隔を設定
                roofSpawnTime += roofRundom;
            }

            else
            {
                roofSpawnTime += objectTimeForRoof / playerManager.elapsedTime;
            }
        }

    }

    void GroundGenerate()
    {
        Instantiate(ground, new Vector3(10, -5.0f, 1), Quaternion.identity);
        // groundを生成、回転はさせない
    }

    void WallGenerate()
    {
        float wallPosition = 15.0f;
        wallPosition += wallRundom;
        Instantiate(wall, new Vector3(wallPosition, -3.25f, -1), Quaternion.identity);
        // wallを生成、回転はさせない
    }

    void RoofGenerate()
    {
        float roofPosition = 15.0f;
        roofPosition += roofRundom;
        Instantiate(roof, new Vector3(roofPosition, -2.25f, 1), Quaternion.identity);
        // roofを生成、回転はさせない
    }

}
