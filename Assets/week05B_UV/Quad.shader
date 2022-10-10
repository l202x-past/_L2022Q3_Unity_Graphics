Shader "My/Quad"
{
    Properties
    {
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


        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex+0.5);
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex + _Time.x); //_Time.y-> more faster

            o.Albedo = c.rgb;
            //o.Emission = IN.uv_MainTex.y; //Α¶Έν
            o.Emission = float3(IN.uv_MainTex.x, IN.uv_MainTex.y, 0);
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
