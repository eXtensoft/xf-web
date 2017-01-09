// <copyright company="Recorded Books, Inc" file="eXtensibleWebApiConfig.cs">
// Copyright © 2015 All Rights Reserved
// </copyright>

namespace XF.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using XF.Common;
    using XF.WebApi.Config;

    public static class eXtensibleWebApiConfig
    {

        public static readonly string Zone;
        public static readonly string WebApiPlugins;

        public static readonly string LogSource;
        public static readonly string BigDataUrl;
        public static readonly string ServiceToken;

        public static readonly bool IsLogToDatastore;
        public static readonly LoggingStrategyOption LogTo;
        public static readonly string SqlConnectionKey;

        public static readonly LoggingModeOption LoggingMode;

        public static readonly string MessageProviderFolder;

        public static readonly bool IsEditRegistration;

        public static readonly string CatchAll;

        public static readonly string MessageIdHeaderKey;

        static eXtensibleWebApiConfig()
        {
            try
            {
                string configfilepath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                string configFolder = Path.GetDirectoryName(configfilepath);

                WebApiPlugins = configFolder + "\\" + "webApiControllers";


                LoggingModeOption loggingMode;
                LoggingStrategyOption loggingStrategy;
                string logToCandidate = ConfigurationManager.AppSettings[XFAPIConstants.Config.LogToKey];
                string loggingModeCandidate = ConfigurationManager.AppSettings[XFAPIConstants.Config.LoggingModeKey];
                string sqlConnectionKeyCandidate = ConfigurationManager.AppSettings[XFAPIConstants.Config.SqlConnectionKey];

                var configfilemap = new ExeConfigurationFileMap() { ExeConfigFilename = configfilepath };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configfilemap, ConfigurationUserLevel.None);
                eXtensibleWebApiSection section = config.Sections[XFWebApiConstants.Config.SectionName] as eXtensibleWebApiSection;

                
                if (section != null)
                {
                    MessageProviderFolder = section.MessageProviderFolder;
                    var found = section.Elements.GetForLoggingMode(section.LoggingKey);

                    if (Enum.TryParse<LoggingStrategyOption>(found.LoggingStrategy, true, out loggingStrategy)
                        && Enum.TryParse<LoggingModeOption>(found.LoggingMode, true, out loggingMode))
                    {
                        if (loggingStrategy == LoggingStrategyOption.Datastore)
                        {
                            SqlConnectionKey = found.DatastoreKey;
                        }
                        LoggingMode = loggingMode;
                        LogTo = loggingStrategy;
                    }
                    else
                    {
                        loggingMode = XFAPIConstants.Default.LoggingMode;
                        LogTo = XFAPIConstants.Default.LogTo;
                    }

                    IsEditRegistration = section.EditRegistration;
                    CatchAll = section.CatchAllControllerId;
                    MessageIdHeaderKey = section.MessageIdHeaderKey;

                }
                else
                {
                    IsEditRegistration = false;
                    if (!String.IsNullOrWhiteSpace(loggingModeCandidate) && Enum.TryParse<LoggingModeOption>(loggingModeCandidate, true, out loggingMode))
                    {
                        LoggingMode = loggingMode;
                    }
                    else
                    {
                        LoggingMode = XFAPIConstants.Default.LoggingMode;
                    }
                    // read from appsettings or use defaults
                    if (!String.IsNullOrWhiteSpace(logToCandidate) && Enum.TryParse<LoggingStrategyOption>(logToCandidate, true, out loggingStrategy))
                    {
                        LogTo = loggingStrategy;
                    }
                    else
                    {
                        LogTo = XFAPIConstants.Default.LogTo;
                    }

                    if (!String.IsNullOrWhiteSpace(sqlConnectionKeyCandidate))
                    {
                        SqlConnectionKey = sqlConnectionKeyCandidate;
                    }
                    else
                    {
                        SqlConnectionKey = XFAPIConstants.Default.DatastoreConnectionKey;
                    }

                    if (LogTo.Equals(LoggingStrategyOption.Datastore))
                    {
                        bool b = false;
                        try
                        {
                            string cnText = ConfigurationManager.ConnectionStrings[SqlConnectionKey].ConnectionString;
                            using (System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(cnText))
                            {
                                cn.Open();
                                if (cn.State == System.Data.ConnectionState.Open)
                                {
                                    IsLogToDatastore = true;
                                }
                                else
                                {
                                    LogTo = XFAPIConstants.Default.LogTo;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            LogTo = LoggingStrategyOption.None;
                        }
                    }
                    MessageProviderFolder = XFAPIConstants.Default.MessageProviderFolder;
                    IsEditRegistration = XFAPIConstants.Default.IsEditRegistration;
                    CatchAll = XFAPIConstants.Default.CatchAllControllerId;
                    MessageIdHeaderKey = XFAPIConstants.Default.MessageIdHeaderKey;
                }


            }
            catch (Exception ex)
            {
                // nows setup defaults
                MessageProviderFolder = XFAPIConstants.Default.MessageProviderFolder;
                LoggingMode = XFAPIConstants.Default.LoggingMode;
                LogTo = XFAPIConstants.Default.LogTo;
                IsEditRegistration = XFAPIConstants.Default.IsEditRegistration;
                CatchAll = XFAPIConstants.Default.CatchAllControllerId;
                MessageIdHeaderKey = XFAPIConstants.Default.MessageIdHeaderKey;
            }
        }
    }

}
