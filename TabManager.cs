using System;
using UnityEngine;

#nullable enable

/// <summary>
/// The tab manager that manages the behaviour of buttons between eachother.
/// </summary>
public sealed class TabManager : MonoBehaviour
{
    // Singleton
    private static TabManager? _instance;
    public static TabManager Instance => TabManager._instance ?? throw new InvalidOperationException($"{nameof(TabManager)}.{nameof(TabManager.Instance)} could not be found.");
    public GameObject AIIS_HUD;

    /// <summary>
    /// The button behaviour associated with the current open tab.
    /// </summary>
    public TabButtonBehaviour? OpenTabButton { get; set; }
    
    private void Awake()
    {
        // Set up the singleton.
        if (TabManager._instance != null)
        {
            Destroy(this);
            throw new Exception($"Multiple instances of {nameof(TabManager)}.{nameof(TabManager.Instance)} are registered in the scene. Only one is allowed.");
        }

        TabManager._instance = this;
    }

    /// <summary>
    /// Callable by tab buttons to inform they have been pressed.
    /// </summary>
    /// <param name="tabButtonInstance">The tab button instance that was pressed.</param>
    public void OnTabButtonPressed(TabButtonBehaviour tabButtonInstance)
    {
        // Ignore if the current open tab button is the same.
        if ((this.OpenTabButton == tabButtonInstance) )
        {
            Debug.LogWarning("Tab was not changed since the current open tab equals the requested tab.");
            return;
        }
        
        // Close the open tab if there is one.
        if (this.OpenTabButton != null)
        {
            Debug.LogWarning("Panel was closed after button was indeed pressed");
            this.OpenTabButton.Close();
        }
        

        // Open the requested tab.
        tabButtonInstance.ConfirmPressed();
        Debug.LogWarning("Button was indeed pressed");
        this.OpenTabButton = tabButtonInstance;
    }
}
