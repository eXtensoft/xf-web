﻿// <copyright company="eXtensible Solutions, LLC" file="eXtensibleFrameworkElement.cs">
// Copyright © 2017 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;
    using System.Configuration;

    public sealed class eXtensibleFrameworkElement : ConfigurationElement
    {
        public eXtensibleFrameworkElement()
        {
        }

        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }

        [ConfigurationProperty("loggingStrategy", IsRequired = true)]
        public string LoggingStrategy
        {
            get { return (string)this["loggingStrategy"]; }
            set { this["loggingStrategy"] = value; }
        }

        [ConfigurationProperty("loggingMode", IsRequired = false)]
        public string LoggingMode
        {
            get
            {
                object o = this["loggingMode"];
                string s = o != null ? o.ToString() : LoggingModeOption.None.ToString();
                LoggingModeOption option;
                Enum.TryParse<LoggingModeOption>(s, true, out option);
                return option.ToString().ToLower();
            }
            set { this["loggingMode"] = value; }
        }

        [ConfigurationProperty("publishSeverity", IsRequired = true)]
        public string PublishSeverity
        {
            get { return (string)this["publishSeverity"]; }
            set
            {
                this["publishSeverity"] = value;
            }
        }

        [ConfigurationProperty("datastoreKey", IsRequired = false)]
        public string DatastoreKey
        {
            get { return (String)this["datastoreKey"]; }
            set { this["datastoreKey"] = value; }
        }

        [ConfigurationProperty("inform", IsRequired = false )]
        public bool Inform
        {
            get { return (bool)this["inform"]; }
            set { this["inform"] = value; }
        }
    }
}