using System.Linq;
using UnityEngine;

namespace GlobalSettings
{
    public class ScreenWrap : MonoBehaviour
    {
        private bool _isWrappingX;
        private bool _isWrappingY;
        private Renderer[] _renderers;

        private void Start() =>  _renderers = GetComponents<Renderer>();
        private void Update() => ScreenWrapObject();
        private void ScreenWrapObject()
        {
            if (IsVisible())
            {
                _isWrappingX = false;
                _isWrappingY = false;
                return;
            }

            var newPosition = transform.position;

            if (!_isWrappingX && (newPosition.x > 1 || newPosition.x < 0))
            {
                newPosition.x = -newPosition.x;
                _isWrappingX = true;
            }

            if (!_isWrappingY && (newPosition.y > 1 || newPosition.y < 0))
            {
                newPosition.y = -newPosition.y;
                _isWrappingY = true;
            }

            transform.position = newPosition;
        }

        private bool IsVisible()
        {
            return _renderers.Any(renderer => renderer.isVisible);
        }
    }
}