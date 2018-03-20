# Xamarin Dynamic iOS Fonts
*A Visual Studio 2017 project that uses the Xamarian DependencyService to dynamically load a bundle file as a font.*

Custom fonts are commonly used function in apps.  And the Xamarin live player (https://www.xamarin.com/live) is a great way to quickly debug apps on your device.  However, a limitation of the Live Player is it cannot load resources using the info.plist file which is the most widely documented method for loading custom fonts.  To get around this limitation, or to just load fonts as needed, fonts on iOS can be loaded dynamically via code.  This project is a sample to show the minimum code neded to accomplish dynamic font loading.  

# Necessary Steps!
1) Add the fonts to the Resources folder as a `BundleResource` and `Copy Always`.
2) Add an interface that defines the contract for the DependencyService.
```cs
    public interface IFontLoader
    {
        void LoadFile(string bundleName);
    }
    
```
3) Add an assembly to the iOS project that that implements the interface as a dependency.
```cs

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
```
4) Add code to the App.xml.cs file to load the files(s) via the dependency service
```cs
DependencyService.Get<IFontLoader>().LoadFile("FontAwesome.ttf");
```
