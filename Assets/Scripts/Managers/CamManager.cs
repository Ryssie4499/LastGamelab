using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    [SerializeField] GameObject playerCam;
    [SerializeField] List<GameObject> enemyCams;
    [SerializeField] List<enemyGroup> groups;

    InputManager iM;
    void Start()
    {
        iM = GameManager.Instance.IM;
        changeToPlayerCam();
    }

    public void changeToEnemyCam()
    {

        foreach (var group in groups)
        {
            group.CheckSelectedGroup();
        }

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


    public void changeToPlayerCam()
    {
        foreach (var group in groups)
        {
            group.CheckSelectedGroup();
        }

        playerCam.SetActive(true);

        foreach (var cam in enemyCams)
        {
            cam.SetActive(false);
        }


    }
}
