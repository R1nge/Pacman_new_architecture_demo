using UnityEngine;

namespace _Assets.Scripts.Services.UIs
{
    public class LoadingWindowView : WindowView
    {
        public override void Open(int sortingOrder)
        {
            base.Open(sortingOrder);
            Debug.Log("OPEN LOADING WINDOW");
        }

        public override void Close()
        {
            base.Close();
            Debug.Log("CLOSE LOADING WINDOW");
        }
    }
}