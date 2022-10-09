Shader "My/SurfaceShader/UV_Time"
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

        /*******************************************
        _Time.x = 1/20, _Time.y = 1, _Time.z = 2, _Time.w = 3 // 씬이 열린 후 경과한 시간 
        _SinTime.x = t/8, _SinTime.y = t/4, _SinTime.z = t/2, _SinTime.w = t
        _CosTime.x = t/8, _CosTime.y = t/4, _CosTime.z = t/2, _CosTime.w = t
        unity_DeltaTime.x = dt, unity_DeltaTime.y = 1/dt, unity_DeltaTime.z = smoothDt, unity_DeltaTime.w = 1/smoothDt // 이전 frame 이후 경과한 시간
        *******************************************/
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex + _Time.y);
            //fixed4 c = tex2D (_MainTex, float2(IN.uv_MainTex.x + _Time.y, IN.uv_MainTex.y)); // x 축으로 이동
            fixed4 c = tex2D (_MainTex, float2(IN.uv_MainTex.x, IN.uv_MainTex.y + _Time.y)); // y 축으로 이동
            //o.Albedo = c.rgb;
            o.Emission = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
