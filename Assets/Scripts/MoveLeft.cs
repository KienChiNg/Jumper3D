using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float leftBound = -15.0f;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)){
            speed = 20;
        }
        if(Input.GetKeyUp(KeyCode.S)){
            speed = 10;
        }
        if(!playerController.gameOver)
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstancle")){
            Destroy(gameObject);
        }
    }
}
