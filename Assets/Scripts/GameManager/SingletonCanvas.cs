using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonCanvas : MonoBehaviour
{
    public static SingletonCanvas singletonCanvasInstance { get; private set; }

    private void Awake()
    {
        if (singletonCanvasInstance == null) {
            singletonCanvasInstance = this;
        }
        else { 
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
            
    }
}
