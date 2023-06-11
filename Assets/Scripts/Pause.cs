using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool isPuase;

    void Start()
    {
        isPuase = false;
    }
    
    public void OnpauseButtonClicked()
    {
        isPuase = !isPuase;

        if (isPuase)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
