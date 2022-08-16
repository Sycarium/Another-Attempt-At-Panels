using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public Button Tab_Intro { get; private set; }
    [SerializeField] public Button Tab_SK{ get; private set; }
    [SerializeField] public Button Tab_AI { get; private set; }
    [SerializeField] public Button Tab_Challenges { get; private set; }
    public int IndexofButton { get; private set; }

    public event UnityAction? ButtonEvent1 ;


    private void OnEnable()
    {
        this.ButtonEvent1 += GameManager.Instance.ToggleALL.ToggleAll;
      
        this.Tab_Intro.GetComponent<Button>().onClick.AddListener(GameManager.Instance.ToggleALL.ToggleAll);
        this.Tab_SK.GetComponent<Button>().onClick.AddListener(GameManager.Instance.ToggleALL.ToggleAll);
        this.Tab_AI.GetComponent<Button>().onClick.AddListener(GameManager.Instance.ToggleALL.ToggleAll);
        this.Tab_Challenges.GetComponent<Button>().onClick.AddListener(GameManager.Instance.ToggleALL.ToggleAll);
    }
    private void OnDisable()
    {
        
    }

}
