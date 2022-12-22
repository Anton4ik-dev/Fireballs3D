using Player;
using ScriptableObjects;
using System;

namespace MV
{
    public class Charge
    {
        private ScoreAndChargeView _scoreAndChargeView;
        private ChargeSO _chargeSO;
        private ShootingInput _shootingInput;
        private int _nowCharge;

        public static Action OnChargeChange;
        public static Action OnExpose;

        public Charge(ScoreAndChargeView scoreAndChargeView, ChargeSO chargeSO, ShootingInput shootingInput)
        {
            _scoreAndChargeView = scoreAndChargeView;
            _scoreAndChargeView.Bind(chargeSO.maxCharge);

            _chargeSO = chargeSO;
            _nowCharge = chargeSO.maxCharge;

            _shootingInput = shootingInput;

            Bind();
        }

        private void Bind()
        {
            OnChargeChange += ChangeCharge;
            OnExpose += Expose;
        }

        private void Expose()
        {
            OnChargeChange -= ChangeCharge;
            OnExpose -= Expose;
        }

        private void ChangeCharge()
        {
            _nowCharge -= _chargeSO.shootCost;
            _scoreAndChargeView.UpdateChargeView(_nowCharge);

            if (_nowCharge <= 0)
            {
                _nowCharge = _chargeSO.maxCharge;
                _shootingInput.SetReloadTime(_chargeSO.reloadTime);
            }
        }
    }
}