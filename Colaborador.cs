using QRCoder;

public class Colaborador{
    public string? Nome {get; set;}
    public string? Email {get; set;}
    public string? Cargo {get; set;}
    public string? Telefone {get; set;}
    public int Id { get; protected set; }

    public byte Qrcode {get; set;}

 public Colaborador(){

    }

    public Colaborador(string nome, string email, string cargo, string telefone)
    {
        Nome = nome;
        Email = email;
        Cargo = cargo;
        Telefone = telefone;
    }

    public Colaborador (int Id, string nome, string email, string cargo, string telefone, byte Qrcode) : this(nome, email, cargo, telefone){

    }

    QRCodeGenerator qrGenerator = new QRCodeGenerator();
    QRCodeData qrCodeData = qrGenerator.CreateQrCode("email", QRCodeGenerator.ECCLevel.Q);
    BitmapByteQRCode qrCode = new BitmapByteQRCode(QrCodeData);
    byte[] qrCodeAsBitmapByteArr = QrCode.GetGraphic(20);


}   