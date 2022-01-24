using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIEnginer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI score;
    [SerializeField]
    private TextMeshProUGUI life;
    [SerializeField]
    private TextMeshProUGUI speed;
    [SerializeField]
    private GameObject BaseWindow;
    void Update()
    {
        score.text = PlayerStats.score.ToString();
        life.text = PlayerStats.live.ToString();
        speed.text = PlayerStats.speed.ToString();
        if (PlayerStats.live == 0)
        {
            PlayerStats.speed = 0;
            BaseWindow.SetActive(true);
        }
    }
}
