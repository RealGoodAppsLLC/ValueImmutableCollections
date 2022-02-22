// <copyright file="ValueImmutableListJsonConverter.cs" company="Real Good Apps">
// Copyright (c) Real Good Apps. All rights reserved.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace RealGoodApps.ValueImmutableCollections
{
    /// <inheritdoc cref="JsonConverter{T}"/>
    public sealed class ValueImmutableListJsonConverter : JsonConverter
    {
        /// <inheritdoc cref="JsonConverter{T}"/>
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (!(value is IEnumerable valueEnumerable))
            {
                writer.WriteNull();
                return;
            }

            writer.WriteStartArray();

            foreach (var item in valueEnumerable)
            {
                serializer.Serialize(writer, item);
            }

            writer.WriteEndArray();
        }

        /// <inheritdoc cref="JsonConverter{T}"/>
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var itemType = objectType.GenericTypeArguments[0];
            var genericReadOnlyList = typeof(IReadOnlyList<>);
            var boundedGenericReadOnlyList = genericReadOnlyList.MakeGenericType(itemType);

            var readOnlyList = serializer.Deserialize(reader, boundedGenericReadOnlyList);

            var method = typeof(ValueImmutableListJsonConverter).GetMethod(
                nameof(this.ToValueImmutableList),
                BindingFlags.Static | BindingFlags.NonPublic);

            var genericMethod = method?.MakeGenericMethod(itemType);

            return genericMethod?.Invoke(null, new[] { readOnlyList });
        }

        /// <inheritdoc cref="JsonConverter{T}"/>
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(ValueImmutableList<>));
        }

        private static ValueImmutableList<T> ToValueImmutableList<T>(IReadOnlyList<T> input)
        {
            return input.ToValueImmutableList();
        }
    }
}
