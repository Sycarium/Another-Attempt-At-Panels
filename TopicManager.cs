using System;
using UnityEngine;

#nullable enable

/// <summary>
/// The tab manager that manages the behaviour of buttons between eachother.
/// </summary>
public sealed class TopicManager : MonoBehaviour
{
    // Singleton
    private static TopicManager? _instance;
    public static TopicManager Instance => TopicManager._instance ?? throw new InvalidOperationException($"{nameof(TopicManager)}.{nameof(TopicManager.Instance)} could not be found.");

    /// <summary>
    /// The button behaviour associated with the current open tab.
    /// </summary>
    public TopicButtonBehaviour? OpenTabButton { get; set; }

    private void Awake()
    {
        // Set up the singleton.
        if (TopicManager._instance != null)
        {
            Destroy(this);
            throw new Exception($"Multiple instances of {nameof(TopicManager)}.{nameof(TopicManager.Instance)} are registered in the scene. Only one is allowed.");
        }

        TopicManager._instance = this;
        
    }

    /// <summary>
    /// Callable by tab buttons to inform they have been pressed.
    /// </summary>
    /// <param name="TopicButtonInstance">The tab button instance that was pressed.</param>
    public void OnTabButtonPressed(TopicButtonBehaviour TopicButtonInstance)
    {
        // Ignore if the current open tab button is the same.
        if (this.OpenTabButton == TopicButtonInstance)
        {
            Debug.Log("Tab was not changed since the current open tab equals the requested tab.");
            return;
        }

        // Close the open tab if there is one.
        if (this.OpenTabButton != null)
        {
            this.OpenTabButton.Close();
        }

        // Open the requested tab.
        TopicButtonInstance.ConfirmPressed();

        this.OpenTabButton = TopicButtonInstance;
    }
}
