using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Save static value
    public static int live;
    public static float speed;
    public static int score;

    //window game ower
    private void Update()
    {
        //dead speed
        if (live == 0)
        {
            speed = 0;

        }

    }
    //need for restart +delay on start
    public void startGame()
    {
        
        //set base value
        live = 3;
        score = 0;
        StartCoroutine(StartNew());
    }
    IEnumerator StartNew()
    {
        yield return new WaitForSeconds(2.0f);
        speed = 1.0f;
        yield return null;
    } 
}
