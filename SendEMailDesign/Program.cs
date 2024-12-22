// See https://aka.ms/new-console-template for more information


using SendEMail.Infrastructur.RestService;
using SendEMail.Infrastructur.RestService.GetItemSlip;
using SendEMailDesign;
using SendEMailDesign.Model;
using SendEMailDesign.Service;

internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {

         


        List<EMailDTO> mailDto = (await DapperDatabase.QueryAsync<EMailDTO>($@"
            SELECT  
            SP.CARI_KODU as CustomerCode,
            SP.FATIRS_NO AS OrderNumber,
            CE.EMAIL as CustomerEmail,
            SP.SUBE_KODU AS BranchCode
             FROM TBLSIPAMAS SP
             INNER JOIN TBLCASABIT CS ON CS.CARI_KOD=SP.CARI_KODU
             LEFT JOIN TBLCARIEMAIL CE ON CE.CARI_KOD=SP.CARI_KODU

             WHERE  CE.EMAIL IS NOT NULL  AND SP.FTIRSIP=6  AND CONVERT(DATE, TARIH) = CONVERT(DATE, GETDATE());")).ToList();
        RestService restService = new();
        List<MailObject> mailObjects = new();
        MailObject mailObject = new();
        MailManager mailManager = new();
        foreach (var mail in mailDto)
        {
            GetItemSlipDesign slipDesign = new();
           string result = await slipDesign.GetItemSlip(mail.CustomerCode, mail.OrderNumber, 7, Configuration.DesignNumber,mail.BranchCode);
           if (string.IsNullOrEmpty(result)) // Eğer result boş ya da null ise
                continue; 
            mailObject.To = mail.CustomerEmail;
            mailObject.ProviderType = MailProviderType.Smtp;
            mailObject.Base64Key = ConvertBase64ToBytes(result);

            mailObjects.Add(mailObject);
        }
        if (mailObjects.Count > 0)
        {
            mailManager.AddMails(mailObjects);
            await mailManager.SendAllMails();
        }
       
        
    }
        
    catch (Exception ex)
        {
            Console.WriteLine(ex);
            

            
}
    }
    static byte[] ConvertBase64ToBytes(string base64String)
    {
        // Base64 string'i byte dizisine dönüştür
        return Convert.FromBase64String(base64String);
    }
}