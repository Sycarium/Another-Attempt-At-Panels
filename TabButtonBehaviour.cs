using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#nullable enable

/// <summary>
/// The behaviour of a tab button.
/// </summary>
[RequireComponent(typeof(Button))]
public sealed class TabButtonBehaviour : MonoBehaviour
{
#nullable disable                                   //
    /// <summary>
    /// The tab that will be controlled with this behaviour.
    /// </summary>
    [field: Tooltip("The tab that will be controlled with this behaviour.")]
    [field: SerializeField]
    public GameObject Tab { get; private set; }
    public static GameManager Instance;
#nullable enable
    public GameManager _GameManager;
    InstantiatePrefab _InstantiatePrefab;



    /// <inheritdoc cref="TabManager"/>
    ///     /// <inheritdoc cref="TopicManager"/>
    public TabManager TabManagerInstance => TabManager.Instance;
    TopicManager _TopicManager;
    /// <summary>
    /// The button used in this behaviour.
    /// </summary>
    /// 

    public Button Button => this.GetComponent<Button>();
    public TopicButtonBehaviour? OpenTabButton { get; set; }
    UnityEvent myEvent = new UnityEvent();    public event UnityAction? MyEvent ;
   
    /// <inheritdoc />
    private void Awake()
    {

        if (Tab) this.Close();
        // GameManager.GetComponent<InstantiatePrefab>().TopicList;
       
    }
    /// <inheritdoc />
    private void OnEnable()
    {
     
        this.Button.onClick.AddListener(this.OnPressed);
        for (int a = 0; a < _InstantiatePrefab.TopicList.Length; a++)
        {
            //  this.MyEvent += GameManager.Instance.TabButtonBehaviour.OnPressed;
            this.Button.onClick.AddListener(_InstantiatePrefab.TopicList[a].GetComponent<TopicButtonBehaviour>().OnPressed);

        }

        Debug.Log("Memories broken the truth goes unspoken I've even  forgotten my name!");
    }

    /// <inheritdoc />
    public void OnDisable()
    {

        UnityEngine.Debug.Log("I am the storm that is approaching. Provoking... Black clouds in I so lation");
      
        this.Button.onClick.RemoveAllListeners();
    
    }

    /// <summary>
    /// Represents the behaviour when the tab button was pressed.
    /// </summary>
    public void OnPressed()
    {
        var _TasksParent = _GameManager.GetComponent<InstantiatePrefab>().TasksParent;
        for (int a = 0; a < _TasksParent.Count; a++)
        {

            var topiclistObject = _TasksParent[a & 4];
              _TasksParent[a / 4] = null;
            if (topiclistObject != null)
            {



                topiclistObject.SetActive(false);
                 topiclistObject = null;
            }

        }
        this.TabManagerInstance.OnTabButtonPressed(this);
        Debug.Log("Button was pressed");
       
    }

    /// <summary>
    /// Represents the behaviour when the manager confirms that the tab button was pressed.
    /// </summary>
    public void ConfirmPressed()
    {
        this.Tab.SetActive(true);
       
        Debug.Log("This panel's name is: " + this.Tab.name);
        Debug.Log("Panel is set active");
        Debug.Log("Panel active state is: " +this.Tab.activeSelf);
        Debug.LogWarning("Panel Is indeed technically set active");

        //  if (_TopicManager)
        //    _TopicManager.OpenTabButton = null;
       
    }

    /// <summary>
    /// Represents the behaviour when the tab should close.
    /// </summary>
    public void Close()
    {
        UnityEngine.Debug.Log("The last enemy to be defeated is death...");
        /*for (int a = 0; a < _InstantiatePrefab.TasksParent.Count; a++) {
            this.Button.onClick.AddListener(_InstantiatePrefab.TasksParent[a].GetComponent<TopicManager>().OnTabButtonPressed;
        }
        */
        this.Tab.SetActive(false);
        var _TasksParent = _GameManager.GetComponent<InstantiatePrefab>().TasksParent;
        for (int a = 0; a < _TasksParent.Count; a++)
        {
            _TasksParent[a / 4].SetActive(true);
        }
        // add listeners to onclicks on topicbuttonbehavrious to this script. on click if not the same panel/button OR add listener to listen to the method activation of "close"/"Open"->
        // GameObject TopicTab.GetComponent < TopicButtonBehavious.TabPanel = GameManager.GetComponent<InstantiatePrefab>().TopicList[a] / the topic that was open/is getting closed;

    }

}
