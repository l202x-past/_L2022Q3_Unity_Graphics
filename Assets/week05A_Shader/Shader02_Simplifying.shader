Shader "My/SurfaceShader/Simplifying"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1) 
        _MainTex ("Albedo (RGB)", 2D) = "white" {}    
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5  // <-- RM.
        //_Metallic ("Metallic", Range(0,1)) = 0.0      // <-- RM.
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        //LOD 200                                       // <-- RM.

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        //#pragma target 3.0                            // <-- RM.

        sampler2D _MainTex;                             

        struct Input
        {
            float2 uv_MainTex;
        };

        //half _Glossiness;                             // <-- RM.
        //half _Metallic;                               // <-- RM.
        fixed4 _Color;                                  

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        //UNITY_INSTANCING_BUFFER_START(Props)          // <-- RM.
            // put more per-instance properties here
        //UNITY_INSTANCING_BUFFER_END(Props)            // <-- RM.
         
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;     
            o.Albedo = c.rgb;
            //o.Metallic = _Metallic;                   // <-- RM.
            //o.Smoothness = _Glossiness;               // <-- RM.
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
