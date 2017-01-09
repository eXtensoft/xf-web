// <copyright company="eXtensible Solutions, LLC" file="EventWriterLoader.cs">
// Copyright © 2015 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System.Linq;

    public static class EventWriterLoader
    {
        public static IEventWriter Load()
        {
            IEventWriter writer = null;
            switch (eXtensibleConfig.LoggingStrategy)
            {
                case LoggingStrategyOption.None:
                    break;
                case LoggingStrategyOption.WindowsEventLog:
                    writer = new EventLogWriter();
                    break;
                case LoggingStrategyOption.Silent:
                    writer = new EventLogWriter();
                    break;
                case LoggingStrategyOption.Datastore:
                    writer = new DatastoreEventWriter();
                    break;
                default:
                    break;
            }
            //return new EventLogWriter() as IEventWriter;

            return writer;
        }
    }

}
