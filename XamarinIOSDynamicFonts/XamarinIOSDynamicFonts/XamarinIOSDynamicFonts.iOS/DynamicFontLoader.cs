using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinIOSDynamicFonts;

using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinIOSDynamicFonts.iOS.IOSFontLoader))]
namespace XamarinIOSDynamicFonts.iOS
{
    public class IOSFontLoader : IFontLoader
    {
        public void LoadFile(string bundleName)
        {
            NSError t;
            CoreGraphics.CGDataProvider provider = CoreGraphics.CGDataProvider.FromFile(bundleName);
            if(provider == null)
            {
                Console.WriteLine("Provider " + bundleName + " is not valid.");
                return;
            }
            //ProTip: Examine font in a dubugger to see details of the font file.
            //Expand font->non-public->PostScriptName to get the FontFamily
            CoreGraphics.CGFont font = CoreGraphics.CGFont.CreateFromProvider(provider);
            if(!CoreText.CTFontManager.RegisterGraphicsFont(font, out t))
            {
                Console.WriteLine("Unable to register font file: " + bundleName);
            }
        }
    }
}