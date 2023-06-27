using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    [SerializeField] GameObject playerCam;
    [SerializeField] List<GameObject> enemyCams;
    [SerializeField] List<enemyGroup> groups;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameState == GameManager.GameState.inCombat)
        {
            changeToEnemyCam();
        }
        else if(GameManager.Instance.gameState == GameManager.GameState.inGame)
        {
            changeToPlayerCam();
        }
    }

    void changeToEnemyCam()
    {
        playerCam.SetActive(false);
        for (int i = 0; i < groups.Count; i++)
        {
            if (groups[i].inCombat)
            {
                enemyCams[i].SetActive(true);
            }
            else
            {
                enemyCams[i].SetActive(false);
            }
        }
    }


    void changeToPlayerCam()
    {
        foreach (var cam in enemyCams)
        {
            cam.SetActive(false);
        }

        playerCam.SetActive(true);
    }
}
