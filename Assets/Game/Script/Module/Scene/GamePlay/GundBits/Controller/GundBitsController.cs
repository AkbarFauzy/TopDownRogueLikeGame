using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Weapon {
    public class GundBitsController : ObjectController<GundBitsController, GundBitsModel, IGundBitsModel, GundBitsView>
    {
        public void Init(GundBitsModel model, GundBitsView view) {
            SetView(view);
            _model = model;
            //Instantite bits
            for (int i = 0; i < _model.NumberOfBits; i++)
            {
                Vector2 spawnPosition = (Vector2)_view.transform.position + Random.insideUnitCircle * 2f;
                GameObject bit = Object.Instantiate(_view.BitPrefab, spawnPosition, Quaternion.identity, _view.transform);

                BitView bitView = bit.GetComponent<BitView>();
                BitController bitController = new BitController();
                BitModel bitModel = new BitModel();

                InjectDependencies(bitController);
                bitController.Init(bitModel, bitView);
                bit.SetActive(false);
                _model.AddBit(bit);
            }
            ActivateBit(1);
        }

        public void ActivateBit(int num) {
            for (int i = 0; i < num; i++) {
                _model.Bits[i].SetActive(true);
            }
        }
    }
}

