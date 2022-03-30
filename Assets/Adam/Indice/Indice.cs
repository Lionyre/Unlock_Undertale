using UnityEngine;

[CreateAssetMenu(fileName = "XXXX", menuName = "Clue/NewClue", order = 1)]
public class Indice : ScriptableObject
{
    [Header("Le numero que les joueurs rentre :")]
    [SerializeField] private int _cardID;

    [Header("Les trois indices :")]
    [TextArea(5, 20), SerializeField] private string _firstClue = null;
    [TextArea(5, 20), SerializeField] private string _secondClue = null;
    [TextArea(5, 20), SerializeField] private string _thirdClue = null;

    [Header("Les fonctions utilisables :")]
    [SerializeField] private bool isUsed = false;


    public int _CardID { get => _cardID; set => _cardID = value; }
    public string _FirstClue { get => _firstClue; set => _firstClue = value; }
    public string _SecondClue { get => _secondClue; set => _secondClue = value; }
    public string _ThirdClue { get => _thirdClue; set => _thirdClue = value; }

}
