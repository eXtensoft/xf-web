//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using XF.Common;

//namespace XF.WebApi
//{
//    public static class eXtensibleApiConfig
//    {
//        public static readonly bool IsLogToDatastore;
//        public static readonly LoggingStrategyOption LogTo;
//        public static readonly string SqlConnectionKey;


//        static eXtensibleApiConfig()
//        {
//            try
//            {
//                LoggingStrategyOption option;
//                string logToCandidate = ConfigurationManager.AppSettings[XFAPIConstants.Config.LogToKey];
//                if (!String.IsNullOrWhiteSpace(logToCandidate) && Enum.TryParse<LoggingStrategyOption>(logToCandidate, true, out option))
//                {
//                    LogTo = option;
//                }
//                else
//                {
//                    LogTo = XFAPIConstants.Default.LogTo;
//                }
                



//                string sqlConnectionKeyCandidate = ConfigurationManager.AppSettings[XFAPIConstants.Config.SqlConnectionKey];
//                if (!String.IsNullOrWhiteSpace(sqlConnectionKeyCandidate))
//                {
//                    SqlConnectionKey = sqlConnectionKeyCandidate;
//                }
//                else
//                {
//                    SqlConnectionKey = XFAPIConstants.Default.DatastoreConnectionKey;
//                }

//                if (LogTo.Equals(LoggingStrategyOption.Datastore))
//                {
//                    bool b = false;
//                    try
//                    {
//                        string cnText = ConfigurationManager.ConnectionStrings[SqlConnectionKey].ConnectionString;
//                        using (System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(cnText))
//                        {
//                            cn.Open();
//                            if (cn.State == System.Data.ConnectionState.Open)
//                            {
//                                IsLogToDatastore = true;                                
//                            }
//                            else
//                            {
//                                LogTo = XFAPIConstants.Default.LogTo;
//                            }
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        LogTo = LoggingStrategyOption.None;
//                    }
//                }               
     
            
//            }
//            catch
//            {
//                IsLogToDatastore = XFAPIConstants.Default.IsLogToDatastore;
//                LogTo = XFAPIConstants.Default.LogTo;
//                SqlConnectionKey = XFAPIConstants.Default.DatastoreConnectionKey;

//            }
//        }
//    }
//}
