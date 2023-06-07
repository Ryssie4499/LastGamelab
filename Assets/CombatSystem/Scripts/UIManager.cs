using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static event Action OnRightChoice;
    public static event Action OnWrongChoice;
    public Image[] player_hearts;
    public int player_numOfHearts;
    public Image[] shadow_hearts;
    public int shadow_numOfHearts;
    public GameObject button1, button2, button3;
    [SerializeField] TextMeshProUGUI text;
    private string[] dom = new string[] { "Ciao, mi chiamo Mario e non mi piacciono i muffin", "Ciao, mi chiamo Alfonso e odio la crostata", "Ciao, mi chiamo Gesualdo e mi fanno schifo i biscotti" };
    private string[] ris = new string[] { "Muffin", "Crostata", "Biscotti" };
    private Dictionary<string, string> risposte;
    private string risposta;
    private int mistakesCounter;
    private void Awake()
    {
        risposte = new Dictionary<string, string>
        {
            {dom[0], ris[0] },
            {dom[1], ris[1] },
            {dom[2], ris[2] }
        };
        text.text = dom[UnityEngine.Random.Range(0, 3)];
    }
    private void Update()
    {
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
    public void Risposta1()
    {
        var colors = button1.GetComponent<Button>().colors;
        risposta = "Muffin";
        if (text.text == dom[0] && risposte["Ciao, mi chiamo Mario e non mi piacciono i muffin"].Equals(risposta))
        {
            text.text = dom[UnityEngine.Random.Range(0, 3)];
            colors.selectedColor = Color.green;
            button1.GetComponent<Button>().colors = colors;
            MakeDamage(1);
            Debug.Log("Giusto!");
        }
        else
        {
            mistakesCounter++;
            colors.selectedColor = Color.red;
            button1.GetComponent<Button>().colors = colors;
            Debug.Log("Sbagliato!");
        }
        if (mistakesCounter == 2)
        {
            TakeDamage(1);
            text.text = dom[UnityEngine.Random.Range(0, 3)];
            mistakesCounter = 0;
        }
    }
    public void Risposta2()
    {
        var colors = button2.GetComponent<Button>().colors;
        risposta = "Crostata";
        if (text.text == dom[1] && risposte["Ciao, mi chiamo Alfonso e odio la crostata"].Equals(risposta))
        {
            text.text = dom[UnityEngine.Random.Range(0, 3)];
            colors.selectedColor = Color.green;
            button2.GetComponent<Button>().colors = colors;
            MakeDamage(1);
            Debug.Log("Giusto!");
        }
        else
        {
            mistakesCounter++;
            colors.selectedColor = Color.red;
            button2.GetComponent<Button>().colors = colors;
            Debug.Log("Sbagliato!");
        }
        if (mistakesCounter == 2)
        {
            TakeDamage(1);
            text.text = dom[UnityEngine.Random.Range(0, 3)];
            mistakesCounter = 0;
        }
    }
    public void Risposta3()
    {
        var colors = button3.GetComponent<Button>().colors;
        risposta = "Biscotti";
        if (text.text == dom[2] && risposte["Ciao, mi chiamo Gesualdo e mi fanno schifo i biscotti"].Equals(risposta))
        {
            text.text = dom[UnityEngine.Random.Range(0, 3)];
            colors.selectedColor = Color.green;
            button3.GetComponent<Button>().colors = colors;
            MakeDamage(1);
            Debug.Log("Giusto!");
        }
        else
        {
            mistakesCounter++;
            colors.selectedColor = Color.red;
            button3.GetComponent<Button>().colors = colors;
            Debug.Log("Sbagliato!");
        }
        if(mistakesCounter==2)
        {
            TakeDamage(1);
            text.text = dom[UnityEngine.Random.Range(0, 3)];
            mistakesCounter = 0;
        }
    }
    public void TakeDamage(int damageAmount)
    {
        player_numOfHearts -= damageAmount;
        OnWrongChoice?.Invoke();
    }
    public void MakeDamage(int damageAmount)
    {
        shadow_numOfHearts -= damageAmount;
        OnRightChoice?.Invoke();
    }
}