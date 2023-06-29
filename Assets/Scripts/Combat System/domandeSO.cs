using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName= "DomandeSO", menuName= "scriptableObjects/DomandeSO")]
public class domandeSO : ScriptableObject
{
    public string domanda;
    public string rispostaGiusta;
    public string[] risposteSbagliate;
}
