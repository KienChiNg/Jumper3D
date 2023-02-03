using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnim : MonoBehaviour
{
    private bool startAnim = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startAnim)
        {
            if (transform.position.x < -8.8)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * 10);
            }
            else
            {
                startAnim = false;
                GetComponent<PlayerController>().gameOver = false;
            }
        }
    }
}
