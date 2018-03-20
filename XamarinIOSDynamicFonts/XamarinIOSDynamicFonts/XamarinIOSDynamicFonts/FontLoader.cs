using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinIOSDynamicFonts
{
    public interface IFontLoader
    {
        void LoadFile(string bundleName);
    }
}
