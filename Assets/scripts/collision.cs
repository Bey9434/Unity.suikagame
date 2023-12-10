using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using TMPro;

public class collision : MonoBehaviour
{   

   [SerializeField]
   private Vector3 _contactPoint;

   [SerializeField]
   public int _Spheresize;

   [SerializeField]
   public GameObject _nextball;

   [SerializeField]
   public int _nextpoint;

   [SerializeField]
   public static int _score;

   [SerializeField]
   private TextMeshProUGUI _scoredis;


   private bool isMergeFlag =  false;

     void OnCollisionEnter(Collision collision)
   {
         GameObject _colSphere = collision.gameObject;
         GameObject _gameObject = GameObject.Find("GameObject");
           
         GameObject[] _colseed = _gameObject.GetComponent<sphere>()._seeds;
         

         if(collision.gameObject.tag == gameObject.tag)
         {
            if(_colSphere.GetComponent<collision>().isMergeFlag == true ) return; 
            {
            isMergeFlag = true;
            _contactPoint = collision.contacts[0].point; // 衝突点を取得
            Destroy(collision.gameObject); // 衝突したオブジェクトを削除
            Destroy(this.gameObject); // このオブジェクト自身も削除
          
             // プレハブから配列のインデックスを取得する
            
             Instantiate(_nextball, _contactPoint,Quaternion.identity);
            _score += _nextpoint; 
             ScoreManager.AddScore(_nextpoint);
            Debug.Log("Score updated: " + _score);

            }
         }

   }

 

}
