using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    int index;

    [SerializeField] List<buttonFunctionsSO> functions;
    [SerializeField] List<Image> button;

    InputManager iM;
    void Start()
    {
        iM = GameManager.Instance.IM;
    }


    void Update()
    {
        ControllIndex();
        HighlightButton();
        if (iM.SelectWithController.triggered)
        {
            RunButton();
        }
    }


    void ControllIndex()
    {
        if (!iM.usingKeybord)
        {
            if (iM.UpMenu.triggered)
            {
                if (index > 0)
                {
                    index--;
                }
                else
                {
                    index = functions.Count - 1;
                }

            }
            else if (iM.downMenu.triggered)
            {
                if (index < functions.Count - 1)
                {
                    index++;
                }
                else
                {
                    index = 0;
                }

            }
        }
        else
        {
            index = 0;
        }
    }


    void HighlightButton()
    {
        if (iM.UpMenu.triggered || iM.downMenu.triggered)
        {
            for (int i = 0; i < button.Count; i++)
            {
                if (i == index)
                {
                    button[i].color = Color.green;
                }
                else
                {
                    button[i].color = Color.white;
                }
            }
        }
        else if (iM.AnyKeybord.triggered)
        {
            for (int i = 0; i < button.Count - 1; i++)
            {
                button[i].color = Color.white;
            }
        }
    }

    void RunButton()
    {
        functions[index].RunButton();
    }
}
