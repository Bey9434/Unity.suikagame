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
      _mousePosition.z = 100f; // カメラから球までの距離。プレハブの距離がキャンバス基準のrecttransformなので、その分の補正が必要。
      _mousePosition.y = 750f;
      //Debug.Log(_mousePosition);

    // スクリーン座標からワールド座標への変換
      Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);
      Debug.Log(worldMousePosition);

      if(Input.GetMouseButtonDown(0))
      {
         index = Random.Range(0, 5); 
         _previewSphere = Instantiate(_seeds[index], AdjustPosition(worldMousePosition, _seeds[index].transform.localScale.x / 2), Quaternion.identity);
      }

      if(Input.GetMouseButton(0) && _previewSphere != null)
      {
         _previewSphere.transform.position = AdjustPosition(worldMousePosition, _previewSphere.transform.localScale.x / 2);
      }

      if(Input.GetMouseButtonUp(0) && _previewSphere != null)
      {
         Destroy(_previewSphere);
         Instantiate(_seeds[index], AdjustPosition(worldMousePosition, _seeds[index].transform.localScale.x / 2), Quaternion.identity);
      }
   }

// 生成位置を調整するメソッド
   Vector3 AdjustPosition(Vector3 position, float radius)
   {
      float leftWall = -5.25f + radius;
      float rightWall = 5.25f - radius;
      position.x = Mathf.Clamp(position.x, leftWall, rightWall);
      return position;
   }

      
}


