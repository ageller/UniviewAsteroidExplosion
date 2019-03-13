uniform float uv_fade;

uniform sampler2D cmap;
uniform float eventTime;
uniform float tfac;
uniform float tmax;

in vec2 texcoord;
in float time;

out vec4 fragColor;

void main()
{
	vec3 color = texture(cmap ,vec2(clamp(time/tmax,0.,0.99),0.5)).rgb;
	float alpha = 1. - clamp(abs(eventTime - time)/tmax*tfac, 0., 1.);

    fragColor = vec4(color, alpha);
    fragColor.a *= uv_fade;
    vec2 fromCenter = texcoord * 2 - vec2(1);
    float dist = dot(fromCenter, fromCenter);
    if (dist > 1){
    	discard;
    }
	//fragColor.a *= exp(-0.5*dist/0.1);
    //fragColor.a *= smoothstep(-1.5, -0.5, -length(fwidth(texcoord.xy)));
    //fragColor.a *= pow(max(0, 1 - dot(fromCenter, fromCenter)), 2);
}
