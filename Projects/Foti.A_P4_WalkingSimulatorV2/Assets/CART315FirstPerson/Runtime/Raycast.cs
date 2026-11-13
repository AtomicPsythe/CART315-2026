using UnityEngine;
using UnityEngine.UI;

namespace Cart315.FirstPerson
{
    public class Raycast : MonoBehaviour
    {
        // raycast features
        [SerializeField] private float rayLength = 5;
        private Camera _camera;

        private NoteController _noteController;

        // crosshair
        [SerializeField] private Image crosshair;

        // input key
        [SerializeField] private KeyCode interactKey;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _camera = GetComponent<Camera>();
        }

        // Update is called once per frame
        private void Update()
        {
            if(Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hit, rayLength))
            {
                var readableItem = hit.collider.GetComponent<NoteController>(); 
                if(readableItem != null)
                {
                    _noteController = readableItem;
                    HighlightCrosshair(true);
                }
                else
                {
                    ClearNote();
                }
            }
            else
            {
                ClearNote();
            }

            if (_noteController != null)
            {
                if (Input.GetKeyDown(interactKey))
                {
                    _noteController.ShowNote();
                }
            }
        }

        void ClearNote()
        {
            if (_noteController != null)
            {
                HighlightCrosshair(false);
                _noteController = null;
            }
        }

        void HighlightCrosshair(bool on)
        {
            if (on)
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.white;
            }
        }
    }
}
