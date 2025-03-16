using _Project.Codebase.Modules.UI;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Modules.Player
{
    public class CoinsController : MonoBehaviour
    {
        private CoinPanel _coinPanel;
        private int _currentAmount;

        [Inject]
        public void Construct(CoinPanel coinPanel)
        {
            _coinPanel = coinPanel;
        }

        public void AddCoin()
        {
            _currentAmount++;
            _coinPanel.IncreaseCoinValue(_currentAmount);
        }
    }
}