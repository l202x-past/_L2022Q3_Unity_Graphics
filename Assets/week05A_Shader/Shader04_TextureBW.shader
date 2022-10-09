Shader "My/SurfaceShader/TextureBW"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        // #pragma surface surf Standard fullforwardshadows // <-- fullforwardshadows »èÁ¦
        #pragma surface surf Standard 

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            //o.Albedo = c.rgb;
            o.Albedo = (c.r + c.g + c.b)/3;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
