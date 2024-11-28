using System;

namespace Knv.MRLY240314
{
    internal class AppConstants
    {
        public const string ValueNotAvailable2 = "n/a";
        public const string SoftwareCustomer = "Konvolúció Bt.";
        public const string SoftwareTitle = "Knv.MRLY240314";
        public const string GenericTimestampFormat = "yyyy.MM.dd HH:mm:ss";
        public const string FileNameTimestampFormat = "yyMMdd_HHmmss";
        //c:\Users\Public\Documents\Knv.MRLY240314
        public static string ReportDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments)}\\{SoftwareTitle}";
    }
}
