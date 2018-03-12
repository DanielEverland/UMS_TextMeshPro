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

        }

        [JsonIgnore]
        private int _deserializedWeightsCount;
        [JsonIgnore]
        private TMP_FontWeights[] _deserializedWeights;
        [JsonIgnore]
        private int _deserializedFontAssetsCount;
        [JsonIgnore]
        private List<TMP_FontAsset> _deserializedFontAssets;

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

        public override TMP_FontAsset Deserialize(SerializableTMP_FontAsset serializable)
        {
            TMP_FontAsset asset = ScriptableObject.CreateInstance<TMP_FontAsset>();

            asset.fontAssetType = serializable._fontAssetType;
            asset.italicStyle = serializable._italicStyle;
            asset.boldSpacing = serializable._boldSpacing;
            asset.boldStyle = serializable._boldStyle;
            asset.normalStyle = serializable._normalStyle;
            asset.normalSpacingOffset = serializable._normalSpacingOffset;
            asset.fontCreationSettings = serializable._fontCreationSettings;



            Deserializer.GetDeserializedObject<Texture2D>(serializable._atlas.ID, texture =>
            {
                asset.atlas = texture;
            });

            

            return asset;
        }
        private void DeserializeWeights(SerializableTMP_FontAsset serializable)
        {
            serializable._deserializedWeightsCount = serializable._fontWeights.Length;


        }
        public override SerializableTMP_FontAsset Serialize(TMP_FontAsset obj)
        {
            return new SerializableTMP_FontAsset(obj);
        }
    }
}
