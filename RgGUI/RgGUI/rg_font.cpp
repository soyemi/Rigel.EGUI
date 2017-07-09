#include "rg_font.h"

namespace rg
{
	namespace font
	{

		void RgFont_FreeType_Init()
		{
			if (s_ftInited) return;
			FT_Error err;
			err = FT_Init_FreeType(&s_ftLibrary);

			if (err)
			{
				RgLogE() << "FreeType init error:" << err;
				return;
			}
			RgLogD() << "FreeType init done!" << err;
			s_ftInited = true;

		}

		void RgFont_FreeType_Release()
		{

		}

		bool RgFontFreeType::LoadFont(LPCSTR fontpath, RgFontFreeType * font)
		{
			if (!s_ftInited) return false;
			FT_Error err;
			FT_Face * face = new FT_Face();
			err = FT_New_Face(s_ftLibrary, fontpath, 0, face);
			if (err)
			{
				RgLogE() << "FreeType load error:" << err;
				return false;
			}

			font = new RgFontFreeType(face);
			return true;
		}

		RgFontFreeType::~RgFontFreeType()
		{
			Release();
		}

		RgFontFreeType::RgFontFreeType(FT_Face * face)
		{
			m_pFtFace = face;
		}

		void RgFontFreeType::Release()
		{
		}

	}
}
