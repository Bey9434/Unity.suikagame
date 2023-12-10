using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class sphere : MonoBehaviour
{
   private Vector3 _mousePosition;
   private GameObject _previewSphere;
   private Vector3 _contactPoint;
   
   [SerializeField] 
   public GameObject[] _seeds;
   
   [SerializeField]
   private int _SphereRange; 

   [SerializeField]
   private int index;

    [SerializeField]
   public int _Spheresize;
   

  void Update()
   {
        
         _mousePosition = Input.mousePosition;
         _mousePosition.x = Mathf.Clamp(_mousePosition.x,0,Camera.main.pixelWidth);
         _mousePosition.y = 800f;
         _mousePosition.z = 100f;


      if(Input.GetMouseButtonDown(0))
      {
         index = Random.Range(0,5);
         _previewSphere = Instantiate(_seeds[index], Camera.main.ScreenToWorldPoint(_mousePosition),Quaternion.identity);
      }
      if(Input.GetMouseButton(0) && _previewSphere != null)
      {
         _previewSphere.transform.position = Camera.main.ScreenToWorldPoint(_mousePosition);
      }
      if(Input.GetMouseButtonUp(0))
      {
         Destroy(_previewSphere);
        Instantiate(_seeds[index], Camera.main.ScreenToWorldPoint(_mousePosition),Quaternion.identity);
      }
      
   }

}
