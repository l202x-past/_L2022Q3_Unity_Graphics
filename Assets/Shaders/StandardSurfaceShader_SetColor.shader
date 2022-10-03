Shader "My/StandardSurfaceShader/Test01_SetColor"
{
    Properties
    {
        /*********************************************
        * Float 인터페이스
        * _Name ("display name", Range (min, max)) = number
        * _Name ("display name", Float) = number
        * _Name ("display name", int) = number

        * Float4 인터페이스
        * _Name ("display name", Color) = (number, number, number, number)
        * _Name ("display name", Vector) = (number, number, number, number)

        * 기타 Sampler 인터페이스
        * _Name ("display name", 2D) = "name" { options }
        * _Name ("display name", Rect) = "name" { options }
        * _Name ("display name", Cube) = "name" { options }
        * _Name ("display name", 3D) = "name" { options }
        *********************************************/

        _Color ("Color", Color) = (1,0,0,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            //o.Albedo = c.rgb;
            o.Albedo = float3(1, 0, 0); // Albedo 색상을 설정함
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
