using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Module.Enemy;
using Roguelike.Module.Bullet;
using Roguelike.Utility;

namespace Roguelike.Module.Weapon 
{
    public class WeaponController : ObjectController<WeaponController, WeaponModel, IWeaponModel, WeaponView>
    {
        private GundBitsController _gundBitsController;
        private Animator _anim;

        public void Init(WeaponModel model, WeaponView view) {
            SetView(view);
            _model = model;
            _model.SetStats(_view.Stats);
            _model.SetWeaponName(_view.WeaponName);
            _model.SetWeaponType(_view.WeaponType);
            _model.InitStats();
            if (_view.TryGetComponent(out Animator animator))
            {
                _anim = animator;
            }

            switch (_model.WeaponType) {
                case WeaponType.FollowPlayer:
                    _view.transform.parent = _model.Player.transform;
                    _view.transform.position = new Vector3(0, 0, 0);
                    break;
                case WeaponType.Spawner:
                    WeaponSpawnerPoolView pool = _view.GetComponent<WeaponSpawnerPoolView>();
                    WeaponSpawnerPoolModel poolModel = new WeaponSpawnerPoolModel();
                    WeaponSpawnerPoolController poolController = new WeaponSpawnerPoolController();
                    InjectDependencies(poolController);
                    poolController.Init(poolModel, pool, this);
                    _view.gameObject.SetActive(false);
                    break;
                default:
                    break;
            }

            switch (_model.WeaponName) {
                case WeaponName.DefaultWeapon:
                    BulletPoolView bulletPoolView = _view.GetComponent<BulletPoolView>();
                    BulletPoolModel bulletPoolModel = new BulletPoolModel();
                    BulletPoolController bulletPoolController = new BulletPoolController();
                    InjectDependencies(bulletPoolController);
                    bulletPoolController.Init(bulletPoolModel, bulletPoolView, this);
                    break;
                case WeaponName.GundBits:
                    GundBitsView bits = _view.GetComponent<GundBitsView>();
                    GundBitsModel gundBitsModel = new GundBitsModel();
                    _gundBitsController = new GundBitsController();
                    InjectDependencies(_gundBitsController);
                    _gundBitsController.Init(gundBitsModel, bits);
                    _view.gameObject.SetActive(false);
                    break;
                default:
                    _view.gameObject.SetActive(false);
                    break;
            }
        }

        public override void SetView(WeaponView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnCollideWithEnemy);
        }

        public void OnCollideWithEnemy(EnemyView enemy) {
            enemy.OnTakeDamage?.Invoke(_model.Damage);
        }

        public void Activate() {
/*            if (_model.WeaponType.Equals(WeaponType.Spawner)) {
                WeaponView weaponView;
                for (int i = 0; i< _model.NumberOfSpawnPool ;i++ ) {
                    GameObject selectedWeapon = Object.Instantiate(_view.SpawnPrefab);
                    if (selectedWeapon.TryGetComponent(out WeaponView view))
                    {
                        weaponView = view;
                    }
                    else { 
                        weaponView = selectedWeapon.AddComponent<WeaponView>();
                    }
                    weaponView.Stats = _view.Stats;
                    WeaponModel weaponModel = new WeaponModel();
                    WeaponController weaponController = new WeaponController();

                    InjectDependencies(weaponController);
                    weaponController.Init(weaponModel, weaponView);
                    _model.AddSpawnPool(weaponController);
                }

                foreach (Transform child in _view.transform)
                    child.gameObject.SetActive(false);
            }*/

            _view.gameObject.SetActive(true);
            _model.LevelUpWeapon();
            if (_anim != null)
            {
                _anim.SetInteger("Lvl", _model.WeaponLevel);
            }
        }

        public void SetTrigger()
        {
            _anim.SetTrigger("Trigger");
        }

        public void LevelUpWeapon() {
            _model.LevelUpWeapon();
            switch (_model.WeaponName)
            {
                case WeaponName.DefaultWeapon:
                    break;
                case WeaponName.GundBits:
                    _gundBitsController.ActivateBit(_model.CurrentStat.NumberOfInstance); 
                    break;
                case WeaponName.LandMine:
                    break;
                default:
                    _anim.SetInteger("Lvl", _model.WeaponLevel);
                    break;
            }
        }   
    }
}

