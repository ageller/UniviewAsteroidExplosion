uniform float uv_fade;

uniform sampler2D cmap;
uniform float eventTime;
uniform float alpha;
uniform float dMin;
uniform float dMax;

in vec2 texcoord;
in float damage;

out vec4 fragColor;

void main()
{
	//set the color
	vec3 color = texture(cmap ,vec2(clamp((damage - dMin)/(dMax - dMin),0.,0.99),0.5)).rgb;

	fragColor = vec4(color, alpha);
	fragColor.a *= uv_fade;

	//make this a circle
	vec2 fromCenter = texcoord * 2 - vec2(1);
	float dist = dot(fromCenter, fromCenter);
	if (dist > 1){
		discard;
	}

}
