using Models;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterfaceControllers.TextControllers
{
    public class PickedPointInfoText : MonoBehaviour
    {
        [SerializeField] private Text pickedPointInfoText;

        [SerializeField] private Color greenPointColor;
        [SerializeField] private Color yellowPointColor;
        [SerializeField] private Color redPointColor;
        
        private void OnEnable()
        {
            GreenPoint.OnPicked += SetGreenPointInfo;
            YellowPoint.OnPicked += SetYellowPointInfo;
            RedPoint.OnPicked += SetRedPointInfo;
        }
        
        private void OnDisable()
        {
            GreenPoint.OnPicked -= SetGreenPointInfo;
            YellowPoint.OnPicked -= SetYellowPointInfo;
            RedPoint.OnPicked -= SetRedPointInfo;
        }
        
        private void SetGreenPointInfo()
        {
            pickedPointInfoText.color = greenPointColor;
            pickedPointInfoText.text = "+1";
        }
        
        private void SetYellowPointInfo()
        {
            pickedPointInfoText.color = yellowPointColor;
            pickedPointInfoText.text = "-10";
        }
        
        private void SetRedPointInfo()
        {
            pickedPointInfoText.color = redPointColor;
            pickedPointInfoText.text = "game over";
        }
    }
}