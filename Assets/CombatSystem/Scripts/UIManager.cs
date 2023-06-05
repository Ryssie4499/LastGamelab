using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public Image[] p_hearts;
    public int p_numOfHearts;
    public Image[] s_hearts;
    public int s_numOfHearts;
    public GameObject b1, b2, b3;
    [SerializeField] float typingDelay;
    [SerializeField] float speedMultiplier;
    [SerializeField] TextMeshProUGUI text;
    private string[] dom = new string[] { "Ciao, mi chiamo Mario e non mi piacciono i muffin", "Ciao, mi chiamo Alfonso e odio la crostata", "Ciao, mi chiamo Gesualdo e mi fanno schifo i biscotti" };
    private string[] ris = new string[] { "Muffin", "Crostata", "Biscotti" };
    private Dictionary<string, string> risposte;
    private string risposta;
    private void Awake()
    {
        risposte = new Dictionary<string, string>
        {
            {dom[0], ris[0] },
            {dom[1], ris[1] },
            {dom[2], ris[2] }
        };
        text.text = dom[Random.Range(0, 3)];
    }
    public void Risposta1()
    {
        var colors = b1.GetComponent<Button>().colors;
        risposta = "Muffin";
        if(text.text == dom[0] && risposte["Ciao, mi chiamo Mario e non mi piacciono i muffin"].Equals(risposta))
        {
            colors.selectedColor = Color.green;
            colors.normalColor = Color.green;
            b1.GetComponent<Button>().colors = colors;
            Debug.Log("Giusto!");
        }
        else
        {
            colors.selectedColor = Color.red;
            colors.normalColor = Color.red;
            b1.GetComponent<Button>().colors = colors;
            Debug.Log("Sbagliato!");
        }
    }
    public void Risposta2()
    {
        var colors = b2.GetComponent<Button>().colors;
        risposta = "Crostata";
        if (text.text == dom[1] && risposte["Ciao, mi chiamo Alfonso e odio la crostata"].Equals(risposta))
        {
            colors.selectedColor = Color.green;
            colors.normalColor = Color.green;
            b2.GetComponent<Button>().colors = colors;
            Debug.Log("Giusto!");
        }
        else
        {
            colors.selectedColor = Color.red; 
            colors.normalColor = Color.red;
            b2.GetComponent<Button>().colors = colors;
            Debug.Log("Sbagliato!");
        }
    }
    public void Risposta3()
    {
        var colors = b3.GetComponent<Button>().colors;
        risposta = "Biscotti";
        if (text.text == dom[2] && risposte["Ciao, mi chiamo Gesualdo e mi fanno schifo i biscotti"].Equals(risposta))
        {
            colors.selectedColor = Color.green; 
            colors.normalColor = Color.green;
            b3.GetComponent<Button>().colors = colors;
            Debug.Log("Giusto!");
        }
        else
        {
            colors.selectedColor = Color.red; 
            colors.normalColor = Color.red;
            b3.GetComponent<Button>().colors = colors;
            Debug.Log("Sbagliato!");
        }
    }
}