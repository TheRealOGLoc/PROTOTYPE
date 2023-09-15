using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveLeft : MonoBehaviour
{
    public float speedMonster;
    private Vector3 monsterDirection = Vector3.forward;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        speedMonster = Random.Range(7.0f, 13.0f); // generate random speed
    }

    // Update is called once per frame
    void Update()
    {
        // if game is not over, move enemy to left
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(monsterDirection * Time.deltaTime * speedMonster);
        }
    }
}
