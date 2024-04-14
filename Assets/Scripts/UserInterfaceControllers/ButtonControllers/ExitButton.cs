using UnityEngine;
using UnityEngine.UI;

namespace UserInterfaceControllers.ButtonControllers
{
    public class ExitButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        
        private void Start()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}