using TMPro;
using UnityEngine;

namespace _Project.Codebase.Modules.UI
{
    public class CoinPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;

        public void IncreaseCoinValue(int amount)
        {
            coinText.text = amount.ToString();
        }
    }
}