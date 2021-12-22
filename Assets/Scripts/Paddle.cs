using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float Speed = 2.0f;
    public float MaxMovement = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        float paddleSize = DifficultyManager.Instance.paddleSize;
        transform.localScale = new Vector3(paddleSize, transform.localScale.y, transform.localScale.z);
        Ball ball = FindObjectOfType<Ball>();
        if (paddleSize >= 0.39 && paddleSize <= 0.41) {
            ball.gameObject.transform.localScale = new Vector3( 0.1875f*2 , ball.gameObject.transform.localScale.y, ball.gameObject.transform.localScale.z);
        } else if (paddleSize >= 0.79 && paddleSize <= 0.81) {
            ball.gameObject.transform.localScale = new Vector3( 0.1875f , ball.gameObject.transform.localScale.y, ball.gameObject.transform.localScale.z);
        } else {
            ball.gameObject.transform.localScale = new Vector3( 0.1875f /2 , ball.gameObject.transform.localScale.y, ball.gameObject.transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");

        Vector3 pos = transform.position;
        pos.x += input * Speed * Time.deltaTime;

        if (pos.x > MaxMovement)
            pos.x = MaxMovement;
        else if (pos.x < -MaxMovement)
            pos.x = -MaxMovement;

        transform.position = pos;
    }
}
