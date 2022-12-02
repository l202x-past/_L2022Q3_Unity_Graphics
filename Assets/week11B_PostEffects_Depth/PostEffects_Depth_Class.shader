Shader "My/PostEffects/Depth_Class"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Depth("Depth", Range(0, 1)) = 1
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
            sampler2D _CameraDepthTexture;
            float _Depth;

            fixed4 frag(v2f i) : SV_Target
            {
                /*
                fixed depth = UNITY_SAMPLE_DEPTH(tex2D(_CameraDepthTexture, i.uv));
                fixed4 col = fixed4(depth, depth, depth, 1.0) * _Depth;
                return col;
                */
                fixed depth = UNITY_SAMPLE_DEPTH(tex2D(_CameraDepthTexture, i.uv));
                fixed4 col = (Linear01Depth(depth) * _Depth);
                return col;


            }
            ENDCG
        }
    }
}
