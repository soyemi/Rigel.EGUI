#pragma once

namespace rg
{
	struct RgVec2
	{
		float x, y;
		RgVec2() { x = y = 0.0f; }
		RgVec2(float _x, float _y) { x = _x; y = _y; }
		RgVec2(float v) { x = y = v; }

	};

	struct RgVec4
	{
		float x, y, z, w;
		RgVec4() { x = y = z = w = 0.0f; }
		RgVec4(float _x, float _y, float _z, float _w) :x(_x), y(_y), z(_z), w(_w) {}
	};

	RgVec2 operator +(RgVec2& v1, RgVec2& v2);
}

