using System.Text.Json.Serialization;
using QRCoder;

public class Colaborador{
    public string? Nome {get; set;}
    public string? Email {get; set;}
    public string? Cargo {get; set;}
    public string? Telefone {get; set;}
    public int Id { get; set; }

    public byte[] Qrcode {get; set;}

    //public Colaborador() {}

    public Colaborador(int id, string nome, string email, string cargo, string telefone) : this(nome, email, cargo, telefone) {
        Id = id;
    }

    [JsonConstructor]
    public Colaborador(string nome, string email, string cargo, string telefone)
    {
        Nome = nome;
        Email = email;
        Cargo = cargo;
        Telefone = telefone;
        Qrcode = GenerateImageQr($"{Id}");
    }
    
    byte[] GenerateImageQr(string url){
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode("http://10.26.12.67:3000/cardShow?id="+url, QRCodeGenerator.ECCLevel.Q);
        BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
        byte[] qrCodeAsBitmapByteArr = qrCode.GetGraphic(20);
        Console.WriteLine(qrCodeAsBitmapByteArr);
        return qrCodeAsBitmapByteArr;
    }

}   