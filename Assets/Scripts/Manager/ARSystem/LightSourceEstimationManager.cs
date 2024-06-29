using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class LightSourceEstimationManager : MonoBehaviour
   {
      /// <summary>
      /// ARCameraManager
      /// </summary>
      [SerializeField] private ARCameraManager _cameraManager;

      /// <summary>
      /// DirectionLight
      /// </summary>
      [SerializeField] private Light _directionLight;
      
      /// <summary>
      ///
      /// </summary>
      private float? _averageBrightness;

      private float? _averageColorTemperature;
      
      private Color? _colorCorrection;

      /// <summary>
      /// 
      /// </summary>
      private void Start()
      {
         Observable.FromEvent<ARCameraFrameEventArgs>(
            handler => _cameraManager.frameReceived += handler,
            handler => _cameraManager.frameReceived -= handler
         ).Subscribe(SetVirtualLight).AddTo(this.gameObject);
      }

      /// <summary>
      /// 仮想カメラに光源推定で得た値を設定
      /// </summary>
      private void SetVirtualLight(ARCameraFrameEventArgs eventArgs)
      {
         var lightEst = eventArgs.lightEstimation;
         
         //環境光
         _averageBrightness = lightEst.averageBrightness;
         if (_averageBrightness.HasValue)
         {
            _directionLight.intensity = _averageBrightness.Value;
         }

         //色温度
         _averageColorTemperature = lightEst.averageColorTemperature;
         if (_averageColorTemperature.HasValue)
         {
            _directionLight.colorTemperature = _averageColorTemperature.Value;
         }
         
         //色補正
         _colorCorrection = lightEst.colorCorrection;
         if (_colorCorrection.HasValue)
         {
            _directionLight.color = _colorCorrection.Value;
         }
      }
}