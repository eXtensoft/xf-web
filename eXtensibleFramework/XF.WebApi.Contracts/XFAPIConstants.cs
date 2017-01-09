using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XF.Common;

namespace XF.WebApi
{
    public static class XFAPIConstants
    {
        public static class Config
        {
            public const string IsLogToDatastoreKey = "is.logtosql";
            public const string LogToKey = "apirequest.logto";
            public const string SqlConnectionKey = "logtosql.connectionkey";
            public const string LoggingModeKey = "apirequest.loggingmode";
            public const string MessageProviderFolder = "message-provider.folder";
        }

        public static class Default
        {
            public const bool IsLogToDatastore = false;
            public const string DatastoreConnectionKey = "api.request.datastore";
            public const LoggingStrategyOption LogTo = LoggingStrategyOption.None;
            public const LoggingModeOption LoggingMode = LoggingModeOption.All;
            public const string MessageProviderFolder = "messageprovider";
            public const string CatchAllControllerId = "CCCBFDC2-783C-49E6-B938-61F8ABDBB3C3";
            public const string MessageIdHeaderKey = "X-Message-Id";
            public const bool IsEditRegistration = false;
        }
    }
}
