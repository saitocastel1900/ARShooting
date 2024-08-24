using UniRx;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// 光源推定を管理する
/// </summary>
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
      /// 平均輝度
      /// </summary>
      private float? _averageBrightness;

      /// <summary>
      /// 光温度
      /// </summary>
      private float? _averageColorTemperature;
      
      /// <summary>
      /// 色調補正
      /// </summary>
      private Color? _colorCorrection;
      
      private void Start()
      {
         Observable.FromEvent<ARCameraFrameEventArgs>(
            handler => _cameraManager.frameReceived += handler,
            handler => _cameraManager.frameReceived -= handler
         ).Subscribe(SetVirtualLight).AddTo(this.gameObject);
      }

      /// <summary>
      /// 光源推定を行う
      /// </summary>
      /// <param name="eventArgs">光に関する情報</param>
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