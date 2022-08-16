using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
//Dictionary<Tkey, Tvalue> dictionary = System.Collections.Generic.Dictionary<Tkey, Tvalue>;
public enum idList {  };
public class InstantiatePrefab : MonoBehaviour
{

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject TaskPrefab;

  
    public List<GameObject> TasksParent; //parents for the tasks to be created
    public Transform[] TopicParent; //parent panels for the topics.
    GameObject[] TasksParentArray;
    public GameObject TaskPanel; //panel for the task, copied for each topic.

    [SerializeField] int topicIDTaskCount; // general task count for each individua ltopic, if instead of creating panels after the tasks,  I create a list of topics, each which would create their own tasks, according to the number of tasks they contain.
    public int TopicIDTaskCount => topicIDTaskCount; // just making the delegate  for topicIDcount.
    public int topicID;  // to throw topic ids to the Dictionary.
    public GameObject[] TopicList; //list of topics. Combined from all panels.
    public List<int> InstanceIDList;
    public Transform[] PanelInstanceList;
    public int TopicCount; // topic count of each indivual panel.
    public int c = 0;

    // need to add taskparents to the taskparent list...
    //public Vector3 anchoredPosition3D;
    // for each topic 1-5 per panel still missing & on the works!
    public GameObject obj;

    public GameObject ImageVariable; // image component

    void Awake()
    {


        topicIDTaskCount = 4;

       
        print(this);
        List<int> taskValues = new List<int>(new int[80]); // the number of tasks within all 4 panels.


        for (int a = 0; a < TopicList.Length; a++)
        {


            Debug.Log("TopicListLenghtis" + TopicList.Length);

            GameObject instance1 = Instantiate(TaskPanel, Vector3.one, Quaternion.identity);
            instance1.GetComponent<RectTransform>().anchorMin = Vector2.zero;
            instance1.GetComponent<RectTransform>().anchorMax = Vector2.zero;
            instance1.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(848.26f, 36.9622f, -63.29781f);
            //           instance1.GetComponent<RectTransform>();
            TasksParent.Add(instance1);
          //  TasksParent[a].GetComponent<Button>().onClick.AddListener(TasksParent[a].GetComponent<TopicButtonBehaviour>().OnPressed);
            Debug.LogWarning("TaskparentListLenght= " + TasksParent.Count);
            TopicList[a].GetComponent<TopicButtonBehaviour>().TopicTab = instance1;
          


            Debug.Log(TaskPanel.name);

            if (a % 5 != 0)
            {
                instance1.SetActive(false);
                

            }
            
            
            Debug.Log(TaskPanel.activeSelf);

            if (a < 20)
            {
                instance1.transform.SetParent(TopicParent[a / TopicCount].transform);


                //topic count needs to alter between panels. rn its just the topic count without any changes to it.
                //Debug.Log("TopicParentA name is" + TopicParent[a].name);
            }
            if (a == TopicCount / 4)
            {
                TopicCount = TopicParent[c].GetComponent<Variables>().declarations.Get<int>("TopicCount");
                c++;
            }
            int id = instance1.GetInstanceID();
            //TaskManager1.taskIds.add(id);
            //instance1.transform.name = TaskManager.taskDictionary[id].name;
            // instance1.transform.name = TaskObject.taskTitle.
            Debug.Log("instance id list print" + InstanceIDList);
            instance1.GetComponent<RectTransform>().anchorMin = new Vector2(0,1);
            instance1.GetComponent<RectTransform>().anchorMax = new Vector2(0,1);
            instance1.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(848.26f, -557.1754f, 0);
            
        }

            // for each instance, create 4 task to instance.  Switch to next instance after 4 tasks. Switch to next parent after 5 instances)
            for (int p = 0; p < PanelInstanceList.Length; p++)
            {

            }
            for (int i = 0; i < TasksParent.Count; i++)
            {


                var taskObjects = TasksParent[i].transform.Cast<Transform>().ToList();

                int count = 0;

                foreach (var obj in taskObjects)
                    Destroy(obj.gameObject);



            }


            for (int j = 0; j < taskValues/*80 */.Count; ++j)
            {
            Debug.Log("Printing TaskValues"  + taskValues);
                GameObject instance = Instantiate(TaskPrefab);
                int Taskid = instance.GetInstanceID();
                InstanceIDList.Add(Taskid);
                //  TaskManager1.taskIds.add(id, instance);
                //TaskManager1.taskIds.add(Key, id);
                instance.GetComponent<Task1PrefabTitleVariable>().TaskTittle.text = "placeholder for scriptable object text variable trough possibly an index?";// TaskObject.taskTitle[id]; // TaskArray[i]
                instance.GetComponent<Task1PrefabTitleVariable>().TaskDescription.text = "placeholder for scriptable object text variable trough possibly an index?";  // + TaskObject.taskDescription[id] ; // TaskArray[i]

                // instance.GetComponent<ImageVarariable>().ImageFromChild.image = TaskObject.imagename[id];
                instance.transform.localScale = Vector3.one;
                obj = instance;
                //  taskSpawned.Add(obj, 16);

                if (j < 80)
            {
                Debug.LogWarning("taskParent Count is" + TasksParent.Count);
                instance.transform.SetParent(TasksParent[j  /* 4 */ / topicIDTaskCount/*4 */].transform);
                }

                Debug.Log(TasksParent[j / topicIDTaskCount].name);



            }
            Debug.Log("Before");
         

            Debug.Log("After");

        }
    }



          
        
    