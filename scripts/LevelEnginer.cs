using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnginer : MonoBehaviour
{
    //filds
    [SerializeField]
    private GameObject fild;

    //limits parameters
    [SerializeField]
    private Transform Spawn;
    [SerializeField]
    private Transform Destroer;

    // camera 
    [SerializeField]
    private Camera cam;
    private Vector3 camPos;

    private void Start()
    {
        for (float i = Spawn.position.y; i > Destroer.position.y; i-=fild.transform.localScale.y)
        {
            Instantiate(fild, new Vector3(
                Spawn.position.x, 
                i-fild.transform.localScale.y, 
                Spawn.position.z), Quaternion.identity);
        }

        //for set base position camera
        camPos = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
    }
    private void Update()
    {
        //move camera
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player !=null)
        {
            cam.transform.position = new Vector3(camPos.x, camPos.y+player.transform.position.y, camPos.z);
        }
    }
}
