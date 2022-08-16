using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance = null;
    [SerializeField] public ToggleALL ToggleALL;
    public ToggleALL toggleALL;
    [SerializeField] public ColorsForTheColorGod colorsForTheColorGod;
    //[SerializeField] public TopicButtonBehaviour TopicButtonBehaviour;
   // [SerializeField] public TabButtonBehaviour TabButtonBehaviour;
    private void Awake()
    {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void Start()
    {
        
    }
}
