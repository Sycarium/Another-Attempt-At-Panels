using UnityEngine;
using UnityEngine.UI;

#nullable enable

/// <summary>
/// The behaviour of a tab button.
/// </summary>
[RequireComponent(typeof(Button))]
public sealed class TopicButtonBehaviour : MonoBehaviour
{
#nullable disable                                   //
    /// <summary>
    /// The tab that will be controlled with this behaviour.
    /// </summary>
    [field: Tooltip("The tab that will be controlled with this behaviour.")]
    [field: SerializeField]
    public GameObject TopicTab { private  get; set; }
    
#nullable enable

    /// <inheritdoc cref="TabManager"/>
    public TopicManager TopicManagerInstance => TopicManager.Instance;
    public TabManager _TabManager2;

    /// <summary>
    /// The button used in this behaviour.
    /// </summary>
    /// 

    public Button Button => this.GetComponent<Button>();

    /// <inheritdoc />
    private void Awake()
    {
//        GameManager.GetComponent<InstantiatePrefab>().TopicList[a] = GameManager.GetComponent<InstantiatePrefab>().Instance1;
     // if (TopicTab)  this.Close();
    }

    /// <inheritdoc />
    private void OnEnable()
    {
        this.Button.onClick.AddListener(this.OnPressed);
       // if (_TabManager2)
         //   _TabManager2.OpenTabButton = null;
        Debug.Log("Memories broken the truth goes unspoken I've even  forgotten my name!");
    }

    /// <inheritdoc />
    private void OnDisable()
    {
        UnityEngine.Debug.Log("I am the storm that is approaching. Provoking... Black clouds in I so lation");
        this.Button.onClick.RemoveAllListeners();
    }

    /// <summary>
    /// Represents the behaviour when the tab button was pressed.
    /// </summary>
    public void OnPressed()
    {
        this.TopicManagerInstance.OnTabButtonPressed(this);
        Debug.Log("Topic Button was pressed");
    }

    /// <summary>
    /// Represents the behaviour when the manager confirms that the tab button was pressed.
    /// </summary>
    public void ConfirmPressed()
    {
        this.TopicTab.SetActive(true);
        Debug.LogWarning("Topic Panel is set active");
        Debug.Log("This Topic panel's name is: " + this.TopicTab.name);
        Debug.Log("Topic Panel active state is: " + this.TopicTab.activeSelf);
        Debug.LogWarning("Topic Panel Is indeed technically set active");
    }

    /// <summary>
    /// Represents the behaviour when the tab should close.
    /// </summary>
    public void Close()
    {
        UnityEngine.Debug.Log("The last enemy to be defeated is death...");
        this.TopicTab.SetActive(false);
      
    }
  /*  public void TabButtonListenerCloser()
    {
        foreach in TabButtonlist {
            TabbuttonList.AddListener.OnEnable.();
        }
  
    }
  */
}
