﻿using System;
using System.Collections;
using Newtonsoft.Json.Serialization;

namespace ErgastApi.Serialization
{
    public class InterfaceContractResolver : DefaultContractResolver
    {
        // TODO: Move this somewhere else or refactor at least, at it is used elsewhere
        public static bool CanHandleType(Type type)
        {
            return type.IsInterface && !typeof(IEnumerable).IsAssignableFrom(type);
        }

        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);

            if (!CanHandleType(objectType))
                return contract;

            contract.Converter = new InterfaceJsonConverter();

            return contract;
        }
    }
}