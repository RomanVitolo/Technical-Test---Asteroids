using UnityEngine;
using UnityEngine.Events;

namespace PlayerBehaviour
{
    public class PlayerInput : MonoBehaviour
    {
        [field: SerializeField] public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
        [field: SerializeField] public UnityEvent OnFireButtonPressed{ get; set; }

        private bool fireButton;

        private void FixedUpdate()
        {
            GetMovementInput();
            GetFireInput();
        }
        private void GetFireInput()
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
                }
            }
        }

        private void GetMovementInput()
        {
            OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }
    }

}
