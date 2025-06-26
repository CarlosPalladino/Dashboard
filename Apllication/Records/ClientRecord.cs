namespace Apllication.Records
{
    public record ClientRecordInfo(string name, string address, bool active);
    public record NewClientRecord(string name, string address, long cuit, bool active);
}
