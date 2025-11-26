using System;
using System.IO;
using PdfSharp.Fonts;

namespace RCTemp.PdfFonts
{
    // Simple IFontResolver implementation:
    // - Maps requested family/style to a face name
    // - Loads corresponding .ttf bytes from a "fonts" folder under the app base directory
    //
    // Place the required TTF files in: <app>/fonts/
    //   arial.ttf, arialbd.ttf, ariali.ttf, arialbi.ttf
    //
    // Register before creating any PDF fonts:
    //   GlobalFontSettings.FontResolver = new SimpleFontResolver();
    public class SimpleFontResolver : IFontResolver
    {
        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            var family = (familyName ?? string.Empty).Trim().ToLowerInvariant();

            // Prefer Arial for unknown/unsupported families. Extend this map as needed.
            if (family.Contains("arial") || family.Contains("helvetica") || string.IsNullOrEmpty(family))
            {
                if (isBold && isItalic) return new FontResolverInfo("Arial#BoldItalic");
                if (isBold) return new FontResolverInfo("Arial#Bold");
                if (isItalic) return new FontResolverInfo("Arial#Italic");
                return new FontResolverInfo("Arial#Regular");
            }

            // fallback to Arial regular
            return new FontResolverInfo("Arial#Regular");
        }

        public byte[] GetFont(string faceName)
        {
            // faceName values must match those returned by ResolveTypeface.
            string fileName;

            // Use C# 7.3 compatible switch statement (switch-expression not supported)
            switch (faceName)
            {
                case "Arial#Regular":
                    fileName = "arial.ttf";
                    break;
                case "Arial#Bold":
                    fileName = "arialbd.ttf";
                    break;
                case "Arial#Italic":
                    fileName = "ariali.ttf";
                    break;
                case "Arial#BoldItalic":
                    fileName = "arialbi.ttf";
                    break;
                default:
                    throw new FileNotFoundException(string.Format("No font mapping for face name '{0}'.", faceName));
            }

            var fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fonts", fileName);

            if (!File.Exists(fontPath))
            {
                throw new FileNotFoundException(
                    $"Font file not found: {fontPath}. Add the file to the 'fonts' folder or update SimpleFontResolver mappings.");
            }

            return File.ReadAllBytes(fontPath);
        }
    }
}