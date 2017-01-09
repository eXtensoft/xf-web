

namespace XF.WebApi.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    using XF.Common;

    public static class ApiRequestSqlAccess
    {
        #region local fields

        private const string ApiRequestIdParamName = "@apirequestid";
        private const string AppKeyParamName = "@appkey";
        private const string AppZoneParamName = "@appzone";
        private const string AppInstanceParamName = "@appinstance";
        private const string ElapsedParamName = "@elapsed";
        private const string StartParamName = "@start";
        private const string ProtocolParamName = "@protocol";
        private const string HostParamName = "@host";
        private const string PathParamName = "@path";
        private const string ClientIPParamName = "@clientip";
        private const string UserAgentParamName = "@useragent";
        private const string HttpMethodParamName = "@httpmethod";
        private const string ControllerNameParamName = "@controllername";
        private const string ControllerMethodParamName = "@controllermethod";
        private const string MethodReturnTypeParamName = "@methodreturntype";
        private const string ResponseCodeParamName = "@responsecode";
        private const string ResponseTextParamName = "@responsetext";
        private const string XmlDataParamName = "@xmldata";
        private const string MessageIdParamName = "@messageid";
        private const string BasicTokenParamName = "@basictoken";
        private const string BearerTokenParamName = "@bearertoken";
        private const string AuthSchemaParamName = "@authschema";
        private const string AuthValueParamName = "@authvalue";
        private const string MessageBodyParamName = "@messagebody";
        private const string DbSchema = "log";
        #endregion local fields

        public static void Post(ApiRequest model)
        {
            string schema = eXtensibleConfig.Zone.Equals("production",StringComparison.OrdinalIgnoreCase) ? DateTime.Today.ToString("MMM").ToLower():"log";
            string sql = "insert into [" + schema + "].[ApiRequest] ( [AppKey],[AppZone],[AppInstance],[Elapsed],[Start],[Protocol],[Host],[Path]" +
                ",[ClientIP],[UserAgent],[HttpMethod],[ControllerName],[ControllerMethod],[MethodReturnType],[ResponseCode],[ResponseText]" +
                ",[XmlData],[MessageId],[BasicToken],[BearerToken],[AuthSchema],[AuthValue],[MessageBody] ) values (" + AppKeyParamName + "," + AppZoneParamName + "," + 
                AppInstanceParamName + "," + ElapsedParamName + "," + StartParamName + "," + ProtocolParamName + "," + HostParamName + "," + 
                PathParamName + "," + ClientIPParamName + "," + UserAgentParamName + "," + HttpMethodParamName + "," + ControllerNameParamName + "," + 
                ControllerMethodParamName + "," + MethodReturnTypeParamName + "," + ResponseCodeParamName + "," + ResponseTextParamName + "," + 
                XmlDataParamName + "," + MessageIdParamName + "," + BasicTokenParamName + "," + BearerTokenParamName + "," + AuthSchemaParamName + "," + AuthValueParamName + "," + MessageBodyParamName + ")";


            var settings = ConfigurationManager.ConnectionStrings[eXtensibleWebApiConfig.SqlConnectionKey];
            if (settings != null && !String.IsNullOrWhiteSpace(settings.ConnectionString))
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection(settings.ConnectionString))
                    {
                        cn.Open();
                        using (SqlCommand cmd = cn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = sql;
                            cmd.CommandTimeout = 0;

                            cmd.Parameters.AddWithValue(AppKeyParamName, model.AppKey.Truncate(25));
                            cmd.Parameters.AddWithValue(AppZoneParamName, model.AppZone.Truncate(15));
                            cmd.Parameters.AddWithValue(AppInstanceParamName, model.AppInstance.Truncate(25));
                            cmd.Parameters.AddWithValue(ElapsedParamName, model.Elapsed);
                            cmd.Parameters.AddWithValue(StartParamName, model.Start);
                            cmd.Parameters.AddWithValue(ProtocolParamName, model.Protocol.Truncate(5));
                            cmd.Parameters.AddWithValue(HostParamName, model.Host.Truncate(50));
                            cmd.Parameters.AddWithValue(PathParamName, model.Path.Truncate(150));
                            cmd.Parameters.AddWithValue(ClientIPParamName, model.ClientIP.Truncate(15));
                            cmd.Parameters.AddWithValue(UserAgentParamName, String.IsNullOrWhiteSpace(model.UserAgent) ? "none" : model.UserAgent.Truncate(200));
                            cmd.Parameters.AddWithValue(HttpMethodParamName, model.HttpMethod);
                            cmd.Parameters.AddWithValue(ControllerNameParamName, String.IsNullOrWhiteSpace(model.ControllerName) ? "none" : model.ControllerName.Truncate(50));
                            cmd.Parameters.AddWithValue(ControllerMethodParamName, String.IsNullOrWhiteSpace(model.ControllerMethod) ? "none" : model.ControllerMethod.Truncate(50));
                            cmd.Parameters.AddWithValue(MethodReturnTypeParamName, String.IsNullOrWhiteSpace(model.MethodReturnType) ? "none" : model.MethodReturnType.Truncate(50));
                            cmd.Parameters.AddWithValue(ResponseCodeParamName, model.ResponseCode);
                            cmd.Parameters.AddWithValue(ResponseTextParamName, model.ResponseText.Truncate(50));
                            cmd.Parameters.AddWithValue(XmlDataParamName, model.ToXmlString());
                            cmd.Parameters.AddWithValue(MessageIdParamName, model.MessageId);
                            cmd.Parameters.AddWithValue(BasicTokenParamName, String.IsNullOrWhiteSpace(model.BasicToken) ? "none" : model.BasicToken);
                            cmd.Parameters.AddWithValue(BearerTokenParamName, String.IsNullOrWhiteSpace(model.BearerToken) ? "none" : model.BearerToken);
                            cmd.Parameters.AddWithValue(AuthSchemaParamName, model.AuthSchema);
                            cmd.Parameters.AddWithValue(AuthValueParamName, model.AuthValue);
                            cmd.Parameters.AddWithValue(MessageBodyParamName, !String.IsNullOrWhiteSpace(model.MessageBody) ? (object)model.MessageBody : DBNull.Value);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    IEventWriter writer = new EventLogWriter();
                    var props = eXtensibleConfig.GetProperties();
                    writer.WriteError(message, SeverityType.Critical, "ApiRequestSqlAccess", props);
                }                
            }

        }


        public static IEnumerable<ApiRequest> Get(int id)
        {
            List<ApiRequest> list = new List<ApiRequest>();
           string schema = eXtensibleConfig.Zone.Equals("production",StringComparison.OrdinalIgnoreCase) ? DateTime.Today.ToString("MMM").ToLower():"log";
            var settings = ConfigurationManager.ConnectionStrings[eXtensibleWebApiConfig.SqlConnectionKey];
            if (settings != null && !String.IsNullOrWhiteSpace(settings.ConnectionString))
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection(settings.ConnectionString))
                    {
                        cn.Open();
                        using (SqlCommand cmd = cn.CreateCommand())
                        {

                            string sql = " [ApiRequestId],[XmlData] from [" + schema + "].[ApiRequest] ";
                            StringBuilder sb = new StringBuilder();
                            sb.Append("select ");
                            if (id > 999)
	                        {
		                        sb.Append(sql);
                                sb.Append(" where [ApiRequestId] = " + ApiRequestIdParamName);
                                cmd.Parameters.AddWithValue(ApiRequestIdParamName, id);
	                        }
                            else
	                        {
                                sb.Append("top " + id.ToString() + " ");
                                sb.Append(sql);
                                sb.Append(" order by [ApiRequestId] desc");
	                        }



                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = sb.ToString();
                            cmd.CommandTimeout = 0;


                            

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    
                                    string xml = reader.GetString(reader.GetOrdinal("XmlData"));
                                    var apiRequest = StringToRequest(xml);
                                    apiRequest.ApiRequestId = reader.GetInt64(reader.GetOrdinal("ApiRequestId"));
                                    list.Add(apiRequest);
                                    
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                }
            }
            return list;
        }

        public static ApiRequest Get(Guid id)
        {
            ApiRequest item = null;

            string sql = "";
            var settings = ConfigurationManager.ConnectionStrings[eXtensibleWebApiConfig.SqlConnectionKey];
            if (settings != null && !String.IsNullOrWhiteSpace(settings.ConnectionString))
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection(settings.ConnectionString))
                    {
                        cn.Open();
                        using (SqlCommand cmd = cn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = sql;
                            cmd.CommandTimeout = 0;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                }
            }

            return item;
        }


        private static ApiRequest StringToRequest(string xml)
        {

            var t = Activator.CreateInstance<ApiRequest>();
            Type type = typeof(ApiRequest);
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xml);
            XmlSerializer serializer = new XmlSerializer(type);
            using(MemoryStream stream = new MemoryStream())
            {
                xdoc.Save(stream);
                stream.Position = 0;
                t = (ApiRequest)serializer.Deserialize(stream);
            }

            return t;
        }

        public static IEnumerable<ApiRequest> Get(int pageSize, int pageIndex, string token)
        {
            throw new NotImplementedException();
        }
    }
}
