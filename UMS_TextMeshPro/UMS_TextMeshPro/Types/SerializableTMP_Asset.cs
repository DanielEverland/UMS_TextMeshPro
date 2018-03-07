using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMS.Deserialization;
using UMS.Serialization;
using UMS.Core.Types;
using TMPro;
using Newtonsoft.Json;
using UnityEngine;

namespace UMS.TextMeshPro.Types
{
    public abstract class SerializableTMP_Asset<TNonSerializable, TSerializable> : SerializableObject<TNonSerializable, TSerializable> where TNonSerializable : TMP_Asset
    {
        public SerializableTMP_Asset() { }
        public SerializableTMP_Asset(TMP_Asset asset)
        {
            _hashCode = asset.hashCode;

            if(asset.material != null)
            {
                _material = Reference.Create(asset.material);
            }
        }

        [JsonProperty]
        private int _hashCode;
        [JsonProperty]
        private Reference _material;

        protected void Deserialize(TMP_Asset asset)
        {
            asset.hashCode = _hashCode;

            Deserializer.GetDeserializedObject<Material>(_material.ID, material =>
            {
                asset.material = material;
                asset.materialHashCode = material.GetHashCode();
            });
        }
    }
}
