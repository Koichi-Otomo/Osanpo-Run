using UnityEngine;

public class GroundContoroller : MonoBehaviour
{
    private PlayerManager playerManager;
    private float movespeed = -1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(movespeed * playerManager.gamespeed,0,0);
    }
}
