Shader "My/SurfaceShader/UV_Operation"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex + 0.1); // add value to uv in all vertex. uv increases to move texture to left-down side
            o.Albedo = c.rgb;
            o.Emission = float3(IN.uv_MainTex.x, IN.uv_MainTex.y, 0);
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
