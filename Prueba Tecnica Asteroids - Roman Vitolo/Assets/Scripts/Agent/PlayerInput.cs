using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
   [field: SerializeField] public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
   [field: SerializeField] public UnityEvent OnFireButtonPressed{ get; set; }
   [field: SerializeField] public UnityEvent OnFireButtonReleased{ get; set; }

   private bool fireButton;

   private void FixedUpdate()
   {
      GetMovementInput();
      GetFiretInput();
   }

   private void GetFiretInput()
   {
      if (Input.GetAxis("Fire1") > 0)
      {
         if (fireButton == false)
         {
            fireButton = true;
            OnFireButtonPressed?.Invoke();
         }
      }
      else
      {
         if (fireButton)
         {
            fireButton = false;
            OnFireButtonReleased?.Invoke();
         }
      }
   }

   private void GetMovementInput()
   {
      OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
   }
}
