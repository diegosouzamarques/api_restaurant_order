using Api_Restaurant_Order.Domain.Integrations;

namespace Api_Restaurant_Order.Infra.Data.Integrations
{
    public class SaveFile : ISaveFile
    {
        private readonly string _filePath;

        public SaveFile()
        {
            // exemplo path
            // aws servie stoge img or idrive implements 
            _filePath = "D:/Api_Restaurant_Order/arquivos";
        }

        public string Save(byte[] file, string fileExt)
        {

            BinaryWriter Writer = null;

            var fileName = Guid.NewGuid().ToString() + "." + fileExt;

            Writer = new BinaryWriter(File.OpenWrite(_filePath + "/" + fileName));
            Writer.Write(file);
            Writer.Flush();
            Writer.Close();


            return _filePath + "/" + fileName;
        }
    }
}
