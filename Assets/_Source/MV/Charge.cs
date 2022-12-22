using Player;
using ScriptableObjects;
using StateSystem;
using System;
using UnityEngine;

namespace MV
{
    public class Charge
    {
        private Hud _uiView;
        private ChargeSO _chargeSO;
        private ShootingInput _shootingInput;
        private int _nowCharge;

        public static Action OnChargeChange;
        public static Action OnExpose;

        public Charge(Hud uiView, ChargeSO chargeSO, ShootingInput shootingInput)
        {
            _uiView = uiView;
            _uiView.Bind(chargeSO.maxCharge);
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
            _uiView.UpdateChargeView(_nowCharge);
            if (_nowCharge <= 0)
            {
                _nowCharge = _chargeSO.maxCharge;
                _shootingInput.SetReloadTime(_chargeSO.reloadTime);
            }
        }
    }
}