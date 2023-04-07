using UnityEngine;

namespace GlobalSettings
{
    public class ShowOrHideCursor : MonoBehaviour
    {
        [SerializeField] private bool activeOrDeactivated;
        private void Start()
        {
            CursorVisibility();
        }

        private void CursorVisibility()
        {
            Cursor.visible = activeOrDeactivated;
        }
    }
}
