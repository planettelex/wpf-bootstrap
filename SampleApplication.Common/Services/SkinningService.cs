using System;
using System.Collections.Generic;
using System.Windows;

namespace SampleApplication.Common.Services
{
    /// <summary>
    /// Service for managing application skins, which are named collections of brushes and icons.
    /// </summary>
    public class SkinningService : ISkinningService
    {
        public SkinningService()
        {
            _skins = new Dictionary<string, string>
            {
                {"default", "/SampleApplication.Resources;component/Skins/Default/Skin.xaml"},
                {"light", "/SampleApplication.Resources;component/Skins/Light/Skin.xaml"},
                {"dark", "/SampleApplication.Resources;component/Skins/Dark/Skin.xaml"}
            };
        }
        private readonly Dictionary<string, string> _skins;

        /// <summary>
        /// Sets the skin.
        /// </summary>
        /// <param name="skinName">Name of the skin.</param>
        public void SetSkin(string skinName)
        {
            if (!_skins.ContainsKey(skinName.ToLower()))
                return;

            if (!UriParser.IsKnownScheme("pack"))
                UriParser.Register(new GenericUriParser(GenericUriParserOptions.GenericAuthority), "pack", -1);

            var skinUri = new Uri(_skins[skinName.ToLower()], UriKind.Relative);
            var skin = new ResourceDictionary { Source = skinUri };

            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(skin);
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/SampleApplication.Resources;component/Resources.xaml", UriKind.RelativeOrAbsolute)
            });
        }
    }
}
