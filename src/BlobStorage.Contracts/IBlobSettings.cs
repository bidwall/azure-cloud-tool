namespace BlobStorage.Contracts
{
   public interface IBlobSettings
   {
      string ConnectionString { get; set; }
      string ContainerName { get; set; }
      string DirectoryName { get; set; }
   }
}