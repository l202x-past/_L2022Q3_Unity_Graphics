Shader "My/SurfaceShader/Simplifying"
{
    Properties
    {
        //_Color ("Color", Color) = (1,1,1,1) // <-- 삭제
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5 // <-- 삭제
        //_Metallic ("Metallic", Range(0,1)) = 0.0 // <-- 삭제
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        //LOD 200 // <-- 삭제

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        //#pragma target 3.0 // <-- 삭제

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        //half _Glossiness; // <-- 삭제
        //half _Metallic; // <-- 삭제
        //fixed4 _Color; // <-- 삭제

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        //UNITY_INSTANCING_BUFFER_START(Props) // <-- 삭제
            // put more per-instance properties here
        //UNITY_INSTANCING_BUFFER_END(Props) // <-- 삭제
         
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color; // <-- 수정
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex); // <-- 수정
            o.Albedo = c.rgb;
            //o.Metallic = _Metallic; // <-- 삭제
            //o.Smoothness = _Glossiness; // <-- 삭제
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
