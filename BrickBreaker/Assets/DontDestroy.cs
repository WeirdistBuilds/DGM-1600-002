using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    public class Music : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
