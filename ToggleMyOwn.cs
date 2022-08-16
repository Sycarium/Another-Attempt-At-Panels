using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMyOwn : MonoBehaviour
{
    public GameObject[] AnotherGameObjectArray2;
    public GameObject BackgroundPanel;
    public GameObject MainPanel;
    public List<Button> ButtonArray;
    // Start is called before the first frame update
    public TabManager _TabManager;
    public TopicManager _TopicManager;
    public GameManager  _GameManager;
    void Start()
    {
        CallOfTheVoid();
    }
    public void CallOfTheVoid() {
     
        

        var FilthyToggleUser = MainPanel.GetComponent<Toggle>();
    
     
        if (FilthyToggleUser.isOn)
        {
            
            OnSwitchON(true);

        }
        else
        {
            OnSwitchOFF(true);


        }

    }
      public  bool OnSwitchON(bool on)
    {
        
        var IntroPanel = AnotherGameObjectArray2[0];

        IntroPanel.SetActive(true);
            BackgroundPanel.SetActive(true);
        return on;
        }
       public  bool OnSwitchOFF(bool on)
        {

        if (_TabManager) 
                _TabManager.OpenTabButton = null;
            BackgroundPanel.SetActive(false);
            for (int i = 0; i < AnotherGameObjectArray2.Length; i++)
            {
                AnotherGameObjectArray2[i].SetActive(false);

          
            }
        if ( _TopicManager)
        _TopicManager.OpenTabButton = null;
        _TabManager.OpenTabButton = null;
         for(int i = 0; i<AnotherGameObjectArray2.Length; i++)
        {
            AnotherGameObjectArray2[i].SetActive(false);
            var _TasksParent = _GameManager.GetComponent<InstantiatePrefab>().TasksParent;
            for (int a = 0; a < _TasksParent.Count; a++)
            {
                var topiclistObject = _GameManager.GetComponent<InstantiatePrefab>().TopicList[a];
                //if (topiclistObject[a]=!0)
                {
                    topiclistObject.SetActive(false);
                    topiclistObject = null; 
                }
            }
            //AnotherGameObjectArray2[i].transform.GetChild(i).gameObject.SetActive(false);
        }
        
        
        foreach (Button Button in ButtonArray)
        {
            this.GetComponent<TabButtonBehaviour>().Button.onClick.RemoveAllListeners();
        }
            return on;
        }
    }