Shader "My/SurfaceShader/UV_Starter"
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
            float2 uv_MainTex; // vertex에 있는 uv 데이터
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            //o.Emission = IN.uv_MainTex.x;
            //o.Emission = IN.uv_MainTex.y;
            o.Emission = float3(IN.uv_MainTex.x, IN.uv_MainTex.y, 0); // U --> Red, V --> Green
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
