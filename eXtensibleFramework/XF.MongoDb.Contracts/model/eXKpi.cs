﻿// <copyright company="eXtensible Solutions LLC" file="eXKpi.cs">
// Copyright © 2015 All Right Reserved
// </copyright>

namespace XF.Common.MongoDb
{
    using System;
    using System.Runtime.Serialization;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    [Serializable]
    [DataContract(Namespace = "http://eXtensoft/schemas/2014/04")]
    public class eXKpi : XF.Common.eXKpi
    {

        [DataMember]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

    }
}
