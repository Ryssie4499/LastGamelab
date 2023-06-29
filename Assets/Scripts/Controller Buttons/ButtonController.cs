using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    int index;

    [SerializeField] List<buttonFunctionsSO> functions;
    [SerializeField] List<Image> button;
    [SerializeField] List<GameObject> CombatButtons;
    UIButtons buttons;
    UICombat combatButton;
    InputManager iM;
    [SerializeField] bool combat;


    void Start()
    {
        iM = GameManager.Instance.IM;
        buttons = FindObjectOfType<UIButtons>();
        combatButton = FindObjectOfType<UICombat>();
    }


    void Update()
    {
        ControllIndex();

        if (combat)
        {
            HighlightCombatButton();
        }
        else
        {
            HighlightButton();
        }

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
            for (int i = 0; i < button.Count; i++)
            {
                button[i].color = Color.white;
            }
        }
    }


    void HighlightCombatButton()
    {
        if (iM.UpMenu.triggered || iM.downMenu.triggered)
        {
            for (int i = 0; i < CombatButtons.Count; i++)
            {
                if (i == index)
                {
                    CombatButtons[i].SetActive(true);
                }
                else
                {
                    CombatButtons[i].SetActive(false);
                }
            }
        }
        else if (iM.AnyKeybord.triggered)
        {
            for (int i = 0; i < CombatButtons.Count; i++)
            {
                CombatButtons[i].SetActive(false);
            }
        }
    }
    void RunButton()
    {
        functions[index].RunButton(buttons,combatButton);
    }

}
