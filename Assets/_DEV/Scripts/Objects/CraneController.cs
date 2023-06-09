using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
   [SerializeField] private GameObject verticalMoveObject;
   [SerializeField] private GameObject horizontalMoveObject;
   [SerializeField] private GameObject forwardBackMoveObject;

   [SerializeField] private float speed = 15f;
   private float _verticalSpeed;
   private float _horizontalSpeed;
   private float _forwardSpeed;
   
   public void MoveUp()
   {
      _verticalSpeed = 10f;
      Vector3 movementDown = new Vector3(transform.position.x, _verticalSpeed, transform.position.z);
      movementDown.Normalize();
      verticalMoveObject.transform.Translate(movementDown * speed * Time.deltaTime);
   }

   public void MoveDown()
   {
      _verticalSpeed = -10f;
      Vector3 movementDown = new Vector3(transform.position.x, _verticalSpeed, transform.position.z);
      movementDown.Normalize();
      verticalMoveObject.transform.Translate(movementDown * speed * Time.deltaTime);
   }
   
   public void MoveRight()
   {
      _horizontalSpeed = -10f;
      Vector3 movement = new Vector3(_horizontalSpeed, transform.position.y,  transform.position.z);
      movement.Normalize();  
      horizontalMoveObject.transform.Translate(movement * speed * Time.deltaTime);
   }
   
   public void MoveLeft()
   {
      _horizontalSpeed = 10f;
      Vector3 movement = new Vector3(_horizontalSpeed, transform.position.y,  transform.position.z);
      movement.Normalize();  
      horizontalMoveObject.transform.Translate(movement * speed * Time.deltaTime);
   }
   
   public void MoveForward()
   {
      _forwardSpeed = -10f;
      Vector3 movementDown = new Vector3(transform.position.x, transform.position.y, _forwardSpeed);
      movementDown.Normalize();
      forwardBackMoveObject.transform.Translate(movementDown * speed * Time.deltaTime);
   }
   
   public void MoveBack()
   {
      _forwardSpeed = 10f;
      Vector3 movementDown = new Vector3(transform.position.x, transform.position.y, _forwardSpeed);
      movementDown.Normalize();
      forwardBackMoveObject.transform.Translate(movementDown * speed * Time.deltaTime);
   }
}