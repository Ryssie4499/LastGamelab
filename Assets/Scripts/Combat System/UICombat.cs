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
    bool endEnemyCombat;
    #region Answers
    public GameObject button1, button2, button3, spiegazione;
    //private string[] ris = new string[] { "Muffin", "Crostata", "Biscotti", "Budino", "Krapfen" };
    //private Dictionary<string, string> risposte;
    //private string rispostaGiusta;
    //private string rispostaAttuale;
    private int mistakesCounter;
    public Wisp[] wisp;
    Color startColor;
    #endregion
    #region Questions
    //private string[] dom = new string[]
    //{
    //    "Ciao, mi chiamo Mario e non mi piacciono i MUFFIN",
    //    "Ciao, mi chiamo Alfonso e odio la CROSTATA",
    //    "Ciao, mi chiamo Gesualdo e mi fanno schifo i BISCOTTI",
    //    "Ciao, mi chiamo Ingrid e non sopporto il BUDINO",
    //    "Ciao, mi chiamo Doris e sono una KRAPFEN-hater"
    //};
    #endregion
    #region Health
    public Image[] player_hearts;
    public int player_numOfHearts;
    public Image[] shadow_hearts;
    public int shadow_numOfHearts;
    public Image[] boss_hearts;
    public int boss_numOfHearts;
    #endregion
    public GameObject[] enemies;
    public GameObject shadowLife;
    public GameObject bossLife;
    int randomIndex;
    InputManager inputManager;
    CamManager cM;

    public bool bambino, madre, padre;
    public List<domandeSO> domandeBambino;
    public List<domandeSO> domandeMadre;
    public List<domandeSO> domandePadre;
    int domandaRNG;
    int slotRNG;
    private void Awake()
    {
        wisp = FindObjectsOfType<Wisp>();
    }
    private void Start()
    {
        inputManager = GameManager.Instance.IM;
        cM = GameManager.Instance.CM;
        CreateQuestionsAndAnswers();
        var color = button1.GetComponent<Button>().colors;
        startColor = color.normalColor;
    }
    private void Update()
    {
        if (CombatCanvas.activeSelf)
        {
            FireChoice();
            IceChoice();
            RockChoice();
            HealthSystem();
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
        if (endEnemyCombat)
            boss_numOfHearts -= damageAmount;
        else
            shadow_numOfHearts -= damageAmount;
        OnRightChoice?.Invoke();
    }
    void HealthSystem()
    {
        if (StatsManager.Instance.PlayerHealth <= 0)
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


        if (endEnemyCombat)
        {
            Debug.Log("EndOfEnemies");
            Debug.Log("Instance: " + StatsManager.Instance.BossHealth + ", numOfHearts = " + boss_numOfHearts);
            if (StatsManager.Instance.BossHealth < boss_numOfHearts)
            {
                boss_numOfHearts = StatsManager.Instance.BossHealth;
            }
            for (int j = 0; j < boss_hearts.Length; j++)
            {
                if (j < StatsManager.Instance.BossHealth)
                {
                    boss_hearts[j].enabled = true;
                }
                else
                {
                    boss_hearts[j].enabled = false;
                }
            }
            if (StatsManager.Instance.BossHealth <= 0)
            {
                cM.changeToPlayerCam();
            }
        }
        else
        {
            if (StatsManager.Instance.TotalEnemyHealth < shadow_numOfHearts)
            {
                shadow_numOfHearts = StatsManager.Instance.TotalEnemyHealth;
            }
            for (int j = 0; j < shadow_hearts.Length; j++)
            {
                if (j < StatsManager.Instance.TotalEnemyHealth)
                {
                    shadow_hearts[j].enabled = true;
                }
                else
                {
                    shadow_hearts[j].enabled = false;
                }
            }
            if (StatsManager.Instance.TotalEnemyHealth <= 0)
            {
                GameManager.Instance.gameState = GameManager.GameState.inGame;
                CombatCanvas.SetActive(false);
                shadowLife.SetActive(false);
                bossLife.SetActive(true);
                endEnemyCombat = true;
                cM.changeToPlayerCam();
            }
        }

    }
    #endregion
    public void Answer1()
    {
        var colors = button1.GetComponent<Button>().colors;
        if (slotRNG == 0)
        {
            CreateQuestionsAndAnswers();
            colors.selectedColor = Color.green;
            colors.normalColor = Color.green;
            button1.GetComponent<Button>().colors = colors;
            for (int i = 0; i < wisp.Count(); i++)
            {
                if (wisp[i].typeOfWisp == TypeOfWisp.Rock)
                    wisp[i].attack = true;
            }
            MakeDamage(1);
        }
        else
        {
            mistakesCounter++;
            colors.selectedColor = Color.red;
            colors.normalColor = Color.red;
            button1.GetComponent<Button>().colors = colors;
        }
        if (mistakesCounter == 2)
        {
            colors.selectedColor = Color.red;
            colors.normalColor = Color.red;
            button1.GetComponent<Button>().colors = colors;
            TakeDamage(1);
            CreateQuestionsAndAnswers();
            mistakesCounter = 0;
        }
    }
    public void Answer2()
    {
        var colors = button2.GetComponent<Button>().colors;
        if (slotRNG == 1)
        {
            CreateQuestionsAndAnswers();
            colors.selectedColor = Color.green;
            colors.normalColor = Color.green;
            button2.GetComponent<Button>().colors = colors;
            for (int i = 0; i < wisp.Count(); i++)
            {
                if (wisp[i].typeOfWisp == TypeOfWisp.Ice)
                    wisp[i].attack = true;
            }
            MakeDamage(1);
        }
        else
        {
            mistakesCounter++;
            colors.selectedColor = Color.red;
            colors.normalColor = Color.red;
            button2.GetComponent<Button>().colors = colors;
        }
        if (mistakesCounter == 2)
        {
            TakeDamage(1);
            CreateQuestionsAndAnswers();
            mistakesCounter = 0;
            colors.selectedColor = Color.red;
            colors.normalColor = Color.red;
            button2.GetComponent<Button>().colors = colors;
        }
    }
    public void Answer3()
    {
        var colors = button3.GetComponent<Button>().colors;
        if (slotRNG == 2)
        {
            CreateQuestionsAndAnswers();
            colors.selectedColor = Color.green;
            colors.normalColor = Color.green;
            button3.GetComponent<Button>().colors = colors;
            for (int i = 0; i < wisp.Count(); i++)
            {
                if (wisp[i].typeOfWisp == TypeOfWisp.Fire)
                    wisp[i].attack = true;
            }
            MakeDamage(1);
        }
        else
        {
            mistakesCounter++;
            colors.selectedColor = Color.red;
            colors.normalColor = Color.red;
            button3.GetComponent<Button>().colors = colors;
        }
        if (mistakesCounter == 2)
        {
            TakeDamage(1);
            CreateQuestionsAndAnswers();
            mistakesCounter = 0;
            colors.selectedColor = Color.red;
            colors.normalColor = Color.red;
            button3.GetComponent<Button>().colors = colors;
        }
    }
    void FireChoice()
    {
        if (inputManager.Fire.triggered)
        {
            Debug.Log("Fuoco");
            Answer1();
        }
    }
    void IceChoice()
    {
        if (inputManager.Ice.triggered)
        {
            Debug.Log("Ghiaccio");
            Answer2();
        }
    }
    void RockChoice()
    {
        if (inputManager.Rock.triggered)
        {
            Debug.Log("Roccia");
            Answer3();
        }
    }
    IEnumerator timeColorChange()
    {
        yield return new WaitForSeconds(0.2f);
        var color1 = button1.GetComponent<Button>().colors;
        var color2 = button2.GetComponent<Button>().colors;
        var color3 = button3.GetComponent<Button>().colors;
        color1.normalColor = startColor;
        color1.selectedColor = color1.normalColor;
        color2.normalColor = startColor;
        color2.selectedColor = color2.normalColor;
        color3.normalColor = startColor;
        color3.selectedColor = color3.normalColor;
        button1.GetComponent<Button>().colors = color1;
        button2.GetComponent<Button>().colors = color2;
        button3.GetComponent<Button>().colors = color3;

    }



    int RS1RNG, RS2RNG;
    void CreateQuestionsAndAnswers()
    {
        if (bambino == true)
        {

            slotRNG = UnityEngine.Random.Range(0, 3);                                                                   //creo uno slot randomico in cui può finire la risposta giusta
            domandaRNG = UnityEngine.Random.Range(0, domandeBambino.Count);                                                    //creo una domanda randomica

            if (slotRNG == 0)                                                                                            //se la risposta giusta si trova sul pulsante 0
            {
                risposta1Txt.text = domandeBambino[domandaRNG].rispostaGiusta;                                                 //la risposta 1 è la risposta giusta
                RS1RNG = UnityEngine.Random.Range(0, domandeBambino[domandaRNG].risposteSbagliate.Length);                     //la risposta 2 è randomica tra quelle sbagliate
                RS2RNG = UnityEngine.Random.Range(0, domandeBambino[domandaRNG].risposteSbagliate.Length);                     //la risposta 3 è randomica tra quelle sbagliate
                while (RS2RNG == RS1RNG)                                                                                  //fintantochè la risposta 2 e la risposta 3 sono uguali
                {
                    RS2RNG = UnityEngine.Random.Range(0, RS1RNG);                                                       //la risposta 3 si randomizzerà tra 0 e la risposta 2
                }
                risposta2Txt.text = domandeBambino[domandaRNG].risposteSbagliate[RS1RNG];                                      //assegno le nuove risposte agli altri due slot
                risposta3Txt.text = domandeBambino[domandaRNG].risposteSbagliate[RS2RNG];
            }

            if (slotRNG == 1)
            {
                risposta2Txt.text = domandeBambino[domandaRNG].rispostaGiusta;
                RS1RNG = UnityEngine.Random.Range(0, domandeBambino[domandaRNG].risposteSbagliate.Length);
                RS2RNG = UnityEngine.Random.Range(0, domandeBambino[domandaRNG].risposteSbagliate.Length);
                while (RS2RNG == RS1RNG)
                {
                    RS2RNG = UnityEngine.Random.Range(0, RS1RNG);
                }
                risposta1Txt.text = domandeBambino[domandaRNG].risposteSbagliate[RS1RNG];
                risposta3Txt.text = domandeBambino[domandaRNG].risposteSbagliate[RS2RNG];
            }

            if (slotRNG == 2)
            {
                risposta3Txt.text = domandeBambino[domandaRNG].rispostaGiusta;
                RS1RNG = UnityEngine.Random.Range(0, domandeBambino[domandaRNG].risposteSbagliate.Length);
                RS2RNG = UnityEngine.Random.Range(0, domandeBambino[domandaRNG].risposteSbagliate.Length);
                while (RS2RNG == RS1RNG)
                {
                    RS2RNG = UnityEngine.Random.Range(0, RS1RNG);
                }
                risposta1Txt.text = domandeBambino[domandaRNG].risposteSbagliate[RS1RNG];
                risposta2Txt.text = domandeBambino[domandaRNG].risposteSbagliate[RS2RNG];
            }
        }

        if (madre == true)
        {

            slotRNG = UnityEngine.Random.Range(0, 3);                                                                   //creo uno slot randomico in cui può finire la risposta giusta
            domandaRNG = UnityEngine.Random.Range(0, domandeMadre.Count);                                                    //creo una domanda randomica

            if (slotRNG == 0)                                                                                            //se la risposta giusta si trova sul pulsante 0
            {
                risposta1Txt.text = domandeMadre[domandaRNG].rispostaGiusta;                                                 //la risposta 1 è la risposta giusta
                RS1RNG = UnityEngine.Random.Range(0, domandeMadre[domandaRNG].risposteSbagliate.Length);                     //la risposta 2 è randomica tra quelle sbagliate
                RS2RNG = UnityEngine.Random.Range(0, domandeMadre[domandaRNG].risposteSbagliate.Length);                     //la risposta 3 è randomica tra quelle sbagliate
                while (RS2RNG == RS1RNG)                                                                                  //fintantochè la risposta 2 e la risposta 3 sono uguali
                {
                    RS2RNG = UnityEngine.Random.Range(0, RS1RNG);                                                       //la risposta 3 si randomizzerà tra 0 e la risposta 2
                }
                risposta2Txt.text = domandeMadre[domandaRNG].risposteSbagliate[RS1RNG];                                      //assegno le nuove risposte agli altri due slot
                risposta3Txt.text = domandeMadre[domandaRNG].risposteSbagliate[RS2RNG];
            }

            if (slotRNG == 1)
            {
                risposta2Txt.text = domandeMadre[domandaRNG].rispostaGiusta;
                RS1RNG = UnityEngine.Random.Range(0, domandeMadre[domandaRNG].risposteSbagliate.Length);
                RS2RNG = UnityEngine.Random.Range(0, domandeMadre[domandaRNG].risposteSbagliate.Length);
                while (RS2RNG == RS1RNG)
                {
                    RS2RNG = UnityEngine.Random.Range(0, RS1RNG);
                }
                risposta1Txt.text = domandeMadre[domandaRNG].risposteSbagliate[RS1RNG];
                risposta3Txt.text = domandeMadre[domandaRNG].risposteSbagliate[RS2RNG];
            }

            if (slotRNG == 2)
            {
                risposta3Txt.text = domandeMadre[domandaRNG].rispostaGiusta;
                RS1RNG = UnityEngine.Random.Range(0, domandeMadre[domandaRNG].risposteSbagliate.Length);
                RS2RNG = UnityEngine.Random.Range(0, domandeMadre[domandaRNG].risposteSbagliate.Length);
                while (RS2RNG == RS1RNG)
                {
                    RS2RNG = UnityEngine.Random.Range(0, RS1RNG);
                }
                risposta1Txt.text = domandeMadre[domandaRNG].risposteSbagliate[RS1RNG];
                risposta2Txt.text = domandeMadre[domandaRNG].risposteSbagliate[RS2RNG];
            }
        }

        if (padre == true)
        {

            slotRNG = UnityEngine.Random.Range(0, 3);                                                                   //creo uno slot randomico in cui può finire la risposta giusta
            domandaRNG = UnityEngine.Random.Range(0, domandePadre.Count);                                                    //creo una domanda randomica

            if (slotRNG == 0)                                                                                            //se la risposta giusta si trova sul pulsante 0
            {
                risposta1Txt.text = domandePadre[domandaRNG].rispostaGiusta;                                                 //la risposta 1 è la risposta giusta
                RS1RNG = UnityEngine.Random.Range(0, domandePadre[domandaRNG].risposteSbagliate.Length);                     //la risposta 2 è randomica tra quelle sbagliate
                RS2RNG = UnityEngine.Random.Range(0, domandePadre[domandaRNG].risposteSbagliate.Length);                     //la risposta 3 è randomica tra quelle sbagliate
                while (RS2RNG == RS1RNG)                                                                                  //fintantochè la risposta 2 e la risposta 3 sono uguali
                {
                    RS2RNG = UnityEngine.Random.Range(0, RS1RNG);                                                       //la risposta 3 si randomizzerà tra 0 e la risposta 2
                }
                risposta2Txt.text = domandePadre[domandaRNG].risposteSbagliate[RS1RNG];                                      //assegno le nuove risposte agli altri due slot
                risposta3Txt.text = domandePadre[domandaRNG].risposteSbagliate[RS2RNG];
            }

            if (slotRNG == 1)
            {
                risposta2Txt.text = domandePadre[domandaRNG].rispostaGiusta;
                RS1RNG = UnityEngine.Random.Range(0, domandePadre[domandaRNG].risposteSbagliate.Length);
                RS2RNG = UnityEngine.Random.Range(0, domandePadre[domandaRNG].risposteSbagliate.Length);
                while (RS2RNG == RS1RNG)
                {
                    RS2RNG = UnityEngine.Random.Range(0, RS1RNG);
                }
                risposta1Txt.text = domandePadre[domandaRNG].risposteSbagliate[RS1RNG];
                risposta3Txt.text = domandePadre[domandaRNG].risposteSbagliate[RS2RNG];
            }

            if (slotRNG == 2)
            {
                risposta3Txt.text = domandePadre[domandaRNG].rispostaGiusta;
                RS1RNG = UnityEngine.Random.Range(0, domandePadre[domandaRNG].risposteSbagliate.Length);
                RS2RNG = UnityEngine.Random.Range(0, domandePadre[domandaRNG].risposteSbagliate.Length);
                while (RS2RNG == RS1RNG)
                {
                    RS2RNG = UnityEngine.Random.Range(0, RS1RNG);
                }
                risposta1Txt.text = domandePadre[domandaRNG].risposteSbagliate[RS1RNG];
                risposta2Txt.text = domandePadre[domandaRNG].risposteSbagliate[RS2RNG];
            }
        }
    }
}
