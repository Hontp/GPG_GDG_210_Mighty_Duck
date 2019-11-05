Shader "Custom/Fire"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }

		CGINCLUDE

		#include "UnityCG.cginc"

		sampler2D _MainTex;
		fixed4 _MainTex_ST;
		
		struct appdata
		{
			fixed4  vertex : POSITION;
			fixed4 color : COLOR;
			fixed3 uv : TEXCOORD0;
		};

		struct v2f
		{
			fixed3 uv : TEXCOORD0;
			fixed4 color : COLOR;
			fixed4 pos : SV_POSITION;
		};

	
		ENDCG

    SubShader
    {
        Tags 
		{ 
			"Queue" = "Transparent"
			"RenderType"="Opaque"			
		}

        LOD 100

		Blend SrcAlpha One
		ZWrite Off
	
        Pass
        {
            CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag


            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
				o.color = v.color;

				o.uv.xy = TRANSFORM_TEX(v.uv, _MainTex);

				o.uv.z = v.uv.z;

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

				col *= i.color;

				fixed particleAge = i.uv.z;
				fixed4 color = fixed4(1, 0, 0, 1);

				col = lerp(col, color * col.a, particleAge);

                return col;
            }
            ENDCG
        }
    }
}
