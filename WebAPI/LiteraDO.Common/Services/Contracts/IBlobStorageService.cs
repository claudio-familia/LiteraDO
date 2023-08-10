namespace LiteraDO.Common.Services.Contracts
{
    public interface IBlobStorageService
    {
        public List<string> GetAllDocuments();
        void UploadDocument(string fileName, Stream fileContent);
        Stream GetDocument(string fileName);
        bool DeleteDocument(string fileName);
    }
}
