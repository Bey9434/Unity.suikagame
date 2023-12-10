using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoverline : MonoBehaviour
{


    [SerializeField]
    private float colTime = 0.0f;
   
    [SerializeField]
     private HashSet<GameObject> _collidingObjects = new HashSet<GameObject>();

    void Update()
    {
        if(_collidingObjects.Count > 0)
        {
            colTime +=Time.deltaTime;

            if(colTime > 5.0f)
            {
                gameover();
            }
            
        }

    }

     void OnTriggerEnter(Collider other)
    {
        _collidingObjects.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
         if(_collidingObjects.Remove(other.gameObject))
        {
            if(_collidingObjects.Count == 0)
            {
                colTime = 0.0f;
            }
        }
        
    }

    private void gameover()
    {
        
        Scene loadScene = SceneManager.GetActiveScene();
        // 現在のシーンを再読み込みする
        SceneManager.LoadScene(loadScene.name);

    }

}
