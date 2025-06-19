namespace Apllication.Records
{
    public record ClientRecordInfo(string name, string address);
    public record NewClientRecord(string name, string address, long cuit);
}
