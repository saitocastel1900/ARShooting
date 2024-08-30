Shader "Custom/ARHole"
{
    Properties
    {
        _RectSize("RectSize", Range(0,1)) = 0.5
    }

    SubShader
    {
        Tags
        {
            "Queue"="geometry-1"
        }

        Blend Zero SrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float _RectSize;

            float rectangle(float2 p, float2 size)
            {
                return max(abs(p.x) - size.x, abs(p.y) - size.y);
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 f_st = frac(i.uv) * 2 - 1;
                float ri = rectangle(f_st,float2(0,0));
                float4 col = step(_RectSize, ri);

                clip(col.a - 0.5);
                return col;
            }
            ENDCG
        }
    }
}