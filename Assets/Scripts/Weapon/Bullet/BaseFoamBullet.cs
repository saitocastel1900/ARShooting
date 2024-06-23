using UniRx;
using UnityEngine;

    public abstract class BaseFoamBullet : MonoBehaviour
    {
        /// <summary>
        /// MoleCore
        /// </summary>
        protected FoamBulletCore _foamBulletCore;
        
        private void Start()
        {
            _foamBulletCore = this.gameObject.GetComponent<FoamBulletCore>();
            _foamBulletCore.OnInitialized.Subscribe(_=>OnInitialize()).AddTo(this);
            
            OnStart();
        }

        protected virtual void OnStart() { }

        protected abstract void OnInitialize();
    }
