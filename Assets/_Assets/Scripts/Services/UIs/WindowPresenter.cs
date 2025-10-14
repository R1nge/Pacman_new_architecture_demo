using UnityEngine;

namespace _Assets.Scripts.Services.UIs
{
    public class WindowPresenter : MonoBehaviour
    {
        [SerializeField] private WindowView windowView;
        public int Order { get; set; }
        public bool IsActive { get; private set; }

        public void Open()
        {
            IsActive = true;
            windowView.Open(Order);
        }

        public void Close()
        {
            IsActive = false;
            windowView.Close();
        }
    }
}