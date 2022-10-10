Shader "My/SurfaceShader/UV_Flame2"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _MainTex2 ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent"} // <-- 수정

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows alpha:fade // <-- 수정

        sampler2D _MainTex;
        sampler2D _MainTex2; // <-- 수정

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MainTex2; // <-- 수정
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {            
            fixed4 d = tex2D (_MainTex2, float2(IN.uv_MainTex2.x, IN.uv_MainTex2.y - _Time.y)); // <-- 수정
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex + d.r);
            o.Emission = c.rgb; // <-- 수정
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
