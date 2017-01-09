﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XF.Common {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("XF.Common.ErrorMessages", typeof(ErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework encountered a &apos;BorrowReader&apos; error for {0}.{1} in {2}.
        /// </summary>
        public static string BorrowReaderExceptionFormat {
            get {
                return ResourceManager.GetString("BorrowReaderExceptionFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework encountered a &apos;BorrowReader&apos; error for {0}.{1} in {2}     details: {3}     errorId:{4}.
        /// </summary>
        public static string BorrowReaderExceptionFormatVerbose {
            get {
                return ResourceManager.GetString("BorrowReaderExceptionFormatVerbose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework encountered a {3}Exception for {0}.{1} in {2}.
        /// </summary>
        public static string DatastoreExceptionFormat {
            get {
                return ResourceManager.GetString("DatastoreExceptionFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework encountered a {3}Exception for {0}.{1} in {2}     details: {4}     errorId:{5}.
        /// </summary>
        public static string DatastoreExceptionFormatVerbose {
            get {
                return ResourceManager.GetString("DatastoreExceptionFormatVerbose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework was unable to create a DbConnection using key=&apos;{2}&apos; for {0}.{1}.
        /// </summary>
        public static string DbConnectionCreationFormat {
            get {
                return ResourceManager.GetString("DbConnectionCreationFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework was unable to create a DbConnection using key=&apos;{2}&apos; for {0}.{1}     details: {3}     errorId:{4}.
        /// </summary>
        public static string DbConnectionCreationFormatVerbose {
            get {
                return ResourceManager.GetString("DbConnectionCreationFormatVerbose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework encountered an improperly formatted DbConnectionString for {0}.
        /// </summary>
        public static string DbConnectionStringFormat {
            get {
                return ResourceManager.GetString("DbConnectionStringFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework encountered an improperly formatted DbConnectionString: key=&apos;{0}&apos; connectionString=&apos;{1}&apos; for {2}     errorId:{3}.
        /// </summary>
        public static string DbConnectionStringFormatVerbose {
            get {
                return ResourceManager.GetString("DbConnectionStringFormatVerbose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework was unable to locate a DbConnectionString with key=&apos;{2}&apos; for {0}.{1}.
        /// </summary>
        public static string DbConnectionStringNullSettings {
            get {
                return ResourceManager.GetString("DbConnectionStringNullSettings", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework was unable to locate a DbConnectionString with key=&apos;{2}&apos; for {0}.{1}     details: {3}     errorId:{4}.
        /// </summary>
        public static string DbConnectionStringNullSettingsVerbose {
            get {
                return ResourceManager.GetString("DbConnectionStringNullSettingsVerbose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework was unable to resolve the DbConnection string key for {0}.{1}.
        /// </summary>
        public static string DbConnectionStringResolution {
            get {
                return ResourceManager.GetString("DbConnectionStringResolution", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework was unable to resolve the DbConnection string key for {0}.{1}     details: {2}     errorId:{3}.
        /// </summary>
        public static string DbConnectionStringResolutionVerbose {
            get {
                return ResourceManager.GetString("DbConnectionStringResolutionVerbose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ex: {0}.
        /// </summary>
        public static string ExceptionFormat {
            get {
                return ResourceManager.GetString("ExceptionFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework encountered an Exception for {0}.{1} .
        /// </summary>
        public static string GeneralExceptionFormat {
            get {
                return ResourceManager.GetString("GeneralExceptionFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework encountered an Exception for {0}.{1}     details: {2}     errorId:{3}.
        /// </summary>
        public static string GeneralExceptionFormatVerbose {
            get {
                return ResourceManager.GetString("GeneralExceptionFormatVerbose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework encountered an Exception for {0}.{1} in {2}.
        /// </summary>
        public static string GeneralExceptionInFormat {
            get {
                return ResourceManager.GetString("GeneralExceptionInFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework encountered an Exception for {0}.{1} in {2}     details: {3}     errorId:{4}.
        /// </summary>
        public static string GeneralExceptionInFormatVerbose {
            get {
                return ResourceManager.GetString("GeneralExceptionInFormatVerbose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IContext: {0}.
        /// </summary>
        public static string IContextFormat {
            get {
                return ResourceManager.GetString("IContextFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ICriterion: {0}.
        /// </summary>
        public static string ICriterionFormat {
            get {
                return ResourceManager.GetString("ICriterionFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework was unable to instantiate {2} for {0}.{1}.
        /// </summary>
        public static string ModelDataGatewayImplementationInstantiation {
            get {
                return ResourceManager.GetString("ModelDataGatewayImplementationInstantiation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework was unable to instantiate {2} for {0}.{1}     details: {3}     errorId:{4}.
        /// </summary>
        public static string ModelDataGatewayImplementationInstantiationVerbose {
            get {
                return ResourceManager.GetString("ModelDataGatewayImplementationInstantiationVerbose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Model: {0}.
        /// </summary>
        public static string ModelFormat {
            get {
                return ResourceManager.GetString("ModelFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework was unable to resolve the ModelDataGateway for {0}.{1}     errorId:{2}.
        /// </summary>
        public static string NullModelDataGatewayImplementation {
            get {
                return ResourceManager.GetString("NullModelDataGatewayImplementation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework was unable to resolve the RpcHandler for {0}.{1}     errorId:{2}.
        /// </summary>
        public static string NullRpcHandlerImplementation {
            get {
                return ResourceManager.GetString("NullRpcHandlerImplementation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework was unable to resolve the SqlCommand for {0}.{1} in {2}.
        /// </summary>
        public static string NullSqlCommandFormat {
            get {
                return ResourceManager.GetString("NullSqlCommandFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework was unable to resolve the SqlCommand for {0}.{1} in {2}     details: {3}     errorId:{4}.
        /// </summary>
        public static string NullSqlCommandFormatVerbose {
            get {
                return ResourceManager.GetString("NullSqlCommandFormatVerbose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework was unable to locate the resource for {0}.{1}.
        /// </summary>
        public static string ResourceNotFoundFormat {
            get {
                return ResourceManager.GetString("ResourceNotFoundFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework was unable to locate the resource for {0}.{1}     details: {2}     errorId:{3}.
        /// </summary>
        public static string ResourceNotFoundFormatVerbose {
            get {
                return ResourceManager.GetString("ResourceNotFoundFormatVerbose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework was unable to instantiate {2} for {0}.{1}.
        /// </summary>
        public static string RpcHandlerImplementationInstantiation {
            get {
                return ResourceManager.GetString("RpcHandlerImplementationInstantiation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework was unable to instantiate {2} for {0}.{1}     details: {3}     errorId:{4}.
        /// </summary>
        public static string RpcHandlerImplementationInstantiationVerbose {
            get {
                return ResourceManager.GetString("RpcHandlerImplementationInstantiationVerbose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework encountered a SqlException for {0}.{1} in {2}.
        /// </summary>
        public static string SqlExceptionFormat {
            get {
                return ResourceManager.GetString("SqlExceptionFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eXtensible Framework encountered a SqlException for {0}.{1} in {2}     details: {3}     errorId:{4}.
        /// </summary>
        public static string SqlExceptionFormatVerbose {
            get {
                return ResourceManager.GetString("SqlExceptionFormatVerbose", resourceCulture);
            }
        }
    }
}
