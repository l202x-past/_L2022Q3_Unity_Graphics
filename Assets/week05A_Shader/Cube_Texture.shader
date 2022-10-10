Shader "My/Cube_Texture"
{
    Properties
    {
        //_Color ("Color", Color) = (1,1,1,1) //주석처리시 색상 검은색
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        
        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        
        //fixed4 _Color;


        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            //o.Albedo = c.rgb;
            o.Albedo = (c.r + c.g + c.b) / 3;
            //o.Albedo = 0.5;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
