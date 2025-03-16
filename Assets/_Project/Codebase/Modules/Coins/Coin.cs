using _Project.Codebase.Modules.Player;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Modules.Coins
{
    public class Coin : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.TryGetComponent(out CoinsController coinsController))
            {
                coinsController.AddCoin();
                Destroy(gameObject);
            }
        }

        public class Factory : PlaceholderFactory<Coin>{}
    }
}