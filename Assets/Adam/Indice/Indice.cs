using UnityEngine;

[CreateAssetMenu(fileName = "XXXX", menuName = "Clue/NewClue", order = 1)]
public class Indice : ScriptableObject
{
    [Header("Le numéro que les joueurs rentre :")]
    public string _cardNumber = null;

    [Header("Les trois indices :")]
    [TextArea(5, 20)] public string _firstClue = null;
    [TextArea(5, 20)] public string _secondClue = null;
    [TextArea(5, 20)] public string _thirdClue = null;

    [Header("Les fonctions utilisables :")]
    public bool isUsed = false;
}
