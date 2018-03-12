using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;
using UMS.Types;
using UMS.Deserialization;
using TMPro;
using Newtonsoft.Json;

namespace UMS_TextMeshPro.Types
{
    public class SerializableTMP_FontAsset : SerializableTMP_Asset<TMP_FontAsset, SerializableTMP_FontAsset>
    {
        public override string Extension => "fontAsset";

        public SerializableTMP_FontAsset() { }
        public SerializableTMP_FontAsset(TMP_FontAsset obj)
        {
            _fontAssetType = obj.fontAssetType;
            _italicStyle = obj.italicStyle;
            _boldSpacing = obj.boldSpacing;
            _boldStyle = obj.boldStyle;
            _normalStyle = obj.normalStyle;
            _normalSpacingOffset = obj.normalSpacingOffset;
            _tabSize = obj.tabSize;
            _fontCreationSettings = obj.fontCreationSettings;
            _fallbackFontAssets = new List<Reference>(obj.fallbackFontAssets.Select(x => Reference.Create(x)));
            _atlas = Reference.Create(obj.atlas);

            _fontWeights = new Reference[obj.fontWeights.Length];
            for (int i = 0; i < obj.fontWeights.Length; i++)
            {
                _fontWeights[i] = Reference.Create(obj.fontWeights[i]);
            }
        }

        [JsonProperty]
        private TMP_FontAsset.FontAssetTypes _fontAssetType;
        [JsonProperty]
        private byte _italicStyle;
        [JsonProperty]
        private float _boldSpacing;
        [JsonProperty]
        private float _boldStyle;
        [JsonProperty]
        private float _normalStyle;
        [JsonProperty]
        private float _normalSpacingOffset;
        [JsonProperty]
        private byte _tabSize;
        [JsonProperty]
        private Reference[] _fontWeights;
        [JsonProperty]
        private FontCreationSetting _fontCreationSettings;
        [JsonProperty]
        private List<Reference> _fallbackFontAssets;
        [JsonProperty]
        private Reference _atlas;

        public override TMP_FontAsset Deserialize()
        {
            TMP_FontAsset asset = ScriptableObject.CreateInstance<TMP_FontAsset>();

            asset.fontAssetType = _fontAssetType;
            asset.italicStyle = _italicStyle;
            asset.boldSpacing = _boldSpacing;
            asset.boldStyle = _boldStyle;
            asset.normalStyle = _normalStyle;
            asset.normalSpacingOffset = _normalSpacingOffset;
            asset.fontCreationSettings = _fontCreationSettings;

            asset.fontWeights = new TMP_FontWeights[_fontWeights.Length];
            for (int i = 0; i < _fontWeights.Length; i++)
            {
                Deserializer.GetDeserializedObject<TMP_FontWeights>(_fontWeights[i].ID, x =>
                {
                    asset.fontWeights[i] = x;
                });
            }

            asset.fallbackFontAssets = new List<TMP_FontAsset>(_fallbackFontAssets.Count);
            for (int i = 0; i < _fallbackFontAssets.Count; i++)
            {
                Deserializer.GetDeserializedObject<TMP_FontAsset>(_fallbackFontAssets[i].ID, x =>
                {
                    asset.fallbackFontAssets[i] = x;
                });
            }

            Deserializer.GetDeserializedObject<Texture2D>(_atlas.ID, x =>
            {
                asset.atlas = x;
            });
            
            return asset;
        }
        public static SerializableTMP_FontAsset Serialize(TMP_FontAsset obj)
        {
            return new SerializableTMP_FontAsset(obj);
        }
    }
}
