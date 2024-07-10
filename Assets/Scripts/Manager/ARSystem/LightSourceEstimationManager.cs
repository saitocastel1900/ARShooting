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

      /// <summary>
      /// 
      /// </summary>
      private float? _averageColorTemperature;
      
      /// <summary>
      /// 
      /// </summary>
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
         Color color = Color.white;
         float intensity = 1.0f;
         var lightEst = eventArgs.lightEstimation;

         // 環境光
         _averageBrightness = lightEst.averageBrightness;
         if (_averageBrightness.HasValue)
         {
            intensity = Mathf.Clamp(_averageBrightness.Value, 0f, 1f);
         }

         // 色温度
         _averageColorTemperature = lightEst.averageColorTemperature;
         if (_averageColorTemperature.HasValue)
         {
            color = Mathf.CorrelatedColorTemperatureToRGB(_averageColorTemperature.Value);
         }

         // 色補正
         _colorCorrection = lightEst.colorCorrection;
         if (_colorCorrection.HasValue)
         {
            color *= _colorCorrection.Value;
         }

         Color estimatedLightColor  = color * intensity;
         _directionLight.color = estimatedLightColor ;
         RenderSettings.ambientSkyColor = estimatedLightColor ;
      }
}