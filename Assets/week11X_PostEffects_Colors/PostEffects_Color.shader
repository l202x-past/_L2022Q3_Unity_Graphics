Shader "My/PostEffects/Color"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Brightness ("Brightness", Range(0, 1)) = 1
        _Saturation ("Saturation", Range(0, 1)) = 1
        _Contrast ("Contrast", Range(0, 1)) = 1
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

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
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _Brightness;
            float _Saturation;
            float _Contrast;
            
            float3 BrightnessSaturationContrast(float3 color, float brightness, float saturation, float contrast){
                float avrgR = 0.5;
                float avrgG = 0.5;
                float avrgB = 0.5;
                
                float3 LuminanceCoeff = float3(0.2125, 0.7154, 0.0721);

                // brightness
                float3 AvrgLumin = float3(avrgR, avrgG, avrgB);
                float3 brtColor = color * brightness;
                float intensityf = dot(brtColor, LuminanceCoeff);
                float3 intensity = float3(intensityf, intensityf, intensityf);

                // saturation 
                float3 satColor = lerp(intensity, brtColor, saturation);

                // contrast 
                float3 conColor = lerp(AvrgLumin, satColor, contrast);
                
                return conColor;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                col.rgb = BrightnessSaturationContrast(col.rgb, _Brightness, _Saturation, _Contrast);
                return col;
            }
            ENDCG
        }
    }
}
