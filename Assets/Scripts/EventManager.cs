using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action OnLevelCompleted;
    public static Action OnLevelFailed;
    public static Action OnLevelPaused;
    public static Action OnLevelStarted;

}
