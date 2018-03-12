using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TMPro;
using UMS.Types;
using UMS.Deserialization;

namespace UMS_TextMeshPro.Types
{
    public class SerializableTMP_FontWeights : Serializable<TMP_FontWeights, SerializableTMP_FontWeights>, IAsynchronousDeserializer<SerializableTMP_FontWeights>
    {
        public SerializableTMP_FontWeights() { }
        public SerializableTMP_FontWeights(TMP_FontWeights weights)
        {
            _regularTypeface = Reference.Create(weights.regularTypeface);
            _italicTypeface = Reference.Create(weights.italicTypeface);
        }

        [JsonIgnore]
        private TMP_FontAsset _deserializedRegularTypeface;
        [JsonIgnore]
        private TMP_FontAsset _deserializedItalicTypeface;

        [JsonProperty]
        private Reference _regularTypeface;
        [JsonProperty]
        private Reference _italicTypeface;
        
        public void AsynchronousDeserialization(Action<object> action, SerializableTMP_FontWeights serialized)
        {
            Deserializer.GetDeserializedObject<TMP_FontAsset>(serialized._regularTypeface.ID, regularTypeface =>
            {
                serialized._deserializedRegularTypeface = regularTypeface;
                serialized.CheckIfDeserialized(action);
            });

            Deserializer.GetDeserializedObject<TMP_FontAsset>(serialized._italicTypeface.ID, italicTypeface =>
            {
                serialized._deserializedItalicTypeface = italicTypeface;
                serialized.CheckIfDeserialized(action);
            });
        }
        private void CheckIfDeserialized(Action<object> action)
        {
            if(_deserializedRegularTypeface && _deserializedItalicTypeface)
            {
                action(Create(_deserializedRegularTypeface, _deserializedItalicTypeface));
            }
        }
        private TMP_FontWeights Create(TMP_FontAsset regularTypeface, TMP_FontAsset italicTypeface)
        {
            return new TMP_FontWeights()
            {
                regularTypeface = regularTypeface,
                italicTypeface = italicTypeface,
            };
        }
        public static SerializableTMP_FontWeights Serialize(TMP_FontWeights obj)
        {
            return new SerializableTMP_FontWeights(obj);
        }
    }
}
