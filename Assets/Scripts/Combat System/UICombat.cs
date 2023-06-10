using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;

public class UICombat : MonoBehaviour
{
    public static event Action OnRightChoice;
    public static event Action OnWrongChoice;
    public GameObject CombatCanvas;
    [SerializeField] TextMeshProUGUI domandaTxt, risposta1Txt, risposta2Txt, risposta3Txt;
    #region Answers
    public GameObject button1, button2, button3, spiegazione;
    private string[] ris = new string[] { "Muffin", "Crostata", "Biscotti", "Budino", "Krapfen" };
    private Dictionary<string, string> risposte;
    private string rispostaGiusta;
    private string rispostaAttuale;
    private int mistakesCounter;
    #endregion
    #region Questions
    private string[] dom = new string[]
    {
        "Ciao, mi chiamo Mario e non mi piacciono i MUFFIN",
        "Ciao, mi chiamo Alfonso e odio la CROSTATA",
        "Ciao, mi chiamo Gesualdo e mi fanno schifo i BISCOTTI",
        "Ciao, mi chiamo Ingrid e non sopporto il BUDINO",
        "Ciao, mi chiamo Doris e sono una KRAPFEN-hater"
    };
    #endregion
    #region Health
    public Image[] player_hearts;
    public int player_numOfHearts;
    public Image[] shadow_hearts;
    public int shadow_numOfHearts;
    #endregion
    int randomIndex;
    InputManager inputManager;
    bool selected;
    private void Awake()
    {
        risposte = new Dictionary<string, string>
        {
            {dom[0], ris[0] },
            {dom[1], ris[1] },
            {dom[2], ris[2] },
            {dom[3], ris[3] },
            {dom[4], ris[4] }
        };
        randomIndex = UnityEngine.Random.Range(0, dom.Count());
    }
    private void Start()
    {
        inputManager = GameManager.Instance.IM;
        domandaTxt.text = dom[randomIndex];
        rispostaGiusta = ris[randomIndex];
        CheckRightAnswer();

    }
    private void Update()
    {
        //FireChoice();
        //IceChoice();
        //RockChoice();
        SameAnswerCheck();
        HealthSystem();
        //if (inputManager.Select.ReadValue<float>() < 1f) return;
        if (inputManager.Select.ReadValue<float>() == 1f)
        {
            CombatCanvas.SetActive(true);
            GameManager.Instance.gameState = GameManager.GameState.inMenu;
        }

    }
    #region Damage
    public void TakeDamage(int damageAmount)
    {
        StartCoroutine(timeColorChange());
        player_numOfHearts -= damageAmount;
        OnWrongChoice?.Invoke();
    }
    public void MakeDamage(int damageAmount)
    {
        StartCoroutine(timeColorChange());
        shadow_numOfHearts -= damageAmount;
        OnRightChoice?.Invoke();
    }
    void HealthSystem()
    {
        if (StatsManager.Instance.PlayerHealth <= 0 || StatsManager.Instance.EnemyHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (StatsManager.Instance.PlayerHealth < player_numOfHearts)
        {
            player_numOfHearts = StatsManager.Instance.PlayerHealth;
        }
        for (int i = 0; i < player_hearts.Length; i++)
        {
            if (i < StatsManager.Instance.PlayerHealth)
            {
                player_hearts[i].enabled = true;
            }
            else
            {
                player_hearts[i].enabled = false;
            }
        }
        if (StatsManager.Instance.EnemyHealth < shadow_numOfHearts)
        {
            shadow_numOfHearts = StatsManager.Instance.EnemyHealth;
        }
        for (int i = 0; i < shadow_hearts.Length; i++)
        {
            if (i < StatsManager.Instance.EnemyHealth)
            {
                shadow_hearts[i].enabled = true;
            }
            else
            {
                shadow_hearts[i].enabled = false;
            }
        }
    }
    #endregion
    void SameAnswerCheck()
    {
        if (risposta1Txt.text == risposta2Txt.text || risposta1Txt.text == risposta3Txt.text || risposta2Txt.text == risposta3Txt.text)
        {
            CheckRightAnswer();
        }
        else
        {
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
            spiegazione.SetActive(true);
        }


    }
    public void Answer1()
    {
        var colors = button1.GetComponent<Button>().colors;
        rispostaAttuale = risposta1Txt.text;
        //giusto
        if (rispostaGiusta == rispostaAttuale)
        {
            randomIndex = UnityEngine.Random.Range(0, dom.Count());
            domandaTxt.text = dom[randomIndex];
            rispostaGiusta = ris[randomIndex];
            CheckRightAnswer();
            colors.selectedColor = Color.green;
            button1.GetComponent<Button>().colors = colors;
            MakeDamage(1);
        }
        //sbagliato
        else
        {
            mistakesCounter++;
            colors.selectedColor = Color.red;
            button1.GetComponent<Button>().colors = colors;
        }
        if (mistakesCounter == 2)
        {
            colors.selectedColor = Color.red;
            button1.GetComponent<Button>().colors = colors;
            TakeDamage(1);
            randomIndex = UnityEngine.Random.Range(0, dom.Count());
            domandaTxt.text = dom[randomIndex];
            rispostaGiusta = ris[randomIndex];
            CheckRightAnswer();
            mistakesCounter = 0;
        }
        //selected = false;
    }
    public void Answer2()
    {
        var colors = button2.GetComponent<Button>().colors;
        rispostaAttuale = risposta2Txt.text;
        //giusto
        if (rispostaGiusta == rispostaAttuale)
        {
            randomIndex = UnityEngine.Random.Range(0, dom.Count());
            domandaTxt.text = dom[randomIndex];
            rispostaGiusta = ris[randomIndex];
            CheckRightAnswer();
            colors.selectedColor = Color.green;
            button2.GetComponent<Button>().colors = colors;
            MakeDamage(1);
        }
        //sbagliato
        else
        {
            mistakesCounter++;
            colors.selectedColor = Color.red;
            button2.GetComponent<Button>().colors = colors;
        }
        if (mistakesCounter == 2)
        {
            TakeDamage(1);
            randomIndex = UnityEngine.Random.Range(0, dom.Count());
            domandaTxt.text = dom[randomIndex];
            rispostaGiusta = ris[randomIndex];
            CheckRightAnswer();
            mistakesCounter = 0;
            colors.selectedColor = Color.red;
            button2.GetComponent<Button>().colors = colors;
        }
        //selected = false;
    }
    public void Answer3()
    {
        var colors = button3.GetComponent<Button>().colors;
        rispostaAttuale = risposta3Txt.text;
        //giusto
        if (rispostaGiusta == rispostaAttuale)
        {
            randomIndex = UnityEngine.Random.Range(0, dom.Count());
            domandaTxt.text = dom[randomIndex];
            rispostaGiusta = ris[randomIndex];
            CheckRightAnswer();
            colors.selectedColor = Color.green;
            button3.GetComponent<Button>().colors = colors;
            MakeDamage(1);
        }
        //sbagliato
        else
        {
            mistakesCounter++;
            colors.selectedColor = Color.red;
            button3.GetComponent<Button>().colors = colors;
        }
        if (mistakesCounter == 2)
        {
            TakeDamage(1);
            randomIndex = UnityEngine.Random.Range(0, dom.Count());
            domandaTxt.text = dom[randomIndex];
            rispostaGiusta = ris[randomIndex];
            CheckRightAnswer();
            mistakesCounter = 0;
            colors.selectedColor = Color.red;
            button3.GetComponent<Button>().colors = colors;
        }
        //selected = false;
    }
    void CheckRightAnswer()
    {
        risposta1Txt.text = ris[UnityEngine.Random.Range(0, ris.Count())];
        risposta2Txt.text = ris[UnityEngine.Random.Range(0, ris.Count())];
        if (risposta1Txt.text != rispostaGiusta && risposta2Txt.text != rispostaGiusta)
            risposta3Txt.text = rispostaGiusta;
        else
            risposta3Txt.text = ris[UnityEngine.Random.Range(0, ris.Count())];
    }
    //void FireChoice()
    //{
    //    //if (inputManager.Fire.ReadValue<float>() < 1f) return;
    //    if (inputManager.Fire.ReadValue<float>() == 1f)
    //    {
    //        Debug.Log("Fuoco");
    //        selected = true;
    //        if (selected)
    //            Answer1();
    //    }
    //}
    //void IceChoice()
    //{
    //    //if (inputManager.Ice.ReadValue<float>() < 1f) return;
    //    if (inputManager.Fire.ReadValue<float>() == 1f)
    //    {
    //        Debug.Log("Ghiaccio");
    //        selected = true;
    //        if (selected)
    //            Answer2();
    //    }
    //}
    //void RockChoice()
    //{
    //    //if (inputManager.Rock.ReadValue<float>() < 1f) return;
    //    if (inputManager.Fire.ReadValue<float>() == 1f)
    //    {
    //        Debug.Log("Roccia");
    //        selected = true;
    //        if (selected)
    //            Answer3();
    //    }
    //}
    IEnumerator timeColorChange()
    {
        yield return new WaitForSeconds(0.2f);
        var color1 = button1.GetComponent<Button>().colors;
        var color2 = button2.GetComponent<Button>().colors;
        var color3 = button3.GetComponent<Button>().colors;
        color1.selectedColor = color1.normalColor;
        color2.selectedColor = color2.normalColor;
        color3.selectedColor = color3.normalColor;
        button1.GetComponent<Button>().colors = color1;
        button2.GetComponent<Button>().colors = color2;
        button3.GetComponent<Button>().colors = color3;

    }
}
