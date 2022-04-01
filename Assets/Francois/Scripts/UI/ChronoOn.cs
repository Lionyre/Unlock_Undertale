using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChronoOn : MonoBehaviour
{
    private Button ClickonButton;
    [SerializeField] private Timer timerBool;
    public Toggle Togle;
    // Start is called before the first frame update
    void Start()
    {
        ClickonButton = this.gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
