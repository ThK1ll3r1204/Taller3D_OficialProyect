void IceDepth_half (
	in Texture2D Texture,
	in float2 UV,
	in SamplerState SS,
	in float Samples,
	in float Offset,
	in float3 WPos,
	in float Lerp,
	in int LOD,
	out float4 Out)
	{
		half4 col = 0;
		half u_off = 0;
		half v_off = 0;
		half Samples = Samples;

		for (int s=0; s < samples; s++)
		{
			float2 uvs = float2 (u_off, v_off);
			col += SAMPLE_TEXTURE2D_LOD (Texture, SS, uvs + UV, LOD);
			v_off += Offset * (_WorldSpaceCamaraPos.z - WPos.z)
			u_off += Offset * (_WorldSpaceCamaraPos.x - WPos.x)
		}

		half4 render = (col /= samples);
		Out = lerp (SAMPLE_TEXTURE2D(Texture,SS,UV),render,Lerp);
	}