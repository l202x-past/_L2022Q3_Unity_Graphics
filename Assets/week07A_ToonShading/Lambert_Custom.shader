Shader "My/Lambert/Custom"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM

        // added MyCustom
        // added noambient
        #pragma surface surf MyCustom noambient

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }

        //define MyCuston function
        // function name should be defined like "Lighting" + "MyCustom"
        /***********************************
        // https://docs.unity3d.com/kr/2021.3/Manual/SL-SurfaceShaders.html
        struct SurfaceOutput
        {
            fixed3 Albedo;  // diffuse color
            fixed3 Normal;  // tangent space normal, if written
            fixed3 Emission;
            half Specular;  // specular power in 0..1 range
            fixed Gloss;    // specular intensity
            fixed Alpha;    // alpha for transparencies
        };
        ***********************************/
        float4 LightingMyCustom(SurfaceOutput s, float3 lightDir, float atten){
            return float4(1, 0, 0, 1);
        }

        ENDCG
    }
    FallBack "Diffuse"
}
