using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    //get Rigidbody
    [SerializeField]
    private Rigidbody rb;
    private void Start()
    {

        StartCoroutine(speedBuster());
    }

    IEnumerator speedBuster()
    {
        yield return new WaitForSeconds(0.5f);
        rb.velocity = new Vector3(0.0f, PlayerStats.speed * 10.0f, 0.0f);

        if(PlayerStats.score >= 2 && PlayerStats.speed < 1.5) 
        {
            PlayerStats.speed += 0.1f;
        }

        if (PlayerStats.score >= 25 && PlayerStats.speed < 2)
        {
            PlayerStats.speed += 0.1f;
        }

        if (PlayerStats.score >= 50 && PlayerStats.speed < 3)
        {
            PlayerStats.speed += 0.1f;
        }

        if (PlayerStats.score >= 100 && PlayerStats.speed < 4)
        {
            PlayerStats.speed += 0.1f;
        }
        yield return new WaitForSeconds(0.5f);
        yield return speedBuster();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Block")
        {
            if(col.name== "Bonus2")
            {
                col.gameObject.SetActive(false);
            }
            Dead();
        }
        if (col.tag == "Bonus")
        {
            col.gameObject.SetActive(false);
            PlayerStats.score++;
        }
    }
    void Dead()
    {
        PlayerStats.live--;
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }


       private void Update()
        {
        //move gj keypad
        transform.Translate(Vector3.right* Input.GetAxis("Horizontal")*PlayerStats.speed*2*Time.deltaTime);


        //move android slise
        
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.GetTouch(0);

            Vector2 moveDirection=Vector2.zero;
            if (myTouch.phase == TouchPhase.Moved)
            {
                Vector2 positionChange = myTouch.deltaPosition;
                positionChange.y = -positionChange.y;
                moveDirection = positionChange.normalized;
            }
            transform.Translate(Vector3.right * moveDirection.x * PlayerStats.speed * 2 * Time.deltaTime);
        }
        
    }
}
